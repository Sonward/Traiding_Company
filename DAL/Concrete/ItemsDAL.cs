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
    public class ItemsDAL : IItemDAL
    {
        private string connectionString;

        public ItemsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public ItemDTO CreateItem(ItemDTO item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Item (ItemName, ItemPrice, ItemQuantity, CategoryId) output INSERTED.ItemId values(@name, @price, @qa, @category)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@namer", item.ItemName);
                comm.Parameters.AddWithValue("@price", item.ItemPrice);
                comm.Parameters.AddWithValue("@qa", item.ItemQuantity);
                comm.Parameters.AddWithValue("@category", item.Category_Id);
                conn.Open();

                item.ItemId = Convert.ToInt32(comm.ExecuteScalar());
                return item;
            }
        }

        public void DeleteItem(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Item where CategoryId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<ItemDTO> GetAllItems()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Item";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<ItemDTO> categories = new List<ItemDTO>();
                while (reader.Read())
                {
                    categories.Add(new ItemDTO
                    {
                        ItemId = (int)reader["ItemId"],
                        ItemName = (string)reader["ItemName"],
                        ItemPrice = (SqlMoney)reader["ItemPrice"],
                        ItemQuantity = (int)reader["ItemQuantity"],
                        Category_Id = (int)reader["Category_Id"]
                    });
                }

                return categories;
            }
        }

        public ItemDTO GetItemById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Item where CategoryId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                ItemDTO item = new ItemDTO {
                    ItemId = (int)reader["ItemId"],
                    ItemName = (string)reader["ItemName"],
                    ItemPrice = (SqlMoney)reader["ItemPrice"],
                    ItemQuantity = (int)reader["ItemQuantity"],
                    Category_Id = (int)reader["Category_Id"]
                };
                return item;
            }
        }

        public ItemDTO UpdateItem(ItemDTO item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Item set ItemName = @name, ItemPrice = @price, ItemQuantity = @qa, CategoryId = @category where ItemId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", item.ItemId);
                comm.Parameters.AddWithValue("@name", item.ItemName);
                comm.Parameters.AddWithValue("@price", item.ItemPrice);
                comm.Parameters.AddWithValue("@qa", item.ItemQuantity);
                comm.Parameters.AddWithValue("@category", item.Category_Id);
                conn.Open();

                item.ItemId = Convert.ToInt32(comm.ExecuteScalar());
                return item;
            }
        }
    }
}
