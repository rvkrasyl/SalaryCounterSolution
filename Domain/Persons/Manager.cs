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
                if (!isMounthly)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(new string('-', 70));
                    Console.WriteLine("WARNING! Overtime bonuses report available only in Month report!");
                    Console.WriteLine(new string('-', 70));
                    Console.ResetColor();
                }

                var employeeReport = DailyReports.Where(employee => employee.ID == Passport && employee.Date.Day >= fromDate.Day && employee.Date.Day <= toDate.Day)
                                                    .Select(employee => new { Date = employee.Date, WorkedHours = employee.WorkHours }).OrderBy(employee => employee.Date);
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
                        periodSalary += ManagerOvertimeBonus;
                    }
                Console.WriteLine(new string('-', 70));
                Console.WriteLine($"In common from {fromDate:d} to {toDate:d}: {periodWorkHours} hours worked for {periodSalary} uah");
                if (isMounthly)
                    Console.WriteLine($"Overtime hours this month: {periodWorkHours - MonthlyWorkHours}. Overtime bonus this month: {ManagerOvertimeBonus} uah.\nGreat job!");
                Console.WriteLine(new string('-', 70));
            }
        }
        public void GetGeneralReportForPeriod(Roles role, List<DailyReport> reports, DateTime fromDate, DateTime toDate, bool isMounthly = false)
        {
            switch ((int)role)
            {
                case 0:
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

                        var employeeReport = DailyReports.Where(employee => employee.Role == role && employee.Date.Day >= fromDate.Day && employee.Date.Day <= toDate.Day)
                                                            .Select(employee => new { Name = employee.Name, Date = employee.Date, WorkedHours = employee.WorkHours })
                                                            .OrderBy(employee => employee.Date)
                                                            .GroupBy(employee => employee.Name);

                        decimal totalSpendPerSalary = 0;
                        int totalWorkedHours = 0;
                        int totalOvertimeHours = 0;

                        foreach (var employee in employeeReport)
                        {
                            short periodWorkHours = Convert.ToInt16(employee.Sum(period => period.WorkedHours));
                            decimal periodSalary = 0;
                            decimal todaysSalary = 0;
                            var name = employee.Select(x => x.Name).ToList();
                            foreach (var report in employee)
                            {
                                todaysSalary = NormalDayWorkTime * ManagerSalaryPerHour;
                                periodSalary += todaysSalary;
                                Console.WriteLine($"{report.Date:d} {name[0]} worked for {report.WorkedHours} hours and earned {todaysSalary} uah");
                            }

                            Console.WriteLine(new string('-', 70));
                            
                            if (isMounthly && periodWorkHours > MonthlyWorkHours)
                            {
                                periodSalary += ManagerOvertimeBonus;
                                int overtime = periodWorkHours - MonthlyWorkHours;
                                Console.WriteLine($"Overtime hours this month: {overtime}. Overtime bonus this month: {ManagerOvertimeBonus} uah.\nGreat job!");
                                totalOvertimeHours += overtime;
                            }
                            else
                            {
                                Console.WriteLine($"In common from {fromDate:d} to {toDate:d} {name[0]}: worked {periodWorkHours} hours and earned {periodSalary} uah");
                            }
                            Console.WriteLine(new string('-', 70));
                            totalSpendPerSalary += periodSalary;
                            totalWorkedHours += periodWorkHours;
                        }
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (isMounthly)
                        {
                            Console.WriteLine($"In common from {fromDate:d} to {toDate:d} {role}s worked for {totalWorkedHours} hours, including {totalOvertimeHours} overtime hours.\nTotal spend for salary = {totalSpendPerSalary} uah");
                        }
                        else
                        {
                            Console.WriteLine($"In common from {fromDate:d} to {toDate:d} {role}s worked for {totalWorkedHours} hours.\nTotal spend for salary = {totalSpendPerSalary} uah");
                        }
                        Console.ResetColor();
                        Console.WriteLine(new string('-', 70));
                    }
                    break;
                case 1:
                    if (toDate < fromDate)
                    {
                        Console.WriteLine("Invalid date range selected!");
                        return;
                    }
                    else
                    {
                        if (!isMounthly)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(new string('-', 70));
                            Console.WriteLine("WARNING! Overtime bonuses report available only in Month report!");
                            Console.WriteLine(new string('-', 70));
                            Console.ResetColor();
                        }

                        Worker worker = new Worker("OO99999999", "My name", reports);
                        var employeeReport = worker.DailyReports.Where(employee => employee.Role == role && employee.Date.Day >= fromDate.Day && employee.Date.Day <= toDate.Day)
                                                            .Select(employee => new { Name = employee.Name, Date = employee.Date, WorkedHours = employee.WorkHours })
                                                            .OrderBy(employee => employee.Date)
                                                            .GroupBy(employee => employee.Name);
                        
                        decimal totalSpendPerSalary = 0;
                        int totalWorkedHours = 0;
                        int totalOvertimeHours = 0;

                        foreach (var employee in employeeReport)
                        {
                            short periodWorkHours = Convert.ToInt16(employee.Sum(period => period.WorkedHours));
                            decimal periodSalary = 0;
                            decimal todaysSalary = 0;
                            var name = employee.Select(x => x.Name).ToList();
                            if (isMounthly && periodWorkHours > MonthlyWorkHours)
                            {
                                foreach (var report in employee)
                                {
                                    if (NormalDayWorkTime >= report.WorkedHours)
                                    {
                                        todaysSalary = report.WorkedHours * WorkerSalaryPerHour;
                                    }
                                    else
                                    {
                                        todaysSalary = (NormalDayWorkTime * WorkerSalaryPerHour) + ((report.WorkedHours - NormalDayWorkTime) * WorkerSalaryPerHour * 2); // x2 bonus for overtime hours
                                    }
                                    periodSalary += todaysSalary;
                                    Console.WriteLine($"{report.Date:d} {name[0]} worked for {report.WorkedHours} hours and earned {todaysSalary} uah");
                                }
                            }
                            else
                            {
                                foreach (var report in employee)
                                {
                                    todaysSalary = report.WorkedHours * WorkerSalaryPerHour;
                                    periodSalary += todaysSalary;
                                    Console.WriteLine($"{report.Date:d} {name[0]} worked for {report.WorkedHours} hours and earned {todaysSalary} uah");
                                }
                            }
                            Console.WriteLine(new string('-', 70));
                            Console.WriteLine($"In common from {fromDate:d} to {toDate:d}: {name[0]} worked for {periodWorkHours} hours and earned {periodSalary} uah");
                            if (isMounthly && periodWorkHours > MonthlyWorkHours)
                            {
                                int overtime = periodWorkHours - MonthlyWorkHours;
                                Console.WriteLine($"Overtime hours this month: {overtime}. Overtime bonus this month: {periodSalary - (MonthlyWorkHours * WorkerSalaryPerHour)} uah.\nGreat job!");
                                totalOvertimeHours += overtime;
                            }
                            Console.WriteLine(new string('-', 70));
                            totalWorkedHours += periodWorkHours;
                            totalSpendPerSalary += periodSalary;
                        }
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (isMounthly)
                        {
                            Console.WriteLine($"In common from {fromDate:d} to {toDate:d} {role}s worked for {totalWorkedHours} hours, including {totalOvertimeHours} overtime hours.\nTotal spend for salary = {totalSpendPerSalary} uah");
                        }
                        else
                        {
                            Console.WriteLine($"In common from {fromDate:d} to {toDate:d} {role}s worked for {totalWorkedHours} hours.\nTotal spend for salary = {totalSpendPerSalary} uah");
                        }
                        Console.ResetColor();
                        Console.WriteLine(new string('-', 70));
                    }
                    break;
                case 2:
                    if (toDate < fromDate)
                    {
                        Console.WriteLine("Invalid date range selected!");
                        return;
                    }
                    else
                    {
                        if (!isMounthly)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(new string('-', 70));
                            Console.WriteLine("WARNING! Overtime bonuses report available only in Month report!");
                            Console.WriteLine(new string('-', 70));
                            Console.ResetColor();
                        }

                        Freelancer freelancer = new Freelancer("TT99999999", "My name", reports);
                        var employeeReport = freelancer.DailyReports.Where(employee => employee.Role == role && employee.Date.Day >= fromDate.Day && employee.Date.Day <= toDate.Day)
                                                            .Select(employee => new { Name = employee.Name, Date = employee.Date, WorkedHours = employee.WorkHours })
                                                            .OrderBy(employee => employee.Date)
                                                            .GroupBy(employee => employee.Name);

                        decimal totalSpendPerSalary = 0;
                        int totalWorkedHours = 0;

                        foreach (var employee in employeeReport)
                        {
                            short periodWorkHours = Convert.ToInt16(employee.Sum(period => period.WorkedHours));
                            decimal periodSalary = 0;
                            decimal todaysSalary = 0;
                            var name = employee.Select(x => x.Name).ToList();
                            foreach (var report in employee)
                            {
                                todaysSalary = report.WorkedHours * FreelancerSalaryPerHour;
                                periodSalary += todaysSalary;
                                Console.WriteLine($"{report.Date:d} you worked for {report.WorkedHours} hours and earned {todaysSalary} uah");
                            }

                            Console.WriteLine(new string('-', 70));
                            Console.WriteLine($"In common from {fromDate:d} to {toDate:d}: {name[0]} worked for {periodWorkHours} hours and earned {periodSalary} uah");
                            Console.WriteLine(new string('-', 70));
                            totalWorkedHours += periodWorkHours;
                            totalSpendPerSalary += periodSalary;
                        }
                        Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"In common from {fromDate:d} to {toDate:d} {role}s worked for {totalWorkedHours} hours.\nTotal spend for salary = {totalSpendPerSalary} uah");
                        Console.ResetColor();
                        Console.WriteLine(new string('-', 70));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("New Role was added");
                    break;
            }

        }
        public void GetGeneralReportForDay(Roles role, DateTime day ,List<DailyReport> reports)
        {
            GetGeneralReportForPeriod(role, reports ,day, day, false);
        }
        public void GetGeteralReportForWeek(Roles role, DateTime fromDate, List<DailyReport> reports)
        {
            GetGeneralReportForPeriod(role, reports , fromDate, fromDate.AddDays(7), false);
        }
        public void GetGeneralReportForMonth(Roles role, int month, List<DailyReport> reports)
        {
            if (month < DateTime.Now.Month)
            {
                Console.WriteLine("You try to get report about future month;");
                return;
            }
            string date = $"01,{month},{DateTime.Now.Year}";
            int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);
            DateTime.TryParse(date, out DateTime day);
            GetGeneralReportForPeriod(role ,reports ,day, day.AddDays(daysInCurrentMonth - 1), true);
        }

    }
}