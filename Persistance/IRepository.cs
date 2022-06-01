using SalaryCounter.Domain;

namespace SalaryCounter.Persistance
{
    internal interface IRepository
    {
        void AddReport(Roles role, DailyReport report);
        List<DailyReport> GetAllReports(Roles role);
        void AddEmployee(Employee employee);
        Employees GetAllEmployees();
    }
}
