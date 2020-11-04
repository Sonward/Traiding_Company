using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IRoleDAL
    {
        RoleDTO CreateItem(RoleDTO role);
        RoleDTO GetRoleById(int id);
        List<RoleDTO> GetAllRoles();
        RoleDTO UpdateRole(RoleDTO role);
        void DeleteItem(int id);
    }
}
