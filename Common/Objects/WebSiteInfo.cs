using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.SiteManager.Common
{
    [DataContract]
    public class SiteInfo
    {
        public SiteInfo()
        {
            this.Bindings = new List<SiteBinding>();
            this.Applications = new List<SiteApplication>();
        }
        /// <summary>
        /// 站点ID
        /// </summary>
        [DataMember]
        public long Id { get; set;}


        /// <summary>
        /// .NET版本
        /// </summary>
        [DataMember]
        public ManagedRuntimeVersion ManagedRuntimeVersion { get; set; }

        /// <summary>
        /// 站点名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 物理路径
        /// </summary>
        [DataMember]
        public string PhysicalPath { get; set; }

        /// <summary>
        /// 自动启动
        /// </summary>
        [DataMember]
        public bool ServerAutoStart { get; set; }

        /// <summary>
        /// 站点状态
        /// </summary>
        [DataMember]
        public SiteState State { get; set; }

        /// <summary>
        /// 应用程序池名称
        /// </summary>
        [DataMember]
        public string ApplicationPoolName { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[DataMember]
        //public string UserName { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[DataMember]
        //public string Password { get; set; }

        /// <summary>
        /// 站点绑定
        /// </summary>
        [DataMember]
        public List<SiteApplication> Applications { get; set; }

        /// <summary>
        /// 站点绑定
        /// </summary>
        [DataMember]
        public List<SiteBinding> Bindings { get; set; }
    }
}
