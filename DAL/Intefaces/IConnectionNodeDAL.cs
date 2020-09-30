using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IConnectionNodeDAL
    {
        ConnectionNodeDTO GetNodeById(int id);
        List<ConnectionNodeDTO> GetAllNodes();
        ConnectionNodeDTO UpdateNode(ConnectionNodeDTO node);
        ConnectionNodeDTO CreateteNode(ConnectionNodeDTO node);
        void DeleteNode(int id);
    }
}
