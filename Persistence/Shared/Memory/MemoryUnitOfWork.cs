using Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Shared.Memory
{
    public class MemoryUnitOfWork : IUnitOfWork
    {
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
