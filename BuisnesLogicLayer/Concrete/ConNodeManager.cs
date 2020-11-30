using BuisnesLogicLayer.Interfaces;
using DAL.Intefaces;
using DTO;
using System.Collections.Generic;

namespace BuisnesLogicLayer.Concrete
{
    public class ConNodeManager : IConNodeManager
    {
        private readonly IConnectionNodeDAL _connectionNodeDAL;
        private readonly ICustomerDataDAL _customerDataDAL;
        private readonly IItemDAL _itemDAL;
        private readonly IStatusDAL _statusDAL;

        public ConNodeManager(IConnectionNodeDAL connectionNodeDAL) { _connectionNodeDAL = connectionNodeDAL; }
        public ConnectionNodeDTO AddNode(ConnectionNodeDTO node)
        {
            return _connectionNodeDAL.CreateteNode(node);
        }

        public void DeleteNode(int custId, int itemId)
        {
            _connectionNodeDAL.DeleteNode(custId, itemId);
        }

        public List<ConnectionNodeDTO> GetListOfNodes()
        {
            return _connectionNodeDAL.GetAllNodes();
        }

        public List<CustomerDataDTO> GetListOfCustomers()
        {
            return _customerDataDAL.GetAllUsers();
        }

        public List<ItemDTO> GetListOfItems()
        {
            return _itemDAL.GetAllItems();
        }

        public List<StatusDTO> GetListOfStatuses()
        {
            return _statusDAL.GetAllStatus();
        }

        public ConnectionNodeDTO UpdateNode(ConnectionNodeDTO node)
        {
            return _connectionNodeDAL.UpdateNode(node);
        }
    }
}
