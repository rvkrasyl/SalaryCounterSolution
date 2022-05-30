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
    new DailyReport(DateTime.Now.AddDays(-28), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-27), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-26), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-25), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-24), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-23), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-22), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-21), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-20), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-19), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-18), "MO50896213", "Grigory Zavodniy", 8, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-17), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-16), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-15), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-14), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-13), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-12), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-11), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-10), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-9), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-8), "MO50896213", "Grigory Zavodniy", 9, "no comments"),
    new DailyReport(DateTime.Now.AddDays(-7), "MO50896213", "Grigory Zavodniy", 9, "no comments"),




};
Worker grisha = new Worker("MO50896213", "Grigory Zavodniy", dailyReports);
grisha.GetReportForPeriod(DateTime.Now.AddDays(-28), DateTime.Now);

