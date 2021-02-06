using System;
using System.Collections.Generic;

namespace Uni.Lectures.Domain
{
    public class Lecture
    {
        public Guid Id { get; set; }

        public Guid SubjectId { get; set; }

        public Guid LectureTheatreId { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Duration { get; set; }        
    }
}
