namespace SalaryCounter.Domain
{
    public class DailyReport
    {
        public DateTime Date { get; }
        public string ID { get; }
        public string Name { get; }
        public byte WorkHours { get; }
        public string Comment { get; }
        public DailyReport(DateTime date, string id, string name, byte workHours, string comment)
        {
            Date = date;
            ID = id;
            Name = name;
            WorkHours = workHours;
            Comment = comment;
        }
        public override string ToString()
        {
            return $"{ID} - {Name} - {Date:d} - {WorkHours} - {Comment}";
        }
    }
}
