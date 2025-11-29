using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace DMR2020.View
{
    public partial class SetupWindow : Window
    {
        public ObservableCollection<TestItem> Items { get; set; }

        public SetupWindow()
        {
            InitializeComponent();

            Items = new ObservableCollection<TestItem>
            {
                new TestItem { TestName = "Tensile Test A", CreatedTime = DateTime.Now.AddMinutes(-15) },
                new TestItem { TestName = "Compression Test B", CreatedTime = DateTime.Now }
            };

            LvTests.ItemsSource = Items;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement)?.DataContext as TestItem;
            if (item != null)
            {
                MessageBox.Show($"Edit: {item.TestName}");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement)?.DataContext as TestItem;
            if (item != null)
            {
                Items.Remove(item);
            }
        }
    }

    public class TestItem
    {
        public string TestName { get; set; }
        public DateTime CreatedTime { get; set; }

        // Format yêu cầu: dd/MM/yyyy HH:mm:ss
        public string CreatedTimeFormatted =>
            CreatedTime.ToString("dd/MM/yyyy HH:mm:ss");
    }
}
