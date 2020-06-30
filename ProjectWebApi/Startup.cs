using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using IContainer = Autofac.IContainer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.DAL.Migrations;
using Project.Service.Common;
using Project.Repository.Repositories;
using Project.Repository.Common.IRepositories;
using Project.Service;
using Project.Repositories.Repository;
using Project.DAL.Common.DatabaseInterfaces;
using Project.DAL.DatabaseModels;
using Project.Repository;
using Project.Repository.Common;
using Project.Service.DependencyResolver;
using Project.Repository.DependencyResolver;
using Project.WebApi.DependencyResolver;

namespace ProjectWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VehicleDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Project.DAL")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //automapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {  
                cfg.AddProfile(new RepositoryProfile());
                cfg.AddProfile(new ApiProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            // Autofac
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new RepositoryModule());
            this.ApplicationContainer = builder.Build();
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
            
        }
       
       
            
           
           
       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

           // app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors(builder => builder
           .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
           .AllowCredentials());
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
