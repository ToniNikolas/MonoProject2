using Microsoft.EntityFrameworkCore;
using Project.DAL.Migrations;
using Project.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly VehicleDbContext context;
        private readonly DbSet<T> table;

        public Repository(VehicleDbContext _context)
        {
            context = _context;
            table = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
          IEnumerable<T> vehicles = await table.ToListAsync();
          return vehicles;
        }


        public Task Delete(object id)
        {
            throw new NotImplementedException();
        }

       
        public Task<T> GetId(object id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetMakeList()
        {
            throw new NotImplementedException();
        }

        public Task Insert(T vehicleMake)
        {
            throw new NotImplementedException();
        }

        public Task Update(T vehicleMake)
        {
            throw new NotImplementedException();
        }
    }
}
