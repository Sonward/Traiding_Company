using DTO;
using TCWPF.ViewModels;
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
using Unity;
using Unity.Resolution;

namespace TCWPF.Windows
{
    /// <summary>
    /// Interaction logic for OrdersList.xaml
    /// </summary>
    public partial class OrdersList : Window
    {
        OrdersListViewModel _ordersListViewModel;
        CollectionViewSource _ordersCollection;

        public OrdersList(OrdersListViewModel om)
        {
            _ordersListViewModel = om;
            DataContext = om;
            InitializeComponent();

            _ordersCollection = (CollectionViewSource)(Resources["OrdersCollection"]);
            _ordersCollection.Filter += _ordersCollection_Filter;
        }

        private void _ordersCollection_Filter(object sender, FilterEventArgs e)
        {
            var filter = txtFilter.Text;
            var order = e.Item as ConnectionNodeDTO;
            if (order.CustomerName.Contains(filter) || order.ItemName.Contains(filter) || order.QuantityOfItem.ToString().Contains(filter) || order.StatusName.Contains(filter))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            _ordersCollection.View.Refresh();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var orderDetailsWindow = ((App)Application.Current).Container.Resolve<OrderDetails>();
            orderDetailsWindow.ShowDialog();
            _ordersListViewModel.Update();
        }

        private void dgOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            var item = (ConnectionNodeDTO)grid.SelectedItem;
            var detailsViewModel = ((App)Application.Current).Container.Resolve<OrdersDetailsViewModel>(new ParameterOverride("order", item));
            var orderDetailsWindow = new OrderDetails(detailsViewModel);
            orderDetailsWindow.ShowDialog();
            _ordersListViewModel.Update();
        }
    }
}
