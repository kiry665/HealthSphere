using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthSphere.Pages
{
    /// <summary>
    /// Логика взаимодействия для SpecializationPage.xaml
    /// </summary>
    public partial class SpecializationsPage : Page
    {
        private List<Specialization> CheckList = new List<Specialization> { };
        private List<Specialization> items_list;
        public SpecializationsPage()
        {
            InitializeComponent();
            CreateTable();


            BitmapImage image = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(Properties.Resources.search))
            {
                image.BeginInit();
                image.StreamSource = stream;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
            }
            ImageControl.Source = image;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void CreateTable()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Table.ItemsSource = null;
                ObservableCollection<Specialization> items = new ObservableCollection<Specialization>(db.specializations);
                Table.ItemsSource = items.ToList();
                items_list = items.ToList();
            }
        }
        private void Table_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var prop = e.PropertyDescriptor as PropertyDescriptor;
            if (prop != null)
            {
                e.Column.Header = prop.DisplayName;

            }
        }
        public void HandleSecondWindowClosed(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Table.SelectedItems.Clear();
            Table.SelectedCells.Clear();
        }

        private void Table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCellInfo cellInfo = Table.CurrentCell;
            if (cellInfo != null && cellInfo.IsValid)
            {
                object dataObject = cellInfo.Item;
                int columnIndex = cellInfo.Column.DisplayIndex;
                if (dataObject is Specialization item && columnIndex == 0)
                {
                    item.isSelect = !item.isSelect;
                    Table.Items.Refresh();
                    if (item.isSelect == true)
                    {
                        CheckList.Add(item);
                    }
                    else
                    {
                        CheckList.Remove(item);
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string text = textBox.Text;
                UpdateDataGrid(text);
            }
        }
        private void UpdateDataGrid(string searchTerm)
        {
            if (items_list is List<Specialization> items)
            {
                var filteredData = items
                    .Where(item => item.name_speciality.Contains(searchTerm))
                    .ToList();

                Table.ItemsSource = filteredData;
            }
        }
    }
}
