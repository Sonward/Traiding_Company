using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ConnectionNodeDTO
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public int Item_Id { get; set; }
        public int Quantity_of_Item { get; set; }
        public SqlDateTime Time_of_Receipt { get; set; }
        public SqlDateTime Sending_Time { get; set; }
        public int Status_Id { get; set; }
    }
}
