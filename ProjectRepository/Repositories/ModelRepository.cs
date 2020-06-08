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
        private readonly IRepository<VehicleModel> _repository;
        private readonly IMapper _mapper;

        public ModelRepository(IRepository<VehicleModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IVehicleModelDomain>> GetAllModels()
        {
            IEnumerable<IVehicleModelDomain> vehicles = _mapper.Map<IEnumerable<IVehicleModelDomain>>(await _repository.GetAll());
            return vehicles;
        }

        public async Task InsertModel(IVehicleModelDomain vehicleModel)
        {
            VehicleModel vehicle = _mapper.Map<VehicleModel>(vehicleModel);
            await _repository.Insert(vehicle);
        }

        public async Task UpdateModel(IVehicleModelDomain vehicleModel)
        {
            VehicleModel vehicle = _mapper.Map<VehicleModel>(vehicleModel);
            await _repository.Update(vehicle);
        }

        public async Task DeleteModel(Guid? id)
        {
            await _repository.Delete(id);
        }

        public async Task<IVehicleModelDomain> GetIdModel(Guid? id)
        {
            VehicleModel vehicle = await _repository.GetId(id);
            return _mapper.Map<IVehicleModelDomain>(vehicle);
        }
        
    }
}
