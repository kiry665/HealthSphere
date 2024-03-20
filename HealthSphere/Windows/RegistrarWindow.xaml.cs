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
using HealthSphere.Pages;

namespace HealthSphere.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrarWindow.xaml
    /// </summary>
    public partial class RegistrarWindow : Window
    {
        private PatientsPage PatientsPage = new PatientsPage();
        private DoctorsPage DoctorsPage = new DoctorsPage();
        public RegistrarWindow()
        {
            InitializeComponent();
            Frame2.Navigate(PatientsPage);
            Frame3.Navigate(DoctorsPage);
        }

        private void NewRecord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewPatient_Click(object sender, RoutedEventArgs e)
        {
            PatientAddWindow window = new PatientAddWindow();
            window.Show();
            window.Closed += (sender, e) => { PatientsPage.CreateTable(); };
        }
    }
}
