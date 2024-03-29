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
    /// Логика взаимодействия для PatientInfoWindow.xaml
    /// </summary>
    public partial class PatientInfoWindow : Window
    {
        private int id;
        public PatientInfoWindow()
        {
            InitializeComponent();
        }
        public PatientInfoWindow(int id, string fio, string date, string sex, int policy)
        {
            InitializeComponent();
            fio_TB.Text = fio;
            
            using(ApplicationContext db = new ApplicationContext())
            {
                var records = db.records.Where(r => r.patientid == id).Include(r => r.doctor).ToList();
                Table_History.ItemsSource = records;
                Table_Current.ItemsSource = records.Where(r => r.time < TimeOnly.FromDateTime(DateTime.Now));
            }
        }

        private void Table_History_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var prop = e.PropertyDescriptor as PropertyDescriptor;
            if (prop != null)
            {
                e.Column.Header = prop.DisplayName;
            }

            if (prop.Name == "doctor")
            {
                e.Column = new DataGridTextColumn
                {
                    Header = "Доктор",
                    Binding = new Binding("doctor.fio"),
                    IsReadOnly = true
                };
            }

            if (prop.PropertyType == typeof(DateOnly))
            {
                DataGridTextColumn textColumn = e.Column as DataGridTextColumn;
                if (textColumn != null)
                {
                    textColumn.Binding.StringFormat = "dd.MM.yyyy";
                }
            }

            if (new[] { "patientid", "doctorid" }.Contains(prop.Name))
            {
                e.Cancel = true;
            }

            if (prop.PropertyType == typeof(TimeOnly))
            {
                DataGridTextColumn textColumn = e.Column as DataGridTextColumn;
                if (textColumn != null)
                {
                    Binding binding = (Binding)textColumn.Binding;
                    binding.StringFormat = "HH:mm";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RecordWindow window = new RecordWindow(fio_TB.Text);
            window.Show();
            this.Close();
        }
    }
}
