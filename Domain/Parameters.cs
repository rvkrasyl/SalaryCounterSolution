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
    }
    public enum Roles
    {
        manager,
        worker,
        freelancer,
    }
}
