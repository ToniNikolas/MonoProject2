using Project.Common;
using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common.IRepositories
{
   public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid? id);
        Task<T> GetIdAsync(Guid? id);
    }
}
