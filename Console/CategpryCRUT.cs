using System;
using System.Collections.Generic;
using DTO;
using DAL.Concrete;
using System.Configuration;

namespace Console
{
    class CategpryCRUT
    {
        CategoryDAL dal = new CategoryDAL(ConfigurationManager.ConnectionStrings["ITCDB"].ConnectionString);
        CategoryDTO category;

        public void CategoryDAL()
        {
            System.Console.WriteLine("Welcome in Category CRUD");



            while (true)
            {
                System.Console.WriteLine("c - Create");
                System.Console.WriteLine("r1 - read one");
                System.Console.WriteLine("r2 - read all");
                System.Console.WriteLine("u - update");
                System.Console.WriteLine("d - delete");
                System.Console.WriteLine("f - exit");



                switch (System.Console.ReadLine())
                {
                    case "c":
                        System.Console.WriteLine("Input Category Name:");
                        category = dal.CreateCategory(new CategoryDTO { CategoryName = System.Console.ReadLine() });
                        System.Console.WriteLine("You add the: Id - " + category.CategoryId + " Name - " + category.CategoryName);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;

                    case "r1":
                        System.Console.Write("Choose Id: ");
                        category = dal.GetCategoryById(Convert.ToInt32(System.Console.ReadLine()));
                        System.Console.WriteLine("You read the: Id - " + category.CategoryId + " Name - " + category.CategoryName);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;

                    case "r2":
                        List<CategoryDTO> categories = dal.GetAllCategories();
                        for (int i = 0; i < categories.Count; i++)
                        {
                            System.Console.WriteLine("Id - " + categories[i].CategoryId + " Name - " + categories[i].CategoryName);
                        }
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;

                    case "u":
                        System.Console.WriteLine("Update Name:");
                        category = dal.UpdateCategory(new CategoryDTO { CategoryName = System.Console.ReadLine() });
                        System.Console.WriteLine("You change the: Id - " + category.CategoryId + " Name - " + category.CategoryName);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;

                    case "d":
                        System.Console.WriteLine("Choose Id:");
                        dal.DeleteteCategory(Convert.ToInt32(System.Console.ReadLine()));
                        System.Console.WriteLine("Delete successful");
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;

                    default:
                        return;
                }
            }




        }
    }
}