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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Sign.xaml
    /// </summary>
    public partial class Sign : Window
    {
        Entities6 en = new Entities6();
        public Sign()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Users users = en.Users.Where(x => x.user_login == txtlogin.Text && x.user_password == txtpassword.Password).FirstOrDefault();
            if(users == null)
            {
                MessageBox.Show("Не верный логин или пароль");
                return;
            }
            if(users.status_id == 1)
            {
                Users currentuser = new Users();
                this.Hide();
                MainWindow main = new MainWindow(currentuser);
                main.ShowDialog();
                this.Close();
            }
            //if (users.status_id == 3)
            //{
            //    this.Hide();
            //    MainWindow main = new MainWindow();
            //    main.ShowDialog();
            //    this.Close();
            //}


        }
    }
}
