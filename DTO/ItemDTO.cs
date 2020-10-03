using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public SqlMoney ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public int Category_Id { get; set; }
    }
}
