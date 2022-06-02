namespace SalaryCounter.Domain
{
    public class DailyReport
    {
        public DateTime Date { get; }
        public string ID { get; }
        public string Name { get; }
        public Roles Role { get; }
        public byte WorkHours { get; }
        public string Comment { get; }
        public DailyReport(DateTime date, string id, string name, int role, byte workHours, string comment)
        {
            Date = date;
            ID = id;
            Name = name;
            Role = (Roles)role;
            WorkHours = workHours;
            Comment = comment;
        }
        public override string ToString()
        {
            return $"{ID} - {Name} - {Role} - {Date:d} - {WorkHours} - {Comment}";
        }
    }
}
