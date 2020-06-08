
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Common.DatabaseInterfaces;
using Project.DAL.DatabaseModels;
using Project.DAL.Migrations;
using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.Repository
{
    public class MakeRepository : IMakeRepository
    {
        private readonly IRepository<VehicleMake> _repository;
        private readonly IMapper _mapper;

        public MakeRepository(IRepository<VehicleMake> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        public async Task<IEnumerable<IVehicleMakeDomain>> GetAllMakes()
        {
            IEnumerable<IVehicleMakeDomain> vehicles = _mapper.Map<IEnumerable<IVehicleMakeDomain>>(await _repository.GetAll());
             return  vehicles;
        }

        public async Task InsertMake(IVehicleMakeDomain vehicleMake)
        {
          VehicleMake vehicle = _mapper.Map<VehicleMake>(vehicleMake);
          await _repository.Insert(vehicle);
        }


        public async Task UpdateMake(IVehicleMakeDomain vehicleMake)
        {
            VehicleMake vehicle = _mapper.Map<VehicleMake>(vehicleMake);
            await _repository.Update(vehicle);
        }

        public async Task DeleteMake(Guid? id)
        {
            await _repository.Delete(id);
        }

        public async Task<IVehicleMakeDomain> GetIdMake(Guid? id)
        {
            VehicleMake vehicle = await _repository.GetId(id);
            return _mapper.Map<IVehicleMakeDomain>(vehicle);
        }

    }
}
