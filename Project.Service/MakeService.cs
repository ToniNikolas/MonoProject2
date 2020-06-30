using Project.Common;
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
      

        public MakeService(IUnitOfWork unitOfWork, IMakeRepository makeRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<IVehicleMakeDomain>> GetAllMakesAsync()
        {
            return await _unitOfWork.Makes.GetAllMakesAsync();
          
        }

        public async Task InsertMakeAsync(IVehicleMakeDomain vehicleMake)
        {
            await _unitOfWork.Makes.InsertMakeAsync(vehicleMake);
            await _unitOfWork.CompleteAsync();
        
        }

        public async Task UpdateMakeAsync(IVehicleMakeDomain vehicleMake)
        {
            await _unitOfWork.Makes.UpdateMakeAsync(vehicleMake);
            await _unitOfWork.CompleteAsync();
            
        }

        public async Task DeleteMakeAsync(Guid? id)
        {
            await _unitOfWork.Makes.DeleteMakeAsync(id);
            await _unitOfWork.CompleteAsync();
       
        }

        public async Task<IVehicleMakeDomain> GetIdMakeAsync(Guid? id)
        {
            return  await _unitOfWork.Makes.GetIdMakeAsync(id);
          
        }
  
    }
}
