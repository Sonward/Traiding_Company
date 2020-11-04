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
    public class ConnectionNodeDAL : IConnectionNodeDAL
    {
        private string connectionString;

        public ConnectionNodeDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public ConnectionNodeDTO CreateteNode(ConnectionNodeDTO node)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into ConnectionNode (CustomerDataId, ItemId, QuantityOfItem, TimeOfReceipt, StatusId) values (@customer, @item, @quantity, @receiptTime, @status)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@customer", node.CustomerDataId);
                comm.Parameters.AddWithValue("@item", node.ItemId);
                comm.Parameters.AddWithValue("@quantity", node.QuantityOfItem);
                comm.Parameters.AddWithValue("@receiptTime", node.TimeOfReceipt); // замість цього можна дати GETDATE()
                comm.Parameters.AddWithValue("@status", node.StatusId);
                conn.Open();

                return node;
            }
        }
        public void DeleteNode(int custId, int itemId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Category where CustomerDataId = @cust AND ItemId = @item";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@cust", custId);
                comm.Parameters.AddWithValue("@item", itemId);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<ConnectionNodeDTO> GetAllNodes()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from ConnectionNode";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<ConnectionNodeDTO> nodes = new List<ConnectionNodeDTO>();
                while (reader.Read())
                {
                    nodes.Add(new ConnectionNodeDTO
                    {
                        CustomerDataId = (int)reader["CustomerDataId"],
                        ItemId = (int)reader["ItemId"],
                        QuantityOfItem = (int)reader["QuantityOfItem"],
                        SendingTime = (SqlDateTime)reader["SendingTime"],
                        TimeOfReceipt = (SqlDateTime)reader["TimeOfReceipt"],
                        StatusId = (int)reader["StatusId"]
                    });
                }

                return nodes;
            }
        }
        public ConnectionNodeDTO GetNodeById(int custId, int itemId)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from ConnectionNode where CustomerDataId = @cust AND ItemId = @item";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@cust", custId);
                comm.Parameters.AddWithValue("@item", itemId);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                ConnectionNodeDTO node = new ConnectionNodeDTO
                {
                    CustomerDataId = (int)reader["CustomerDataId"],
                    ItemId = (int)reader["ItemId"],
                    QuantityOfItem = (int)reader["QuantityOfItem"],
                    SendingTime = (SqlDateTime)reader["SendingTime"],
                    TimeOfReceipt = (SqlDateTime)reader["TimeOfReceipt"],
                    StatusId = (int)reader["StatusId"]
                };

                return node;
            }
        }
        public ConnectionNodeDTO UpdateNode(ConnectionNodeDTO node)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update ConnectionNode set CustomerDataId = @customer, ItemId = @item, QuantityOfItem = @quantity, TimeOfReceipt = @receiptTime, SendingTime = @sendTime, StatusId = @status";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@customer", node.CustomerDataId);
                comm.Parameters.AddWithValue("@item", node.ItemId);
                comm.Parameters.AddWithValue("@quantity", node.QuantityOfItem);
                comm.Parameters.AddWithValue("@receiptTime", node.TimeOfReceipt);
                comm.Parameters.AddWithValue("@sendTime", node.SendingTime);
                comm.Parameters.AddWithValue("@status", node.StatusId);
                conn.Open();

                return node;
            }
        }
    }
}
