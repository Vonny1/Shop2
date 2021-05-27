using System;
using System.Collections.Generic;

#nullable disable

namespace Shop2.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double? Cost { get; set; }
        public long? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
