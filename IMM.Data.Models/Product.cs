namespace IMM.Data.Models
{
    using IMM.Data.Common.Models;

    public class Product : AuditInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Category Category { get; set; }
    }
}
