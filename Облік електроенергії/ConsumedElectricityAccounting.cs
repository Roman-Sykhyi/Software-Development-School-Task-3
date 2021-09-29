using System;
using System.IO;

namespace Облік_електроенергії
{
    public class ConsumedElectricityAccounting
    {
        public int FlatsCount { get; private set; }
        public int QuarterNumber { get; private set; }
        public Flat[] Flats { get; private set; }

        private string month1 = "";
        private string month2 = "";
        private string month3 = "";

        public ConsumedElectricityAccounting(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException("Шлях до файлу не може бути пустим", nameof(filePath));

            InitFromFile(filePath);

            switch (QuarterNumber)
            {
                case 1:
                    month1 = "січень";
                    month2 = "лютий";
                    month3 = "березень";
                    break;
                case 2:
                    month1 = "квітень";
                    month2 = "травень";
                    month3 = "червень";
                    break;
                case 3:
                    month1 = "липень";
                    month2 = "серпень";
                    month3 = "вересень";
                    break;
                case 4:
                    month1 = "жовтень";
                    month2 = "листопад";
                    month3 = "грудень";
                    break;
            }
        }

        private void InitFromFile(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            string[] lines = reader.ReadLine().Split();

            if (!int.TryParse(lines[0], out int flatsCount))
                throw new FormatException("Неправильний формат файлу");
            if (!int.TryParse(lines[1], out int quarterNumber))
                throw new FormatException("Неправильний формат файлу");

            FlatsCount = flatsCount;
            QuarterNumber = quarterNumber;

            Flats = new Flat[FlatsCount];

            for(int i = 0; i < FlatsCount; i++)
            {
                lines = reader.ReadLine().Split();

                int number = int.Parse(lines[0]);
                string lastName = lines[1];
                int meterInput = int.Parse(lines[2]);
                int[] meterOutput = new int[3];
                meterOutput[0] = int.Parse(lines[3]);
                meterOutput[1] = int.Parse(lines[4]);
                meterOutput[2] = int.Parse(lines[5]);
                
                Flats[i] = new Flat(number, lastName, meterInput, meterOutput);
            }
        }

        public void PrintReport()
        {
            Console.WriteLine(string.Format("Квартал: {0}", QuarterNumber));
            Console.WriteLine(string.Format("Кількість квартир на обліку: {0}\n", FlatsCount));

            Console.WriteLine($" {"#", -5} {"Прізвище", -20} {"Вхідний показник", -20} {month1, -10} {month2, -10} {month3, -10}");
            for (int i = 0; i < FlatsCount; i++)
            {
                Console.WriteLine(Flats[i].ToString());
            }
        }

        public void PrintFlatInfo(int number)
        {
            Flat flat = null;
            for(int i = 0; i < FlatsCount; i++)
            {
                if(Flats[i].Number == number)
                {
                    flat = Flats[i];
                    break;
                }
            }

            if (flat == null)
            {
                Console.WriteLine("Квартири з таким номером не знайдено.");
                return;
            }

            Console.WriteLine($" {"#",-5} {"Прізвище",-20} {"Вхідний показник",-20} {month1,-10} {month2,-10} {month3,-10}");
            Console.WriteLine(flat.ToString());
        }

        public string GetOwnerWithHighestDebt()
        {
            Flat flat = Flats[0];

            for(int i = 1; i < FlatsCount; i++)
            {
                if(Flats[i].Debt > flat.Debt)
                {
                    flat = Flats[i];
                }
            }

            return flat.OwnerLastName;
        }

        public int GetFlatNumberWithNoElectricityUsed()
        {
            for(int i = 0; i < FlatsCount; i++)
            {
                if(Flats[i].MeterOutput[2] - Flats[i].MeterInput == 0)
                {
                    return Flats[i].Number;
                }
            }

            return 0;
        }
    }
}