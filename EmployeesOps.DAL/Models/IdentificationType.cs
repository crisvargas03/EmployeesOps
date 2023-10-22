namespace EmployeesOps.DAL.Models
{
    public class IdentificationType : BaseEntity<int>
    {
        public string Description { get; set; } = string.Empty;
        public ICollection<Employee>? Employees { get; set; }
    }
}
