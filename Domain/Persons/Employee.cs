using SalaryCounter.Domain.FileIOServices;

namespace SalaryCounter.Domain
{
    public class Employee
    {
        public string Passport { get; }
        public string Name { get; }
        public Roles Role { get; }
        public decimal SalaryPerHour { get; }
        public Employee (string passportId, string name, int role, decimal salaryPerHour)
        {
            Passport = passportId;
            Name = name;
            Role = (Roles)role;
            SalaryPerHour = salaryPerHour;
        }
        public virtual void AddNewReport(DateTime date, byte workHours, string comment, bool isManager = false)
        {
            FileIO fileIO = new FileIO();
            if (date > DateTime.Now)
            {
                Console.WriteLine("No cheating! You cant create report for dates in future!");
                return;
            }

            if (!isManager && fileIO.GetReportsData((int)Role).Where(item => item.ID == Passport).Select(report => report.Date.Day).Contains(date.Day))
            {
                Console.WriteLine($"You have alredy sended report for {date:d}");
                return;
            }

            if (!isManager && 11 < workHours)
            {
                Console.WriteLine("Ou! Its huge! We appreciate your layalty. But rest is important too!" +
                    "\nIf you worked for more than 11 hours per day - please contact to your manager for approval");
                return;
            }

            DailyReport report = new DailyReport(date, Passport, Name, (int)Role, workHours, comment);
            fileIO.AddReport((int)Role, report);
            Console.WriteLine("Succesfully added!");
        }
        public virtual void GetReportForPeriod(DateTime fromDate, DateTime toDate, bool isMounthly = false) { }
        public void GetReportForDay(DateTime day)
        {
            GetReportForPeriod(day, day.AddHours(1), false);
        }
        public void GetReportForWeek(DateTime fromDate)
        {
            GetReportForPeriod(fromDate, fromDate.AddDays(7), false);
        }
        public void GetReportForMonth(int month)
        {
            if (month > DateTime.Now.Month)
            {
                Console.WriteLine("You try to get report about future month;");
                return;
            }

            string date = $"01,{month},{DateTime.Now.Year}";
            int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);
            DateTime.TryParse(date, out DateTime day);
            
            GetReportForPeriod(day, day.AddDays(daysInCurrentMonth-1), true);
        }
        public override string ToString()
        {
            return $"{Passport} - {Role} - {Name}";
        }
    }
}
