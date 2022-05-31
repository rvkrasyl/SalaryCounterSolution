using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCounter.Domain
{
    public class Employees
    {
        public List<Employee> List { get; }
        public Employees ()
        {
            List = new List<Employee> ();
            List.Add(new Employee("AA00000001", "Director", Roles.manager, new List<DailyReport>(), 10m));
        }
        public void AddNew(Employee newEmployee)
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
        public bool Exist(string passport)
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
        public void ShowAll()
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
