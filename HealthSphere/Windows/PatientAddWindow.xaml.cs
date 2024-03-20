using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public PatientAddWindow(int number, string fio, string date, string sex, int policy)
        {
            InitializeComponent();
            id = number;
            change = true;

            string[] substings = fio.Split(' ');
            last_nameTB.Text = substings[0];
            first_nameTB.Text = substings[1];
            patronymic_nameTB.Text = substings[2];

            birthday.Text = date;
            policyTB.Text = policy.ToString();
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
            if(policyTB.Text == "" || policyTB.Text.Length < 6)
            {
                policyTB.Foreground = Brushes.Red;
                flag = false;
            }
            if (flag && !change)
            {
                string fio = last_nameTB.Text.Trim() + " " + first_nameTB.Text.Trim() + " " + patronymic_nameTB.Text.Trim();
                Patient patient = new Patient { fio = fio,  date = DateOnly.Parse(birthday.Text), sex = male.IsChecked.GetValueOrDefault() ? "М" : "Ж", policy_number = Int32.Parse(policyTB.Text)};
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
                        string fio = last_nameTB.Text.Trim() + " " + first_nameTB.Text.Trim() + " " + patronymic_nameTB.Text.Trim();
                        patient.fio = fio;
                        patient.date = DateOnly.Parse(birthday.Text);
                        patient.sex = male.IsChecked.GetValueOrDefault() ? "М" : "Ж";
                        patient.policy_number = Int32.Parse(policyTB.Text);
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

        private void policyTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"^\d$"))
            {
                e.Handled = true; // Если это не число, отменяем событие
            }
        }
    }
}
