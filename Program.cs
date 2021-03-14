using CsvHelper;
using CsvUpdater.Utility;
using CsvUpdater.Models;
using CsvUpdater.Services;
using System;
using System.Collections.Generic;

namespace CsvUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("  ");

            string fileTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            string filepath = @"c:\temp\csvFiles\myCsvFile.csv";

            //=========================================================//


            Console.WriteLine("  ");
            Console.WriteLine("File Timestamp:  " + fileTimeStamp);
            Console.WriteLine("  ");
            Console.WriteLine("**** Read a CSV file *****");
            Console.WriteLine("  ");

            var csvParserService = new CsvParserService();

            var result = csvParserService.ReadCsvFileToLoanModel(filepath);

            //var employeeToAdd = new EmployeeModel()
            //{
            //    Address = "address 20",
            //    City = "city 20",
            //    Direction = "direction 20",
            //    Firstname = "first name 20",
            //    Email = "email20@mail.com",
            //    Lastname = "lastname 20",
            //    Mobile = "1111",
            //    Salary = "100000"
            //};
            //
            //result.Add(loanToAdd);

            Console.WriteLine("**** List Input Records *****");
            Console.WriteLine("  ");

            foreach (LoanModel loan in result)
            {
                Console.WriteLine($"Loan Info:    {loan.BorrowerName}   " +
                    $"{loan.City}   {loan.State}   {loan.LoanNumber}   {loan.LoanAmount}");
            }


            Console.WriteLine("**** Update Input File Records *****");
            Console.WriteLine("  ");
            
            
            foreach (LoanModel loan in result)
            {

                Random rnd = new Random();

                int index = rnd.Next(1, 301);

                NameHelper nameHelper = new NameHelper();

                string newBowrrowerName = nameHelper.PerformGetLastName(index);

                //string newBowrrowerName = loan.BorrowerName + "-Smith";


                loan.BorrowerName = newBowrrowerName;

                int tmpLoanNumber = int.Parse(loan.LoanNumber);
                tmpLoanNumber += 5;
                loan.LoanNumber = tmpLoanNumber.ToString();

            }


            Console.WriteLine("**** Write Updated CSV file *****");
            Console.WriteLine("  ");

            string outFile = @"C:\temp\csvfiles\myCsvFile-" + fileTimeStamp + ".csv";

            csvParserService.WriteNewCsvFile(outFile, result);

            Console.WriteLine("Modified CSV File written to disk - " + outFile);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();


            //=========================================================//


            Console.WriteLine("Listing the updated records to the console...");
            Console.WriteLine("  ");

            foreach (LoanModel loan in result)
            {
                Console.WriteLine($"Loan Info:    {loan.BorrowerName}   " +
                    $"{loan.City}   {loan.State}   {loan.LoanNumber}   {loan.LoanAmount}");
            }

            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }
    }
}
