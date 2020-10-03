namespace Console
{
    public class MainMenu
    {
        CategpryCRUT CCRUD = new CategpryCRUT();
        CustomerDataCRUD UCRUD = new CustomerDataCRUD(); // U - user

        public void Start()
        {
            System.Console.WriteLine("Welcome in CRUD Presentation");

            while (true)
            {
                System.Console.WriteLine("Choose the Table:");
                System.Console.WriteLine("c - Category");
                System.Console.WriteLine("u - Customer Data");
                System.Console.WriteLine("f - exit");

                switch (System.Console.ReadLine())
                {
                    case "c":
                        CCRUD.CategoryDAL();
                        break;
                    case "u":
                        UCRUD.CustomerDataDAL();
                        break;
                    default:
                        return;
                }


            }
        }
    }
}
