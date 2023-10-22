namespace EmployeesOps.DAL.Models
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public string? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
