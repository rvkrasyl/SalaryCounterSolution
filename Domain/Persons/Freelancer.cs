namespace SalaryCounter.Domain
{
    public class Freelancer : Employee
    {
        public Freelancer(string passportId, string name, List<DailyReport> dailyReports, decimal salaryPerHour) : base(passportId, name,  Roles.freelancer, dailyReports, salaryPerHour)
        {

        }
    }
}
