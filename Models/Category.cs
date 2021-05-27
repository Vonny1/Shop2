using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Shop2.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
