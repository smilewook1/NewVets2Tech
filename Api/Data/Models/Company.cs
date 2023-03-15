using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// Will be used to store information on the companies each employer belongs to. Multiple employers can be associated with 1 company, and the same applies to jobs.
    /// </summary>
    public partial class Company
    {
        public Company()
        {
            Documents = new HashSet<Document>();
            Employers = new HashSet<Employer>();
            Jobs = new HashSet<Job>();
        }

        public int InternalId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public string? Address { get; set; }
        public string? About { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Employer> Employers { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
