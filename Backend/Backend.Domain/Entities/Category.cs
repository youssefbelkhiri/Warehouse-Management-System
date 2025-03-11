using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string DefaultUnit { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
