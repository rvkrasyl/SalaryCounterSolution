using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCounter.Domain
{
    public static class Parameters
    {
        /// <summary>
        /// Work Hours in every Month
        /// </summary>
        public const byte MonthlyWorkHours = 160;
        /// <summary>
        /// Managers Salary for every working hour in uah
        /// </summary>
        public const int ManagerSalaryPerHour = 1250;
        public const int ManagerOvertimeBonus = 20000;
        /// <summary>
        /// Managers Salary for every working hour in uah
        /// </summary>
        public const int WorkerSalaryPerHour = 750;
        public const byte NormalDayWorkTime = 8;
        public const int FreelancerSalaryPerHour = 1000;

        public const string EmployeeListFilePath = @"C:\Users\iamdn\source\repos\Solutions Heep\SalaryCounterSolution\SalaryCounter\Data\EmployeesList.csv";
        public const string FreelancersReportsFilePath = @"C:\Users\iamdn\source\repos\Solutions Heep\SalaryCounterSolution\SalaryCounter\Data\FreelancersReports.csv";
        public const string ManagersReportsFilePath = @"C:\Users\iamdn\source\repos\Solutions Heep\SalaryCounterSolution\SalaryCounter\Data\ManagersReports.csv";
        public const string WorkersReportsFilePath = @"C:\Users\iamdn\source\repos\Solutions Heep\SalaryCounterSolution\SalaryCounter\Data\WorkersReports.csv";
    }
    public enum Roles
    {
        manager,
        worker,
        freelancer,
    }
}
