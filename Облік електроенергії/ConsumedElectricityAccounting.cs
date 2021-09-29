using System;
using System.IO;

namespace Облік_електроенергії
{
    public class ConsumedElectricityAccounting
    {
        public int FlatsCount { get; private set; }
        public int QuarterNumber { get; private set; }
        public Flat[] Flats { get; private set; }

        public ConsumedElectricityAccounting(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException("Шлях до файлу не може бути пустим", nameof(filePath));

            InitFromFile(filePath);
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
    }
}
