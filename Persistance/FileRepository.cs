using SalaryCounter.Domain;

namespace SalaryCounter.Persistance
{
    public class FileRepository : IRepository
    {
        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void AddReport(Roles role, DailyReport report)
        {
            throw new NotImplementedException();
        }

        public Employees GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public List<DailyReport> GetAllReports(Roles role)
        {
            throw new NotImplementedException();
        }
    }
}