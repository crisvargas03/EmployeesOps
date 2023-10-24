using System.Linq.Expressions;

namespace EmployeesOps.DAL.Repository.Core
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<T> CreateAsync(T entity);
        Task SaveAsync();
    }
}
