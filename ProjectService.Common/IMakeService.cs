using Project.Common;
using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
   public interface IMakeService
    {
        Task<IEnumerable<IVehicleMakeDomain>> GetAllMakesAsync();
        Task InsertMakeAsync(IVehicleMakeDomain vehicleMake);
        Task UpdateMakeAsync(IVehicleMakeDomain vehicleMake);
        Task DeleteMakeAsync(Guid? id);
        Task<IVehicleMakeDomain> GetIdMakeAsync(Guid? id);
    }
}
