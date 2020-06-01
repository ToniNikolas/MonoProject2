
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Common.DatabaseInterfaces;
using Project.DAL.DatabaseModels;
using Project.DAL.Migrations;
using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class MakeRepository : IMakeRepository
    {
        private readonly VehicleDbContext context;
        private readonly IMapper mapper;

        public MakeRepository(VehicleDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
       

        public async Task<List<IVehicleMakeDomain>> GetAllMakes()
        {
            
            List<IVehicleMakeDomain> vehicles = mapper.Map<List<IVehicleMakeDomain>>(await context.VehicleMakes.ToListAsync());
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
