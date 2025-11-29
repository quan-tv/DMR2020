using System.Linq;
using System.Windows;
using System.IO.Ports;

namespace DMR2020
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadComPorts();
        }

        private void LoadComPorts()
        {
            // Lấy danh sách COM trên máy, sắp xếp COM1, COM2, COM3...
            var ports = SerialPort.GetPortNames()
                                  .OrderBy(p => p)
                                  .ToList();

            CboComPorts.ItemsSource = ports;

            if (ports.Count > 0)
            {
                CboComPorts.SelectedIndex = 0;   // chọn COM đầu tiên
            }
        }

        private void QuitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
