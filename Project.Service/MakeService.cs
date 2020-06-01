using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class MakeService : IMakeService
    {
        private readonly IMakeRepository repository;

        public MakeService(IMakeRepository _repository)
        {
            repository = _repository;
        }

        public async Task<List<IVehicleMakeDomain>> GetAllMakes()
        {
                return await repository.GetAllMakes();
        }

        public Task DeleteMake(Guid? id)
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
