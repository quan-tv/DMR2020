using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DMR2020.View
{
    public partial class SetupWindow : Window
    {
        public ObservableCollection<TestItem> Items { get; set; }

        private ICollectionView _view;

        public SetupWindow()
        {
            InitializeComponent();

            // Dữ liệu mẫu
            Items = new ObservableCollection<TestItem>
            {
                new TestItem
                {
                    TestName = "Tensile Test A",
                    CreatedTime = DateTime.Now.AddMinutes(-15)
                },
                new TestItem
                {
                    TestName = "Compression Test B",
                    CreatedTime = DateTime.Now
                }
            };

            LvTests.ItemsSource = Items;

            // CollectionView để filter
            _view = CollectionViewSource.GetDefaultView(LvTests.ItemsSource);
            _view.Filter = FilterTests;
        }

        // Model 1 dòng
        public class TestItem
        {
            public string TestName { get; set; }
            public DateTime CreatedTime { get; set; }
        }

        // Hàm filter theo text search
        private bool FilterTests(object obj)
        {
            if (obj is not TestItem item)
                return false;

            var txt = TxtSearch.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(txt))
                return true;

            // Tìm theo TestName hoặc theo chuỗi thời gian đã format
            var timeStr = item.CreatedTime.ToString("dd/MM/yyyy HH:mm:ss");

            return (item.TestName?.IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0)
                   || (timeStr.IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _view?.Refresh();
        }

        // Nút Add
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var win = new EditTestWindow();
            win.Owner = this;
            win.Title = "Add Test Item";

            if (win.ShowDialog() == true)
            {
                Items.Add(new TestItem
                {
                    TestName = win.TestName,
                    CreatedTime = DateTime.Now   // đúng kiểu DateTime
                });

                // refresh filter (nếu đang search)
                _view?.Refresh();
            }
        }

        // Nút Edit
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement)?.DataContext as TestItem;
            if (item == null) return;

            var win = new EditTestWindow();
            win.Title = "Edit Test Item";
            win.Owner = this;
            win.TestName = item.TestName;   // nạp dữ liệu cũ

            if (win.ShowDialog() == true)
            {
                item.TestName = win.TestName;   // lấy lại TestName mới
                _view?.Refresh();
            }
        }

        // Nút Delete: confirm trước khi xóa
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is TestItem item)
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa test \"{item.TestName}\"?",
                    "Xác nhận xóa",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Items.Remove(item);
                    _view?.Refresh();
                }
            }
        }
    }
}
