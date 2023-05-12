using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace O2matic.Persistens
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public object Lokation { get; private set; }

        public Window1()
        {
            InitializeComponent();
        }


        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Date.Items.Add("17-06-2023");
            Date.Items.Add("10-07-2023");
            Date.Items.Add("12-08-2023");
            //clear the second combo
            EquipmentType.Items.Clear();
            // add some items to the box based on the selected item in the first box
            switch (EquipmentType.SelectedItem.ToString())
            {
                case "17-06-2023":
                    EquipmentType.Items.Add("PRO");
                    EquipmentType.Items.Add("PRO");
                    break;
                case "10-07-2023":
                    EquipmentType.Items.Add("PRO");
                    EquipmentType.Items.Add("HOT");
                    break;
                case "12-08-2023":
                    EquipmentType.Items.Add("PRO");
                    EquipmentType.Items.Add("HOT");
                    break;

                    EquipmentType.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to save this", MessageBoxButton.YesNo);
            if (result==DialogResult.Yes)
            {
                var form2 = new Form2();
                form2.ShowDialog();

            }
            else
            {
                Console.WriteLine("the equiptment is not saved");
            }
            //if (MessageBox.Show("Are you sure you want to save this", "Save", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    Console.WriteLine("Saved");
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to save this edit");
        }

        private void EquiptmentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EquipmentType.IsEnabled = true;

            List<string> types = new List<string>();
            types.Add("HOt");
            types.Add("PRO");
            //  OR  
            //EquipmentType.Items.Add("PRO");
            //EquipmentType.Items.Add("HOT");

            switch (EquipmentType.SelectedItem.ToString())
            {
                case "PRO":
                    lokation.Items.Add("Madrigal 205, 4587");
                    lokation.Items.Add("Alapo 57, 5675");
                    break;
                case "HOT":
                    lokation.Items.Add("Avai 34, 5786");
                    lokation.Items.Add("Madrigal 205, 4587");
                    break;

            }



        }

        private void Lokation_load(object sender, EventArgs e)
        {
            lokation.Items.Clear();
            List<string> lokationValues = new List<string>();
            lokationValues.Add("Madrigal 205, 4587");
            lokationValues.Add("Alapo 57, 5675");
            lokationValues.Add("Avai 34, 5786");

            BindingSource bindingSource = new BindingSource(lokationValues);
            bindingSource.DataSource = lokationValues;
            lokation.DataSource = lokationValues;

        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lokation.SelectionChanged += ComboBox_SelectionChanged;
            quantity.Text = lokation.SelectedItem.ToString();
        }
    }

    internal class BindingSource
    {
        internal List<string> DataSource;
        private List<string> lokationValues;

        public BindingSource(List<string> lokationValues)
        {
            this.lokationValues = lokationValues;
        }
    }
}
