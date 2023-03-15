﻿using System;
using System.Collections.Generic;

namespace NewVets2Tech.Api.Data.Models
{
    /// <summary>
    /// IMPORTANT: Read the description of the columns &quot;request_type&quot; and &quot;account_type.&quot; References to this table in code must ALWAYS account for the value of &quot;account_type&quot; to prevent students from being mixed up with employers.
    /// 
    /// A table to track help requests that have been submitted, the details of the request, and whether or not they have been resolved.
    /// </summary>
    public partial class HelpRequest
    {
        public int InternalId { get; set; }
        /// <summary>
        /// An integer serving as an enumerable, representing the different categories of support. This is to help narrow down who is most qualified to help.
        /// </summary>
        public int RequestType { get; set; }
        public string RequestDetails { get; set; } = null!;
        /// <summary>
        /// Nullable, in case the person requesting does not have an account.
        /// </summary>
        public string? RequestAccountEmail { get; set; }
        public string RequestContactEmail { get; set; } = null!;
        /// <summary>
        /// A varchar serving as an enumerable, representing the type of account (if applicable): &quot;None&quot; &quot;Student&quot; or &quot;Employer&quot; (Admin-related issues should be resolved in some other way)
        /// </summary>
        public string AccountType { get; set; } = null!;
        /// <summary>
        /// Should be left blank if there is not a student/employer account associated with this request.
        /// </summary>
        public int? AccountId { get; set; }
        /// <summary>
        /// 0 for no, 1 for yes
        /// </summary>
        public bool RequestSolved { get; set; }
        /// <summary>
        /// The internal ID of the admin that resolved the request, if applicable.
        /// </summary>
        public int? SolvedAdminId { get; set; }

        public virtual Employer? Account { get; set; }
        public virtual Student? AccountNavigation { get; set; }
        public virtual Admin? SolvedAdmin { get; set; }
    }
}
