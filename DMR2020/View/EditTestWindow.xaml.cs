using System.Windows;
using System.Windows.Controls;

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
    }

    public class SpecItem
    {
        public string Spec { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
    }
}
