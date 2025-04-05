using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface ITagRepository
    {
        public Task<Tag> GetById(int id);
        public Task<List<Tag>> GetAll();
    }
}
