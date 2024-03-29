using HealthSphere.Windows;
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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            User user = null;
            string login = LoginTB.Text.Trim();
            string password = PasswordTB.Password.Trim();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var item in db.users.Where(u => u.login == login && u.password == password).ToHashSet())
                {
                    user = item;
                };
            }
            if (user != null)
            {
                if(user.level == 1)
                {
                    RegistrarWindow window = new RegistrarWindow();
                    window.Show();
                    this.Close();
                }
            }
        }
    }
}
