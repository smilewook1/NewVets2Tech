using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// A table containing information on student accounts.
    /// </summary>
    public class Student
    {
        public Student()
        {
            BookmarkedJobs = new HashSet<BookmarkedJob>();
            BookmarkedStudents = new HashSet<BookmarkedStudent>();
            Documents = new HashSet<Document>();
            Educations = new HashSet<Education>();
            Experiences = new HashSet<Experience>();
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
        public string? Linkedin { get; set; }
        public string? About { get; set; }
        public string? Interests { get; set; }
        public string? AdditionalTraining { get; set; }

        public virtual MilitaryBackground? MilitaryBackground { get; set; }
        public virtual ICollection<BookmarkedJob> BookmarkedJobs { get; set; }
        public virtual ICollection<BookmarkedStudent> BookmarkedStudents { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<HelpRequest> HelpRequests { get; set; }
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
