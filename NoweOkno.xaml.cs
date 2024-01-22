using LiveCharts;
using LiveCharts.Defaults;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace wykresCw
{
    public partial class NoweOkno : Window
    {
        public ChartValues<ObservablePoint> ChartValues { get; set; }

        public NoweOkno(double a, double b, double c)
        {
            InitializeComponent();
            DataContext = this;

            ChartValues = new ChartValues<ObservablePoint>();
            for (double x = -10; x <= 10; x += 0.1)
            {
                double y = a * x * x + b * x + c;
                ChartValues.Add(new ObservablePoint(x, y));
            }
        }

        private void SaveChartImage_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Pliki obrazów (*.png)|*.png",
                DefaultExt = "png",
                Title = "Zapisz wykres jako obraz"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                SaveAsPng(chart, saveFileDialog.FileName);
                MessageBox.Show($"Wykres został zapisany jako: {saveFileDialog.FileName}", "Zapisano");
            }
        }

        private static void SaveAsPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);

            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                encoder.Save(stream);
            }
        }
    }
}
