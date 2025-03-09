using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Infrastructure.Context;

namespace Backend.Infrastructure.Repositories
{
    internal abstract class Repositories<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected Repositories(ApplicationDbContext context)
        {
            _context = context;
        }
        public  void Add(TEntity entity)
        {
           _context.Set<TEntity>().AddAsync(entity);
        }
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
        }
    }
}
