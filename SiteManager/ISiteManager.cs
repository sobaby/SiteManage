using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using DuoMall.SiteManager.Common;

namespace DuoMall.WebSiteManager
{
    [ServiceContract(Name = "RestDemoServices")]
    public interface ISiteManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "Site", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        List<SiteInfo> GetAllSite();

        /// <summary>
        /// 添加虚拟目录
        /// </summary>
        /// <param name="siteName"></param>
        [OperationContract]
        void AddVirtualDirectory(string siteName);

        /// <summary>
        /// 添加站点
        /// </summary>
        /// <param name="siteInfo"></param>
        [OperationContract]
        void CreateWebSite(SiteInfo siteInfo);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns></returns>
        [OperationContract]

        bool WebSiteExists(string siteName);

        /// <summary>
        /// 获取站点信息
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "Site/{siteName}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        SiteInfo GetWebSiteInfo(string siteName);

        /// <summary>
        /// 启动站点 
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns></returns>
        [OperationContract]
        SiteState Start(string siteName);

        /// <summary>
        /// 停止站点
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns></returns>
        [OperationContract]
        SiteState Stop(string siteName);
    }
}