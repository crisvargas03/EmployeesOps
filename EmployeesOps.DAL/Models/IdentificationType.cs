namespace EmployeesOps.DAL.Models
{
    public class IdentificationType : BaseEntity<int>
    {
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
