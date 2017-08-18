using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.SiteManager.Common
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ApplicationPoolInfo
    {
        public ApplicationPoolInfo()
        {
            this.AutoStart = true;
        }
        /// <summary>
        /// 程序池名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 是否自动启动
        /// </summary>
        [DataMember]
        public bool AutoStart { get; set; }

        /// <summary>
        /// .NET版本
        /// </summary>
        [DataMember]
        public string ManagedRuntimeVersion { get; set; }
    }
}