using AutoMapper;
using Project.DAL.DatabaseModels;
using Project.DAL.Migrations;
using Project.Repositories.Repository;
using Project.Repository.Common;
using Project.Repository.Common.IRepositories;
using Project.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDbContext context;


        public UnitOfWork(VehicleDbContext _context,  IMakeRepository _makeRepository, IModelRepository _modelRepository)
          {
              context = _context;
              Makes = _makeRepository;
              Models = _modelRepository;
          }

            public IMakeRepository Makes { get; private set; }
            public IModelRepository Models { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /*public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }*/
    }
}
