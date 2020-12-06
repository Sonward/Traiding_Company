using BuisnesLogicLayer.Interfaces;
using DTO;
using TCWPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCWPF.ViewModels
{
    public class OrdersDetailsViewModel : INotifyPropertyChanged
    {
        private IConNodeManager _manager;

        private ConnectionNodeDTO _order;
        public ConnectionNodeDTO Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        public List<CustomerDataDTO> Customers { get; set; }
        public List<ItemDTO> Items { get; set; }
        public List<StatusDTO> Statuses { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public OrdersDetailsViewModel(IConNodeManager manager, ConnectionNodeDTO order)
        {
            _manager = manager;
            Order = order ?? new ConnectionNodeDTO();
            Customers = _manager.GetListOfCustomers();
            Items = _manager.GetListOfItems();
            Statuses = _manager.GetListOfStatuses();
        }

        public void Save()
        {
            Order = _manager.UpdateNode(Order);
        }
    }
}
