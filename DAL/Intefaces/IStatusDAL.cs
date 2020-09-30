using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IStatusDAL
    {
        StatusDTO GetStatusById(int id);
        List<StatusDTO> GetAllStatus();
        StatusDTO UpdateStatus(StatusDTO status);
        StatusDTO CreateStatus(StatusDTO status);
        void DeleteStatus(int id);
    }
}
