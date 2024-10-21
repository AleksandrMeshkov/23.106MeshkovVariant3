using System;
using System.Windows;
using System.Windows.Controls;

namespace _23._106MeshkovVariant3
{
    public partial class Zadacha : Window
    {
        public Zadacha()
        {
            InitializeComponent();
            CenterWindow();
        }
        private void CenterWindow()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBoxN.Text);
                if (n <= 0)
                {
                    throw new ArgumentException("Размер массива должен быть положительным.");
                }

                int min = Convert.ToInt32(textBoxMin.Text);
                int max = Convert.ToInt32(textBoxMax.Text);
                if (min >= max)
                {
                    throw new ArgumentException("Нижняя граница должна быть меньше верхней.");
                }

                int[] array = GenerateArray(n, min, max);
                SortArray(array);

                outputTextBox.Text = string.Join(" ", array);
                errorTextBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                errorTextBox.Text = ex.Message;
            }
        }

        static int[] GenerateArray(int n, int min, int max)
        {
            int[] array = new int[n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(min, max + 1);
            }

            return array;
        }

        static void SortArray(int[] array)
        {
            int[] chet = Array.FindAll(array, x => x % 2 == 0);
            int[] nechet = Array.FindAll(array, x => x % 2 != 0);

            int[] result = new int[array.Length];
            Array.Copy(chet, 0, result, 0, chet.Length);
            Array.Copy(nechet, 0, result, chet.Length, nechet.Length);

            Array.Copy(result, array, array.Length);
        }
    }
}