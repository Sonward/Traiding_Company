using DAL.Intefaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
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
            using (SqlCommand comm = new SqlCommand())
            {
                comm.CommandText = "select * from Customer_Data where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                CustomerDataDTO custData = new CustomerDataDTO
                {
                    Id = (int)reader["Id"],
                    Cust_Name = (string)reader["Cust_Name"],
                    Cust_Surame = (string)reader["Cust_Surame"],
                    Cust_Email = (string)reader["Cust_Email"],
                    Cust_Phone = (int)reader["Cust_Phone"],
                    Cust_Address = (string)reader["Cust_Address"],
                    Cust_Password = (SqlBinary)reader["Cust_Password"],
                    Role_Id = (int)reader["Role_Id"]
                };
                return custData;
            }
        }
        public List<CustomerDataDTO> GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = new SqlCommand())
            {
                comm.CommandText = "select * from Customer_Data";
                comm.Parameters.Clear();
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<CustomerDataDTO> customers = new List<CustomerDataDTO>();
                while (reader.Read())
                {
                    customers.Add(new CustomerDataDTO
                    {
                        Id = (int)reader["Id"],
                        Cust_Name = (string)reader["Cust_Name"],
                        Cust_Surame = (string)reader["Cust_Surame"],
                        Cust_Email = (string)reader["Cust_Email"],
                        Cust_Phone = (int)reader["Cust_Phone"],
                        Cust_Address = (string)reader["Cust_Address"],
                        Cust_Password = (SqlBinary)reader["Cust_Password"],
                        Role_Id = (int)reader["Role_Id"]
                    });
                }
                return customers;
            }
        }
        public CustomerDataDTO UpdateUser(CustomerDataDTO customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = new SqlCommand())
            {
                comm.CommandText = "update Customer_Data set Cust_Name = @name, Cust_Surname = @surname, Cust_Email = @email, Cust_Phone = @phone, Cust_Address = @address, Cust_Password = @password, Role_Id = @roleId where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", customer.Id);
                comm.Parameters.AddWithValue("@name", customer.Cust_Name);
                comm.Parameters.AddWithValue("@surname", customer.Cust_Surame);
                comm.Parameters.AddWithValue("@email", customer.Cust_Email);
                comm.Parameters.AddWithValue("@phone", customer.Cust_Phone);
                comm.Parameters.AddWithValue("@address", customer.Cust_Address);
                comm.Parameters.AddWithValue("@password", customer.Cust_Password);
                comm.Parameters.AddWithValue("@roleId", customer.Role_Id);
                conn.Open();

                customer.Id = Convert.ToInt32(comm.ExecuteScalar());
                return customer;
            }
        }
        public CustomerDataDTO CreateUser(CustomerDataDTO customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = new SqlCommand())
            {
                comm.CommandText = "insert into Customer_Data (Cust_Name, Cust_Surname, Cust_Email, Cust_Phone, Cust_Address, Cust_Password, Role_Id) output INSERTED.Id values (@name, @surname, @email, @phone, @address, @password, @roleId)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name", customer.Cust_Name);
                comm.Parameters.AddWithValue("@surname", customer.Cust_Surame);
                comm.Parameters.AddWithValue("@email", customer.Cust_Email);
                comm.Parameters.AddWithValue("@phone", customer.Cust_Phone);
                comm.Parameters.AddWithValue("@address", customer.Cust_Address);
                comm.Parameters.AddWithValue("@password", customer.Cust_Password);
                comm.Parameters.AddWithValue("@roleId", customer.Role_Id);
                conn.Open();

                customer.Id = Convert.ToInt32(comm.ExecuteScalar());
                return customer;
            }
        }
        public  void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = new SqlCommand())
            {
                comm.CommandText = "delete from Customer_Data where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
    }
}
