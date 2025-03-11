using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class Movement
    {
        [Key]
        public int Id { get; set; }
        public string MovementType { get; set; } = string.Empty; 
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int TotalQuantity { get; set; }

        // Navigation Properties
        public Product Product { get; set; }
        public ICollection<MovementLine> MovementLines { get; set; } = new List<MovementLine>();
    }
}
