using System;
using System.Collections.Generic;
using System.Text;

namespace Uni.Subjects.Domain
{
    public class SubjectStudent
    {
        public Subject Subject { get; set; }

        public Guid SubjectId { get; set; }

        public Guid StudentId { get; set; }
    }
}
