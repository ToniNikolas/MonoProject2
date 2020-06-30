using Project.DAL.DatabaseModels;
using Project.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IMakeRepository Makes {get;}
        IModelRepository Models { get; }
       
        Task<int> CompleteAsync();
    }
}
