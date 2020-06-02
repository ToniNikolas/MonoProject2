using Autofac;
using Project.DAL.DatabaseModels;
using Project.Repositories.Repository;
using Project.Repository.Common;
using Project.Repository.Common.IRepositories;
using Project.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository.DependencyResolver
{
  public  class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<MakeRepository>().As<IMakeRepository>();
            builder.RegisterType<ModelRepository>().As<IModelRepository>();
            builder.RegisterType<Repository<VehicleMake>>().As<IRepository<VehicleMake>>();
            builder.RegisterType<Repository<VehicleModel>>().As<IRepository<VehicleModel>>();
        }
    }
}
