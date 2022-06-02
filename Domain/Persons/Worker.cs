using SalaryCounter.Domain.FileIOServices;
using static SalaryCounter.Domain.Parameters;

namespace SalaryCounter.Domain
{
    public class Worker : FullTimeEmployee
    {
        public Worker(string passportId, string name/*, List<DailyReport> dailyReports*/) : base(passportId, name, 1,/* dailyReports,*/ WorkerSalaryPerHour, WorkerSalaryPerHour * MonthlyWorkHours)
        {

        }
        public override void GetReportForPeriod(DateTime fromDate, DateTime toDate, bool isMounthly = false)
        {
            if (toDate < fromDate)
            {
                Console.WriteLine("Invalid date range selected!");
                return;
            }

            if (!isMounthly)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('-', 70));
                Console.WriteLine("WARNING! Overtime bonuses report available only in Month report!");
                Console.WriteLine(new string('-', 70));
                Console.ResetColor();
            }

            var employeeReport = FileIO.GetReportsData((int)Role).Where(employee => employee.ID == Passport && employee.Date.Ticks >= fromDate.Ticks && employee.Date.Ticks <= toDate.Ticks)
                                                .Select(employee => new { Date = employee.Date, WorkedHours = employee.WorkHours })
                                                .OrderBy(employee => employee.Date);

            short periodWorkHours = Convert.ToInt16(employeeReport.Sum(period => period.WorkedHours));
            decimal periodSalary = 0;
            decimal todaysSalary = 0;

            if (isMounthly && periodWorkHours > MonthlyWorkHours)
            {
                foreach (var report in employeeReport)
                {
                    if (NormalDayWorkTime >= report.WorkedHours)
                    {
                        todaysSalary = report.WorkedHours * WorkerSalaryPerHour;
                    }
                    else
                    {
                        todaysSalary = (NormalDayWorkTime * WorkerSalaryPerHour) + ((report.WorkedHours - NormalDayWorkTime) * WorkerSalaryPerHour * 2); // x2 bonus for overtime hours
                    }
                    periodSalary += todaysSalary;
                    Console.WriteLine($"{report.Date:d} you worked for {report.WorkedHours} hours and earned {todaysSalary} uah");
                }
            }
            else
            {
                foreach (var report in employeeReport)
                {
                    todaysSalary = report.WorkedHours * WorkerSalaryPerHour;
                    periodSalary += todaysSalary;
                    Console.WriteLine($"{report.Date:d} you worked for {report.WorkedHours} hours and earned {todaysSalary} uah");
                }
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"In common from {fromDate:d} to {toDate:d}: {periodWorkHours} hours worked for {periodSalary} uah");
            if (isMounthly)
                Console.WriteLine($"Overtime hours this month: {periodWorkHours - MonthlyWorkHours}. Overtime bonus this month: {periodSalary - (MonthlyWorkHours * WorkerSalaryPerHour)} uah.\nGreat job!");
            Console.WriteLine(new string('-', 70));
        }
    }
}
