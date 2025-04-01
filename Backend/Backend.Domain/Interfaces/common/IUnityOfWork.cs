using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Interfaces.common
{
    public interface IUnityOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
