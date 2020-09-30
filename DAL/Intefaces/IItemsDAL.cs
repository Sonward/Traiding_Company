using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IItemsDAL
    {
        ItemsDTO GetItemById(int id);
        List<ItemsDTO> GetAllItems();
        ItemsDTO UpdateItem(ItemsDTO item);
        ItemsDTO CreateItem(ItemsDTO item);
        void DeleteItem(int id);
    }
}
