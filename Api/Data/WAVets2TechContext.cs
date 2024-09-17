using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NewVets2Tech.Api.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NewVets2Tech.Api.Data.Models
{
    public class AppUser : IdentityUser
    {

    }
    public partial class WAVets2TechContext : IdentityDbContext<AppUser>
    {
        public WAVets2TechContext()
        {
        }

        public WAVets2TechContext(DbContextOptions<WAVets2TechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<BookmarkedJob> BookmarkedJobs { get; set; } = null!;
        public virtual DbSet<BookmarkedStudent> BookmarkedStudents { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Education> Educations { get; set; } = null!;
        public virtual DbSet<Employer> Employers { get; set; } = null!;
        public virtual DbSet<Experience> Experiences { get; set; } = null!;
        public virtual DbSet<HelpRequest> HelpRequests { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<MilitaryBackground> MilitaryBackgrounds { get; set; } = null!;
        public virtual DbSet<Preference> Preferences { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Admin");

                entity.ToTable(e => e.HasComment("IMPORTANT: Read the description of the column \\\"control_level.\\\" References to this table in code must ALWAYS account for the value of \\\"control_level\\\" to prevent security issues.\\r\\n\\r\\nStores information on administrator accounts. Less thorough than the other two account types, because not as much is necessary."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.About)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("about");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.ControlLevel)
                    .HasColumnName("control_level")
                    .HasComment("Serves as an enumerable to determine how much access/permissions the admin account has. The higher the number, the greater the permissions. As of writing, the current tiers have yet to be decided.");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<BookmarkedJob>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Bookmarked_Job");

                entity.ToTable(e => e.HasComment("Stores jobs bookedmarked by individual student accounts."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.BookmarkedJobs)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookmark_References_Job");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.BookmarkedJobs)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookmark_Belongs_To_Student");
            });

            modelBuilder.Entity<BookmarkedStudent>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Bookmarked_Student");

                entity.ToTable(e => e.HasComment("Stores students bookmarked by individual employer accounts."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.EmployerId).HasColumnName("employer_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.BookmarkedStudents)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookmark_Belongs_To_Employer");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.BookmarkedStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookmark_References_Student");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Company");

                entity.ToTable(e => e.HasComment("Will be used to store information on the companies each employer belongs to. Multiple employers can be associated with 1 company, and the same applies to jobs."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.About)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("about");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Document");

                entity.ToTable(e => e.HasComment("IMPORTANT: Read the description of the column \"document_for.\" References to this table in code must ALWAYS account for the value of \"document_for,\" to prevent documents from appearing in unexpected places.\r\n\r\nStores documents related to students, companies, and jobs. Since the column \"reference_id\" can reference 3 tables, it is treated as a foreign key to all 3, but with minimal constraints, and does not respond to changes to related tables. "));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DocumentData).HasColumnName("document_data");

                entity.Property(e => e.DocumentFor)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("document_for")
                    .HasDefaultValueSql("('None')")
                    .HasComment("A varchar functioning as an enumerable variable, with 3 different types: \"Student\" \"Company\" and \"Job\"");

                entity.Property(e => e.ReferenceId)
                    .HasColumnName("reference_id")
                    .HasComment("Serves as a foreign key to 3 tables (Student, Company, and Job) depending on the value of \"document_for.\" Has minimal constraints to prevent issues.");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Reference)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.ReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Document_To_Company_FK");

                entity.HasOne(d => d.ReferenceNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.ReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Document_To_Job_FK");

                entity.HasOne(d => d.Reference1)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.ReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Document_To_Student_FK");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Education");

                entity.ToTable(e => e.HasComment("Details a student's education at a particular school. Multiple schools can be linked to a single student's account.  If the student_id value is 0, that probably means it isn't connected to a student for some reason."));

                entity.Property(e => e.InternalId)
                    .ValueGeneratedNever()
                    .HasColumnName("internal_id");

                entity.Property(e => e.About)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("about");

                entity.Property(e => e.Degree)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("degree");

                entity.Property(e => e.GraduationYear)
                    .HasColumnType("date")
                    .HasColumnName("graduation_year");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.School)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("school");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Education_To_Student_FK");
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Employer");

                entity.ToTable(e => e.HasComment("A table containing information on employer accounts."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.About)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("about");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employers)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employer_To_Company_FK");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Experience");

                entity.ToTable(e => e.HasComment("Describes work experience a student has from a past employer. Multiple entires in this table can be linked to a single student. The column \"date_range_end\" is nullable, just in case they're still working for that employer."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.DateRangeEnd)
                    .HasColumnType("date")
                    .HasColumnName("date_range_end");

                entity.Property(e => e.DateRangeStart)
                    .HasColumnType("date")
                    .HasColumnName("date_range_start");

                entity.Property(e => e.Employer)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("employer");

                entity.Property(e => e.JobDescription)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("job_description");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_title");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Experience_To_Student_FK");
            });

            modelBuilder.Entity<HelpRequest>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Help_Request");

                entity.ToTable(e => e.HasComment("IMPORTANT: Read the description of the columns \"request_type\" and \"account_type.\" References to this table in code must ALWAYS account for the value of \"account_type\" to prevent students from being mixed up with employers.\r\n\r\nA table to track help requests that have been submitted, the details of the request, and whether or not they have been resolved."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasComment("Should be left blank if there is not a student/employer account associated with this request.");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("account_type")
                    .HasDefaultValueSql("('None')")
                    .HasComment("A varchar serving as an enumerable, representing the type of account (if applicable): \"None\" \"Student\" or \"Employer\" (Admin-related issues should be resolved in some other way)");

                entity.Property(e => e.RequestAccountEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("request_account_email")
                    .HasComment("Nullable, in case the person requesting does not have an account.");

                entity.Property(e => e.RequestContactEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("request_contact_email");

                entity.Property(e => e.RequestDetails)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("request_details");

                entity.Property(e => e.RequestSolved)
                    .HasColumnName("request_solved")
                    .HasComment("0 for no, 1 for yes");

                entity.Property(e => e.RequestType)
                    .HasColumnName("request_type")
                    .HasComment("An integer serving as an enumerable, representing the different categories of support. This is to help narrow down who is most qualified to help.");

                entity.Property(e => e.SolvedAdminId)
                    .HasColumnName("solved_admin_id")
                    .HasComment("The internal ID of the admin that resolved the request, if applicable.");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.HelpRequests)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("Help_Request_Account_Is_Employer");

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.HelpRequests)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("Help_Request_Account_Is_Student");

                entity.HasOne(d => d.SolvedAdmin)
                    .WithMany(p => p.HelpRequests)
                    .HasForeignKey(d => d.SolvedAdminId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Request_Solved_By_Admin");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Job");

                entity.ToTable(e => e.HasComment("A table containing all the details on job postings."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.CompanyContact)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_contact");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("date")
                    .HasColumnName("date_posted");

                entity.Property(e => e.DescriptionBenefits)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("description_benefits");

                entity.Property(e => e.DescriptionDuties)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("description_duties");

                entity.Property(e => e.DescriptionNotes)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("description_notes");

                entity.Property(e => e.DescriptionRequirements)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("description_requirements");

                entity.Property(e => e.DescriptionSummary)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("description_summary");

                entity.Property(e => e.EmployerId).HasColumnName("employer_id");

                entity.Property(e => e.ExternalPostingUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("external_posting_url");

                entity.Property(e => e.FieldSupervisor)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("field_supervisor");

                entity.Property(e => e.HrContact)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("hr_contact");

                entity.Property(e => e.HrRecruiterContact)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("hr_recruiter_contact");

                entity.Property(e => e.JobCategory)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_category");

                entity.Property(e => e.JobCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_code");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_title");

                entity.Property(e => e.LevelOrSalaryRange)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("level_or_salary_range");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.PositionType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("position_type");

                entity.Property(e => e.PostingExpires)
                    .HasColumnType("date")
                    .HasColumnName("posting_expires");

                entity.Property(e => e.TravelRequired)
                    .HasColumnName("travel_required")
                    .HasComment("0 for no, 1 for yes");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Job_To_Company_FK");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Job_To_Employer_FK");
            });

            modelBuilder.Entity<MilitaryBackground>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Military_Background");

                entity.ToTable(e => e.HasComment("A table containing the details on a specific student's military background. Tied to a student record but stored separately so the student table does not become bloated."));

                entity.HasIndex(e => e.StudentId, "Military_Background_FK_Unique")
                    .IsUnique();

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.About)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("about");

                entity.Property(e => e.AvailabilityDate)
                    .HasColumnType("date")
                    .HasColumnName("availability_date");

                entity.Property(e => e.BranchOfService)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("branch_of_service");

                entity.Property(e => e.Expires)
                    .HasColumnType("date")
                    .HasColumnName("expires");

                entity.Property(e => e.JobSpecialty)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_specialty");

                entity.Property(e => e.Rank)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rank");

                entity.Property(e => e.SecurityClearance)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("security_clearance");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.MilitaryBackground)
                    .HasForeignKey<MilitaryBackground>(d => d.StudentId)
                    .HasConstraintName("Military_Background_To_Student_FK");
            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable(e => e.HasComment("IMPORTANT: Read the description of the column \"account_type.\" References to this table in code must ALWAYS account for the value of \"account_type\" to prevent the preferences from a different account from being used by accident.\r\n\r\nStores the personal preferences/settings of an an Admin, Employer, or Student account. More columns are planned to be added over time."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasComment("Serves as a foreign key to 3 tables (Student, Employer, and Admin) depending on the value of \"account_type.\" Has minimal constraints to prevent issues. Does NOT change or disappear if the corresponding account is created, to prevent issues.");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("account_type")
                    .HasDefaultValueSql("('None')")
                    .HasComment("A varchar functioning as an enumerable variable, with 3 different types: \"Student\" \"Employer\" and \"Admin\"");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Preferences)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_Account_Preferences");

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.Preferences)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employer_Account_Preferences");

                entity.HasOne(d => d.Account1)
                    .WithMany(p => p.Preferences)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Account_Preferences");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.InternalId);

                entity.ToTable("Student");

                entity.ToTable(e => e.HasComment("A table containing information on student accounts."));

                entity.Property(e => e.InternalId).HasColumnName("internal_id");

                entity.Property(e => e.About)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("about");

                entity.Property(e => e.AdditionalTraining)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("additional_training");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Interests)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("interests");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Linkedin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("linkedin");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
