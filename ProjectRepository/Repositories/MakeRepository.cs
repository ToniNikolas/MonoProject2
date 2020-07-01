
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
using Project.Common.Functionalities;
using System.Linq.Expressions;

namespace Project.Repositories.Repository
{
    public class MakeRepository : Repository<VehicleMake>, IMakeRepository 
    {
        private readonly IMapper _mapper;
     
        public MakeRepository(IMapper mapper, VehicleDbContext _context):base(_context)
        {
            _mapper = mapper;
        }
       
        public async Task<IEnumerable<IVehicleMakeDomain>> GetAllMakesAsync(Sorting sorting, Searching searching, PaginatedList<VehicleMake> paging)
        {
            SortBy sortBy = new SortBy();
            SearchBy searchBy = new SearchBy();
            Func<IQueryable<VehicleMake>, IOrderedQueryable<VehicleMake>> sort = sortBy.MakeOrderBy(sorting.SortString);
            
            if (!String.IsNullOrWhiteSpace(searching.SearchingString))
            { 
            Expression<Func<VehicleMake, bool>> search = searchBy.MakeSearchBy(searching.SearchingString);
            return _mapper.Map<IEnumerable<IVehicleMakeDomain>>(await base.GetAllAsync(sort,paging,search));     
            }

            else
            {
                return _mapper.Map<IEnumerable<IVehicleMakeDomain>>(await base.GetAllAsync(sort,paging));
            }
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
