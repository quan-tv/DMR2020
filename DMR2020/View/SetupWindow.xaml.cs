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

        // Nút Add (bạn có thể thay bằng mở window tạo test mới)
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Items.Add(new TestItem
            {
                TestName = "New Test",
                CreatedTime = DateTime.Now
            });
        }

        // Nút Edit
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is TestItem item)
            {
                MessageBox.Show($"Edit: {item.TestName}",
                    "Edit",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                // TODO: mở Setup chi tiết để sửa item
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
                }
            }
        }
    }
}
