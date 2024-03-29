using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window
    {
        private List<Patient> patients;
        private List<Specialization> specializations;
        private List<Doctor> doctors;
        public RecordWindow()
        {
            InitializeComponent();
            InitializeDatePicker();
            using (ApplicationContext db = new ApplicationContext())
            {
                patients = db.patients.ToList();
                specializations = db.specializations.ToList();
                doctors = db.doctors.ToList();
            }
            patients_CB.ItemsSource = patients.Select(p => p.fio).Order();
            specializations_CB.ItemsSource = specializations.Select(s => s.name_speciality).Order();
        }

        public RecordWindow(string fio)
        {
            InitializeComponent();
            InitializeDatePicker();
            using (ApplicationContext db = new ApplicationContext())
            {
                specializations = db.specializations.ToList();
                doctors = db.doctors.ToList();
            }
            patients_CB.Items.Add(fio);
            patients_CB.SelectedIndex = 0;
            specializations_CB.ItemsSource = specializations.Select(s => s.name_speciality).Order();
        }

        private void InitializeDatePicker()
        {
            datePicker.DisplayDateStart = DateTime.Today;
            datePicker.DisplayDateEnd = DateTime.Today.AddDays(14);
            for (DateTime date = DateTime.Today; date <= DateTime.Today.AddDays(14); date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    datePicker.BlackoutDates.Add(new CalendarDateRange(date));
                }
            }
        }

        private void specialization_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = specializations.FirstOrDefault(s => s.name_speciality == specializations_CB.SelectedItem.ToString());
            if (item != null)
            {
                doctors_CB.ItemsSource = doctors.Where(d => d.specializationid == item.id).Select(d => d.fio).Order();
            }
        }

        private void doctors_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datePicker.IsEnabled = true;
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                DateOnly date = DateOnly.FromDateTime(datePicker.SelectedDate.Value.Date);
                Doctor doctor = db.doctors.FirstOrDefault(d => d.fio == doctors_CB.SelectedItem.ToString());
                var times = db.times
                    .Where(t => t.shiftid == doctor.shiftid && !db.records
                        .Where(r => r.date == date && r.doctorid == doctor.id)
                        .Select(r => r.time)
                        .Contains(t.time))
                    .Select(t => t.time)
                    .ToList();

                if(datePicker.SelectedDate == DateTime.Today)
                {
                    times = times.Where(t => t > TimeOnly.FromDateTime(DateTime.Now)).ToList();
                }

                times_list.ItemsSource = times.Order();
            }
        }

        private void times_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time_tb.Text = times_list.SelectedItem.ToString();
            record_button.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Doctor doctor = db.doctors.First(d => d.fio == doctors_CB.SelectedItem.ToString());
                Patient patient = db.patients.First(p => p.fio == patients_CB.SelectedItem.ToString());
                Records record = new Records { patientid = patient.id, doctorid = doctor.id, date = DateOnly.FromDateTime(datePicker.SelectedDate.Value.Date), time = TimeOnly.Parse(time_tb.Text) };
                db.records.Add(record);
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
