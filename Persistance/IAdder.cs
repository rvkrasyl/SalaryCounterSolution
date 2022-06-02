using SalaryCounter.Domain;

namespace SalaryCounter.Persistance
{
    internal interface IAdder
    {
        void AddReport(Roles role, DailyReport report);
        //List<DailyReport> GetMyReports(Roles role);
        void AddEmployee(Employee employee);
        //Employees GetAllEmployees();
    }
}
