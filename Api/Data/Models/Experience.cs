using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// Describes work experience a student has from a past employer. Multiple entires in this table can be linked to a single student. The column &quot;date_range_end&quot; is nullable, just in case they&apos;re still working for that employer.
    /// </summary>
    public partial class Experience
    {
        public int InternalId { get; set; }
        public int StudentId { get; set; }
        public string Employer { get; set; } = null!;
        public DateTime DateRangeStart { get; set; }
        public DateTime? DateRangeEnd { get; set; }
        public string Location { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string? JobDescription { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
