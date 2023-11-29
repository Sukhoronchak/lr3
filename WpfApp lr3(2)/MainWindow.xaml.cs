using System;
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
            if (!int.TryParse(RowsTextBox.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Будь ласка, введіть додатне ціле число для кількості рядків.", "Помилка");
                return;
            }

            if (!int.TryParse(ColumnsTextBox.Text, out int m) || m <= 0)
            {
                MessageBox.Show("Будь ласка, введіть додатне ціле число для кількості стовпців.", "Помилка");
                return;
            }

            double[,] array = new double[n, m];
            Random random = new Random();

            // Заповнення двовимірного масиву псевдовипадковими числами у заданому діапазоні [-42.31, 7.03]
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    double randomValue = random.NextDouble() * (7.03 - (-42.31)) + (-42.31);
                    array[i, j] = Math.Round(randomValue, 2);
                }
            }

            ResultsTextBox.Text = "Двовимірний масив псевдовипадкових чисел:\n";
            ResultsTextBox.Text += PrintArray(array);

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
            ResultsTextBox.Text += $"\nКількість рядків без від'ємних елементів: {rowsWithoutNegatives}\n";

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    double temp = array[i, j];
                    array[i, j] = array[n - 1 - i, j];
                    array[n - 1 - i, j] = temp;
                }
            }

            ResultsTextBox.Text += "\nДвовимірний масив після зміни порядку елементів у стовпцях:\n";
            ResultsTextBox.Text += PrintArray(array);
        }

        // Допоміжний метод для форматованого виведення двовимірного масиву
        private string PrintArray(double[,] array)
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            string result = "";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result += $"{array[i, j],8} ";
                }
                result += "\n";
            }
            result += "\n";
            return result;
        }
    }
}
