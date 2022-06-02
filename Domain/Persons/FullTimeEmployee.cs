namespace SalaryCounter.Domain
{
    public class FullTimeEmployee: Employee
    {
        decimal MouthSalary { get; }
        public FullTimeEmployee(string passportId, string name, int role, decimal salaryPerHour, decimal mouthSalary) : base(passportId, name, role, salaryPerHour)
        {
            MouthSalary = mouthSalary;
        }
    }
}
