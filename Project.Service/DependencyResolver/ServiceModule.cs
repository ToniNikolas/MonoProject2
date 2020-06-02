using System;
using System.Collections.Generic;
using Autofac;
using System.Text;
using Project.Repository;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service.DependencyResolver
{
  public  class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MakeService>().As<IMakeService>();
            builder.RegisterType<ModelService>().As<IModelService>();
        }
    }
}
