using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для PatientAddWindow.xaml
    /// </summary>
    public partial class PatientAddWindow : Window
    {
        private bool change = false;
        private int id;
        public PatientAddWindow()
        {
            InitializeComponent();
        }
        public PatientAddWindow(int number, string last_name, string first_name, string patronymic, string date, string sex)
        {
            InitializeComponent();
            id = number;
            change = true;
            last_nameTB.Text = last_name;
            first_nameTB.Text = first_name;
            patronymic_nameTB.Text = patronymic;
            birthday.Text = date;
            if(sex == "М")
            {
                male.IsChecked = true;
            }
            else
            {
                female.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            if(first_nameTB.Text == "")
            {
                first_nameTB.Foreground = Brushes.Red;
                flag = false;
            }
            if(last_nameTB.Text == "")
            {
                last_nameTB.Foreground = Brushes.Red;
                flag = false;
            }
            if(patronymic_nameTB.Text == "")
            {
                patronymic_nameTB.Foreground = Brushes.Red;
                flag = false;
            }
            if (birthday.SelectedDate == null)
            {
                birthday.Foreground = Brushes.Red;
                flag = false;
            }
            if(!(male.IsChecked.GetValueOrDefault() || female.IsChecked.GetValueOrDefault()))
            {
                male.Foreground = Brushes.Red;
                female.Foreground = Brushes.Red;
                flag = false;
            }
            if (flag && !change)
            {
                Patient patient = new Patient { last_name = last_nameTB.Text, first_name = first_nameTB.Text, patronymic = patronymic_nameTB.Text, date = DateOnly.Parse(birthday.Text), sex = male.IsChecked.GetValueOrDefault() ? "М" : "Ж"};
                using(ApplicationContext db = new ApplicationContext())
                {
                    db.patients.Add(patient);
                    db.SaveChanges();
                    this.Close();
                }
            }
            if(flag && change)
            {
                using(ApplicationContext db = new ApplicationContext())
                {
                    var patient = db.patients.FirstOrDefault(p => p.id == id);
                    if(patient != null)
                    {
                        patient.last_name = last_nameTB.Text;
                        patient.first_name = first_nameTB.Text;
                        patient.patronymic = patronymic_nameTB.Text;
                        patient.date = DateOnly.Parse(birthday.Text);
                        patient.sex = male.IsChecked.GetValueOrDefault() ? "М" : "Ж";
                    }
                    db.SaveChanges();
                    this.Close();
                }
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void DateChanged(object sender, KeyEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if(datePicker != null)
            {
                datePicker.Foreground = Brushes.Black;
            }
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            male.Foreground = Brushes.Black;
            female.Foreground = Brushes.Black;
        }

        private void DateChanged(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if (datePicker != null)
            {
                datePicker.Foreground = Brushes.Black;
            }
        }

        
    }
}
