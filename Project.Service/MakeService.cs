using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common;
using Project.Repository.Common.IRepositories;
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
        private readonly IUnitOfWork unitOfWork;

        public MakeService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<IEnumerable<IVehicleMakeDomain>> GetAllMakes()
        {
            return await unitOfWork.Makes.GetAllMakes();
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
