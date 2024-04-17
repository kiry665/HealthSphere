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
    /// Логика взаимодействия для AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        private int patientId;
        private int doctorId;
        private int recordId;
        public AppointmentWindow(int patientId, int doctorId, int recordId)
        {
            InitializeComponent();
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.recordId = recordId;
            InitForm();
        }
        
        public AppointmentWindow(int recordId)
        {
            InitializeComponent();
            this.recordId = recordId;
            using(ApplicationContext db = new ApplicationContext())
            {
                Appointment appointment = db.appointments.First(a => a.recordid == recordId);
                this.doctorId = appointment.doctorid;
                this.patientId = appointment.patientid;
                InitForm();
                Mkb mkb = db.mkb.First(m => m.id == appointment.mkbid);
                mkbCB.SelectedItem = mkb.code;
                mkbTB.Text = mkb.description;
                resultTB.Text = appointment.result;
            }
            mkbCB.IsReadOnly = true;
            mkbCB.IsHitTestVisible = false;
            resultTB.IsReadOnly = true;
            SaveButton.IsEnabled = false;
        }

        private void InitForm()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Patient patient = db.patients.First(p => p.id == patientId);
                fio_TB.Text = patient.fio;
                birth_TB.Text += patient.date.ToShortDateString();
                policy_TB.Text += patient.policy_number.ToString();
                mkbCB.ItemsSource = db.mkb.Select(m => m.code).ToList();
            }
        }

        private void mkbCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                mkbTB.Text = db.mkb.First(m => m.code == mkbCB.SelectedItem.ToString()).description;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                int mkbId = db.mkb.First(m => m.code == mkbCB.SelectedItem.ToString()).id;
                Appointment appointment = new Appointment { doctorid = doctorId, patientid = patientId, recordid = recordId, mkbid = mkbId, result = resultTB.Text };
                db.appointments.Add(appointment);

                Records record = db.records.First(r => r.id == recordId);
                record.completed = true;

                db.SaveChanges();

                this.Close();
            }
        }
    }
}
