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

            CboTemperatureUnit.Text = pmSettings.SettingsDict["temperature_unit"].giatri;

            TxtCompanyName.Text = pmSettings.SettingsDict["company_name"].giatri;
        }

        private void SaveData()
        {
            PMSettings pmSettings = PMSettings.Instance;

            pmSettings.SettingsDict["operation_mode"].giatri = CboOperationMode.Text;

            pmSettings.SettingsDict["test_mode"].giatri = CboTestMode.Text;

            pmSettings.SettingsDict["TIC_select"].giatri = CboTIC.Text;

            pmSettings.SettingsDict["language"].giatri = CboLanguage.Text;

            pmSettings.SettingsDict["temperature_unit"].giatri = CboTemperatureUnit.Text;

            pmSettings.SettingsDict["company_name"].giatri = TxtCompanyName.Text;

            pmSettings.Save();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveData();

            this.Close();
        }
    }
}
