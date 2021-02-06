using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Uni.Core.Rest.Clients;
using Uni.Subjects.DataAccess;
using Uni.Subjects.Domain;
using Uni.Subjects.Models;


namespace Uni.Subjects.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly SubjectDbContext _context;

        private readonly IHttpClientWrapper _httpClientWrapper;

        public SubjectsController(SubjectDbContext context, IHttpClientWrapper httpClientWrapper)
        {
            _context = context;
            _httpClientWrapper = httpClientWrapper;
        }

        // GET: api/v1/Subjects
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubjectModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SubjectModel>>> GetSubjects()
        {
            return await _context.Subjects.Select(s => toDto(s)).ToListAsync();
        }

        // GET: api/v1/Subjects/{id}/Students
        [HttpGet("{id}/students")]
        [ProducesResponseType(typeof(IEnumerable<StudentModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudents(Guid id)
        {
            var studentIds = await _context.SubjectStudents.Where(ss => ss.SubjectId == id).Select(ss => ss.StudentId).ToListAsync();
            var response = await _httpClientWrapper.GetAsync($"http://localhost:3000/api/v1/Students/Filter?{string.Join('&', studentIds.Select(id => $"studentIds={id}"))}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response?.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<StudentModel>>(jsonString);
                return result.ToArray();
            }
            return BadRequest("Error occurred during execution");
        }

        // GET: api/v1/Subjects/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SubjectModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<SubjectModel>> GetSubject(Guid id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return toDto(subject);
        }

        // PUT: api/v1/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutSubject(Guid id, SubjectModel subjectModel)
        {
            if (id != subjectModel.Id)
            {
                return BadRequest();
            }

            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            subject.Name = subjectModel.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!SubjectExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/v1/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(SubjectModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<SubjectModel>> PostSubject(SubjectModel subjectModel)
        {
            var subject = new Subject { Name = subjectModel.Name };
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubject), new { id = subject.Id }, toDto(subject));
        }

        // POST: api/v1/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/lecture")]
        [ProducesResponseType(typeof(SubjectLectureModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<SubjectLectureModel>> PostLecture(Guid id, SubjectLectureModel subjectLectureModel)
        {
            subjectLectureModel.SubjectId = id;
            var subjectLectureModelJson = JsonConvert.SerializeObject(subjectLectureModel);
            var response = await _httpClientWrapper.PostAsync($"http://localhost:1000/api/v1/Lectures", new StringContent(subjectLectureModelJson, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response?.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SubjectLectureModel>(jsonString);
                return result;
            }
            return BadRequest("Error occurred during execution");
        }

        [HttpPost("{id}/enroll/{studentId}")]
        [ProducesResponseType(typeof(SubjectModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<SubjectModel>> PostEnroll(Guid id, Guid studentId)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            // Get all number of students enrolled it this subject
            // Get all capacities of all lectureTheatres related to all lectures related to the subject e.g [40, 50, 23, ...]
            // If any of capacities equal or greater than number of students enrolled then reject


            // Get all subjects the student currently enrolled
            // Get all lectures related with all those subjects so [{lectureId, startDate, duration}]
            // Group by "week of year value" from startDate to calc week of the year the extention can be used:
            // Func<DateTime, int> weekProjector = 
            //    d => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            // then sum all duration in the week, therefore we will have in output dictionary currentLoad = [{weekOfTheYear, sumOfDuration}, {weekOfTheYear, sumOfDuration}, ...]
            // 
            // Then get all lectures related with the subject student enrolling to. Do the same and have the similar dictionary in output after that subjectLoad = [{weekOfTheYear, sumOfDuration}, {weekOfTheYear, sumOfDuration}, ...].
            // Find intersection between two dictionaries by key and sum they values
            // If any of the value equals or greater then 10 then reject

            return NoContent();
        }

        // DELETE: api/v1/Subjects/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectExists(Guid id) => 
            _context.Subjects.Any(e => e.Id == id);

        private static SubjectModel toDto(Subject todoItem) =>
            new SubjectModel
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
            };
    }
}
