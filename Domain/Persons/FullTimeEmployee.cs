namespace SalaryCounter.Domain
{
    public class FullTimeEmployee: Employee
    {
        decimal MouthSalary { get; }
        public FullTimeEmployee(string passportId, string name, int role, /*List<DailyReport> dailyReports,*/ decimal salaryPerHour, decimal mouthSalary) : base(passportId, name, role, /*dailyReports,*/ salaryPerHour)
        {
            MouthSalary = mouthSalary;
        }
    }
}
