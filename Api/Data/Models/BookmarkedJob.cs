using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// Stores jobs bookedmarked by individual student accounts.
    /// </summary>
    public partial class BookmarkedJob
    {
        public int InternalId { get; set; }
        public int StudentId { get; set; }
        public int JobId { get; set; }

        public virtual Job Job { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
