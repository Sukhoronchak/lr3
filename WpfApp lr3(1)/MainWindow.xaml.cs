using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ArrayManipulation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessArray_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (int.TryParse(ElementsTextBox.Text, out n))
            {
                double[] arr = new double[n];
                Random random = new Random();

                // Заповнення масиву випадковими числами у заданому діапазоні [-7.51, 3.59]
                for (int i = 0; i < n; i++)
                {
                    double randomValue = random.NextDouble() * (3.59 - (-7.51)) + (-7.51);
                    arr[i] = Math.Round(randomValue, 2);
                }

                ResultsTextBox.Text = "Масив випадкових чисел:\n";
                ResultsTextBox.Text += PrintArray(arr);

                // 1. Знайти суму модулів елементів, які мають дробову частину меншу за 0.5
                double sum = 0;
                foreach (double num in arr)
                {
                    if (Math.Abs(num % 1) < 0.5)
                    {
                        sum += Math.Abs(num);
                    }
                }
                ResultsTextBox.Text += $"\nСума модулів елементів з дробовою частиною < 0.5: {sum}\n";

                // 2. Впорядкувати елементи, розташовані після мінімального елементу за спаданням значень
                int minIndex = Array.IndexOf(arr, arr.Min()) + 1;
                Array.Sort(arr, minIndex, arr.Length - minIndex, Comparer<double>.Create((x, y) => y.CompareTo(x)));

                ResultsTextBox.Text += "\nВідсортований масив після мінімального елементу за спаданням значень:\n";
                ResultsTextBox.Text += PrintArray(arr);
            }
            else
            {
                ResultsTextBox.Text = "Некоректне значення для кількості елементів!";
            }
        }

        // Допоміжний метод для форматованого виведення масиву
        private string PrintArray(double[] array)
        {
            string result = "";
            foreach (double element in array)
            {
                result += $"{element} ";
            }
            result += "\n";
            return result;
        }
    }
}
