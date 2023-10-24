using EmployeesOps.DAL.Models;
using EmployeesOps.DAL.Repository.Core;
using EmployeesOps.DAL.Repository.IRepositories;

namespace EmployeesOps.DAL.Repository
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentInterface
    {
        private readonly MainDbContext _mainDbContext;
        public DepartmentRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<Department> Update(Department entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.ModificationBy = entity.Name;
            await _mainDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
