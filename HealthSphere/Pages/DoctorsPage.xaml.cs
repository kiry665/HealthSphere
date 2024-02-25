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
using Microsoft.EntityFrameworkCore;


namespace HealthSphere.Pages
{
    /// <summary>
    /// Логика взаимодействия для DoctorsPage.xaml
    /// </summary>
    public partial class DoctorsPage : Page
    {
        private List<Doctor> items_list;
        public DoctorsPage()
        {
            InitializeComponent();
            CreateTable();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DoctorAddWindow window = new DoctorAddWindow();
            window.Show();
            window.Closed += HandleSecondWindowClosed;
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            List<Doctor> RemoveList = new List<Doctor> { };
            foreach (var item in Table.Items)
            {
                if (item is Doctor doctor)
                {
                    if (doctor.isSelect)
                    {
                        RemoveList.Add(doctor);
                    }
                }
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                db.doctors.RemoveRange(RemoveList);
                db.SaveChanges();
                CreateTable();
            }
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
        private void Table_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var prop = e.PropertyDescriptor as PropertyDescriptor;
            //e.Column.HeaderStyle = (sender as FrameworkElement).FindResource("StandardStyle") as Style;
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
                        HeaderStyle = (sender as FrameworkElement).FindResource("FilterStyle") as Style
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

                //e.Column.HeaderStyle = (sender as FrameworkElement).FindResource("FilterStyle") as Style;
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
                        DoctorAddWindow window = new DoctorAddWindow(item.id, item.last_name, item.first_name, item.patronymic, item.specialization.name_speciality);
                        window.Show();
                        window.Closed += HandleSecondWindowClosed;
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
            string[] substrings = searchTerm.Split(' ');
            string Last_name = substrings[0];
            string First_name = (substrings.Length >= 2) ? substrings[1] : "";
            string Patronymic = (substrings.Length >= 3) ? substrings[2] : "";

            if (items_list is List<Doctor> items)
            {
                var filteredData = items
                    .Where(item => item.last_name.Contains(Last_name) && item.first_name.Contains(First_name) && item.patronymic.Contains(Patronymic))
                    .ToList();

                Table.ItemsSource = filteredData;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                if (items_list is List<Doctor> items)
                {
                    var filteredData = items
                        .Where(item => (item.specializationid == 1))
                        .ToList();

                    Table.ItemsSource = filteredData;
                }
            }
        }

        
    }
}
