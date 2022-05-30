﻿namespace SalaryCounter.Domain
{
    public class Manager : FullTimeEmployee
    {
        public Manager(string passportId, string name, List<DailyReport> dailyReports) : base(passportId, name, dailyReports, Parameters.ManagerSalaryPerHour, Parameters.ManagerSalaryPerHour * Parameters.MonthlyWorkHours)
        {

        }
    }
}