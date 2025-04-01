using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;

namespace Backend.Application.Features.ProductManager.Commands.CreateProduct
{
    public sealed class CreateProductCommand : ICommand
    {
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public string DefaultQuantityUnit { get; set; } = null!;
        public bool HasDetails { get; set; }
    }
}
