﻿using LaptopStoreAPI.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LaptopStoreAPI.Persistence.Repositories
{
    public class LaptopStoreRepository
    {
        private readonly LaptopStoreDbContext context;

        public LaptopStoreRepository(LaptopStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Processor>> GetAllProcessorsAsync()
        {
            return await context.processors.ToListAsync();
        }
        public async Task<Processor> GetProcessorAsync(int id)
        {
            return await context.processors.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProcessorAsync(Processor processor)
        {
            await context.processors.AddAsync(processor);
        }

        public void UpdateProcessor(Processor processor)
        {
            context.processors.Update(processor);
        }
        public void DeleteProcessor(Processor processor)
        {
            context.processors.Remove(processor);
        }



        /* Ram Repository */

        public async Task<IEnumerable<Ram>> GetAllRamsAsync()
        {
            return await context.rams.ToListAsync();
        }
        public async Task<Ram> GetRamAsync(int id)
        {
            return await context.rams.SingleOrDefaultAsync(r => r.Id == id);
        }
        public async Task AddRamAsync(Ram ram)
        {
            await context.AddRangeAsync(ram);
        }
        public async Task<Ram> FindRamAsync(int id)
        {
            var result =  await context.rams.FindAsync(id);
            return result;
        }

        public void UpdateRam(Ram ram)
        {
            context.rams.Update(ram);
        }

        public async Task<bool> DeleteRamAsync(int id)
        {
            var ram = await FindRamAsync(id);
            if (ram == null)
                return false;
            
            context.rams.Remove(ram);
            return true;
        }


        //Generic methods
        public async Task<T> FindEntityAsync<T>(int id) where T: class
        {
            return await context.Set<T>().FindAsync(id);
            
        }
        public async Task<IEnumerable<T>> GetAllEntitiesAsync<T>() where T : class
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityAsync<T>(int id) where T : class
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task AddEntityAsync<T>(T E) where T : class
        {
            await context.Set<T>().AddAsync(E);
        }

        public void UpdateEntiry<T>(T E) where T: class
        {
            context.Set<T>().Update(E);
        }

        public void DeleteEntity<T>(T E) where T: class
        {
            context.Set<T>().Remove(E);
        }

        public async Task<T> IsCompositeExist<T>(Expression<Func<T, bool>> e) where T : class
        {
            return await context.Set<T>().SingleOrDefaultAsync(e);
        }

    }
}
