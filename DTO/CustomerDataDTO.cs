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
        public int Id { get; set; }
        public string Cust_Name { get; set; }
        public string Cust_Surame { get; set; }
        public string Cust_Email { get; set; }
        public int Cust_Phone { get; set; } // в БД bigint, можливо треба буде переробити тут на Int64
        public string Cust_Address { get; set; }
        public SqlBinary Cust_Password { get; set; }
        public int Role_Id { get; set; }
    }
}
