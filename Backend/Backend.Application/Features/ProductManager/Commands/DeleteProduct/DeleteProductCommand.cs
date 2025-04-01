using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;

namespace Backend.Application.Features.ProductManager.Commands.DeleteProduct
{
    public sealed record DeleteProductCommand(int id) : ICommand
    {
    }
}
