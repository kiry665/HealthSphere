using Microsoft.EntityFrameworkCore;
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
using HealthSphere.Windows;

namespace HealthSphere.Pages
{
    /// <summary>
    /// Логика взаимодействия для UniversalTablePage.xaml
    /// </summary>
    public partial class UniversalTablePage : Page
    {
       
        private List<Patient> items_list;
        public UniversalTablePage()
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
            PatientAddWindow window = new PatientAddWindow();
            window.Closed += HandleSecondWindowClosed;
            window.Show();
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            List<Patient> RemoveList = new List<Patient> { };
            foreach (var item in Table.Items)
            {
                if (item is Patient patient)
                {
                    if (patient.isSelect)
                    {
                        RemoveList.Add(patient);
                    }
                }
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                db.patients.RemoveRange(RemoveList);
                db.SaveChanges();
                CreateTable();
            }
        }
        private void CreateTable()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Table.ItemsSource = null;
                ObservableCollection<Patient> items = new ObservableCollection<Patient>(db.patients);
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

                if (prop.Name == "isSelect")
                {
                    e.Column.IsReadOnly = false;
                }

                if (prop.PropertyType == typeof(DateOnly))
                {
                    DataGridTextColumn textColumn = e.Column as DataGridTextColumn;
                    if (textColumn != null)
                    {
                        textColumn.Binding.StringFormat = "dd.MM.yyyy"; // Формат "день.месяц.год"
                    }
                }
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
            string[] substrings = searchTerm.Split(' ');
            string Last_name = substrings[0];
            string First_name = (substrings.Length >= 2) ? substrings[1] : "";
            string Patronymic = (substrings.Length >= 3) ? substrings[2] : "";

            if (items_list is List<Patient> items)
            {
                var filteredData = items
                    .Where(item => item.last_name.Contains(Last_name) && item.first_name.Contains(First_name) && item.patronymic.Contains(Patronymic))
                    .ToList();

                Table.ItemsSource = filteredData;
            }
        }

        private void Table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && sender is DataGrid dataGrid)
            {
                DataGridCellInfo cellInfo = Table.CurrentCell;
                if (cellInfo != null && cellInfo.IsValid)
                {
                    object dataObject = cellInfo.Item;
                    if (dataObject is Patient item)
                    {
                        PatientAddWindow window = new PatientAddWindow(item.id, item.last_name, item.first_name, item.patronymic, item.date.ToString(), item.sex);
                        window.Show();
                        window.Closed += HandleSecondWindowClosed;
                    }
                }
            }
        }
    }
}
