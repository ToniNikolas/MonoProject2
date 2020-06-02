using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common.IRepositories
{
   public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(object id);
        Task<T> GetId(object id);
        List<T> GetMakeList();

    }
}
