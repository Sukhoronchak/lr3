using System;

class Program
{
    static void Main()
    {
        int n;
        bool isValidInput;

        do
        {
            Console.WriteLine("Введіть кількість елементів масиву:");
            isValidInput = int.TryParse(Console.ReadLine(), out n);

            if (!isValidInput || n <= 0)
            {
                Console.WriteLine("Будь ласка, введіть додатне ціле число.");
            }
        } while (!isValidInput || n <= 0);

        double[] arr = new double[n];
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            double randomValue = random.NextDouble() * (3.59 - (-7.51)) + (-7.51);
            arr[i] = Math.Round(randomValue, 2);
        }

        Console.WriteLine("Масив псевдовипадкових чисел:");
        PrintArray(arr);

        double sum = 0;
        foreach (double num in arr)
        {
            if (Math.Abs(num % 1) < 0.5)
            {
                sum += Math.Abs(num);
            }
        }
        Console.WriteLine($"Сума модулів елементів з дробовою частиною < 0.5: {sum}");

        int minIndex = Array.IndexOf(arr, arr.Min()) + 1;
        Array.Sort(arr, minIndex, arr.Length - minIndex, Comparer<double>.Create((x, y) => y.CompareTo(x)));

        Console.WriteLine("Відсортований масив після мінімального елементу за спаданням значень:");
        PrintArray(arr);
    }

    static void PrintArray(double[] array)
    {
        foreach (double element in array)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }
}
