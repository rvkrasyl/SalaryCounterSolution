using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SalaryCounter.Domain
{
    public class Employee
    {
        public string Passport { get; }
        public string Name { get; }
        public Roles Role { get; }
        public decimal SalaryPerHour { get; }
        public List<DailyReport> DailyReports { get; }
        public Employee (string passportId, string name, Roles role, List<DailyReport> dailyReports, decimal salaryPerHour)
        {
            Passport = passportId;
            Name = name;
            Role = role;
            SalaryPerHour = salaryPerHour;
            DailyReports = dailyReports;
        }
        public virtual void AddNewReport(DateTime date, byte workHours, string comment)
        {
            if (date > DateTime.Now)
            {
                Console.WriteLine("No cheating! You cant create report for dates in future!");
                return;
            }
            if (DailyReports.Select(report => report.Date).Contains(date) == true)
            {
                Console.WriteLine($"You have alredy sended report for {date:d}");
                return;
            }
            if (11 < workHours)
            {
                Console.WriteLine("Ou! Its huge! We appreciate your layalty. But rest is important too!" +
                    "\nIf you worked for more than 11 hours per day - please contact to your manager for approval");
                return;
            }
            DailyReport report = new DailyReport(date, Passport, Name, workHours, comment);
            DailyReports.Add(report);
            Console.WriteLine("Succesfully added!");
            Thread.Sleep(200);
        }
    }
}
