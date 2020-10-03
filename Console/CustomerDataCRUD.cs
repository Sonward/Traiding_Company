using System;
using System.Collections.Generic;
using DTO;
using DAL.Concrete;
using System.Configuration;
using System.Text;

namespace Console
{
    class CustomerDataCRUD
    {
        CustomerDataDAL dal = new CustomerDataDAL(ConfigurationManager.ConnectionStrings["ITCDB"].ConnectionString);
        CustomerDataDTO customer;

        public void CustomerDataDAL()
        {
            System.Console.WriteLine("Welcome in Customer CRUD");



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
                        System.Console.WriteLine("Input Customer:");
                        customer = dal.CreateUser(new CustomerDataDTO
                        {
                            CustName = System.Console.ReadLine(),
                            CustSurname = System.Console.ReadLine(),
                            CustEmail = System.Console.ReadLine(),
                            CustPhone = Convert.ToInt32(System.Console.ReadLine()),
                            CustAddress = System.Console.ReadLine(),
                            CustPassword = Encoding.ASCII.GetBytes(System.Console.ReadLine()),
                            RoleId = Convert.ToInt32(System.Console.ReadLine())
                        });

                        System.Console.WriteLine("You add the: Id - " + customer.CustomerDataId + "; Name - " + customer.CustName + " " + customer.CustSurname + "; Email - " + customer.CustEmail + "; Phone - " + customer.CustPhone + "; Address - " + customer.CustAddress + "; Password - " + customer.CustPassword + "; Role Id - " + customer.RoleId);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;

                    case "r1":
                        System.Console.Write("Choose Id: ");
                        customer = dal.GetUserById(Convert.ToInt32(System.Console.ReadLine()));
                        System.Console.WriteLine("You read the: Id - " + customer.CustomerDataId + "; Name - " + customer.CustName + " " + customer.CustSurname + "; Email - " + customer.CustEmail + "; Phone - " + customer.CustPhone + "; Address - " + customer.CustAddress + "; Password - " + customer.CustPassword + "; Role Id - " + customer.RoleId);
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;

                    case "r2":
                        List<CustomerDataDTO> categories = dal.GetAllUsers();
                        for (int i = 0; i < categories.Count; i++)
                        {
                            System.Console.WriteLine("You read the: Id - " + customer.CustomerDataId + "; Name - " + customer.CustName + " " + customer.CustSurname + "; Email - " + customer.CustEmail + "; Phone - " + customer.CustPhone + "; Address - " + customer.CustAddress + "; Password - " + customer.CustPassword + "; Role Id - " + customer.RoleId);
                        }
                        System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;

                    case "u":
                        System.Console.WriteLine("Update Name:");
                        customer = dal.UpdateUser(new CustomerDataDTO 
                        {
                            CustName = System.Console.ReadLine(),
                            CustSurname = System.Console.ReadLine(),
                            CustEmail = System.Console.ReadLine(),
                            CustPhone = Convert.ToInt32(System.Console.ReadLine()),
                            CustAddress = System.Console.ReadLine(),
                            CustPassword = Encoding.ASCII.GetBytes(System.Console.ReadLine()),
                            RoleId = Convert.ToInt32(System.Console.ReadLine())
                        });
                        System.Console.WriteLine("You change the: Id - " + customer.CustomerDataId + "; Name - " + customer.CustName + " " + customer.CustSurname + "; Email - " + customer.CustEmail + "; Phone - " + customer.CustPhone + "; Address - " + customer.CustAddress + "; Password - " + customer.CustPassword + "; Role Id - " + customer.RoleId); System.Console.WriteLine("Press any key");
                        System.Console.WriteLine("");
                        System.Console.WriteLine("");
                        System.Console.ReadKey();
                        break;

                    case "d":
                        System.Console.WriteLine("Choose Id:");
                        dal.DeleteUser(Convert.ToInt32(System.Console.ReadLine()));
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
