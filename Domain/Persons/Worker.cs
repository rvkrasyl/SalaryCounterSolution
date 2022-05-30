namespace SalaryCounter.Domain
{
    public class Worker : FullTimeEmployee
    {
        public Worker(string passportId, string name, List<DailyReport> dailyReports) : base(passportId, name, dailyReports, Parameters.WorkerSalaryPerHour, Parameters.WorkerSalaryPerHour * Parameters.MonthlyWorkHours)
        {

        }
    }
}
