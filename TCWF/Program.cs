using BuisnesLogicLayer.Interfaces;
using BuisnesLogicLayer.Concrete;
using DAL.Intefaces;
using DAL.Concrete;
using TCWF.AppSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace TCWF
{
    static class Program
    {
        public static AppDataManager SettingsManager;
        public static UnityContainer Container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureUnity();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //new UnityContainer().AddExtension(new Diagnostic());
            SettingsManager = new AppDataManager();
            //Container.RegisterType<LoginForm>(Invoke.Constructor());
            LoginForm lf = Container.Resolve<LoginForm>();

            if (lf.ShowDialog() == DialogResult.OK)
            {
                Application.Run(Container.Resolve<SellerUI>());
            }
            else
            {
                Application.Exit();
            }

        }

        private static void ConfigureUnity()
        {
            Container = new UnityContainer();
            //Container.RegisterInstance<>();
            Container.RegisterType<ICategoryDAL, CategoryDAL>()
                .RegisterType<IConnectionNodeDAL, ConnectionNodeDAL>()
                .RegisterType<ICustomerDataDAL, CustomerDataDAL>()
                .RegisterType<IItemDAL, ItemsDAL>()
                .RegisterType<IRoleDAL, RoleDAL>()
                .RegisterType<IStatusDAL, StatusDAL>()
                .RegisterType<IAuthManager, AuthManager>()
                .RegisterType<IConNodeManager, ConNodeManager>();
        }
    }
}
