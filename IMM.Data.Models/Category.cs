namespace IMM.Data.Models
{
    using IMM.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Category : AuditInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
