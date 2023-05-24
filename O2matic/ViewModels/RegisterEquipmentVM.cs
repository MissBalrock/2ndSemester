using O2matic.Models;
using O2maticTracking.Models;
using O2maticTracking.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace O2maticTracking.ViewModels
{
    public class RegisterEquipmentVM : INotifyPropertyChanged
    {
        private readonly O2maticRepo _repository;

        public RegisterEquipmentVM()
        {
            _repository = new O2maticRepo();

            EquipmentTypes = new ObservableCollection<EquipmentType>(_repository.GetEquipmentTypes());
            Locations = new ObservableCollection<Location>(_repository.GetLocations());

           SubmitCommand = new RelayCommand((obj) => Submit());
        }

        public ObservableCollection<EquipmentType> EquipmentTypes { get; }

        public ObservableCollection<Location> Locations { get; }

        public EquipmentType SelectedEquipmentType { get; set; }

        public Location SelectedLocation { get; set; }

        public string SerialNumber { get; set; }

        public ICommand SubmitCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Submit()
        {

            var equipmentType = SelectedEquipmentType;
            var location = SelectedLocation;
            var serialNumber = int.Parse(SerialNumber);
            var toSave = new Equipment(equipmentType.Id, serialNumber, DateTime.Now, location.Id);

            _repository.Save(toSave);

        }

    }
    
}
