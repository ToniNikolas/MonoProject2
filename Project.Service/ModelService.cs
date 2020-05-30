using Project.Model.Common.DomainInterfaces;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class ModelService : IModelService
    {
        public Task DeleteModel(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IVehicleModelDomain>> GetAllModels()
        {
            throw new NotImplementedException();
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
