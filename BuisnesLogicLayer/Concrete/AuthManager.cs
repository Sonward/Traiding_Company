using BuisnesLogicLayer.Interfaces;
using DAL.Intefaces;

namespace BuisnesLogicLayer.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly ICustomerDataDAL _customerDataDAL;

        public AuthManager(ICustomerDataDAL customerDataDAL)
        {
            _customerDataDAL = customerDataDAL;
        }
        public bool Login(string username, string password)
        {
            return _customerDataDAL.Login(username, password);
        }
    }
}
