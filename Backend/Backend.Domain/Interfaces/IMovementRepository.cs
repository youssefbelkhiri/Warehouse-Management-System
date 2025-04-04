using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IMovementRepository
    {
        public Task<Movement> GetById(int id);
        public Task<List<Movement>> GetAll();
    }
}
