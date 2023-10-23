﻿namespace EmployeesOps.BLL.Dtos
{
    public class EmployeeInsertDto
    {
        public string Names { get; set; } = string.Empty;
        public string LastNames { get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime EntryDate { get; set; }
        public double Salary { get; set; }
        public int IdentificationTypeId { get; set; }
        public int DepartmentId { get; set; }
    }
}
