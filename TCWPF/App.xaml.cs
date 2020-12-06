using BuisnesLogicLayer.Concrete;
using BuisnesLogicLayer.Interfaces;
using DAL.Intefaces;
using DAL.Concrete;
using TCWPF.Windows;
using System.Windows;
using Unity;
using System.Configuration;

namespace TCWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IUnityContainer Container;
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            base.OnStartup(e);

            RegisterUnity();

            Container.RegisterInstance(ConfigurationManager.ConnectionStrings["ITCDB"].ConnectionString);

            //Login lf = new Login(new ViewModels.LoginViewModel(new AuthManager(new CustomerDataDAL(ConfigurationManager.ConnectionStrings["ITCDB"].ConnectionString))));

            Login lf = Container.Resolve<Login>();
            bool result = lf.ShowDialog() ?? false;
            if (result)
            {
                OrdersList ol = Container.Resolve<OrdersList>();
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Current.MainWindow = ol;
                ol.Show();
            }
            else
            {
                Current.Shutdown();
            }

            //OrdersList ol = Container.Resolve<OrdersList>();
            //Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            //Current.MainWindow = ol;
            //ol.Show();
        }

        private void RegisterUnity()
        {
            Container = new UnityContainer().AddExtension(new Diagnostic());

            Container.RegisterType<ICategoryDAL, CategoryDAL>()
                .RegisterType<IConnectionNodeDAL, ConnectionNodeDAL>()
                .RegisterType<ICustomerDataDAL, CustomerDataDAL>()
                .RegisterType<IItemDAL, ItemDAL>()
                .RegisterType<IRoleDAL, RoleDAL>()
                .RegisterType<IStatusDAL, StatusDAL>()
                .RegisterType<IAuthManager, AuthManager>()
                .RegisterType<IConNodeManager, ConNodeManager>();
        }
    }
}
