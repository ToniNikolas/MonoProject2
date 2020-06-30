using Project.Common;
using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
   public interface IModelService
    {
        Task<IEnumerable<IVehicleModelDomain>> GetAllModelsAsync();
        Task InsertModelAsync(IVehicleModelDomain vehicleModel);
        Task UpdateModelAsync(IVehicleModelDomain vehicleModel);
        Task DeleteModelAsync(Guid? id);
        Task<IVehicleModelDomain> GetIdModelAsync(Guid? id);
    }
}
