using System;

namespace Облік_електроенергії
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"E:\Sigma Pract\Завдання 3\Облік електроенергії\data.txt";

            ConsumedElectricityAccounting accounting = new ConsumedElectricityAccounting(filePath);
        }
    }
}
