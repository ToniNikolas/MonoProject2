using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class ModelRepository : IModelRepository
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
