using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.WebSiteManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //ISiteManager demoServices = new SiteManagerImpl();
            //WebServiceHost _serviceHost = new WebServiceHost(demoServices, new Uri("http://localhost:8000/SiteService"));
            //_serviceHost.Open();
            //Console.ReadKey();
            //_serviceHost.Close();


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
