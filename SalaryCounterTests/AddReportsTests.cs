using SalaryCounter.Domain;

namespace SalaryCounterTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List<DailyReport> dailyReports = new List<DailyReport>();
            Manager grigory = new Manager("MO50896213", "Grigory Dushniy", dailyReports);
            Freelancer dimka = new Freelancer("TB32599985", "Dmitro Chiller", dailyReports);
            Worker pilip = new Worker("OP56987568", "Pulup Truten", dailyReports);

            grigory.AddNewReport(DateTime.Now.AddDays(-11), 9, "Coment 1");
            dimka.AddNewReport(DateTime.Now.AddDays(-12), 8, "Комент 1");
            pilip.AddNewReport(DateTime.Now.AddDays(-10), 7, "Coment pilip");
            grigory.AddNewReport(DateTime.Now.AddDays(-9), 10, "Coment plus");
            pilip.AddNewReport(DateTime.Now.AddDays(-8), 8, "Шось там роблю");
            dimka.AddNewReport(DateTime.Now.AddDays(-9), 4, "Комент Дiмка");
            grigory.AddNewReport(DateTime.Now.AddDays(-7), 8, "Coment comment");
            dimka.AddNewReport(DateTime.Now.AddDays(-5), 3, "Комент Фрилансер");
            pilip.AddNewReport(DateTime.Now.AddDays(-7), 9, "Тружусь");
            grigory.AddNewReport(DateTime.Now.AddDays(-6), 6, "Coment 12");
            pilip.AddNewReport(DateTime.Now.AddDays(-4), 8, "Скоро пятниця");
            grigory.AddNewReport(DateTime.Now.AddDays(-2), 6, "Coment 33");
            grigory.AddNewReport(DateTime.Now.AddDays(-2), 6, "Coment 33");
            pilip.AddNewReport(DateTime.Now, 9, "Понедiлок(");
            pilip.AddNewReport(DateTime.Now, 9, "Понедiлок(");
            dimka.AddNewReport(DateTime.Now.AddDays(-1), 5, "Работаю");
            dimka.AddNewReport(DateTime.Now.AddDays(-1), 5, "Работаю");

            int i = 1;
            foreach(var item in dailyReports)
            {
                Console.WriteLine(i + ") " + item.ToString());
                i++;
            }

            Assert.IsTrue(dailyReports.Select(report => report.Date.Day).Contains(DateTime.Now.AddDays(-1).Day));
        }
        [Test]
        public void Test2()
        {
            Employees emloyeesList = new Employees();
            Manager grigory = new Manager("MO50896213", "Grigory Dushniy", new List<DailyReport>());
            Freelancer dimka = new Freelancer("TB32599985", "Dmitro Chiller", new List<DailyReport>());
            Worker pilip = new Worker("OP56987568", "Pulup Truten", new List<DailyReport>());
            Employees.AddNewEmployee(grigory);
            Employees.AddNewEmployee(dimka);
            Employees.AddNewEmployee(pilip);
            Assert.IsTrue(Employees.Exists("AA00000001"));
        }
        [Test]
        public void Test3()
        {
            Employees emloyeesList = new Employees();
            Manager grigory = new Manager("MO50896213", "Grigory Dushniy", new List<DailyReport>());
            Freelancer dimka = new Freelancer("TB32599985", "Dmitro Chiller", new List<DailyReport>());
            Worker pilip = new Worker("OP56987568", "Pulup Truten", new List<DailyReport>());
            Employees.AddNewEmployee(grigory);
            Employees.AddNewEmployee(dimka);
            Employees.AddNewEmployee(pilip);
            Assert.IsFalse(Employees.Exists("no waay"));
        }
    }
}