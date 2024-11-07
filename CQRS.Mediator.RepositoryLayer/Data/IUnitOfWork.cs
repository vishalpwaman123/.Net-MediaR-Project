using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.RepositoryLayer.Data
{
    public interface IUnitOfWork
    {
        Task<decimal> NextSequence(string sequenceName);
        Task<int> SaveChangeAsync();
        void Commit();
        void Rollback();
    }
}
