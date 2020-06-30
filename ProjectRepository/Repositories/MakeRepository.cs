
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Common.DatabaseInterfaces;
using Project.DAL.DatabaseModels;
using Project.DAL.Migrations;
using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common.IRepositories;
using Project.Repository.Repositories;
using Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.Repository
{
    public class MakeRepository : Repository<VehicleMake>, IMakeRepository 
    {
        private readonly IMapper _mapper;
     
        public MakeRepository(IMapper mapper, VehicleDbContext _context):base(_context)
        {
            _mapper = mapper;
        }
       
        public async Task<IEnumerable<IVehicleMakeDomain>> GetAllMakesAsync()
        {
            IEnumerable<IVehicleMakeDomain> vehicles = _mapper.Map<IEnumerable<IVehicleMakeDomain>>(await base.GetAllAsync());
            return  vehicles;
        }

        public async Task InsertMakeAsync(IVehicleMakeDomain vehicleMake)
        {
          VehicleMake vehicle = _mapper.Map<VehicleMake>(vehicleMake);
          await base.InsertAsync(vehicle);
        }


        public async Task UpdateMakeAsync(IVehicleMakeDomain vehicleMake)
        {
            VehicleMake vehicle = _mapper.Map<VehicleMake>(vehicleMake);
            await base.UpdateAsync(vehicle);
        }

        public async Task DeleteMakeAsync(Guid? id)
        {
            await base.DeleteAsync(id);
        }

        public async Task<IVehicleMakeDomain> GetIdMakeAsync(Guid? id)
        {
            VehicleMake vehicle = await base.GetIdAsync(id);
            return _mapper.Map<IVehicleMakeDomain>(vehicle);
        }

    }
}
