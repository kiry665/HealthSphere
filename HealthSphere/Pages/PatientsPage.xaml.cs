using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private ApplicationContext dbContext;
        private List<Patient> RemoveList = new List<Patient> { };
        public PatientsPage()
        {
            InitializeComponent();
            CreateTable();
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
            dbContext.patients.RemoveRange(RemoveList);
            dbContext.SaveChanges();
            CreateTable();
        }
        private void CreateTable()
        {
            dbContext = new ApplicationContext();
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>(dbContext.patients);
            PatientsTable.ItemsSource = patients.ToList();
        }
        private void PatientsTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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

        private void PatientsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PatientsTable.SelectedItems.Clear();
            PatientsTable.SelectedCells.Clear();
        }

        private void PatientsTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCellInfo cellInfo = PatientsTable.CurrentCell;
            if (cellInfo != null && cellInfo.IsValid)
            {
                object dataObject = cellInfo.Item;
                int columnIndex = cellInfo.Column.DisplayIndex;
                if (dataObject is Patient patient && columnIndex == 0)
                {
                    patient.isSelect = !patient.isSelect;
                    PatientsTable.Items.Refresh();
                    if(patient.isSelect == true)
                    {
                        RemoveList.Add(patient);
                    }
                    else
                    {
                        RemoveList.Remove(patient);
                    }
                }
            }
        }
    }
}
