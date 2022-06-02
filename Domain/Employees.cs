using SalaryCounter.Domain.FileIOServices;

namespace SalaryCounter.Domain
{
    public class Employees
    {
        public static List<Employee> List = new List<Employee>();
        public static void AddNewEmployee(Employee newEmployee)
        {
            if (List.Select(employee => employee.Passport).Contains(newEmployee.Passport))
            {
                Console.WriteLine($"We already have employee with ID {newEmployee.Passport}");
                return;
            }
            else
            {
                List.Add(newEmployee);
                FileIO.AddEmployee(newEmployee);
                Console.WriteLine("New employee succesfully addded");
            }
        }
        public static bool Exists(string passport)
        {
            FileIO.GetAllEmployees();
            if (List.Select(employee => employee.Passport).Contains(passport))
            {
                var info = List.Where(a => a.Passport == passport).ToList();
                Console.WriteLine($"Hi, {info[0].Name}");
                return true;
            }
            else
            {
                Console.WriteLine($"We dont have an employee with ID {passport}");
                return false;
            }
        }
        public static void ShowAll()
        {
            FileIO.GetAllEmployees();
            int i = 1;
            foreach (Employee employee in List)
            {
                Console.WriteLine(i + ") " + employee);
                i++;
            }
        }
    }
}
