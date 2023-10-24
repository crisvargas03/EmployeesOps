using EmployeesOps.DAL.Models;
using EmployeesOps.DAL.Repository.Core;
using EmployeesOps.DAL.Repository.IRepositories;

namespace EmployeesOps.DAL.Repository
{
    public class IdentificationTypeRepository : BaseRepository<IdentificationType>, IIdentificationTypeInterface
    {
        public IdentificationTypeRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
        }
    }
}
