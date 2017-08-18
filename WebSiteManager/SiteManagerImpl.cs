using DuoMall.SiteManager.Common;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.WebSiteManager
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SiteManagerImpl : ISiteManager
    {
        public List<SiteInfo> GetAllSite()
        {
            using (IISManager manager = new IISManager())
            {
                List<SiteInfo> list = new List<SiteInfo>();
                foreach (var site in manager.GetAllSite())
                {
                    list.Add(Map(site));
                }
                return list;
            }
        }

        public void CreateWebSite(SiteInfo site)
        {
            using (IISManager manager = new IISManager())
            {
                try
                {
                    //创建应用程序池
                    ApplicationPoolInfo appPool = new ApplicationPoolInfo();
                    appPool.ManagedRuntimeVersion = Util.GetManagedRuntimeVersion(site.ManagedRuntimeVersion);
                    appPool.Name = site.Name;
                    manager.CreateApplicationPool(appPool);

                    var webs = manager.CreateWebSite(site);
                    //添加绑定
                    foreach (var binding in site.Bindings)
                        manager.AddSiteBinding(webs, binding);

                    //添加application
                    manager.AddApplication(webs, "/", site.Name, "/", site.PhysicalPath, site.UserName, site.Password);
                    manager.Complete();
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                    throw;
                }
            }
        }

        public void AddVirtualDirectory(string siteName)
        {

        }

        public SiteInfo GetWebSiteInfo(string siteName)
        {
            using (IISManager manager = new IISManager())
            {
                try
                {
                    var site = manager.GetSiteInfo(siteName);

                    return Map(site);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                    throw;
                }
            }
        }

        public SiteState Start(string siteName)
        {
            using (IISManager manager = new IISManager())
            {
                try
                {
                    var site = manager.GetSiteInfo(siteName);
                    if (site == null)
                        throw new ArgumentException("");
                    var state = site.Start();
                    return Util.ConvertoObjectState(state);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                    throw;
                }
            }
        }
        public SiteState Stop(string siteName)
        {
            using (IISManager manager = new IISManager())
            {
                try
                {
                    var site = manager.GetSiteInfo(siteName);
                    if (site == null)
                        throw new ArgumentException("");
                    var state = site.Stop();
                    return Util.ConvertoObjectState(state);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
                    throw;
                }
            }
        }

        public bool WebSiteExists(string siteName)
        {
            throw new NotImplementedException();
        }

        private SiteInfo Map(Site site)
        {

            SiteInfo info = new SiteInfo()
            {
                Id = site.Id,
                Name = site.Name,
                ApplicationPoolName = site.Applications["/"].ApplicationPoolName,
                PhysicalPath = site.Applications["/"].VirtualDirectories["/"].PhysicalPath,
                ServerAutoStart = site.ServerAutoStart,
                State = Util.ConvertoObjectState(site.State),
            };
            foreach (var item in site.Bindings)
            {
                info.Bindings.Add(new SiteBinding()
                {
                    HostName = item.Host,
                    IPAddress = item.EndPoint.Address.ToString(),
                    Port = item.EndPoint.Port,
                    Protocol = item.Protocol
                });
            }
            foreach (var item in site.Applications)
            {
                info.Applications.Add(new SiteApplication()
                {
                    Path = item.Path,
                    ApplicationPoolName = item.ApplicationPoolName,
                    PhysicalPath = item.VirtualDirectories["/"].PhysicalPath,
                });
            }
            return info;
        }
    }
}