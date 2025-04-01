using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.common;
using Backend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Common
{
    internal class TRepositroy<T> : ITRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public TRepositroy(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(T product)
        {
            _context.Set<T>().Add(product);
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            return result;
        }

        public bool Remove(int id)
        {
            var product = _context.Set<T>().Find(id);
            if (product != null)
            {
                _context.Set<T>().Remove(product);
                return true;
            }
            return false;
        }

        public void Update(T product)
        {
            _context.Set<T>().Update(product);
        }
    }
}
