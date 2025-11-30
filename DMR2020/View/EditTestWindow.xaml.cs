using DMR2020.Data;
using SqlSugar;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Collections.Generic;


namespace DMR2020.View
{
    public partial class EditTestWindow : Window
    {
        public string TestName { get; set; }
        private TestSetup _testSetup;   // đây là record Test Setup hiện tại

        public EditTestWindow() : this(null)
        {
        }

        public EditTestWindow(TestSetup setup)
        {
            InitializeComponent();

            // Focus mặc định vào TextBox tên test
            TxtTestName.Focus();
            
            if (setup == null)
            {
                Title = "Add Test Item";
                _testSetup = new TestSetup();      // Id = 0 → chắc chắn là INSERT
                // TODO: nếu muốn default value thì set ở đây
            }
            else
            {
                Title = "Edit Test Item";
                _testSetup = setup;
                LoadTestSetupToUi();               // đổ dữ liệu lên UI nếu đang sửa
            }

            LoadSpecTable();

            DgSpec.Loaded += (s, e) => LockScrollViewer();
        }

        private void LoadTestSetupToUi()
        {
            TxtTestName.Text = _testSetup.TestName;
            TxtTestTime.Text = _testSetup.TestTime?.ToString();

            // chọn lại torque unit, time unit, arc, result… theo _testSetup
            // (nếu cần mình viết chi tiết tiếp)
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

        //private void BtnSave_Click(object sender, RoutedEventArgs e)
        //{
        //    // TODO: lưu dữ liệu từ các control vào model / property
        //    // ...

        //    this.DialogResult = true;   // báo cho SetupWindow biết là Save thành công
        //    this.Close();
        //}

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

        private string GetComboContent(ComboBox cbo)
        {
            if (cbo?.SelectedItem is ComboBoxItem item && item.Content != null)
                return item.Content.ToString();

            return null;
        }


        private void SaveTestSetup()
        {
            // ===== 1. BASIC =====
            _testSetup.TestName = TxtTestName.Text?.Trim();

            if (int.TryParse(TxtTestTime.Text?.Trim(), out int testTime))
                _testSetup.TestTime = testTime;
            else
                _testSetup.TestTime = null;

            _testSetup.TorqueUnit = GetComboContent(CboTorqueUnit);
            _testSetup.TimeUnit = GetComboContent(CboTimeUnit);

            if (int.TryParse(GetComboContent(CboArc), out int arc))
                _testSetup.Arc = arc;
            else
                _testSetup.Arc = null;

            _testSetup.TanDeltaChecked = (ChkTanDelta.IsChecked == true);

            // ===== 2. RESULTS =====
            _testSetup.Result1Unit = GetComboContent(CboResult1);
            _testSetup.Result1Value = TxtResult1.Text?.Trim();

            _testSetup.Result2Unit = GetComboContent(CboResult2);
            _testSetup.Result2Value = TxtResult2.Text?.Trim();

            _testSetup.Result3Unit = GetComboContent(CboResult3);
            _testSetup.Result3Value = TxtResult3.Text?.Trim();

            _testSetup.Result4Unit = GetComboContent(CboResult4);
            _testSetup.Result4Value = TxtResult4.Text?.Trim();

            // ===== 3. SPEC TABLE (DgSpec → TestSetup) =====
            var specList = DgSpec.ItemsSource as List<SpecItem>;
            if (specList != null)
            {
                foreach (var row in specList)
                {
                    switch (row.Spec)
                    {
                        case "MH":
                            _testSetup.MhMinValue = row.Min;
                            _testSetup.MhMaxValue = row.Max;
                            _testSetup.MhChecked = row.IsChecked;
                            break;

                        case "ts1":
                            _testSetup.Ts1MinValue = row.Min;
                            _testSetup.Ts1MaxValue = row.Max;
                            _testSetup.Ts1Checked = row.IsChecked;
                            break;

                        case "tc10":
                            _testSetup.Tc10MinValue = row.Min;
                            _testSetup.Tc10MaxValue = row.Max;
                            _testSetup.Tc10Checked = row.IsChecked;
                            break;

                        case "tc50":
                            _testSetup.Tc50MinValue = row.Min;
                            _testSetup.Tc50MaxValue = row.Max;
                            _testSetup.Tc50Checked = row.IsChecked;
                            break;

                        case "tc90":
                            _testSetup.Tc90MinValue = row.Min;
                            _testSetup.Tc90MaxValue = row.Max;
                            _testSetup.Tc90Checked = row.IsChecked;
                            break;

                            // ML hiện chưa có field trong TestSetup nên mình bỏ qua
                    }
                }
            }

            // ===== 4. LƯU XUỐNG DB VỚI SQLSUGAR =====
            var db = Db.Instance.Client;

            if (_testSetup.Id == 0)
            {
                int newId = db.Insertable(_testSetup).ExecuteReturnIdentity();
                _testSetup.Id = newId;
            }
            else
            {
                db.Updateable(_testSetup).ExecuteCommand();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveTestSetup();
                MessageBox.Show("Test setup has been saved.", "Info",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu Test Setup:\n" + ex.Message,
                                "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
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
