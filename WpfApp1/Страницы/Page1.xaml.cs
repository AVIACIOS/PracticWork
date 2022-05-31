using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WpfApp1.Окно;

namespace WpfApp1
{
    
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 
    {
        Entities6 en = new Entities6();   
        public Page1()
        {
            InitializeComponent();

            gridDrivers.ItemsSource = en.Drivers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddDriver driver = new AddDriver();
            driver.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Drivers drivers = gridDrivers.SelectedValue as Drivers;
            if(drivers != null)
            {
                en.Drivers.Remove(drivers);
                en.SaveChanges();

                gridDrivers.ItemsSource = null;
                gridDrivers.ItemsSource = en.Drivers.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            

            Drivers drivers = gridDrivers.SelectedValue as Drivers;
            if (drivers != null)
            {
                ChangeDriver changeDriver = new ChangeDriver(drivers);

                changeDriver.ShowDialog();
                

                gridDrivers.ItemsSource = null;
                gridDrivers.ItemsSource = en.Drivers.ToList();
            }
            
        }

        
    }
}
