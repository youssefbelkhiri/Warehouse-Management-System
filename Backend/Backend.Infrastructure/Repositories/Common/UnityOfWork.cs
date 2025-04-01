using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.common;
using Backend.Infrastructure.Context;

namespace Backend.Infrastructure.Repositories.Common
{
    internal class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnityOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
