using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.RepositoryLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> NextSequence(string sequenceName)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
