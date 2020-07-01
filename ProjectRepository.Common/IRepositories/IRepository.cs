using Project.Common;
using Project.Common.Functionalities;
using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common.IRepositories
{
   public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, PaginatedList<T> paging,Expression<Func<T, bool>> filter);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid? id);
        Task<T> GetIdAsync(Guid? id);
    }
}
