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
        
        public UnitOfWork(VehicleDbContext _context, IMapper _mapper, IMakeRepository _makeRepository, IModelRepository _modelRepository)
        {
            context = _context;
            Makes = _makeRepository;
            Models = _modelRepository;
        }

        public IMakeRepository Makes { get; private set; }
        public IModelRepository Models { get; private set; }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
