using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Windows.Input;

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

            LoadSpecTable();

            DgSpec.Loaded += (s, e) => LockScrollViewer();
        }

        private ScrollViewer _specScrollViewer;

        private void LockScrollViewer()
        {
            _specScrollViewer = FindVisualChild<ScrollViewer>(DgSpec);

            if (_specScrollViewer != null)
            {
                // Khóa scroll
                _specScrollViewer.ScrollChanged += (s, e) =>
                {
                    _specScrollViewer.ScrollToVerticalOffset(0);
                    e.Handled = true;
                };
            }
        }

        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is T tChild)
                    return tChild;

                var result = FindVisualChild<T>(child);
                if (result != null)
                    return result;
            }
            return null;
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

        private void LoadSpecTable()
        {
            var list = new List<SpecItem>
            {
                new SpecItem { Spec = "ML", Min = 0, Max = 0 },
                new SpecItem { Spec = "MH", Min = 0, Max = 0 },
                new SpecItem { Spec = "ts1", Min = 0, Max = 0 },
                new SpecItem { Spec = "tc10", Min = 0, Max = 0 },
                new SpecItem { Spec = "tc50", Min = 0, Max = 0 },
                new SpecItem { Spec = "tc90", Min = 0, Max = 0 },
            };

            DgSpec.ItemsSource = list;
        }

        // Handler auto chỉnh chiều cao DataGrid Spec
        private void DgSpec_Loaded(object sender, RoutedEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null) return;

            // Số dòng hiển thị (ví dụ bạn luôn có 6 phần tử trong ItemsSource)
            int rowCount = dg.Items.Count;

            // Chiều cao header
            double headerHeight = dg.ColumnHeaderHeight;

            // Tổng chiều cao = header + (rowHeight * số dòng) + 2px border
            double totalHeight = headerHeight + (dg.RowHeight * rowCount) + 2;

            dg.Height = totalHeight;
        }
        private void DgSpec_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Chặn không cho DataGrid xử lý wheel => không scroll
            e.Handled = true;
        }

        private static readonly Regex _integerRegex = new Regex("^[0-9]+$");

        private void SpecNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Chỉ cho phép chữ số 0-9
            if (!_integerRegex.IsMatch(e.Text))
                e.Handled = true;  // chặn ký tự
        }

        private void SpecNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Không cho nhập dấu chấm ".", dấu phẩy ","
            if (e.Key == Key.OemPeriod ||
                e.Key == Key.Decimal ||
                e.Key == Key.OemComma)
            {
                e.Handled = true;
            }
        }
    }

    public class SpecItem
    {
        public string Spec { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public Boolean IsChecked { get; set; }
    }
}
