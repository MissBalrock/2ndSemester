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
using System.Windows.Shapes;

namespace O2matic.Views
{
    /// <summary>
    /// Interaction logic for RegisterEquipment.xaml
    /// </summary>
   public partial class RegisterEquipment : Window
        {
        private readonly O2maticRepo o2MaticRepo;

            public RegisterEquipment()
            {
                InitializeComponent();
                o2MaticRepo = new O2maticRepo();

                //LoadEquipmentTypes();
                //LoadLocations();
            }

            //private void LoadEquipmentTypes()
            //{
            //    var equipmentTypes = o2MaticRepo.GetAllEquipmentTypes();
            //    cmbEquipmentType.ItemsSource = equipmentTypes;
            //}

            //private void LoadLocations()
            //{
            //    var locations = o2MaticRepo.GetAllLocations();
            //    cmbLocation.ItemsSource = locations;
            //}

            private void btnSubmit_Click(object sender, RoutedEventArgs e)
            {
                var equipmentType = cmbEquipmentType.SelectedItem as string;
                var serialNumber = txtSerialNumber.Text;
                var location = cmbLocation.SelectedItem as string;

                MessageBox.Show($"Equipment Type: {equipmentType}\nSerial Number: {serialNumber}\nLocation: {location}");
                // Handle the submission logic here...
            }
    }
}

