using AutoMapper;
using Project.Common.Functionalities;
using Project.Model.Common.DomainInterfaces;
using Project.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebApi.DependencyResolver
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<IVehicleMakeDomain, VehicleMakeView>().ReverseMap();
            CreateMap<IVehicleModelDomain, VehicleModelView>().ReverseMap();
        }
    }
}
