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
        private ApplicationContext dbContext;
        private List<Specialization> RemoveList = new List<Specialization> { };
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
            PatientAddWindow window = new PatientAddWindow();
            window.Closed += HandleSecondWindowClosed;
            window.Show();
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            dbContext = new ApplicationContext();
            dbContext.specializations.RemoveRange(RemoveList);
            dbContext.SaveChanges();
            CreateTable();
        }
        private void CreateTable()
        {
            dbContext = new ApplicationContext();
            ObservableCollection<Specialization> specializations = new ObservableCollection<Specialization>(dbContext.specializations);
            SpecializationsTable.ItemsSource = specializations.ToList();
        }

        private void SpecializationsTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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

        private void SpecializationsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpecializationsTable.SelectedItems.Clear();
            SpecializationsTable.SelectedCells.Clear();
        }

        private void SpecializationsTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCellInfo cellInfo = SpecializationsTable.CurrentCell;
            if (cellInfo != null && cellInfo.IsValid)
            {
                object dataObject = cellInfo.Item;
                int columnIndex = cellInfo.Column.DisplayIndex;
                if (dataObject is Specialization specialization && columnIndex == 0)
                {
                    specialization.isSelect = !specialization.isSelect;
                    SpecializationsTable.Items.Refresh();
                    if (specialization.isSelect == true)
                    {
                        RemoveList.Add(specialization);
                    }
                    else
                    {
                        RemoveList.Remove(specialization);
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

            using (ApplicationContext context = new ApplicationContext())
            {
                var filteredData = context.specializations
                    .Where(item => item.name_speciality.Contains(searchTerm))
                    .ToList();
                SpecializationsTable.ItemsSource = filteredData;
            }
        }
    }
}
