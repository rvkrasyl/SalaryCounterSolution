using SalaryCounter.Domain;

namespace SalaryCounter.Program
{
    public class ReportHandler
    {
        public static void HandleReport(Employee currentEmployee, ref bool condition)
        {
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

                                    condition = AnotherReportNeed(condition, ref periodCondition);

                                    break;
                                }
                            case ConsoleKey.NumPad2:
                            case ConsoleKey.D2:
                                {
                                    Console.Write("Please enter a date from which you want to see Weekly report (Example 01.01.2022): ");
                                    currentEmployee.GetReportForWeek(DateTime.Parse(Console.ReadLine()));

                                    condition = AnotherReportNeed(condition, ref periodCondition);

                                    break;
                                }
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                {
                                    Console.Write("Please enter nu,ber of Month to see report (Example: \"01\" for January, \"11\" for November): ");
                                    currentEmployee.GetReportForMonth(Convert.ToInt32(Console.ReadLine()));

                                    condition = AnotherReportNeed(condition, ref periodCondition);

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

                                    condition = AnotherReportNeed(condition, ref periodCondition);
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

                        condition = AnotherReportNeed(condition, ref periodCondition);
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
        public static bool AnotherReportNeed(bool condition, ref bool periodCondition)
        {
            Console.WriteLine("Press \"Enter\" to add another report or see your work hours and salary for period\nPress any other key to Exit");
            var otherOperation = Console.ReadKey().Key;

            if (otherOperation == ConsoleKey.Enter)
            {
                periodCondition = true;
                condition = false;
            }
            else
                Environment.Exit(0);
            return condition;
        }
    }
}
