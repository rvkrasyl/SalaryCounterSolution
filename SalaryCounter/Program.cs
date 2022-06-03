using SalaryCounter.Domain;
using SalaryCounter.Domain.FileIOServices;

Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("\tWelcome to SoftDevelopment_SalaryCounter.");
Console.ResetColor();

bool condition = false;
string id = default; // MU56711203 is Freelancer; OP56987568 is Worker;  MO50896213 is Manager;

while (!condition)
{
    Console.Write("Please enter your Passport ID: ");
    id = Console.ReadLine();

    if (id == null || id == string.Empty || id.Length != 10)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\tInvalid ID. Please try again.");
        Console.ResetColor();
    }
    else
    {
        Console.Clear();
        condition = true;
    }
}

if (!Employees.Exists(id))
    Environment.Exit(0);
var currentEmployee = (Employees.List.First(employee => employee.Passport == id));
Employee someCurrentEmployee = new Employee(currentEmployee.Passport, currentEmployee.Name, (int)currentEmployee.Role, currentEmployee.SalaryPerHour);

Console.WriteLine($"Your current role is {currentEmployee.Role}");
Console.WriteLine("Please select next option: ");

if (currentEmployee.Role == Roles.manager)
{
    /* Может добавлять отработанные часы в список сотрудников. Добавлять время может только за себя. Возможно добавление времени задним числом.
Может просматривать свои отработанные часы и зарплату за период
Выберите желаемое действие:
(1). Добавить сотрудника
(2). Просмотреть отчет по всем сотрудникам
(3). Просмотреть отчет по конкретному сотруднику
(4). Добавить часы работы
(5). Выход из программы
*/

}
else if (currentEmployee.Role == Roles.worker)
{
    condition = false;
    currentEmployee = new Worker(currentEmployee.Passport, currentEmployee.Name);

    while (!condition)
    {
        bool periodCondition = false;
        Console.WriteLine("Press \"1\" to see your work hours and salary for period;\nPress \"2\" to add new work hours report;\nPress \"Esc\" to Exit");
        var key = Console.ReadKey().Key;

        if (key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
        {
            condition = true;
            Console.Clear();
            while (!periodCondition)
            {
                Console.WriteLine("Select a period for report:\nPress \"1\" to see report for concrete DAY;\nPress \"2\" to see report for concrete WEEK;\nPress \"3\" to see report for concrete MONTH;" +
                    "\nPress \"4\" to see report for CUSTOM PERIOD;\nPress \"5\" for go back to PREVIOUS MENU;\nPress \"Esc\" to Exit ");
                var periodKey = Console.ReadKey().Key;
                switch (periodKey)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        {
                            Console.Write("Please enter a date to see report (Example 01.01.2022): ");
                            currentEmployee.GetReportForDay(DateTime.Parse(Console.ReadLine()).Date);

                            Console.WriteLine("Press \"Enter\" to see another report or add new report\nPress any other key to Exit");
                            var otherOperation = Console.ReadKey().Key;

                            if (otherOperation == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                periodCondition = true;
                                condition = false;
                            }
                            else
                                Environment.Exit(0);

                            break;
                        }
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        {
                            Console.Write("Please enter a date from which you want to see Weekly report (Example 01.01.2022): ");
                            currentEmployee.GetReportForWeek(DateTime.Parse(Console.ReadLine()));

                            Console.WriteLine("Press \"Enter\" to see another report or add new report\nPress any other key to Exit");
                            var otherOperation = Console.ReadKey().Key;

                            if (otherOperation == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                periodCondition = true;
                                condition = false;
                            }
                            else
                                Environment.Exit(0);

                            break;
                        }
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        {
                            Console.Write("Please enter nu,ber of Month to see report (Example: \"01\" for January, \"11\" for November): ");
                            currentEmployee.GetReportForMonth(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Press \"Enter\" to see another report or add new report\nPress any other key to Exit");
                            var otherOperation = Console.ReadKey().Key;

                            if (otherOperation == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                periodCondition = true;
                                condition = false;
                            }
                            else
                                Environment.Exit(0);

                            break;
                        }
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        {
                            Console.Write("Please enter a FROM date for report (Example 01.01.2022): ");
                            DateTime fromDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Please enter a FROM date for report (Example 30.01.2022): ");
                            DateTime toDate = DateTime.Parse(Console.ReadLine());
                            currentEmployee.GetReportForPeriod(fromDate, toDate);

                            Console.WriteLine("Press \"Enter\" to see another report or add new report\nPress any other key to Exit");
                            var otherOperation = Console.ReadKey().Key;

                            if (otherOperation == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                periodCondition = true;
                                condition = false;
                            }
                            else
                                Environment.Exit(0);

                            break;
                        }
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        {
                            Console.Clear();
                            periodCondition = true;
                            condition = false;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
        {
            condition = true;
            Console.Clear();
            Console.Write("Please enter date for report (Example 01.01.2022): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write($"Enter how much time did you spend on work {date:d}: ");
            byte workHours = Convert.ToByte(Console.ReadLine());
            if (workHours < +11)
            {
                Console.WriteLine($"Please enter what kind of tasks did you resolve at {date:d}?");
                string comment = Console.ReadLine();
                currentEmployee.AddNewReport(date, workHours, comment);

                Console.WriteLine("Press \"Enter\" to add another report or see your work hours and salary for period\nPress any other key to Exit");
                var otherOperation = Console.ReadKey().Key;

                if (otherOperation == ConsoleKey.Enter)
                {
                    periodCondition = true;
                    condition = false;
                }
                else
                    Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Thats a lot! Please ask your Manager to help you with such a big report.");
                condition = false;
            }
        }
        else if (key == ConsoleKey.Escape)
        {
            condition = true;
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Invalid command");
        }
    }
}
else if (currentEmployee.Role == Roles.freelancer)
{

    condition = false;
    currentEmployee = new Freelancer(currentEmployee.Passport, currentEmployee.Name);

    while (!condition)
    {
        bool periodCondition = false;
        Console.WriteLine("Press \"1\" to see your work hours and salary for period;\nPress \"2\" to add new work hours report;\nPress \"Esc\" to Exit");
        var key = Console.ReadKey().Key;

        if (key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
        {
            condition = true;
            Console.Clear();
            while (!periodCondition)
            {
                Console.WriteLine("Select a period for report:\nPress \"1\" to see report for concrete DAY;\nPress \"2\" to see report for concrete WEEK;\nPress \"3\" to see report for concrete MONTH;" +
                    "\nPress \"4\" to see report for CUSTOM PERIOD;\nPress \"5\" for go back to PREVIOUS MENU;\nPress \"Esc\" to Exit ");
                var periodKey = Console.ReadKey().Key;
                switch (periodKey)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        {
                            Console.Write("Please enter a date to see report (Example 01.01.2022): ");
                            currentEmployee.GetReportForDay(DateTime.Parse(Console.ReadLine()).Date);

                            Console.WriteLine("Press \"Enter\" to see another report or add new report\nPress any other key to Exit");
                            var otherOperation = Console.ReadKey().Key;

                            if (otherOperation == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                periodCondition = true;
                                condition = false;
                            }
                            else
                                Environment.Exit(0);

                            break;
                        }
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        {
                            Console.Write("Please enter a date from which you want to see Weekly report (Example 01.01.2022): ");
                            currentEmployee.GetReportForWeek(DateTime.Parse(Console.ReadLine()));

                            Console.WriteLine("Press \"Enter\" to see another report or add new report\nPress any other key to Exit");
                            var otherOperation = Console.ReadKey().Key;

                            if (otherOperation == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                periodCondition = true;
                                condition = false;
                            }
                            else
                                Environment.Exit(0);

                            break;
                        }
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        {
                            Console.Write("Please enter nu,ber of Month to see report (Example: \"01\" for January, \"11\" for November): ");
                            currentEmployee.GetReportForMonth(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Press \"Enter\" to see another report or add new report\nPress any other key to Exit");
                            var otherOperation = Console.ReadKey().Key;

                            if (otherOperation == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                periodCondition = true;
                                condition = false;
                            }
                            else
                                Environment.Exit(0);

                            break;
                        }
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        {
                            Console.Write("Please enter a FROM date for report (Example 01.01.2022): ");
                            DateTime fromDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Please enter a FROM date for report (Example 30.01.2022): ");
                            DateTime toDate = DateTime.Parse(Console.ReadLine());
                            currentEmployee.GetReportForPeriod(fromDate, toDate);

                            Console.WriteLine("Press \"Enter\" to see another report or add new report\nPress any other key to Exit");
                            var otherOperation = Console.ReadKey().Key;

                            if (otherOperation == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                periodCondition = true;
                                condition = false;
                            }
                            else
                                Environment.Exit(0);

                            break;
                        }
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        {
                            Console.Clear();
                            periodCondition = true;
                            condition = false;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
        {
            condition = true;
            Console.Clear();
            Console.Write("Please enter date for report (Example 01.01.2022): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write($"Enter how much time did you spend on work {date:d}: ");
            byte workHours = Convert.ToByte(Console.ReadLine());
            if (workHours <+ 11)
            {
                Console.WriteLine($"Please enter what kind of tasks did you resolve at {date:d}?");
                string comment = Console.ReadLine();
                currentEmployee.AddNewReport(date, workHours, comment);

                Console.WriteLine("Press \"Enter\" to add another report or see your work hours and salary for period\nPress any other key to Exit");
                var otherOperation = Console.ReadKey().Key;

                if (otherOperation == ConsoleKey.Enter)
                {
                    Console.Clear();
                    periodCondition = true;
                    condition = false;
                }
                else
                    Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Thats a lot! Please ask your Manager to help you with such a big report.");
                condition = false;
            }
        }
        else if (key == ConsoleKey.Escape)
        {
            condition = true;
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Invalid command");
        }
    }
}
else
{
    Console.WriteLine("New employee Role was added. Please contact to @Vasyl Krachuk for help.\nConsole will close in 5 sec.");
    Thread.Sleep(5000);
    Environment.Exit(0);
}

//Employees emloyeesList= new Employees();
/*List<DailyReport> managersDailyReports = new List<DailyReport>();
List<DailyReport> freelancersDailyReports = new List<DailyReport>();
List<DailyReport> workersDailyReports = new List<DailyReport>();
*/
//Manager grigory = new Manager("MO50896213", "Grigory Dushniy"/*, managersDailyReports*/);
//Freelancer dimka = new Freelancer("TB32599985", "Dmitro Chiller"/*, freelancersDailyReports*/);
//Worker pilip = new Worker("OP56987568", "Pulup Truten"/*, workersDailyReports*/);
//Environment.Exit(0);
//Worker igor = new Worker("GG56988452", "Igor Dobryak"/*, workersDailyReports*/);
//Employees.AddNewEmployee(grigory);
//Employees.AddNewEmployee(dimka);
//Employees.AddNewEmployee(igor);
//Employees.AddNewEmployee(pilip);
//Employees.ShowAll();
//grigory.AddEmployee();
//grigory.AddReportByID();
//grigory.AddReportByID();

//grigory.AddNewReport(DateTime.Now.AddDays(-11), 9, "Coment 1");
//dimka.AddNewReport(DateTime.Now.AddDays(-12), 8, "Комент 1");
//pilip.AddNewReport(DateTime.Now.AddDays(-10), 7, "Coment pilip");
//grigory.AddNewReport(DateTime.Now.AddDays(-9), 10, "Coment plus");
//pilip.AddNewReport(DateTime.Now.AddDays(-8), 8, "Шось там роблю");
//dimka.AddNewReport(DateTime.Now.AddDays(-9), 4, "Комент Дiмка");
//grigory.AddNewReport(DateTime.Now.AddDays(-7), 8, "Coment comment");
//dimka.AddNewReport(DateTime.Now.AddDays(-5), 3, "Комент Фрилансер");
//pilip.AddNewReport(DateTime.Now.AddDays(-7), 9, "Тружусь");
//grigory.AddNewReport(DateTime.Now.AddDays(-6), 6, "Coment 12");
//pilip.AddNewReport(DateTime.Now.AddDays(-4), 8, "Скоро пятниця");
//grigory.AddNewReport(DateTime.Now.AddDays(-2), 7, "Coment 33");
//grigory.AddNewReport(DateTime.Now.AddDays(-2), 6, "Coment 33");
//pilip.AddNewReport(DateTime.Now, 9, "Понедiлок(");
//pilip.AddNewReport(DateTime.Now, 8, "Понедiлок(");
//dimka.AddNewReport(DateTime.Now.AddDays(-1), 5, "Работаю");
//dimka.AddNewReport(DateTime.Now.AddHours(-1), 2, "Работаю 2");
//igor.AddNewReport(DateTime.Now.AddDays(-11), 9, "Coment 1");
//igor.AddNewReport(DateTime.Now.AddDays(-10), 7, "Coment 2");
//igor.AddNewReport(DateTime.Now.AddDays(-9), 8, "Coment 3");
//igor.AddNewReport(DateTime.Now.AddDays(-8), 8, "Coment 4");
//igor.AddNewReport(DateTime.Now.AddDays(-6), 8, "Coment 5");
//dimka.AddNewReport(DateTime.Now.AddDays(-1).AddHours(-2), 6, "Работаю");


//grigory.ShowEmployeesPerformance();

//igor.GetReportForWeek(DateTime.Now.AddDays(-14));
//grigory.GetGeteralReportForWeek((Roles)1, DateTime.Now.AddDays(-14));


//int i = 1;
//foreach (var item in managersDailyReports)
//{
//    Console.WriteLine(i + ") " + item.ToString());
//    i++;
//}
//foreach (var item in freelancersDailyReports)
//{
//    Console.WriteLine(i + ") " + item.ToString());
//    i++;
//}
//foreach (var item in workersDailyReports)
//{
//    Console.WriteLine(i + ") " + item.ToString());
//    i++;
//}
//Employees.Exists("GG56988452");
//Employees.Exists("asd");
//Thread.Sleep(100);
//Employees.ShowAll();

//Console.Clear();

//dimka.GetReportForDay(DateTime.Today);
//grigory.GetGeteralReportForWeek(Roles.freelancer,DateTime.Today.AddDays(-7));


