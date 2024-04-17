using HealthSphere.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HealthSphere.Windows
{
    /// <summary>
    /// Логика взаимодействия для DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        private int doctorId;
        public DoctorWindow(int doctorId)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            CreateTables();
            InitCB();
        }

        private void CreateTables()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Records.ItemsSource = db.records.Where(r => r.doctorid == doctorId).Include(p => p.patient).ToList();
            }
            using(ApplicationContext db = new ApplicationContext())
            {
                
            }
        }
        private void InitCB()
        {
            List<String> daysList = new List<String>();
            DateTime currentDay = DateTime.Today;
            int days = 0;
            while(days < 5)
            {
                if(currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    daysList.Add(currentDay.ToString("dd.MM.yyyy"));
                    days++;
                }
                currentDay = currentDay.AddDays(1);
            }
            DateCB.ItemsSource = daysList;
        }

        private void Records_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var prop = e.PropertyDescriptor as PropertyDescriptor;
            if (prop != null)
            {
                e.Column.Header = prop.DisplayName;
            }

            if (prop.Name == "patient")
            {
                e.Column = new DataGridTextColumn
                {
                    Header = "Пациент",
                    Binding = new Binding("patient.fio"),
                    IsReadOnly = true
                };
            }
            if (new[] { "patientid", "doctorid", "doctor" }.Contains(prop.Name))
            {
                e.Cancel = true;
            }

            if (prop.PropertyType == typeof(DateOnly))
            {
                DataGridTextColumn textColumn = e.Column as DataGridTextColumn;
                if (textColumn != null)
                {
                    textColumn.Binding.StringFormat = "dd.MM.yyyy";
                }
            }
        }

        private void DateCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dateString = DateCB.SelectedItem.ToString();
            DateOnly date = DateOnly.ParseExact(dateString, "dd.MM.yyyy", null);
            using(ApplicationContext db = new ApplicationContext())
            {
                Records.ItemsSource = db.records.Where(r => (r.doctorid == doctorId) && (r.date == date)).Include(p => p.patient).ToList();
            }
        }

        private void Records_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && sender is DataGrid dataGrid)
            {
                DataGridCellInfo cellInfo = Records.CurrentCell;
                if (cellInfo != null && cellInfo.IsValid)
                {
                    object dataObject = cellInfo.Item;
                    if (dataObject is Records item)
                    {
                        if (!item.completed)
                        {
                            AppointmentWindow window = new AppointmentWindow(item.patientid, doctorId, item.id);
                            window.Show();
                            window.Closed += (sender, e) => { CreateTables(); };
                        }
                        else
                        {
                            AppointmentWindow window = new AppointmentWindow(item.id);
                            window.Show();
                        }
                    }
                }
            }
        }
    }
}
