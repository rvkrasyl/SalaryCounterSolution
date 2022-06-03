using SalaryCounter.Domain;
using SalaryCounter.Program;

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
    condition = false;
    currentEmployee = new Manager(currentEmployee.Passport, currentEmployee.Name);
    Manager manager = currentEmployee as Manager; 

    while (!condition)
    {
        condition = true;
        bool periodCondition = false;
        bool roleCondition = false;
        Console.WriteLine("Press \"1\" to ADD new EMPLOYEE;\nPress \"2\" to SEE REPORTS about ALL EMPLOYEES;\nPress \"3\" to SEE REPORT about CONCRETE EMPLOYEE;\nPress \"4\" to ADD REPORT to OTHER EMPLOYEE;" +
            "\nPress \"5\" to ADD YOURS REPORT;\nPress \"6\" to SEE YOURS REPORT;\nPress \"Esc\" to Exit");
        var key = Console.ReadKey().Key;

        switch (key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                {
                    Console.Clear();
                    manager.AddEmployee();

                    condition = ReportHandler.AnotherReportNeed(condition, ref periodCondition);

                    break;
                }
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                {
                    Console.Clear();

                    while (!periodCondition)
                    {
                        Console.WriteLine("Select a period for report:\nPress \"1\" to see report for concrete DAY;\nPress \"2\" to see report for concrete WEEK;\nPress \"3\" to see report for concrete MONTH;" +
                                             "\nPress \"4\" to see report for CUSTOM PERIOD;\nPress \"5\" for go back to PREVIOUS MENU;\nPress \"Esc\" to Exit ");
                        var periodKey = Console.ReadKey().Key;
                        byte role = 0;

                        switch (periodKey)
                        {
                            case ConsoleKey.NumPad1:
                            case ConsoleKey.D1:
                                {
                                    while(!roleCondition)
                                    {
                                        Console.WriteLine("Press \"1\" to see report about all MANAGERS;\nPress \"2\" see report about all WORKERS;\nPress \"3\" to see report about all FREELANCERS");
                                        var roleKey = Console.ReadKey().Key;

                                        if (roleKey == ConsoleKey.D1 || roleKey == ConsoleKey.NumPad1)
                                            role = 0;
                                        else if (roleKey == ConsoleKey.D2 || roleKey == ConsoleKey.NumPad2)
                                            role = 1;
                                        else if (roleKey == ConsoleKey.D3 || roleKey == ConsoleKey.NumPad3)
                                            role = 2;
                                        else
                                        {
                                            Console.WriteLine("Error, new role was added, please contact with Developer. Program will close in 5 sec");
                                            Thread.Sleep(5000);
                                            Environment.Exit(0);
                                        }

                                        Console.Write("Please enter a date to see report (Example 01.01.2022): ");
                                        manager.GetGeneralReportForDay((Roles)role, DateTime.Parse(Console.ReadLine()).Date);

                                        condition = ReportHandler.AnotherReportNeed(condition, ref roleCondition);
                                    }
                                    break;
                                }
                            case ConsoleKey.NumPad2:
                            case ConsoleKey.D2:
                                {
                                    while (!roleCondition)
                                    {
                                        Console.WriteLine("Press \"1\" to see report about all MANAGERS;\nPress \"2\" see report about all WORKERS;\nPress \"3\" to see report about all FREELANCERS");
                                        var roleKey = Console.ReadKey().Key;
                                        if (roleKey == ConsoleKey.D1 || roleKey == ConsoleKey.NumPad1)
                                            role = 0;
                                        else if (roleKey == ConsoleKey.D2 || roleKey == ConsoleKey.NumPad2)
                                            role = 1;
                                        else if (roleKey == ConsoleKey.D3 || roleKey == ConsoleKey.NumPad3)
                                            role = 2;
                                        else
                                        {
                                            Console.WriteLine("Error, new role was added, please contact with Developer. Program will close in 5 sec");
                                            Thread.Sleep(5000);
                                            Environment.Exit(0);
                                        }

                                        Console.Write("Please enter a date from which you want to see Weekly report (Example 01.01.2022): ");
                                        manager.GetGeteralReportForWeek((Roles)role, DateTime.Parse(Console.ReadLine()).Date);

                                        condition = ReportHandler.AnotherReportNeed(condition, ref roleCondition);
                                    }
                                    break;
                                }
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                {
                                    while (!roleCondition)
                                    {
                                        Console.WriteLine("Press \"1\" to see report about all MANAGERS;\nPress \"2\" see report about all WORKERS;\nPress \"3\" to see report about all FREELANCERS");
                                        var roleKey = Console.ReadKey().Key;
                                        if (roleKey == ConsoleKey.D1 || roleKey == ConsoleKey.NumPad1)
                                            role = 0;
                                        else if (roleKey == ConsoleKey.D2 || roleKey == ConsoleKey.NumPad2)
                                            role = 1;
                                        else if (roleKey == ConsoleKey.D3 || roleKey == ConsoleKey.NumPad3)
                                            role = 2;
                                        else
                                        {
                                            Console.WriteLine("Error, new role was added, please contact with Developer. Program will close in 5 sec");
                                            Thread.Sleep(5000);
                                            Environment.Exit(0);
                                        }

                                        Console.Write("Please enter number of Month to see report (Example: \"01\" for January, \"11\" for November): ");
                                        manager.GetGeneralReportForMonth((Roles)role, Convert.ToInt32(Console.ReadLine()));

                                        condition = ReportHandler.AnotherReportNeed(condition, ref roleCondition);
                                    }
                                    break;
                                }
                            case ConsoleKey.NumPad4:
                            case ConsoleKey.D4:
                                {
                                    while (!roleCondition)
                                    {
                                        Console.WriteLine("Press \"1\" to see report about all MANAGERS;\nPress \"2\" see report about all WORKERS;\nPress \"3\" to see report about all FREELANCERS");
                                        var roleKey = Console.ReadKey().Key;
                                        if (roleKey == ConsoleKey.D1 || roleKey == ConsoleKey.NumPad1)
                                            role = 0;
                                        else if (roleKey == ConsoleKey.D2 || roleKey == ConsoleKey.NumPad2)
                                            role = 1;
                                        else if (roleKey == ConsoleKey.D3 || roleKey == ConsoleKey.NumPad3)
                                            role = 2;
                                        else
                                        {
                                            Console.WriteLine("Error, new role was added, please contact with Developer. Program will close in 5 sec");
                                            Thread.Sleep(5000);
                                            Environment.Exit(0);
                                        }

                                        Console.Write("Please enter a FROM date for report (Example 01.01.2022): ");
                                        DateTime fromDate = DateTime.Parse(Console.ReadLine());
                                        Console.Write("Please enter a FROM date for report (Example 30.01.2022): ");
                                        DateTime toDate = DateTime.Parse(Console.ReadLine());
                                        manager.GetGeneralReportForPeriod((Roles)role, fromDate, toDate);

                                        condition = ReportHandler.AnotherReportNeed(condition, ref roleCondition);
                                    }
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
                    break;
                }
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                {
                    Console.Clear();
                    manager.ShowEmployeesPerformance();

                    condition = ReportHandler.AnotherReportNeed(condition, ref periodCondition);

                    break;
                }
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
                {
                    Console.Clear();
                    manager.AddReportByID();

                    condition = ReportHandler.AnotherReportNeed(condition, ref periodCondition);

                    break;
                }
            case ConsoleKey.D5:
            case ConsoleKey.NumPad5:
                {
                    Console.Clear();
                    Console.Write("Please enter date for report (Example 01.01.2022): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    Console.Write($"Enter how much time did you spend on work {date:d}: ");
                    byte workHours = Convert.ToByte(Console.ReadLine());

                    Console.WriteLine($"Please enter what kind of tasks did you resolve at {date:d}?");
                    string comment = Console.ReadLine();

                    manager.AddNewReport(date, workHours, comment);

                    condition = ReportHandler.AnotherReportNeed(condition, ref periodCondition);

                    break;
                }
            case ConsoleKey.D6:
            case ConsoleKey.NumPad6:
                {
                    condition = false;
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
                                    manager.GetReportForDay(DateTime.Parse(Console.ReadLine()).Date);

                                    condition = ReportHandler.AnotherReportNeed(condition, ref periodCondition);

                                    break;
                                }
                            case ConsoleKey.NumPad2:
                            case ConsoleKey.D2:
                                {
                                    Console.Write("Please enter a date from which you want to see Weekly report (Example 01.01.2022): ");
                                    manager.GetReportForWeek(DateTime.Parse(Console.ReadLine()));

                                    condition = ReportHandler.AnotherReportNeed(condition, ref periodCondition);

                                    break;
                                }
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                {
                                    Console.Write("Please enter nu,ber of Month to see report (Example: \"01\" for January, \"11\" for November): ");
                                    manager.GetReportForMonth(Convert.ToInt32(Console.ReadLine()));

                                    condition = ReportHandler.AnotherReportNeed(condition, ref periodCondition);

                                    break;
                                }
                            case ConsoleKey.NumPad4:
                            case ConsoleKey.D4:
                                {
                                    Console.Write("Please enter a FROM date for report (Example 01.01.2022): ");
                                    DateTime fromDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("Please enter a FROM date for report (Example 30.01.2022): ");
                                    DateTime toDate = DateTime.Parse(Console.ReadLine());
                                    manager.GetReportForPeriod(fromDate, toDate);

                                    condition = ReportHandler.AnotherReportNeed(condition, ref periodCondition);

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
else if (currentEmployee.Role == Roles.worker)
{
    condition = false;
    currentEmployee = new Worker(currentEmployee.Passport, currentEmployee.Name);
    ReportHandler.HandleReport(currentEmployee, ref condition);
}
else if (currentEmployee.Role == Roles.freelancer)
{
    condition = false;
    currentEmployee = new Freelancer(currentEmployee.Passport, currentEmployee.Name);
    ReportHandler.HandleReport(currentEmployee, ref condition);
}
else
{
    Console.WriteLine("New employee Role was added. Please contact to @Vasyl Krachuk for help.\nConsole will close in 5 sec.");
    Thread.Sleep(5000);
    Environment.Exit(0);
}