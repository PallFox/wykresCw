using System;
using System.Windows;

namespace wykresCw
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GeneratePlot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.TryParse(txtA.Text, out double a) &&
                    double.TryParse(txtB.Text, out double b) &&
                    double.TryParse(txtC.Text, out double c))
                {
                    Window xd = new NoweOkno(a, b, c);
                    xd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nieprawidłowe dane. Proszę wprowadzić poprawne wartości liczbowe dla A, B i C.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}
