using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using O2matic.Utilities;
using System.Windows.Input;

namespace O2matic.ViewModel
{
    public class NavigationVM : Utilities.ViewModelBase
    {
        private Object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        
        public ICommand HomeCommand { get; set; }
        public ICommand DeviceCommand { get; set; }
        public ICommand EquipmentCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand OrderCommand { get; set; }
        public ICommand BussinessTripCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Device(object obj) => CurrentView = new DeviceVM();
        private void Equipment(object obj) => CurrentView = new EquipmentVM();
        private void Customer(object obj) => CurrentView = new CustomerVM();
        private void Order(object obj) => CurrentView = new OrderVM();
        private void BussinessTrip(object obj) => CurrentView = new BussinessTripVM();
        private void Settings(object obj) => CurrentView = new SettingsVM();


        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            DeviceCommand = new RelayCommand(Device);
            EquipmentCommand = new RelayCommand(Equipment);
            CustomerCommand = new RelayCommand(Customer);
            OrderCommand = new RelayCommand(Order);
            BussinessTripCommand = new RelayCommand(BussinessTrip);
            SettingsCommand = new RelayCommand(Settings);

            //Starter Pitch
            CurrentView = new HomeVM();
        }
    }
}
