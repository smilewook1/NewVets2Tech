using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// A table containing the details on a specific student&apos;s military background. Tied to a student record but stored separately so the student table does not become bloated.
    /// </summary>
    public partial class MilitaryBackground
    {
        public int InternalId { get; set; }
        public int StudentId { get; set; }
        public string Rank { get; set; } = null!;
        public string JobSpecialty { get; set; } = null!;
        public string BranchOfService { get; set; } = null!;
        public string SecurityClearance { get; set; } = null!;
        public DateTime AvailabilityDate { get; set; }
        public DateTime? Expires { get; set; }
        public string? About { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
