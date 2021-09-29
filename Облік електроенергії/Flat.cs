using System;

namespace Облік_електроенергії
{
    public class Flat
    {
        public int Number { get; }
        public string OwnerLastName { get; }

        public int MeterInput { get; }
        public int[] MeterOutput { get; }

        public Flat(int number, string lastName, int meterInputs, int[] meterOutputs)
        {
            #region Перевірки
            if (number <= 0)
                throw new ArgumentException("Номер квартири не може бути меншим за 0", nameof(number));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException("Прізвище власника не може бути пустим", nameof(lastName));
            if (meterInputs < 0)
                throw new ArgumentException("Вхідний показник лічильника не може бути меншим за 0", nameof(meterInputs));
            if (meterOutputs.Length > 3)
                throw new ArgumentException("Кількість вихідних показників лічильника не може бути більшою за 3", nameof(meterOutputs));
            #endregion

            Number = number;
            OwnerLastName = lastName;
            MeterInput = meterInputs;
            MeterOutput = meterOutputs;
        }

        public override string ToString()
        {
            return $" {Number,-5} {OwnerLastName,-20} {MeterInput,-20} {MeterOutput[0],-10} {MeterOutput[1],-10} {MeterOutput[2],-10}";
        }
    }
}