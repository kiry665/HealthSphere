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
    /// Логика взаимодействия для DoctorAddWindow.xaml
    /// </summary>
    public partial class DoctorAddWindow : Window
    {
        public DoctorAddWindow()
        {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {
                List<string> list = db.specializations.Select(s => s.name_speciality).ToList();
                spec_cb.ItemsSource = list.Order();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            if (first_nameTB.Text == "")
            {
                first_nameTB.Foreground = Brushes.Red;
                flag = false;
            }
            if (last_nameTB.Text == "")
            {
                last_nameTB.Foreground = Brushes.Red;
                flag = false;
            }
            if (patronymic_nameTB.Text == "")
            {
                patronymic_nameTB.Foreground = Brushes.Red;
                flag = false;
            }
            if(spec_cb.SelectedIndex == -1)
            {
                spec_cb.Foreground = Brushes.Red;
                flag = false;
            }
            if (!flag) return;
            using (ApplicationContext db = new ApplicationContext())
            {
                string fio = last_nameTB.Text.Trim() + " " + first_nameTB.Text.Trim() + " " + patronymic_nameTB.Text.Trim();
                int id = db.specializations.Where(s => s.name_speciality == spec_cb.SelectedItem.ToString())
                    .Select(p => p.id)
                    .FirstOrDefault();
                Doctor doctor = new Doctor { fio = fio, specializationid = id };
                db.doctors.Add(doctor);
                db.SaveChanges();
                this.Close();
            }
        }
        private void spec_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                cb.Foreground = Brushes.Black;
            }
        }
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }
    }
}
