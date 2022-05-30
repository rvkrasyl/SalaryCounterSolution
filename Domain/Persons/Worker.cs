using static SalaryCounter.Domain.Parameters;

namespace SalaryCounter.Domain
{
    public class Worker : FullTimeEmployee
    {
        public Worker(string passportId, string name, List<DailyReport> dailyReports) : base(passportId, name, Roles.worker, dailyReports, WorkerSalaryPerHour, WorkerSalaryPerHour * MonthlyWorkHours)
        {

        }

        public virtual void GetReportForPeriod(DateTime fromDate, DateTime toDate, bool isMounthly = false)
        {
            if (toDate < fromDate)
            {
                Console.WriteLine("Invalid date range selected!");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('-', 70));
                Console.WriteLine("WARNING! Overtime bonuses report available only in Month report!");
                Console.WriteLine(new string('-', 70));
                Console.ResetColor();

                var employeeReport = DailyReports.Where(employee => employee.ID == Passport && employee.Date >= fromDate && employee.Date <= toDate)
                                                    .Select(employee => new { Date = employee.Date, WorkedHours = employee.WorkHours });
                short periodWorkHours = Convert.ToInt16(employeeReport.Sum(period => period.WorkedHours)); ;
                decimal periodSalary = 0;
                decimal todaysSalary = 0;
                if (isMounthly && periodWorkHours > MonthlyWorkHours)
                {
                    foreach (var report in employeeReport)
                    {
                        if (8 >= report.WorkedHours)
                        {
                            todaysSalary = report.WorkedHours * WorkerSalaryPerHour;
                        }
                        else
                        {
                            todaysSalary = (8 * WorkerSalaryPerHour) + ((report.WorkedHours - 8) * WorkerSalaryPerHour * 2); // x2 bonus for overtime hours
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
        public void GetReportForDay(DateTime day)
        {
            GetReportForPeriod(day, day, false);
        }
        public void GetReportForWeek(DateTime FromDate)
        {
            GetReportForPeriod(FromDate, FromDate.AddDays(7), false);
        }
        public void GetReportForMonth(int month)
        {
            if (month < DateTime.Now.Month)
            {
                Console.WriteLine("Ypu try to get report about future month;");
                return;
            }
            string date = $"01,{month},{DateTime.Now.Year}";
            int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);
            DateTime.TryParse(date, out DateTime day);
            GetReportForPeriod(day, day.AddDays(daysInCurrentMonth), true);
        }

    }
}
