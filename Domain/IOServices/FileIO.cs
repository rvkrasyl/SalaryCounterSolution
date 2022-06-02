using static SalaryCounter.Domain.Parameters;


namespace SalaryCounter.Domain.FileIOServices
{
    public class FileIO
    {
        public static void AddReport(int role, DailyReport report)
        {
            string filePath = GetPath(role);
            if (filePath == "error")
            {
                Console.WriteLine("New role was added");
                return;
            }

            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.Write($"{report.Date:d},{report.ID},{report.Name},{(int)report.Role},{report.WorkHours},{report.Comment}");
                streamWriter.WriteLine();
            }
        }
        public static List<DailyReport> GetReportsData(int role)
        {
            string filePath = GetPath(role);
            if (filePath == "error")
            {
                Console.WriteLine("New role was added");
            }

            List<DailyReport> dailyReports = new List<DailyReport>();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] data = streamReader.ReadLine().Split(',');
                    dailyReports.Add(new DailyReport(DateTime.Parse(data[0]), data[1], data[2], Convert.ToInt32(data[3]), Convert.ToByte(data[4]), data[5]));
                }
            }
            return dailyReports;
        }
        public static void AddEmployee(Employee employee)
        {
            using (StreamWriter streamWriter = new StreamWriter(EmployeeListFilePath, true))
            {
                streamWriter.Write(employee.Passport + ',' + employee.Name + ',' + employee.Role + ',' + employee.SalaryPerHour);
                streamWriter.WriteLine();
            }

        }
        public static Employees GetAllEmployees()
        {
            Employees.List.Clear();
            using (StreamReader streamReader = new StreamReader(EmployeeListFilePath))
            {
                Employee employee = new Employee(default, default, default, default);
                while (!streamReader.EndOfStream)
                {
                    string[] data = streamReader.ReadLine().Split(',');
                    Employees.List.Add(new Employee(data[0], data[1], Convert.ToInt32(data[2]), Convert.ToDecimal(data[3])));
                }
            }
            return new Employees();
        }
        public static void DeleteReport(int role, int date)
        {
            List<DailyReport> report = FileIO.GetReportsData(role).Where(a => a.Date.Day != date).ToList();

            string filePath = GetPath(role);
            if (filePath == "error")
            {
                Console.WriteLine("New role was added");
                return;
            }

            using (FileStream file = new FileStream(filePath, FileMode.Truncate))
            { }

            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                foreach (DailyReport item in report)
                {
                    streamWriter.Write($"{item.Date:d},{item.ID},{item.Name},{(int)item.Role},{item.WorkHours},{item.Comment}");
                    streamWriter.WriteLine();
                }
            }
        }
        private static string GetPath(int role)
        {
            string filePath = default;
            if (role == 0)
                filePath = ManagersReportsFilePath;
            else if (role == 1)
                filePath = WorkersReportsFilePath;
            else if (role == 2)
                filePath = FreelancersReportsFilePath;
            else
                filePath = "error";
            return filePath;
        }
    }
}
