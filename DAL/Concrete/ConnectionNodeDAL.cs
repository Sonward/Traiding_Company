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
                        TimeOfReceipt = (DateTime)reader["TimeOfReceipt"],
                        //SendingTime = (DateTime)reader["SendingTime"],
                        SendingTime = DateTime.Now,
                        StatusId = (int)reader["StatusId"]
                    });
                }
                reader.Close();

                comm.CommandText = "select CustName, CustSurname from CustomerData";
                reader = comm.ExecuteReader();
                //conn.Open();
                List<string> custNames = new List<string>();
                while (reader.Read())
                {
                    custNames.Add((string)reader["CustName"] + " " + (string)reader["CustSurname"]);
                }
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].CustomerName = custNames[nodes[i].CustomerDataId];
                }
                reader.Close();

                comm.CommandText = "select ItemName from Item";
                reader = comm.ExecuteReader();
                //conn.Open();
                List<string> itemNames = new List<string>();
                while (reader.Read())
                {
                    itemNames.Add((string)reader["ItemName"]);
                }
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].ItemName = itemNames[nodes[i].ItemId - 1];
                }
                reader.Close();

                comm.CommandText = "select StatusName from Status";
                reader = comm.ExecuteReader();
                //conn.Open();
                List<string> statusNames = new List<string>();
                while (reader.Read())
                {
                    statusNames.Add((string)reader["StatusName"]);
                }
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].StatusName = statusNames[nodes[i].StatusId - 1];
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
