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
    /// Логика взаимодействия для ChangeLicences.xaml
    /// </summary>
    ///

    public partial class ChangeLicences : Window
    {
        licences licen;
        public ChangeLicences(licences licen)
        {
            InitializeComponent();
            date_get.SelectedDate = licen.licences_date  ;
            date_expire.SelectedDate = licen.expire_date;
            cmbcat.SelectedItem = licen.categorios;
            txtSeria.Text = Convert.ToString(licen.licences_series);
            txtNumber.Text = Convert.ToString( licen.licences_number);
            cmbDriver.SelectedItem = licen.driver_id;

            this.licen = licen;
        }

        private void SaveChange_Click(object sender, RoutedEventArgs e)
        {


            licen.licences_date = date_get.SelectedDate;
            licen.expire_date = date_expire.SelectedDate;
            licen.categorios = (cmbcat.SelectedItem as licences).categorios;
            licen.licences_series = Convert.ToInt32(txtSeria.Text);
            licen.licences_number = Convert.ToInt32(txtNumber.Text) ;
            licen.driver_id = (cmbDriver.SelectedItem as licences).driver_id  ;
        }

        private void txtNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtSeria_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
