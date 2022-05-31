using System;
using System.Collections.Generic;
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

namespace WpfApp1.Окно
{
   
    /// <summary>
    /// Логика взаимодействия для ChangeDriver.xaml
    /// </summary>
    public partial class ChangeDriver : Window
    {
        Entities6 en = new Entities6();
        ImageSourceConverter converter = new ImageSourceConverter();
        byte[] photo;

        Drivers drivers;
        public ChangeDriver(Drivers drivers)
        {
            InitializeComponent();

            cmbRegion.ItemsSource = en.Region.ToList();
            //imgphoto.Source = converter.ConvertFrom(drivers.photo) as ImageSource;

            

            txtName.Text = drivers.firstname;
            txtSurname.Text = drivers.lastname;
            txtmidlname.Text = drivers.middlename;
            txtSeria.Text = Convert.ToString(drivers.passport_serial);
            txtNumber.Text = Convert.ToString(drivers.passport_number);
            txtPostcode.Text = Convert.ToString(drivers.postcode);
            txtaddress.Text = drivers.address_life;
            txtJobname.Text = drivers.jobname;
            txtWork.Text = drivers.company;
            txtPhone.Text = drivers.phone;
            txtEmail.Text = drivers.email;
            photo = drivers.photo;

            this.drivers = drivers;
            //добавление 
           

        }

        private void SaveChange_Click(object sender, RoutedEventArgs e)
        {
            string patternEmail = @"(@)(.+)$";


            if (Regex.IsMatch(txtEmail.Text, patternEmail, RegexOptions.IgnoreCase))
            {


                try
                {

                    Drivers driversedit = en.Drivers.Where(x => x.id == drivers.id).FirstOrDefault();
                    driversedit.firstname = txtName.Text;
                    driversedit.lastname = txtSurname.Text;
                    driversedit.middlename = txtmidlname.Text;
                    driversedit.passport_serial = Convert.ToInt32(txtSeria.Text);
                    driversedit.passport_number = Convert.ToInt32(txtNumber.Text);
                    driversedit.postcode = Convert.ToInt32(txtPostcode.Text);
                    driversedit.address_life = txtaddress.Text;
                    driversedit.jobname = txtJobname.Text;
                    driversedit.company = txtWork.Text;
                    driversedit.phone = txtPhone.Text;
                    driversedit.email = txtEmail.Text;
                    driversedit.photo = photo;

                    en.SaveChanges();

                }
                catch
                {
                    MessageBox.Show("Вы ввели неверные данные");
                }


                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void txtNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!(e.Text == ",")))
            {
                e.Handled = true;               
            }                  
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            if (!Char.IsDigit(e.Text, 0) && (!(e.Text == ",")))
            {
                e.Handled = true;
            }
            if (!(txtPhone.Text[0] == '+'))
            {
                 

                
            }


        }

        private void txtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) && ((e.Text == ",")))
            {
                e.Handled = true;
            }
        }

        private void txtSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) && ((e.Text == ",")))
            {
                e.Handled = true;
            }
        }

        private void txtmidlname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) && ((e.Text == ",")))
            {
                e.Handled = true;
            }
        }

        private void txtSeria_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!(e.Text == ",")))
            {
                e.Handled = true;
            }
        }

        private void txtPostcode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (!(e.Text == ",")))
            {
                e.Handled = true;
            }
        }
    }
}
