﻿using SalaryCounter.Domain.FileIOServices;
using static SalaryCounter.Domain.Parameters;

namespace SalaryCounter.Domain
{
    public class Freelancer : Employee
    {
        public Freelancer(string passportId, string name) : base(passportId, name, 2, FreelancerSalaryPerHour) {  }
        public override void GetReportForPeriod(DateTime fromDate, DateTime toDate, bool isMounthly = false)
        {
            if (toDate < fromDate)
            {
                Console.WriteLine("Invalid date range selected!");
                return;
            }
            FileIO fileIO = new FileIO();
            var employeeReport = fileIO.GetReportsData((int)Role).Where(employee => employee.ID == Passport && employee.Date.Ticks >= fromDate.Ticks && employee.Date.Ticks <= toDate.Ticks)
                                                    .Select(employee => new { Date = employee.Date, WorkedHours = employee.WorkHours })
                                                    .OrderBy(employee => employee.Date);

            short periodWorkHours = Convert.ToInt16(employeeReport.Sum(period => period.WorkedHours));
            decimal periodSalary = 0;
            decimal todaysSalary = 0;

            foreach (var report in employeeReport)
            {
                todaysSalary = report.WorkedHours * FreelancerSalaryPerHour;
                periodSalary += todaysSalary;
                Console.WriteLine($"{report.Date:d} you worked for {report.WorkedHours} hours and earned {todaysSalary} uah");
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"In common from {fromDate:d} to {toDate:d}: {periodWorkHours} hours worked for {periodSalary} uah");
            if (isMounthly)
                Console.WriteLine($"Overtime hours this month: 0. Overtime bonus this month: 0 uah.");
            Console.WriteLine(new string('-', 70));
        }
        public override void AddNewReport(DateTime date, byte workHours, string comment, bool isManager = false)
        {
            if (date < DateTime.Now.AddDays(-2) && !isManager)
            {
                Console.WriteLine("Ou it was long time ago. I cant insert this report in database." +
                    "\nPlease contact to your manager for help");
                return;
            }
            base.AddNewReport(date, workHours, comment);
        }
    }
}
