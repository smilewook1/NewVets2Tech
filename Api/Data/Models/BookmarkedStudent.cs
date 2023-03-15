using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// Stores students bookmarked by individual employer accounts.
    /// </summary>
    public partial class BookmarkedStudent
    {
        public int InternalId { get; set; }
        public int EmployerId { get; set; }
        public int StudentId { get; set; }

        public virtual Employer Employer { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
