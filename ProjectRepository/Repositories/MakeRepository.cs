
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
        private readonly IRepository<VehicleMake> repository;
        private readonly IMapper mapper;

        public MakeRepository(IRepository<VehicleMake> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
       
        public async Task<IEnumerable<IVehicleMakeDomain>> GetAllMakes()
        {
            IEnumerable<IVehicleMakeDomain> vehicles = mapper.Map<IEnumerable<IVehicleMakeDomain>>(await repository.GetAll());
            return  vehicles;
        }

        public Task DeleteMake(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<IVehicleMakeDomain> GetIdMake(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<IVehicleMakeDomain> GetMakeList()
        {
            throw new NotImplementedException();
        }

        public Task InsertMake(IVehicleMakeDomain vehicleMake)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMake(IVehicleMakeDomain vehicleMake)
        {
            throw new NotImplementedException();
        }
    }
}
