using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface ICustomerDataDAL
    {
        CustomerDataDTO GetUserById(int id);
        List<CustomerDataDTO> GetAllUsers();
        CustomerDataDTO UpdateUser(CustomerDataDTO customer);
        CustomerDataDTO CreateUser(CustomerDataDTO customer);
        void DeleteUser(int id);
        bool Login(string username, string password);
    }
}
