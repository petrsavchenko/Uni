using System;

namespace Uni.Subjects.Models
{
    public class SubjectLectureModel
    {
        public Guid SubjectId { get; set; }

        public Guid LectureId { get; set; }

        public Guid LectureTheatreId { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
