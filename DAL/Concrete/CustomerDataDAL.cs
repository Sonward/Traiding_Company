using DAL.Intefaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class CustomerDataDAL : ICustomerDataDAL
    {
        private string connectionString;

        public CustomerDataDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public CustomerDataDTO GetUserById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from CustomerData where CustomerDataId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                CustomerDataDTO custData = new CustomerDataDTO
                {
                    CustomerDataId = (int)reader["CustomerDataId"],
                    CustName = (string)reader["CustName"],
                    CustSurname = (string)reader["CustSurame"],
                    CustEmail = (string)reader["CustEmail"],
                    CustPhone = (int)reader["CustPhone"],
                    CustAddress = (string)reader["CustAddress"],
                    CustPassword = Encoding.ASCII.GetBytes(reader["CustPassword"].ToString()),
                    RoleId = (int)reader["RoleId"]
                };
                return custData;
            }
        }
        public List<CustomerDataDTO> GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from CustomerData";
                comm.Parameters.Clear();
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<CustomerDataDTO> customers = new List<CustomerDataDTO>();
                while (reader.Read())
                {
                    customers.Add(new CustomerDataDTO
                    {
                        CustomerDataId = (int)reader["CustomerDataId"],
                        CustName = reader["CustName"].ToString(),
                        CustSurname = reader["CustSurname"].ToString(),
                        CustEmail = reader["CustEmail"].ToString(),
                        CustPhone = (int)reader["CustPhone"],
                        CustAddress = reader["CustAddress"].ToString(),
                        CustPassword = Encoding.ASCII.GetBytes(reader["CustPassword"].ToString()),
                        RoleId = (int)reader["RoleId"]
                    });
                }
                return customers;
            }
        }
        public CustomerDataDTO UpdateUser(CustomerDataDTO customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                Guid salt = Guid.NewGuid();
                byte[] newPassword = hash(Encoding.ASCII.GetString(customer.CustPassword), customer.CustSalt.ToString());
                comm.CommandText = "update CustomerData set CustName = @name, CustSurname = @surname, CustEmail = @email, CustPhone = @phone, CustAddress = @address, CustPassword = @password, CustSalt = @salt, RoleId = @roleId where CustomerDataId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", customer.CustomerDataId);
                comm.Parameters.AddWithValue("@name", customer.CustName);
                comm.Parameters.AddWithValue("@surname", customer.CustSurname);
                comm.Parameters.AddWithValue("@email", customer.CustEmail);
                comm.Parameters.AddWithValue("@phone", customer.CustPhone);
                comm.Parameters.AddWithValue("@address", customer.CustAddress);
                comm.Parameters.AddWithValue("@password", newPassword);
                comm.Parameters.AddWithValue("@salt", salt);
                comm.Parameters.AddWithValue("@roleId", customer.RoleId);
                conn.Open();

                customer.CustomerDataId = Convert.ToInt32(comm.ExecuteScalar());
                return customer;
            }
        }
        public CustomerDataDTO CreateUser(CustomerDataDTO customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                Guid salt = Guid.NewGuid();
                byte[] newPassword = hash(Encoding.ASCII.GetString(customer.CustPassword), customer.CustSalt.ToString());
                comm.CommandText = "insert into CustomerData (CustName, CustSurname, CustEmail, CustPhone, CustAddress, CustPassword, CustSalt, RoleId) output INSERTED.CustomerDataId values (@name, @surname, @email, @phone, @address, @password, @salt, @roleId)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name", customer.CustName);
                comm.Parameters.AddWithValue("@surname", customer.CustSurname);
                comm.Parameters.AddWithValue("@email", customer.CustEmail);
                comm.Parameters.AddWithValue("@phone", customer.CustPhone);
                comm.Parameters.AddWithValue("@address", customer.CustAddress);
                comm.Parameters.AddWithValue("@password", newPassword);
                comm.Parameters.AddWithValue("@salt", salt);
                comm.Parameters.AddWithValue("@roleId", customer.RoleId);
                conn.Open();

                customer.CustomerDataId = Convert.ToInt32(comm.ExecuteScalar());
                return customer;
            }
        }
        public  void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from CustomerData where CustomerDataId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public bool Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select CustEmail, CustPassword, CustSalt from CustomerData where RoleId = 2 AND CustEmail = @email";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@email", username);
                //comm.Parameters.AddWithValue("@password", hash(password, ));
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                CustomerDataDTO custData = new CustomerDataDTO
                {
                    CustEmail = (string)reader["CustEmail"],
                    CustPassword = Encoding.ASCII.GetBytes(reader["CustPassword"].ToString()),
                    CustSalt = (System.Guid)reader["CustSalt"],
                    RoleId = (int)reader["RoleId"]
                };

                
                return custData.CustEmail != null && custData.CustPassword == hash(password, custData.CustSalt.ToString());
            }
        }

        private byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
    }
}
