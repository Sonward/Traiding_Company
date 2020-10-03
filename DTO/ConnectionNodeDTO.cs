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
        public int ConnectionNodeId { get; set; }
        public int CustomerDataId { get; set; }
        public int ItemId { get; set; }
        public int QuantityOfItem { get; set; }
        public SqlDateTime TimeOfReceipt { get; set; }
        public SqlDateTime SendingTime { get; set; }
        public int StatusId { get; set; }
    }
}
