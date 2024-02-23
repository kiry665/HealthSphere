using HealthSphere.Pages;
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
using System.Windows.Shapes;

namespace HealthSphere.Windows
{
    /// <summary>
    /// Логика взаимодействия для BasicWindow.xaml
    /// </summary>
    public partial class BasicWindow : Window
    {
        private ApplicationContext dbContext;
        public BasicWindow()
        {
            InitializeComponent();
            Frame.Navigate(new UniversalTablePage());
            Frame2.Navigate(new DoctorsPage());
            Frame3.Navigate(new SpecializationsPage());
        }
        
    }
}
