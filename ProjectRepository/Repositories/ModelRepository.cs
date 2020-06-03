using AutoMapper;
using Project.DAL.DatabaseModels;
using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.Repository
{
    public class ModelRepository : IModelRepository
    {
        private readonly IRepository<VehicleModel> repository;
        private readonly IMapper mapper;

        public ModelRepository(IRepository<VehicleModel> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task<IEnumerable<IVehicleModelDomain>> GetAllModels()
        {
            IEnumerable<IVehicleModelDomain> vehicles = mapper.Map<IEnumerable<IVehicleModelDomain>>(await repository.GetAll());
            return vehicles;
        }

        public Task DeleteModel(Guid? id)
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
