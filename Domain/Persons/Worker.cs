using static SalaryCounter.Domain.Parameters;

namespace SalaryCounter.Domain
{
    public class Worker : FullTimeEmployee
    {
        public Worker(string passportId, string name, List<DailyReport> dailyReports) : base(passportId, name, dailyReports, WorkerSalaryPerHour, WorkerSalaryPerHour * MonthlyWorkHours)
        {

        }

        public void GetReportForPeriod(DateTime fromDate, DateTime toDate)
        {
            if (toDate < fromDate)
            {
                Console.WriteLine("Invalid date range selected!");
                return;
            }
            else
            {
                var employeeReport = DailyReports.Where(employee => employee.ID == Passport && employee.Date >= fromDate && employee.Date <= toDate)
                                                    .Select(employee => new { Date = employee.Date, WorkedHours = employee.WorkHours });
                byte periodWorkHours = 0;
                decimal periodSalary = 0;
                foreach (var report in employeeReport)
                {
                    decimal todaysSalary = 0;
                    if (8 >= report.WorkedHours)
                    {
                        todaysSalary = report.WorkedHours * WorkerSalaryPerHour;
                    }
                    else
                    {
                        todaysSalary = (8 * WorkerSalaryPerHour) + ((report.WorkedHours - 8) * WorkerSalaryPerHour * 2); // x2 bonus for overtime hours
                    }
                    periodSalary += todaysSalary;
                    periodWorkHours += report.WorkedHours;
                    Console.WriteLine($"{report.Date:d} you worked for {report.WorkedHours} hours and earned {todaysSalary} uah");
                }
                Console.WriteLine($"In common from {fromDate:d} to {toDate:d}: {periodWorkHours} hours worked for {periodSalary} uah");
            }
        }

    }
}
