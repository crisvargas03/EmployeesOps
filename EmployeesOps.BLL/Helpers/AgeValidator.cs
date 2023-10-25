namespace EmployeesOps.BLL.Helpers
{
    public static class AgeValidator
    {
        public static bool IsAdult(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - birthDate.Year;
            if (birthDate.Date > currentDate.AddYears(-age)) 
            {
                age--;
            }
            return age >= 18;
        }
    }
}
