using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    internal class ProduitRepository : IProduitRepository
    {
        private readonly ApplicationDbContext _context;
        public ProduitRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
