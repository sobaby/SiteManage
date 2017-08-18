using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.WebSiteManager
{
    public partial class Service1 : ServiceBase
    {
        private WebServiceHost _serviceHost;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ISiteManager demoServices = new SiteManagerImpl();
            _serviceHost = new WebServiceHost(demoServices, new Uri("http://localhost:8000/SiteService"));
            _serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (_serviceHost != null)
                _serviceHost.Close();
        }
    }
}