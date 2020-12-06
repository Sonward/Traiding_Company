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

namespace TCWPF.Windows
{
    /// <summary>
    /// Interaction logic for OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Window
    {
        OrdersDetailsViewModel _ordersDetailsViewModel;
        public OrderDetails(OrdersDetailsViewModel om)
        {
            _ordersDetailsViewModel = om;
            DataContext = om;

            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _ordersDetailsViewModel.Save();
            DialogResult = true;
            this.Close();
        }
    }
}
