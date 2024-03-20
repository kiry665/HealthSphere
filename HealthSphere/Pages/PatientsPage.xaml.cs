using HealthSphere.Windows;
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

namespace HealthSphere
{
    /// <summary>
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {

        private List<Patient> items_list;
        public PatientsPage()
        {
            InitializeComponent();
            CreateTable();
        }

        public void CreateTable()
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

                if (prop.Name != "isSelect")
                {
                    e.Column.IsReadOnly = true;
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
            if (items_list is List<Patient> items)
            {
                var filteredData = items
                    .Where(item => (item.fio.Contains(searchTerm)) || item.policy_number.ToString().Contains(searchTerm))
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
                        PatientInfoWindow window = new PatientInfoWindow(item.id, item.fio, item.date.ToString(), item.sex, item.policy_number);
                        window.Show();
                    }
                }
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            DataGridCellInfo cellInfo = Table.CurrentCell;
            if (cellInfo != null && cellInfo.IsValid)
            {
                object dataObject = cellInfo.Item;
                if (dataObject is Patient item)
                {
                    PatientAddWindow window = new PatientAddWindow(item.id, item.fio, item.date.ToString(), item.sex, item.policy_number);
                    window.Show();
                    window.Closed += (sender, e) => { CreateTable(); };
                }
            }
        }
    }
}
