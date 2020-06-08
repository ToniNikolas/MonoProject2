using Microsoft.EntityFrameworkCore;
using Project.DAL.Migrations;
using Project.Repository.Common;
using Project.Repository.Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly VehicleDbContext _context;
        //private readonly DbSet<T> table;
       

        public Repository(VehicleDbContext context)
        {
            _context = context;
        
            //table = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
          IEnumerable<T> vehicles = await _context.Set<T>().ToListAsync(); 
          return vehicles;
        }
        public async Task Insert(T vehicleMake)
        {
           await _context.Set<T>().AddAsync(vehicleMake);
        }

        public async Task Update(T vehicleMake)
        {
            _context.Set<T>().Update(vehicleMake);    
        }

        public async Task Delete(Guid? id)
        {
            T vehicle = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(vehicle);   
        }

        public async Task<T> GetId(Guid? id)
        {
            T vehicle = await _context.Set<T>().FindAsync(id);
            _context.Entry(vehicle).State = EntityState.Detached;
            return vehicle;
        }
       
    }
}
