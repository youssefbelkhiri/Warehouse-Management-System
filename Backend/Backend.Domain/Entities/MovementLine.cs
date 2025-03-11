using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Common;

namespace Backend.Domain.Entities
{
    public class MovementLine 
    {
        [Key]
        public int Id { get; set; }
        public int MovementId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; } 

        public Movement Movement { get; set; } = new Movement();
        public ICollection<MovementLineDetail> MovementLineDetails { get; set; } = new List<MovementLineDetail>();
    }
}
