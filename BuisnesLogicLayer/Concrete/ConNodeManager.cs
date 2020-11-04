using BuisnesLogicLayer.Interfaces;
using DAL.Intefaces;
using DTO;
using System.Collections.Generic;

namespace BuisnesLogicLayer.Concrete
{
    public class ConNodeManager : IConNodeManager
    {
        private readonly IConnectionNodeDAL _connectionNodeDAL;

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

        public ConnectionNodeDTO UpdateNode(ConnectionNodeDTO node)
        {
            return _connectionNodeDAL.UpdateNode(node);
        }
    }
}
