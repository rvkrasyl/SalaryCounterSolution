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
        public const int ManagerSalaryPerHour = 1000;
        /// <summary>
        /// Managers Salary for every working hour in uah
        /// </summary>
        public const int WorkerSalaryPerHour = 600;

    }
    public enum Roles
    {
        manager,
        worker,
        freelancer,
    }
}
