using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// A table containing all the details on job postings.
    /// </summary>
    public partial class Job
    {
        public Job()
        {
            BookmarkedJobs = new HashSet<BookmarkedJob>();
            Documents = new HashSet<Document>();
        }

        public int InternalId { get; set; }
        public string JobTitle { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string LevelOrSalaryRange { get; set; } = null!;
        public string HrContact { get; set; } = null!;
        public string? FieldSupervisor { get; set; }
        public string? ExternalPostingUrl { get; set; }
        public string Location { get; set; } = null!;
        public string? JobCategory { get; set; }
        public string JobCode { get; set; } = null!;
        /// <summary>
        /// 0 for no, 1 for yes
        /// </summary>
        public bool TravelRequired { get; set; }
        public string PositionType { get; set; } = null!;
        public DateTime DatePosted { get; set; }
        public DateTime PostingExpires { get; set; }
        public string HrRecruiterContact { get; set; } = null!;
        public string CompanyContact { get; set; } = null!;
        public string? DescriptionSummary { get; set; }
        public string? DescriptionDuties { get; set; }
        public string? DescriptionRequirements { get; set; }
        public string? DescriptionBenefits { get; set; }
        public string? DescriptionNotes { get; set; }
        public int EmployerId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual Employer Employer { get; set; } = null!;
        public virtual ICollection<BookmarkedJob> BookmarkedJobs { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
