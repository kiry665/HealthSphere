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
    /// Логика взаимодействия для PatientInfoWindow.xaml
    /// </summary>
    public partial class PatientInfoWindow : Window
    {
        public PatientInfoWindow()
        {
            InitializeComponent();
        }
        public PatientInfoWindow(int number, string fio, string date, string sex, int policy)
        {
            InitializeComponent();
            fio_TB.Text = fio;
        } 
    }
}
