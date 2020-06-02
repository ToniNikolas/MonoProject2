using AutoMapper;
using Project.DAL.Common.DatabaseInterfaces;
using Project.DAL.DatabaseModels;
using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository.Automapper
{
   public class AutoMapperRepository : Profile
    {
        public AutoMapperRepository()
           {
            CreateMap<IVehicleMakeDomain,  VehicleMake>().ReverseMap();
           }


        }
    }
