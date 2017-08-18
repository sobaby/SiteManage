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
    public class SiteBinding
    {
        public SiteBinding()
        {
            this.Protocol = "http";
        }

        /// <summary>
        /// 所用协议
        /// </summary>
        [DataMember]
        public string Protocol { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [DataMember]
        public string IPAddress { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        [DataMember]
        public int Port { get; set; }

        /// <summary>
        /// 绑定域名
        /// </summary>
        [DataMember]
        public string HostName { get; set; }

        public override string ToString()
        {
            return IPAddress + ":" + Port + ":" + HostName; 
        }
    }
}
