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
        private readonly IUnitOfWork unitOfWork;

        public ModelService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public Task DeleteModel(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IVehicleModelDomain>> GetAllModels()
        {
            return await unitOfWork.Models.GetAllModels();
        }

        public Task<IVehicleModelDomain> GetIdModel(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task InsertModel(IVehicleModelDomain vehicleModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateModel(IVehicleModelDomain vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}
