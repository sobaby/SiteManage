using DuoMall.SiteManager.Common;
using Microsoft.Web.Administration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.WebSiteManager
{
    class IISManager : IDisposable
    {
        private ServerManager manager;
        private bool isDisposed;

        public IISManager()
        {
            this.manager = new ServerManager();
        }

        #region ApplicationPools
        public void CreateApplicationPool(ApplicationPoolInfo appInfo)
        {
            var applicationPool = manager.ApplicationPools.CreateElement();

            applicationPool.Name = appInfo.Name;
            applicationPool.AutoStart = true;
            applicationPool.ManagedRuntimeVersion = appInfo.ManagedRuntimeVersion;
            //applicationPool.managedRuntimeLoader = webengine4.dll
            applicationPool.ManagedPipelineMode = 0;

            manager.ApplicationPools.Add(applicationPool);
        }
        public ApplicationPool GetApplicationPool(string poolName)
        {
            return manager.ApplicationPools[poolName];
        }
        #endregion

        #region Web Site Management
        /// <summary>
        /// 获取所有站点
        /// </summary>
        /// <returns></returns>
        public SiteCollection GetAllSite()
        {
            SiteCollection sites = manager.Sites;
            return sites;
        }
        public Site CreateWebSite(SiteInfo site)
        {
            if (site == null)
                throw new ArgumentNullException("site", "CreateWebSite: site is null.");

            if (string.IsNullOrEmpty(site.Name))
                throw new ArgumentNullException("siteName", "CreateWebSite: siteName is null or empty.");

            if (string.IsNullOrEmpty(site.PhysicalPath))
                throw new ArgumentNullException("physicalPath", "CreateWebSite: physicalPath is null or empty.");

            Site newSite = manager.Sites.CreateElement();
            //get site id
            newSite.Id = GenerateNewSiteID(manager, site.Name);
            newSite.SetAttributeValue("name", site.Name);

            site.Id = newSite.Id;

            manager.Sites.Add(newSite);

            return newSite;
        }

        public bool AddApplication(Site site, string applicationPath, string applicationPool, string virtualDirectoryPath, string physicalPath, string userName, string password)
        {
            if (site == null)
                throw new ArgumentNullException("site", "AddApplication: site is null or empty.");
            if (string.IsNullOrEmpty(applicationPath))
                throw new ArgumentNullException("applicationPath", "AddApplication: application path is null or empty.");
            if (string.IsNullOrEmpty(physicalPath))
                throw new ArgumentNullException("PhysicalPath", "AddApplication: Invalid physical path.");
            if (string.IsNullOrEmpty(applicationPool))
                throw new ArgumentNullException("ApplicationPool", "AddApplication: application pool namespace is Nullable or empty.");

            ApplicationPool appPool = manager.ApplicationPools[applicationPool];
            if (appPool == null)
                throw new Exception("Application Pool: " + applicationPool + " does not exist.");

            Application app = site.Applications[applicationPath];
            if (app != null)
                throw new Exception("Application: " + applicationPath + " already exists.");
            else
            {
                app = site.Applications.CreateElement();
                app.Path = applicationPath;
                app.ApplicationPoolName = applicationPool;

                VirtualDirectory vDir = app.VirtualDirectories.CreateElement();
                vDir.Path = virtualDirectoryPath;
                vDir.PhysicalPath = physicalPath;
                //vDir.LogonMethod = AuthenticationLogonMethod.ClearText;
                if (!string.IsNullOrEmpty(userName))
                {
                //    if (string.IsNullOrEmpty(password))
                //        throw new Exception("Invalid Virtual Directory User Account Password.");
                //    else
                //    {
                //        vDir.UserName = userName;
                //        vDir.Password = password;
                //    }
                }
                app.VirtualDirectories.Add(vDir);
            }
            site.Applications.Add(app);
            return true;
        }

        public Site GetSiteInfo(string siteName)
        {
            return manager.Sites[siteName];
        }
        
        public void AddSiteBinding(Site site, SiteBinding binding)
        {
            if (site == null)
                throw new ArgumentNullException("site", "AddSiteBinding: site is null.");

            //get the server manager instance

            string bind = binding. IPAddress + ":" + binding.Port + ":" + binding.HostName;
            //check the binding exists or not
            foreach (Binding b in site.Bindings)
            {
                if (b.Protocol == binding.Protocol && b.BindingInformation == bind)
                    throw new Exception("A binding with the same ip, port and host header already exists.");
            }
            Binding newBinding = site.Bindings.CreateElement();
            newBinding.Protocol = binding.Protocol;
            newBinding.BindingInformation = bind;
            site.Bindings.Add(newBinding);
        }
        #endregion

        /// <summary>
        /// 启动站点
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public ObjectState Start(Site site)
        {
            return site.Start();
        }

        /// <summary>
        /// 停止站点
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public ObjectState Stop(Site site)
        {
            return site.Stop();
        }

        public void Complete()
        {
            if (manager != null && isDisposed == false)
                manager.CommitChanges();
        }

        #region GenerateNewSiteID
        public static long GenerateNewSiteID(ServerManager manager, string siteName)
        {
            if (IsIncrementalSiteIDCreationSet())
            {
                return GenerateNewSiteIDIncremental(manager);
            }
            return GenerateNewSiteIDFromName(manager, siteName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GenerateNewSiteIDIncremental(ServerManager manager)
        {
            int num = manager.Sites.Count + 1;
            long[] array = new long[num];
            int length = 1;
            for (int i = 1; i < num; i++)
            {
                long id = manager.Sites[i - 1].Id;
                if (id != 0)
                {
                    array[length++] = id;
                }
            }
            Array.Sort<long>(array, 0, length);
            for (int j = 1; j < num; j++)
            {
                if (array[j] != j)
                {
                    return j;
                }
            }
            return num;
        }

        public static bool IsIncrementalSiteIDCreationSet()
        {
            RegistryKey key = null;
            try
            {
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\InetMgr\Parameters", false);
                if (key == null)
                {
                    return false;
                }
                int num = (int)key.GetValue("IncrementalSiteIDCreation", 0);
                if (num == 1)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                    key = null;
                }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="siteName"></param>
        /// <returns></returns>
        public static int GenerateNewSiteIDFromName(ServerManager manager, string siteName)
        {
            int siteID = Math.Abs(siteName.GetHashCode());
            while (ExistsSiteId(manager, siteID))
            {
                siteID++;
            }
            return siteID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public static bool ExistsSiteId(ServerManager manager, int siteID)
        {
            foreach (Site site in manager.Sites)
            {
                if (siteID == site.Id)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        public void Dispose()
        {
            if (manager != null)
            {
                manager.Dispose();
                manager = null;
                isDisposed = true;
            }
        }
    }
}