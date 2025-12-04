using System.Linq;
using System.Windows;
using System.IO.Ports;
using DMR2020.View;

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
            var ports = SerialPort.GetPortNames()
                                  .OrderBy(p => p)
                                  .ToList();

            if (ports.Count == 0)
            {
                CboComPorts.ItemsSource = new[] { "No COM ports" };
                CboComPorts.SelectedIndex = 0;
                CboComPorts.IsEnabled = false;
                return;
            }

            CboComPorts.ItemsSource = ports;
            CboComPorts.SelectedIndex = 0;
        }

        private void SetupMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var win = new SetupWindow();
            win.Owner = this; // để nó coi MainWindow là cha
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog(); // hoặc win.Show() nếu muốn non-modal
        }

        private void QuitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var win = new ConfirmPasswordWindow("Settings");
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (win.ShowDialog() == true)
            {
                MessageBox.Show("Mo setting");
                // Mở windown Settings
            }

            //var win = new SettingsWindow();
            //win.Owner = this;
            //win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //win.ShowDialog();
        }
    }
}
