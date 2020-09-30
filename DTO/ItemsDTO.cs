using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemsDTO
    {
        public int Id { get; set; }
        public string Item_Name { get; set; }
        public SqlMoney Item_Price { get; set; }
        public int Item_Quantity { get; set; }
        public int Item_Category_Id { get; set; }
    }
}
