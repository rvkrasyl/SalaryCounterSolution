namespace SalaryCounter.Domain
{
    public class DailyReport
    {
        public DateTime Date { get; }
        public string Name { get; }
        public byte WorkHours { get; }
        public string Comment { get; }
        public DailyReport(DateTime date, string name, byte workHours, string comment)
        {
            Date = date;
            Name = name;
            WorkHours = workHours;
            Comment = comment;
        }
    }
}
