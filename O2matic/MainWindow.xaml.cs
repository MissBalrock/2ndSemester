using O2matic.Views;
using O2maticTracking.Models;
using O2maticTracking.Repositories;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace O2matic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    RegisterEquipment registerEquipment = new RegisterEquipment();
        //    registerEquipment.Show();
        //}

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            O2maticRepo repo = new O2maticRepo();
            var locations = repo.GetLocations();




            var addresses = repo.GetAddresses();
            foreach (Location current in locations)
            {

                var address = addresses.First(a => a.Id == current.AddressId);
                //var address = repo.GetAddress(current.AddressId);
                current.Address = address;


            }



        }
    }
}
