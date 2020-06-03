using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
   public interface IModelService
    {
        Task<IEnumerable<IVehicleModelDomain>> GetAllModels();
        Task InsertModel(IVehicleModelDomain vehicleModel);
        Task UpdateModel(IVehicleModelDomain vehicleModel);
        Task DeleteModel(Guid? id);
        Task<IVehicleModelDomain> GetIdModel(Guid? id);
    }
}
