using static SalaryCounter.Domain.Parameters;


namespace SalaryCounter.Domain
{
    public class Manager : FullTimeEmployee
    {
        public Manager(string passportId, string name, List<DailyReport> dailyReports) : base(passportId, name, Roles.manager, dailyReports, Parameters.ManagerSalaryPerHour, Parameters.ManagerSalaryPerHour * Parameters.MonthlyWorkHours)
        {

        }

        public override void GetReportForPeriod(DateTime fromDate, DateTime toDate, bool isMounthly = false)
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
                foreach (var report in employeeReport)
                {
                    todaysSalary = NormalDayWorkTime * ManagerSalaryPerHour; 
                    periodSalary += todaysSalary;
                    Console.WriteLine($"{report.Date:d} you worked for {report.WorkedHours} hours and earned {todaysSalary} uah");
                }
                if (isMounthly && periodWorkHours > MonthlyWorkHours)
                    {
                        periodSalary += ManaferOvertimeBonus;
                    }
                Console.WriteLine(new string('-', 70));
                Console.WriteLine($"In common from {fromDate:d} to {toDate:d}: {periodWorkHours} hours worked for {periodSalary} uah");
                if (isMounthly)
                    Console.WriteLine($"Overtime hours this month: {periodWorkHours - MonthlyWorkHours}. Overtime bonus this month: {ManaferOvertimeBonus} uah.\nGreat job!");
                Console.WriteLine(new string('-', 70));
            }
        }
    }
}