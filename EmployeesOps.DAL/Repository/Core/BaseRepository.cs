using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeesOps.DAL.Repository.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MainDbContext _mainDbContext;
        internal DbSet<T> DbSet;

        public BaseRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
            this.DbSet = _mainDbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _mainDbContext.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = DbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = DbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _mainDbContext.SaveChangesAsync();
        }
    }
}
