using System;
using System.Text;

namespace Магічний_квадрат
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n = GetMatrixSize();

            int[,] magicSquare = GenerateMagicSquare(n);

            Console.WriteLine("\nСтворений магічний квадрат:");
            PrintMatrix(magicSquare);
        }

        private static int GetMatrixSize()
        {
            int n;

            do
            {
                Console.Write("Введіть розмір квадрату (непарне число більше рівне 3): ");
                if (!int.TryParse(Console.ReadLine(), out n)) continue;
            } while (n % 2 == 0 || n < 3);

            return n;
        }

        private static int[,] GenerateMagicSquare(int n)
        {
            int[,] magicSquare = new int[n, n];

            int i = 0;
            int j = n / 2;

            for(int k = 1; k <= n*n; k++)
            {
                magicSquare[i, j] = k;

                int prevI = i; // зберігаємо попередню позицію
                int prevJ = j;

                i--; // рухаємось на один рядок вверх
                j++; // і на один стовпець вправо

                if (i == -1) i = n - 1;
                if (j == n) j = 0;

                if (magicSquare[i, j] != 0) // якшо нова позиція зайнята, то повертаємось на попередню і рухаємось на рядок вниз
                {
                    i = prevI;
                    j = prevJ;
                    i++;
                }
            }

            return magicSquare;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],-3} ");
                }
                Console.WriteLine();
            }
        }
    }
}