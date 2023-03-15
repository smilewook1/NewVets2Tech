using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// IMPORTANT: Read the description of the column &quot;control_level.&quot; References to this table in code must ALWAYS account for the value of &quot;control_level&quot; to prevent security issues.
    /// 
    /// Stores information on administrator accounts. Less thorough than the other two account types, because not as much is necessary.
    /// </summary>
    public partial class Admin
    {
        public Admin()
        {
            HelpRequests = new HashSet<HelpRequest>();
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
        /// <summary>
        /// Serves as an enumerable to determine how much access/permissions the admin account has. The higher the number, the greater the permissions. As of writing, the current tiers have yet to be decided.
        /// </summary>
        public int ControlLevel { get; set; }

        public virtual ICollection<HelpRequest> HelpRequests { get; set; }
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
