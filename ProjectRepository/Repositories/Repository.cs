using Microsoft.EntityFrameworkCore;
using Project.Common;
using Project.DAL.Migrations;
using Project.Repository.Common;
using Project.Repository.Common.IRepositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly VehicleDbContext _context;
        private readonly DbSet<T> dbSet;

        public Repository(VehicleDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> vehicles = await dbSet.ToListAsync();
            return vehicles;
        }
        public async Task InsertAsync(T vehicleMake)
        {
           await dbSet.AddAsync(vehicleMake);
        }

        public async Task UpdateAsync(T vehicleMake)
        {
            dbSet.Update(vehicleMake); 
        }

        public async Task DeleteAsync(Guid? id)
        {
            T vehicle = await dbSet.FindAsync(id);
            dbSet.Remove(vehicle);
        }

        public async Task<T> GetIdAsync(Guid? id)
        {
            T vehicle = await dbSet.FindAsync(id);
            _context.Entry(vehicle).State = EntityState.Detached;
            return vehicle;
        }
       
    }
}
