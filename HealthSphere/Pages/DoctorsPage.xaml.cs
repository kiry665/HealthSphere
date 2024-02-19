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
using Microsoft.EntityFrameworkCore;

namespace HealthSphere.Pages
{
    /// <summary>
    /// Логика взаимодействия для DoctorsPage.xaml
    /// </summary>
    public partial class DoctorsPage : Page
    {
        private ApplicationContext dbContext;
        private List<Doctors> RemoveList = new List<Doctors> { };
        public DoctorsPage()
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
            dbContext = new ApplicationContext();
            dbContext.doctors.RemoveRange(RemoveList);
            dbContext.SaveChanges();
            CreateTable();
        }
        private void CreateTable()
        {
            dbContext = new ApplicationContext();
            ObservableCollection<Doctors> doctors = new ObservableCollection<Doctors>(dbContext.doctors);
            DoctorsTable.ItemsSource = doctors.ToList();

            

        }
        private void DoctorsTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var prop = e.PropertyDescriptor as PropertyDescriptor;
            if (prop != null)
            {
                e.Column.Header = prop.DisplayName;

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

        private void DoctorsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DoctorsTable.SelectedItems.Clear();
            DoctorsTable.SelectedCells.Clear();
        }

        private void DoctorsTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCellInfo cellInfo = DoctorsTable.CurrentCell;
            if (cellInfo != null && cellInfo.IsValid)
            {
                object dataObject = cellInfo.Item;
                int columnIndex = cellInfo.Column.DisplayIndex;
                if (dataObject is Doctors doctors && columnIndex == 0)
                {
                    doctors.isSelect = !doctors.isSelect;
                    DoctorsTable.Items.Refresh();
                    if (doctors.isSelect == true)
                    {
                        RemoveList.Add(doctors);
                    }
                    else
                    {
                        RemoveList.Remove(doctors);
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


            using (ApplicationContext context = new ApplicationContext())
            {
                var filteredData = context.doctors
                    .Where(item => item.last_name.Contains(Last_name) && item.first_name.Contains(First_name) && item.patronymic.Contains(Patronymic))
                    .ToList();
                DoctorsTable.ItemsSource = filteredData;
            }
        }
    }
}
