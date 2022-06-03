namespace SalaryCounter.Domain.IOServices
{
    public interface IDataIO
    {
        void AddReport(int role, DailyReport report);
        public List<DailyReport> GetReportsData(int role);
        public void AddEmployee(Employee employee);
        public Employees GetAllEmployees();
        public void DeleteReport(int role, int date);
        protected string GetPath(int role);
    }
}
