using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface ICategoryDAL
    {
        CategoryDTO GetCategoryById(int id);
        List<CategoryDTO> GetAllCategories();
        CategoryDTO UpdateCategory(CategoryDTO category);
        CategoryDTO CreateCategory(CategoryDTO category);
        void DeleteteCategory(int id);
    }
}
