using Project.Model.Common.DomainInterfaces;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class MakeService : IMakeService
    {
        public Task DeleteMake(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IVehicleMakeDomain>> GetAllMakes()
        {
            throw new NotImplementedException();
        }

        public Task<IVehicleMakeDomain> GetIdMake(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<IVehicleMakeDomain> GetMakeList()
        {
            throw new NotImplementedException();
        }

        public Task InsertMake(IVehicleMakeDomain vehicleMake)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMake(IVehicleMakeDomain vehicleMake)
        {
            throw new NotImplementedException();
        }
    }
}
