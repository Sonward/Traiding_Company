using DAL.Intefaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class CategoryDAL : ICategoryDAL
    {
        private string connectionString;

        public CategoryDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public CategoryDTO GetCategoryById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = new SqlCommand())
            {
                comm.CommandText = "select * from Category where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                CategoryDTO category = new CategoryDTO { Id = (int)reader["Id"], Name = (string)reader["Name"] };
                return category;
            }
        }
        public List<CategoryDTO> GetAllCategories()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Category";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<CategoryDTO> categories = new List<CategoryDTO>();
                while (reader.Read())
                {
                    categories.Add(new CategoryDTO
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"] // може вибити помилку бо можливо має бути "[Name]"
                    });
                }

                return categories;
            }
        }
        public CategoryDTO UpdateCategory(CategoryDTO category) // провірити особливо цю функцію
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = new SqlCommand())
            {
                comm.CommandText = "update Category set [Name] = @name where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name", category.Name);
                conn.Open();

                category.Id = Convert.ToInt32(comm.ExecuteScalar());
                return category;
            }
        }
        public CategoryDTO CreateCategory(CategoryDTO category)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = new SqlCommand())
            {
                comm.CommandText = "insert into Category ([Name]) output INSERTED.Id values (@name)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name",category.Name);
                conn.Open();

                category.Id = Convert.ToInt32(comm.ExecuteScalar());
                return category;
            }
        }
        public void DeleteteCategory(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = new SqlCommand())
            {
                comm.CommandText = "delete from Category where Id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
    }
}
