using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;

namespace Backend.Application.Features.ProductManager.Commands.DeleteProduct
{
    public sealed class DeleteProductCommand() : ICommand
    {
        public int Id { get; set; }
    }
}
