using DMR2020.DB;
using System.Windows;

namespace DMR2020.View
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            PMSettings pmSettings = PMSettings.Instance;

            CboOperationMode.Text = pmSettings.SettingsDict["operation_mode"].giatri;

            CboTestMode.Text = pmSettings.SettingsDict["test_mode"].giatri;

            CboTIC.Text = pmSettings.SettingsDict["TIC_select"].giatri;

            CboLanguage.Text = pmSettings.SettingsDict["language"].giatri;

            TxtCompanyName.Text = pmSettings.SettingsDict["company_name"].giatri;
        }
    }
}
