namespace EmployeesOps.DAL.Models
{
    public abstract class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }

        public BaseEntity()
        {
            CreatedBy = "By User";
            CreationDate = DateTime.Now;
            IsDeleted = false;
            ModificationBy = null;
            ModificationDate = null;
        }
    }
}
