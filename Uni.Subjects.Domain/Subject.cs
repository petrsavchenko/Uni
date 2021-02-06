using System;
using System.Collections.Generic;

namespace Uni.Subjects.Domain
{
    public class Subject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// All Students enrolled on the subject
        /// </summary>
        public ICollection<SubjectStudent> SubjectStudents { get; set; }
    }
}
