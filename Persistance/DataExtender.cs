using SalaryCounter.Domain;
using static SalaryCounter.Domain.Parameters;


namespace SalaryCounter.Persistance
{
    public class DataExtender : IAdder
    {
        public void AddEmployee(Employee employee)
        {
            using (StreamWriter streamWriter = new StreamWriter(EmployeeListFilePath, true))
            {
                streamWriter.Write(employee.Passport + ',' + employee.Name + ',' + employee.Role + ',' + employee.SalaryPerHour);
                streamWriter.WriteLine();
            }
        }

        public void AddReport(Roles role, DailyReport report)
        {
            throw new NotImplementedException();
        }
    }
}