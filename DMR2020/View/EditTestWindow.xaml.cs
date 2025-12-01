using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DMR2020.View
{
    public class SpecRow
    {
        public string Spec { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
        public bool IsChecked { get; set; }
    }

    public partial class EditTestWindow : Window
    {
        // Thuộc tính để SetupWindow lấy/gán Test Name
        public string TestName { get; set; }

        public List<SpecRow> SpecRows { get; set; }

        public EditTestWindow()
        {
            InitializeComponent();

            Loaded += EditTestWindow_Loaded;

            LoadSpecTable();
        }

        private void EditTestWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Khi mở form:
            // - Nếu là Edit: TestName đã được gán từ bên ngoài
            // - Nếu là Add: TestName = null
            TxtTestName.Text = TestName ?? string.Empty;

            TxtTestName.Focus();
            TxtTestName.SelectAll();
        }

        private void LoadSpecTable()
        {
            SpecRows = new List<SpecRow>
            {
                new SpecRow { Spec = "ML"   },
                new SpecRow { Spec = "MH"   },
                new SpecRow { Spec = "ts1"  },
                new SpecRow { Spec = "tc10" },
                new SpecRow { Spec = "tc50" },
                new SpecRow { Spec = "tc90" }
            };

            DgSpec.ItemsSource = SpecRows;
        }

        // ====== SAVE / EXIT ======

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            TestName = TxtTestName.Text?.Trim();

            if (string.IsNullOrEmpty(TestName))
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

        private void SpecNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
