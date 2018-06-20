﻿namespace IMM.Data.Models
{
    using IMM.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product : AuditInfo
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
