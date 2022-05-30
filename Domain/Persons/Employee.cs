using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCounter.Domain
{
    public class Employee
    {
        public string Passport { get; }
        public string Name { get; }
        public decimal SalaryPerHour { get; }
        public List<DailyReport> DailyReports { get; }
        public Employee (string passportId, string name, List<DailyReport> dailyReports, decimal salaryPerHour)
        {
            Passport = passportId;
            Name = name;
            SalaryPerHour = salaryPerHour;
            DailyReports = dailyReports;
        }
    }
}
