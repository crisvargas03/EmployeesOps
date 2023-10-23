namespace EmployeesOps.DAL.Models
{
    public class Employee : BaseEntity<Guid>
    {
        public string Names { get; set; } = string.Empty;
        public string LastNames {  get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime EntryDate { get; set; }
        public double Salary { get; set; }
        public int IdentificationTypeId { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Prop
        public virtual Department? Department { get; set; }
        public virtual IdentificationType? IdentificationType { get; set; }
    }
}
