using System;

class Program
{
    static void Main()
    {
        int n;
        bool isValidInputN;

        do
        {
            Console.WriteLine("Введіть кількість рядків масиву:");
            isValidInputN = int.TryParse(Console.ReadLine(), out n);

            if (!isValidInputN || n <= 0)
            {
                Console.WriteLine("Будь ласка, введіть додатне ціле число для кількості рядків.");
            }
        } while (!isValidInputN || n <= 0);

        int m;
        bool isValidInputM;

        do
        {
            Console.WriteLine("Введіть кількість стовпців масиву:");
            isValidInputM = int.TryParse(Console.ReadLine(), out m);

            if (!isValidInputM || m <= 0)
            {
                Console.WriteLine("Будь ласка, введіть додатне ціле число для кількості стовпців.");
            }
        } while (!isValidInputM || m <= 0);

        double[,] array = new double[n, m];
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                double randomValue = random.NextDouble() * (7.03 - (-42.31)) + (-42.31);
                array[i, j] = Math.Round(randomValue, 2);
            }
        }

        Console.WriteLine("Двовимірний масив псевдовипадкових чисел:");
        PrintArray(array);

        int rowsWithoutNegatives = 0;
        for (int i = 0; i < n; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < m; j++)
            {
                if (array[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative)
            {
                rowsWithoutNegatives++;
            }
        }
        Console.WriteLine($"Кількість рядків без від'ємних елементів: {rowsWithoutNegatives}");

        for (int j = 0; j < m; j++)
        {
            for (int i = 0; i < n / 2; i++)
            {
                double temp = array[i, j];
                array[i, j] = array[n - 1 - i, j];
                array[n - 1 - i, j] = temp;
            }
        }

        Console.WriteLine("Двовимірний масив після зміни порядку елементів у стовпцях:");
        PrintArray(array);
    }

    static void PrintArray(double[,] array)
    {
        int n = array.GetLength(0);
        int m = array.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{array[i, j],8} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
