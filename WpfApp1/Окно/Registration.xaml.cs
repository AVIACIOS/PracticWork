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

namespace WpfApp1.Окно
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        Entities6 en = new Entities6();
        
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users() { user_login = txtLogin.Text, user_password=txtLogin.Text, status_id=3 };
            en.Users.Add(user);
            en.SaveChanges();
            Sign sign = new Sign();
            sign.Show();
            this.Close();
        }

        private void AutorisationUser_Click(object sender, RoutedEventArgs e)
        {
            Sign sign = new Sign();
            sign.Show();
            this.Close();
        }
    }
}
