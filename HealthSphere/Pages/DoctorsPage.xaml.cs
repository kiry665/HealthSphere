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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HealthSphere.Windows;
using Microsoft.EntityFrameworkCore;


namespace HealthSphere.Pages
{
    /// <summary>
    /// Логика взаимодействия для DoctorsPage.xaml
    /// </summary>
    public partial class DoctorsPage : Page
    {
        private List<Doctor> items_list;
        private string search_fio = "";
        private string search_spec = "";
        public DoctorsPage()
        {
            InitializeComponent();
            CreateTable();
            InitComboBox();
        }

        private void CreateTable()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var doctors = db.doctors.Include(d => d.specialization).ToList();
                Table.ItemsSource = doctors;
                items_list = doctors;
            }
        }
        public void InitComboBox()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                List<String> specializations = db.specializations.Select(s => s.name_speciality).ToList();
                specializations.Insert(0, "");
                spec_cb.ItemsSource = specializations;
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

                if (prop.Name == "specialization")
                {
                    e.Column = new DataGridTextColumn
                    {
                        Header = "Специализация",
                        Binding = new Binding("specialization.name_speciality"),
                        IsReadOnly = true
                    };
                }

                if (prop.Name == "specializationid")
                {
                    e.Cancel = true;
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

        private void Table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && sender is DataGrid dataGrid)
            {
                DataGridCellInfo cellInfo = Table.CurrentCell;
                if (cellInfo != null && cellInfo.IsValid)
                {
                    object dataObject = cellInfo.Item;
                    if (dataObject is Doctor item)
                    {
                        
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                search_fio = textBox.Text;
                UpdateDataGrid();
            }
        }
        private void UpdateDataGrid()
        {
            if (items_list is List<Doctor> items)
            {
                var filteredData = items
                    .Where(item => item.fio.Contains(search_fio) && item.specialization.name_speciality.Contains(search_spec))
                    .ToList();

                Table.ItemsSource = filteredData;
            }
        }

        private void spec_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            search_spec = spec_cb.SelectedItem.ToString();
            UpdateDataGrid();
        }
    }
}
