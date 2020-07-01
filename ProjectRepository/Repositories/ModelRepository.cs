using AutoMapper;
using Project.Common;
using Project.Common.Functionalities;
using Project.DAL.DatabaseModels;
using Project.DAL.Migrations;
using Project.Model.Common.DomainInterfaces;
using Project.Repository.Common.IRepositories;
using Project.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.Repository
{
    public class ModelRepository : Repository<VehicleModel>, IModelRepository
    {
        
        private readonly IMapper _mapper;

        public ModelRepository(VehicleDbContext context, IMapper mapper) : base(context)
        {
                   _mapper = mapper;
        }

        public async Task<IEnumerable<IVehicleModelDomain>> GetAllModelsAsync(Sorting sorting, Searching searching, PaginatedList<VehicleModel> paging)
        {
          
            SortBy sortBy = new SortBy();
            SearchBy searchBy = new SearchBy();
            Func<IQueryable<VehicleModel>, IOrderedQueryable<VehicleModel>> sort = sortBy.ModelOrderBy(sorting.SortString);
            if (!String.IsNullOrWhiteSpace(searching.SearchingString))
            { 
                Expression<Func<VehicleModel, bool>> search = searchBy.ModelSearchBy(searching.SearchingString);
                return _mapper.Map<IEnumerable<IVehicleModelDomain>>(await base.GetAllAsync(sort, paging, search));
            }
            else
            {
                return _mapper.Map<IEnumerable<IVehicleModelDomain>>(await base.GetAllAsync(sort,paging));
            }


        }

        public async Task InsertModelAsync(IVehicleModelDomain vehicleModel)
        {
            VehicleModel vehicle = _mapper.Map<VehicleModel>(vehicleModel);
            await base.InsertAsync(vehicle);
        }

        public async Task UpdateModelAsync(IVehicleModelDomain vehicleModel)
        {
            VehicleModel vehicle = _mapper.Map<VehicleModel>(vehicleModel);
            await base.UpdateAsync(vehicle);
        }

        public async Task DeleteModelAsync(Guid? id)
        {
            await base.DeleteAsync(id);
        }

        public async Task<IVehicleModelDomain> GetIdModelAsync(Guid? id)
        {
            VehicleModel vehicle = await base.GetIdAsync(id);
            return _mapper.Map<IVehicleModelDomain>(vehicle);
        }
        
    }
}
