using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// Details a student&apos;s education at a particular school. Multiple schools can be linked to a single student&apos;s account.  If the student_id value is 0, that probably means it isn&apos;t connected to a student for some reason.
    /// </summary>
    public partial class Education
    {
        public int InternalId { get; set; }
        public int StudentId { get; set; }
        public string School { get; set; } = null!;
        public DateTime GraduationYear { get; set; }
        public string Location { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public string? About { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
