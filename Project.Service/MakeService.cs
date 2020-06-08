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
        private readonly IUnitOfWork _unitOfWork;

        public MakeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<IVehicleMakeDomain>> GetAllMakes()
        {
            return await _unitOfWork.Makes.GetAllMakes();
        }

        public async Task InsertMake(IVehicleMakeDomain vehicleMake)
        {
           await _unitOfWork.Makes.InsertMake(vehicleMake);
           await _unitOfWork.Complete();
        }

        public async Task UpdateMake(IVehicleMakeDomain vehicleMake)
        {
            await _unitOfWork.Makes.UpdateMake(vehicleMake);
            await _unitOfWork.Complete();
        }

        public async Task DeleteMake(Guid? id)
        {
            await _unitOfWork.Makes.DeleteMake(id);
            await _unitOfWork.Complete();
        }

        public async Task<IVehicleMakeDomain> GetIdMake(Guid? id)
        {
         return  await _unitOfWork.Makes.GetIdMake(id);
        }
  
    }
}
