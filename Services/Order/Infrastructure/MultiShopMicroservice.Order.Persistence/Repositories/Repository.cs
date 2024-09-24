using Microsoft.EntityFrameworkCore;
using MultiShopMicroservice.Order.Application.Interfaces;
using MultiShopMicroservice.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext context;
        public Repository(OrderContext _context)
        {
            context = _context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity); // set<> ilgili T generic class ını getirmek için kullanılır.
            await context.SaveChangesAsync();
            return entity; // template yüklendikten sonra metod geri dönüşleri kontrol edilsin. hiçbir şey döndürmememiz de gerekebilir.
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
