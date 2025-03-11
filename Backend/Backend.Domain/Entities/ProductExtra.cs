using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Common;

namespace Backend.Domain.Entities
{
    public class ProductExtra
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Attribute { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public Product Product { get; set; } = new Product();
    }
}
