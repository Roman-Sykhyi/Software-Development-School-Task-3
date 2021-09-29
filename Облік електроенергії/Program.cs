using System;
using System.Text;

namespace Облік_електроенергії
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string filePath = @"E:\Sigma Pract\Завдання 3\Облік електроенергії\data.txt";

            ConsumedElectricityAccounting accounting = new ConsumedElectricityAccounting(filePath);

            accounting.PrintReport();
        }
    }
}