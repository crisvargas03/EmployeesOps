﻿namespace EmployeesOps.DAL.Models
{
    public class Department : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;

        // Navigation Prop
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
