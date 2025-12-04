using DMR2020.Data;
using System.Windows;
using System.Windows.Input;


namespace DMR2020.View
{
    /// <summary>
    /// Interaction logic for ConfirmPasswordWindow.xaml
    /// </summary>
    public partial class ConfirmPasswordWindow : Window
    {
        public ConfirmPasswordWindow(string title)
        {
            InitializeComponent();

            this.Title = title;
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;

                var list = Db.Instance.Client.Queryable<Settings>().ToList();

                string password = list.First().password;

                if (PwdInput.Password == password)
                {
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect password.");
                }
            }
        }
    }
}
