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
            if (!isMounthly)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('-', 70));
                Console.WriteLine("WARNING! Overtime bonuses report available only in Month report!");
                Console.WriteLine(new string('-', 70));
                Console.ResetColor();
            }

            var employeeReport = DailyReports.Where(employee => employee.ID == Passport && employee.Date.Day >= fromDate.Day && employee.Date.Day <= toDate.Day)
                                                .Select(employee => new { Date = employee.Date, WorkedHours = employee.WorkHours })
                                                .OrderBy(employee => employee.Date);

            short periodWorkHours = Convert.ToInt16(employeeReport.Sum(period => period.WorkedHours));
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
        public void GetGeneralReportForPeriod(Roles role, DateTime fromDate, DateTime toDate, bool isMounthly = false)
        {
            switch ((int)role)
            {
                case 0:
                    {
                        if (toDate < fromDate)
                        {
                            Console.WriteLine("Invalid date range selected!");
                            return;
                        }
                        if (!isMounthly)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(new string('-', 70));
                            Console.WriteLine("WARNING! Overtime bonuses report available only in Month report!");
                            Console.WriteLine(new string('-', 70));
                            Console.ResetColor();
                        }

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
                        break;
                    }
                
                case 1:
                    {
                        if (toDate < fromDate)
                        {
                            Console.WriteLine("Invalid date range selected!");
                            return;
                        }
                        if (!isMounthly)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(new string('-', 70));
                            Console.WriteLine("WARNING! Overtime bonuses report available only in Month report!");
                            Console.WriteLine(new string('-', 70));
                            Console.ResetColor();
                        }

                        Worker worker = Employees.List.FirstOrDefault(employee => employee.Role == role) as Worker;
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
                            Console.WriteLine($"In common from {fromDate:d} to {toDate:d} {role}s worked for {totalWorkedHours} hours, including {totalOvertimeHours} overtime hours.\nTotal spend for salary = {totalSpendPerSalary} uah");
                        else
                            Console.WriteLine($"In common from {fromDate:d} to {toDate:d} {role}s worked for {totalWorkedHours} hours.\nTotal spend for salary = {totalSpendPerSalary} uah");
                        Console.ResetColor();
                        Console.WriteLine(new string('-', 70));
                        break;
                    }

                case 2:
                    {
                        if (toDate < fromDate)
                        {
                            Console.WriteLine("Invalid date range selected!");
                            return;
                        }
                        if (!isMounthly)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(new string('-', 70));
                            Console.WriteLine("WARNING! Overtime bonuses report available only in Month report!");
                            Console.WriteLine(new string('-', 70));
                            Console.ResetColor();
                        }

                        Freelancer freelancer = Employees.List.FirstOrDefault(employee => employee.Role == role) as Freelancer;
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
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException("New Role was added");
                        break;
                    }
            }

        }
        public void GetGeneralReportForDay(Roles role, DateTime day)
        {
            GetGeneralReportForPeriod(role, day, day, false);
        }
        public void GetGeteralReportForWeek(Roles role, DateTime fromDate)
        {
            GetGeneralReportForPeriod(role, fromDate, fromDate.AddDays(7), false);
        }
        public void GetGeneralReportForMonth(Roles role, int month)
        {
            if (month < DateTime.Now.Month)
            {
                Console.WriteLine("You try to get report about future month;");
                return;
            }

            string date = $"01,{month},{DateTime.Now.Year}";
            int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);
            DateTime.TryParse(date, out DateTime day);
            GetGeneralReportForPeriod(role, day, day.AddDays(daysInCurrentMonth - 1), true);
        }
        public void AddEmployee ()
        {
            Console.Write("Please enter a name of new employee: ");
            string name = Console.ReadLine();

            Console.Write($"Please enter {name} passport ID: ");
            string passport = Console.ReadLine();
            
            int role = 10;
            Console.Write($"Please enter \"0\" on keyboard if {name} is Manager, \"1\" if he or \"2\" if he is Freelancer: ");
            
            while (role == 10)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D0:
                        role = 0;
                        break;
                    case ConsoleKey.D1:
                        role = 1;
                        break;
                    case ConsoleKey.D2:
                        role = 2;
                        break;
                    case ConsoleKey.Escape:
                        role = 6;
                        break;
                    default:
                        role = 10;
                        break;
                }
            }
            
            Console.Write($"\nWhat is {name} salary per hour? ");
            decimal salaryPerHour = Convert.ToDecimal(Console.ReadLine());

            Employees.AddNew(new Employee(passport, name, (Roles)role, new List<DailyReport>(), salaryPerHour));
        }
        public void ShowAllEmployee()
        {
            Employees.ShowAll();
        }
        public void AddReportByID()
        {
            Console.Write("Enter ID of employee to add hours: ");
            string employeeID = Console.ReadLine();
            if (!Employees.List.Select(item => item.Passport).Contains(employeeID))
            {
                Console.WriteLine($"We dont have employee with id {employeeID}");
                return;
            }

            Console.Write("Enter a date to add hours (DD.MM.YYYY) D-day, M-Month, Y-Year: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);
            if (date > DateTime.Now)
            {
                Console.WriteLine("No cheating! You cant create report for dates in future!");
                return;
            }

            Console.Write("Enter number of hours, that employee spend on work: ");
            byte workHours = Convert.ToByte(Console.ReadLine());

            bool needToRemove = false;
            if (DailyReports.Select(report => report.Date.Day).Contains(date.Day))
            {
                Console.Write($"You have alredy sended report for {date:d}. \nPress \"Y\" if you want to Rewrite it or \"N\" to cancel changes ");
                
                bool a = true;
                while (a)
                {
                    var key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.Y:
                            needToRemove = true;
                            a = false;
                            break;
                        case ConsoleKey.N:
                            return;
                        default:
                            Console.WriteLine("Please make your choise;");
                            break;
                    }
                }
            }

            Console.Write("\nAdd comment to report: ");
            string comment = Console.ReadLine();

            Employee check = Employees.List.FirstOrDefault(employee => employee.Passport == employeeID);
            if (check.Role == (Roles)0)
            {
                Manager employee = new Manager(check.Passport, check.Name, check.DailyReports);
                if (needToRemove)
                {
                    var report = employee.DailyReports.Where(a => a.Date.Day == date.Day).ToList();
                    employee.DeleteReport(report[0]);
                }
                employee.AddNewReport(date, workHours, comment, true);
            }

            else if (check.Role == (Roles)1)
            {
                Worker employee = new Worker(check.Passport, check.Name, check.DailyReports);
                if (needToRemove)
                {
                    var report = employee.DailyReports.Where(a => a.Date.Day == date.Day).ToList();
                    employee.DeleteReport(report[0]);
                }
                employee.AddNewReport(date, workHours, comment, true);
            }

            else if (check.Role == (Roles)2)
            {
                Freelancer employee = new Freelancer(check.Passport, check.Name, check.DailyReports);
                if (needToRemove)
                {
                    var report = employee.DailyReports.Where(a => a.Date.Day == date.Day).ToList();
                    employee.DeleteReport(report[0]);
                }
                employee.AddNewReport(date, workHours, comment, true);
            }
        }
        public void ShowEmployeesPerformance()
        {
            Console.Write("Enter ID of employee to show performance: ");
            string employeeID = Console.ReadLine();
            if (!Employees.List.Select(item => item.Passport).Contains(employeeID))
            {
                Console.WriteLine($"We dont have employee with id {employeeID}");
                return;
            }

            Console.Write("Enter a date from which you want to see performance (DD.MM.YYYY) D-day, M-Month, Y-Year: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime fromDate);
            if (fromDate > DateTime.Now)
            {
                Console.WriteLine("No cheating! You cant create report for dates in future!");
                return;
            }

            Console.Write("Enter date till which you want to see performance (DD.MM.YYYY) D-day, M-Month, Y-Year: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime toDate);
            if (toDate < fromDate)
            {
                Console.WriteLine("Invalid date range selected!");
                return;
            }

            int totalWorkHours = 0;
            string employeeName = default;
            var data = Employees.List.First(item => item.Passport == employeeID).DailyReports.Where(data => data.ID == employeeID && data.Date.Day >= fromDate.Day && data.Date.Day <= toDate.Day).ToList();
            foreach (var conditionItem in data)
            {
                Console.WriteLine($"{conditionItem.Date} {conditionItem.Name} worked for {conditionItem.WorkHours} his comment - {conditionItem.Comment}");
                totalWorkHours += conditionItem.WorkHours;
                employeeName = conditionItem.Name;
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"Total work time of {employeeName} for period ({fromDate:d} - {toDate:d}) = {totalWorkHours}");
            Console.WriteLine(new string('-', 70));

        }
    }
}