using AutoMapper;
using Project.DAL.DatabaseModels;
using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository.DependencyResolver
{
   public class RepositoryProfile : Profile
    {
        public RepositoryProfile()
        {
            CreateMap<IVehicleMakeDomain, VehicleMake>().ReverseMap();
            CreateMap<IVehicleModelDomain, VehicleModel>().ReverseMap();
        }
    }
}
