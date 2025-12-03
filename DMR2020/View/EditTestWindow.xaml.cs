using DMR2020.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace DMR2020.View
{
    public partial class EditTestWindow : Window
    {
        public TestSettingsVM TestSettings { get; set; } = new();
        private CollectionViewSource _cvsResults { get; set; } =  new();
        public CollectionView CVResults { get; set; }
        public List<string> LstFeaturePointTypes { get; set; } = ["ts", "tc", "Tc", "T", "t"];

        public EditTestWindow()
        {
            InitializeComponent();
            DataContext = this;

            _cvsResults.Source = TestSettings.FeaturePoints;
            CVResults = (CollectionView)_cvsResults.View;
            CVResults.Filter = x =>
            {
                if (x is FeaturePointVM f)
                {
                    return !string.IsNullOrEmpty(f.Title);
                }
                return false;
            };

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TxtTestName.Focus();
            TxtTestName.SelectAll();
        }

        private void DgSpec_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            // Chặn DataGrid tự scroll khi chọn dòng
            e.Handled = true;
        }

        private void DgSpecRow_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }

        // ====== SAVE / EXIT ======

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TestSettings.Name))
            {
                MessageBox.Show("Please input Test Name.",
                                "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                TxtTestName.Focus();
                return;
            }

            // Nếu bạn cần validate thêm (spec, time...) thì làm thêm ở đây
            DialogResult = true;   // trả về true cho ShowDialog()
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;  // đóng mà không lưu
        }

        // ====== SỰ KIỆN CHO DATAGRID SPEC ======
        private void DgSpec_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Ngăn scroll ăn vào DataGrid nếu cần (hoặc bỏ trống cũng được)
            e.Handled = true;
        }

        private void DgSpec_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Get the original source of the event, which might be a TextBox within a cell
            if (e.OriginalSource is TextBox textBox)
            {
                // Perform checks or modifications
                // Example: Prevent non-numeric input in a specific column
                //if (DgSpec.CurrentColumn.Header.ToString() == "Minimun")
                //{
                // Chặn ký tự không phải số / dấu . / dấu -
                if (!char.IsDigit(e.Text, 0) && e.Text != "." && e.Text != "-")
                {
                    e.Handled = true;
                }
                //}
            }
        }

        private void TxtTypeValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Chặn ký tự không phải số / dấu . / dấu -
            if (!char.IsDigit(e.Text, 0) && e.Text != "." && e.Text != "-")
            {
                e.Handled = true;
            }
        }

        private void SpecNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Cho phép các phím điều hướng, Backspace, Delete...
            // Không cần chặn gì ở đây nếu bạn không muốn.
        }
    }
}
