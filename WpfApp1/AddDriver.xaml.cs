using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddDriver.xaml
    /// </summary>
    public partial class AddDriver : Window
    {
        Entities6 en = new Entities6();
        ImageSourceConverter converter = new ImageSourceConverter();
        byte[] photo;
        public AddDriver()
        {
            InitializeComponent();

            cmbRegion.ItemsSource = en.Region.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                photo = File.ReadAllBytes(openFile.FileName);
                imgphoto.Source = converter.ConvertFrom(openFile.FileName) as ImageSource;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Drivers drivers = new Drivers();
            drivers.firstname = txtName.Text;
            drivers.lastname = txtSurname.Text;
            drivers.middlename = txtmidlname.Text;
            drivers.passport_serial = Convert.ToInt32(txtSeria.Text);
            drivers.passport_number = Convert.ToInt32(txtNumber.Text);
            drivers.postcode = Convert.ToInt32(txtPostcode.Text);
            drivers.address_life = txtaddress.Text;
            drivers.jobname = txtJobname.Text;
            drivers.company = txtWork.Text;
            drivers.phone = txtPhone.Text;
            drivers.email = txtEmail.Text;
            drivers.photo = photo;

            Region region = cmbRegion.SelectedValue as Region;
            if (region != null)
            {
                drivers.region = region.id;
            }

            try
            {
                en.Drivers.Add(drivers);
                en.SaveChanges();
                MessageBox.Show("Добавлена!!!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось добавить!!!");
            }


        }

        
    }
}
