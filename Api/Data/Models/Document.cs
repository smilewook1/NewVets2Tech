using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// IMPORTANT: Read the description of the column &quot;document_for.&quot; References to this table in code must ALWAYS account for the value of &quot;document_for,&quot; to prevent documents from appearing in unexpected places.
    /// 
    /// Stores documents related to students, companies, and jobs. Since the column &quot;reference_id&quot; can reference 3 tables, it is treated as a foreign key to all 3, but with minimal constraints, and does not respond to changes to related tables. 
    /// </summary>
    public partial class Document
    {
        public int InternalId { get; set; }
        public byte[] DocumentData { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        /// <summary>
        /// A varchar functioning as an enumerable variable, with 3 different types: &quot;Student&quot; &quot;Company&quot; and &quot;Job&quot;
        /// </summary>
        public string DocumentFor { get; set; } = null!;
        /// <summary>
        /// Serves as a foreign key to 3 tables (Student, Company, and Job) depending on the value of &quot;document_for.&quot; Has minimal constraints to prevent issues.
        /// </summary>
        public int ReferenceId { get; set; }

        public virtual Company Reference { get; set; } = null!;
        public virtual Student Reference1 { get; set; } = null!;
        public virtual Job ReferenceNavigation { get; set; } = null!;
    }
}
