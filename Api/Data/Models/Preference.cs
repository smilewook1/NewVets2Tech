namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// IMPORTANT: Read the description of the column &quot;account_type.&quot; References to this table in code must ALWAYS account for the value of &quot;account_type&quot; to prevent the preferences from a different account from being used by accident.
    /// 
    /// Stores the personal preferences/settings of an an Admin, Employer, or Student account. More columns are planned to be added over time.
    /// </summary>
    public partial class Preference
    {
        public int InternalId { get; set; }
        /// <summary>
        /// A varchar functioning as an enumerable variable, with 3 different types: &quot;Student&quot; &quot;Employer&quot; and &quot;Admin&quot;
        /// </summary>
        public string AccountType { get; set; } = null!;
        /// <summary>
        /// Serves as a foreign key to 3 tables (Student, Employer, and Admin) depending on the value of &quot;account_type.&quot; Has minimal constraints to prevent issues. Does NOT change or disappear if the corresponding account is created, to prevent issues.
        /// </summary>
        public int AccountId { get; set; }

        public virtual Admin Account { get; set; } = null!;
        public virtual Student Account1 { get; set; } = null!;
        public virtual Employer AccountNavigation { get; set; } = null!;
    }
}
