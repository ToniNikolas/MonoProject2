using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common;
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

        public async Task<IEnumerable<IVehicleModelDomain>> GetAllModels()
        {
            return await _unitOfWork.Models.GetAllModels();
        }

        public async Task InsertModel(IVehicleModelDomain vehicleModel)
        {
            await _unitOfWork.Models.InsertModel(vehicleModel);
            await _unitOfWork.Complete();
        }

        public async Task UpdateModel(IVehicleModelDomain vehicleModel)
        {
            await _unitOfWork.Models.UpdateModel(vehicleModel);
            await _unitOfWork.Complete();
        }

        public async Task DeleteModel(Guid? id)
        {
            await _unitOfWork.Models.DeleteModel(id);
            await _unitOfWork.Complete();
        }

        public async Task<IVehicleModelDomain> GetIdModel(Guid? id)
        {
            return await _unitOfWork.Models.GetIdModel(id);
        }
       
    }
}
