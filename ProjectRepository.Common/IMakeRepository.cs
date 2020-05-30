using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IMakeRepository
    {
        Task<List<IVehicleMakeDomain>> GetAllMakes();
        Task InsertMake(IVehicleMakeDomain vehicleMake);
        Task UpdateMake(IVehicleMakeDomain vehicleMake);
        Task DeleteMake(Guid? id);
        Task<IVehicleMakeDomain> GetIdMake(Guid? id);
        List<IVehicleMakeDomain> GetMakeList();
    }
}
