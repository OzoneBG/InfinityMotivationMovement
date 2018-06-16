namespace IMM.Data.Models
{
    using IMM.Data.Common.Models;

    public class Category : AuditInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
