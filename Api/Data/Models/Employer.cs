using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// A table containing information on employer accounts.
    /// </summary>
    public partial class Employer
    {
        public Employer()
        {
            BookmarkedStudents = new HashSet<BookmarkedStudent>();
            HelpRequests = new HashSet<HelpRequest>();
            Jobs = new HashSet<Job>();
            Preferences = new HashSet<Preference>();
        }

        public int InternalId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PasswordHash { get; set; }
        public int? Phone { get; set; }
        public string? Address { get; set; }
        public string? About { get; set; }
        public string? CompanyName { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<BookmarkedStudent> BookmarkedStudents { get; set; }
        public virtual ICollection<HelpRequest> HelpRequests { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
