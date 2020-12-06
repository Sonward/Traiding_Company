using BuisnesLogicLayer.Interfaces;
using DTO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TCWPF.ViewModels
{
    public class OrdersListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private IConNodeManager _manager;
        private ObservableCollection<ConnectionNodeDTO> _ordersList;
        public ObservableCollection<ConnectionNodeDTO> OrdersList
        {
            get { return _ordersList; }
            set
            {
                _ordersList = value;
                OnPropertyChanged(nameof(OrdersList));
            }
        }

        public OrdersListViewModel(IConNodeManager manader)
        {
            _manager = manader;
            Update();
        }

        public void Update()
        {
            var orders = _manager.GetListOfNodes();
            OrdersList = new ObservableCollection<ConnectionNodeDTO>(orders);
        }
    }
}
