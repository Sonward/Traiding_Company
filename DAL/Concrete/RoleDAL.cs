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
    public class RoleDAL : IRoleDAL
    {
        private string connectionString;

        public RoleDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public RoleDTO CreateItem(RoleDTO role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into [Role] (RoleName) output INSERTED.RoleId values (@name)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name", role.RoleName);
                conn.Open();

                role.RoleId = Convert.ToInt32(comm.ExecuteScalar());
                return role;
            }
        }
        public void DeleteItem(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from [Role] where RoleId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
        public List<RoleDTO> GetAllRoles()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from [Role]";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<RoleDTO> roles = new List<RoleDTO>();
                while (reader.Read())
                {
                    roles.Add(new RoleDTO
                    {
                        RoleId = (int)reader["RoleId"],
                        RoleName = (string)reader["RoleName"]
                    });
                }

                return roles;
            }
        }
        public RoleDTO GetRoleById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from [Role] where RoleId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                RoleDTO role = new RoleDTO {
                    RoleId = (int)reader["RoleId"],
                    RoleName = (string)reader["RoleName"]
                };
                return role;
            }
        }
        public RoleDTO UpdateRole(RoleDTO role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update [Role] set RoleName = @name where RoleId = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", role.RoleId);
                comm.Parameters.AddWithValue("@name", role.RoleName);
                conn.Open();

                role.RoleId = Convert.ToInt32(comm.ExecuteScalar());
                return role;
            }
        }
    }
}
