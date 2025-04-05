using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IProduitRepository
    {
        public Task<Product> GetById(int id);
        public Task<List<Product>> GetAll();
    }
}
