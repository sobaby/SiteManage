using DuoMall.SiteManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.IISClientTest
{
    public class SiteManagerImpl
    {
        public List<SiteInfo> GetAllSite()
        {
            var url = "http://localhost:8000/SiteService/Site";

            return HttpClientUtil.Get<List<SiteInfo>>(url);
        }
        public SiteInfo GetWebSiteInfo(string siteName)
        {
            var url = "http://localhost:8000/SiteService/Site/" + siteName;

            return HttpClientUtil.Get<SiteInfo>(url);
        }
    }
}
