using System;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDataDTO
    {
        public int CustomerDataId { get; set; }
        public string CustName { get; set; }
        public string CustSurname { get; set; }
        public string CustEmail { get; set; }
        public int CustPhone { get; set; }
        public string CustAddress { get; set; }
        public SqlBinary CustPassword { get; set; }
        public int RoleId { get; set; }
    }
}
