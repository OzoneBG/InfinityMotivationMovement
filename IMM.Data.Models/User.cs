namespace IMM.Models
{
    using IMM.Data.Common.Models;
    using Microsoft.AspNetCore.Identity;
    using System;

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool PreserveCreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
