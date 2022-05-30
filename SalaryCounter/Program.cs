using System;
using SalaryCounter;
using SalaryCounter.Domain;
using SalaryCounter.Persistance;

//Console.ForegroundColor = ConsoleColor.DarkBlue;
//Console.WriteLine("\t\tWelcome to SoftDevelopment_SalaryCounter.");
//Console.ResetColor();
//Console.Write("Please enter your Passport ID to continue:");
//string id = Console.ReadLine();

List<DailyReport> dailyReports = new List<DailyReport>()
{
    new DailyReport(DateTime.Now.AddDays(-9), "MO50896213", "Grigory Zavodniy", 10, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-5), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-2), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-1), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now, "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-3), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-3), "WW58999226", "Valera Cheater", 7, "Leave comments"),
    new DailyReport(DateTime.Now.AddDays(-2), "WW58999226", "Valera Cheater", 7, "Leave comments"),
    new DailyReport(DateTime.Now.AddDays(-5), "WW58999226", "Valera Cheater", 7, "Leave comments"),
    new DailyReport(DateTime.Now.AddDays(-7), "WW58999226", "Valera Cheater", 7, "Leave comments"),

};
Worker grisha = new Worker("MO50896213", "Grigory Zavodniy", dailyReports);
grisha.GetReportForPeriod(DateTime.Now.AddDays(-10), DateTime.Now);

