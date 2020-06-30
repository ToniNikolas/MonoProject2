using Project.Common;
using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common;
using Project.Repository.Common.IRepositories;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<IVehicleModelDomain>> GetAllModelsAsync()
        {
            return await _unitOfWork.Models.GetAllModelsAsync();
        }

        public async Task InsertModelAsync(IVehicleModelDomain vehicleModel)
        {
            await _unitOfWork.Models.InsertModelAsync(vehicleModel);
            await _unitOfWork.CompleteAsync();
       
        }

        public async Task UpdateModelAsync(IVehicleModelDomain vehicleModel)
        {
            await _unitOfWork.Models.UpdateModelAsync(vehicleModel);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteModelAsync(Guid? id)
        {
            await _unitOfWork.Models.DeleteModelAsync(id);
            await _unitOfWork.CompleteAsync();
          
        }

        public async Task<IVehicleModelDomain> GetIdModelAsync(Guid? id)
        {
            return await _unitOfWork.Models.GetIdModelAsync(id);
          
        }
       
    }
}
