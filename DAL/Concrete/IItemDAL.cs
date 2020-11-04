using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IItemDAL
    {
        ItemDTO GetItemById(int id);
        List<ItemDTO> GetAllItems();
        ItemDTO UpdateItem(ItemDTO item);
        ItemDTO CreateItem(ItemDTO item);
        void DeleteItem(int id);
    }
}
