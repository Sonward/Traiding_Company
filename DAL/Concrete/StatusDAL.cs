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
    public class StatusDAL : IStatusDAL
    {
        private string connectionString;

        public StatusDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public StatusDTO CreateStatus(StatusDTO status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into [Status] (StatusName) output INSERTED.StatusId values (@name)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name", status.StatusName);
                conn.Open();

                status.StatusId = Convert.ToInt32(comm.ExecuteScalar());
                return status;
            }
        }
        public List<StatusDTO> GetAllStatus()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from [Status]";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<StatusDTO> status = new List<StatusDTO>();
                while (reader.Read())
                {
                    status.Add(new StatusDTO
                    {
                        StatusId = (int)reader["StatusId"],
                        StatusName = (string)reader["StatusName"]
                    });
                }

                return status;
            }
        }
        public StatusDTO GetStatusById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from [Status]";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                StatusDTO status = new StatusDTO
                {
                    StatusId = (int)reader["StatusId"],
                    StatusName = (string)reader["StatusName"]
                };
                
                return status;
            }
        }
        public StatusDTO UpdateStatus(StatusDTO status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update [Status] set StatusName = @name where StatusId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", status.StatusId);
                comm.Parameters.AddWithValue("@name", status.StatusName);
                conn.Open();

                status.StatusId = Convert.ToInt32(comm.ExecuteScalar());
                return status;
            }
        }
        public void DeleteStatus(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from [Status] where StatusId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
    }
}
