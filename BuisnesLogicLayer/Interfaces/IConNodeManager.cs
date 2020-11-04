using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.Interfaces
{
    public interface IConNodeManager
    {
        ConnectionNodeDTO AddNode(ConnectionNodeDTO node);
        List<ConnectionNodeDTO> GetListOfNodes();
        ConnectionNodeDTO UpdateNode(ConnectionNodeDTO node);
        void DeleteNode(int custId, int itemId);
    }
}
