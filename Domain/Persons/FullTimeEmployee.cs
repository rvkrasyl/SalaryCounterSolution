using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCounter.Domain
{
    public class FullTimeEmployee: Employee
    {
        decimal MouthSalary { get; }
        public FullTimeEmployee(string passportId, string name, Roles role, List<DailyReport> dailyReports, decimal salaryPerHour, decimal mouthSalary) : base(passportId, name, role, dailyReports, salaryPerHour)
        {
            MouthSalary = mouthSalary;
        }
    }
}
