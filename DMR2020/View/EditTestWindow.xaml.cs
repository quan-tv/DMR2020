using System.Windows;

namespace DMR2020.View
{
    public partial class EditTestWindow : Window
    {
        public string TestName { get; set; }
        public EditTestWindow()
        {
            InitializeComponent();

            // Focus mặc định vào TextBox tên test
            TxtTestName.Focus();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO: lưu dữ liệu từ các control vào model / property
            // ...

            this.DialogResult = true;   // báo cho SetupWindow biết là Save thành công
            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;  // hoặc bỏ dòng này cũng được
            this.Close();
        }
    }
}
