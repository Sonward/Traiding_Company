using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IRoleDAL
    {
        RoleDTO GetItemById(int id);
        List<RoleDTO> GetAllItems();
        RoleDTO UpdateItem(ItemsDTO item);
        RoleDTO CreateItem(ItemsDTO item);
        void DeleteItem(int id);
    }
}
