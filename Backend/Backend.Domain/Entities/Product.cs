using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string DefaultQuantityUnit { get; set; } = string.Empty;
        public bool HasDetails { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
        public ICollection<ProductExtra> ProductExtras { get; set; } = new List<ProductExtra>();
    }
}
