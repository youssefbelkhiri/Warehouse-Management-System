using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Common;

namespace Backend.Domain.Entities
{
    public class MovementLineDetail
    {
        [Key]
        public int Id { get; set; }
        public int MovementLineId { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }

        public MovementLine MovementLine { get; set; } = new MovementLine();
    }
}
