using System;
using SalaryCounter;
using SalaryCounter.Domain;
using SalaryCounter.Persistance;

//Console.ForegroundColor = ConsoleColor.DarkBlue;
//Console.WriteLine("\t\tWelcome to SoftDevelopment_SalaryCounter.");
//Console.ResetColor();
//Console.Write("Please enter your Passport ID to continue:");
//string id = Console.ReadLine();

Employees emloyeesList= new Employees();
List<DailyReport> dailyReports = new List<DailyReport>();
Manager grigory = new Manager("MO50896213", "Grigory Dushniy", dailyReports);
Freelancer dimka = new Freelancer("TB32599985", "Dmitro Chiller", dailyReports);
Worker pilip = new Worker("OP56987568", "Pulup Truten", dailyReports);
emloyeesList.AddNew(grigory);
emloyeesList.AddNew(dimka);
emloyeesList.AddNew(pilip);

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
grigory.AddNewReport(DateTime.Now.AddDays(-2), 7, "Coment 33");
grigory.AddNewReport(DateTime.Now.AddDays(-2), 6, "Coment 33");
pilip.AddNewReport(DateTime.Now, 9, "Понедiлок(");
pilip.AddNewReport(DateTime.Now, 8, "Понедiлок(");
dimka.AddNewReport(DateTime.Now.AddDays(-1), 5, "Работаю");
dimka.AddNewReport(DateTime.Now.AddDays(-1), 6, "Работаю");

//int i = 1;
//foreach (var item in dailyReports)
//{
//    Console.WriteLine(i + ") " + item.ToString());
//    i++;
//}
emloyeesList.Exist("AA00000001");
emloyeesList.Exist("asd");
Thread.Sleep(100);
emloyeesList.ShowAll();

