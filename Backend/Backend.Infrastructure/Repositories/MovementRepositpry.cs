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
    internal class MovementRepositpry : IMovementRepository
    {
        private readonly ApplicationDbContext _context;
        public MovementRepositpry(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Movement>> GetAll()
        {
            return await _context.Movements.ToListAsync();
        }

        public async Task<Movement> GetById(int id)
        {
            return await _context.Movements.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
