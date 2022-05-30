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
        public FullTimeEmployee(string passportId, string name, List<DailyReport> dailyReports, decimal salaryPerHour, decimal mouthSalary) : base(passportId, name, dailyReports, salaryPerHour)
        {
            MouthSalary = mouthSalary;
        }
    }
}
