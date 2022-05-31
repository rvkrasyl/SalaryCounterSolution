using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCounter.Domain
{
    public class Employees
    {
        public static List<Employee> List = new List<Employee>();
        public Employees ()
        {
            List.Add(new Employee("AA00000001", "Director", Roles.manager, new List<DailyReport>(), 10m));
        }
        public static void AddNew(Employee newEmployee)
        {
            if (List.Select(employee => employee.Passport).Contains(newEmployee.Passport))
            {
                Console.WriteLine($"We already have employee with ID {newEmployee.Passport}");
                return;
            }
            else
            {
                List.Add(newEmployee);
                Console.WriteLine("New employee succesfully addded");
            }
        }
        public static bool Exist(string passport)
        {
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
            int i = 1;
            foreach (Employee employee in List)
            {
                Console.WriteLine(i + ") " + employee);
                i++;
            }
        }
    }
}
