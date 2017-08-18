using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.SiteManager.Common
{
    [DataContract]
    public class SiteApplication
    {

        /// <summary>
        /// 当前路径
        /// </summary>
        [DataMember]
        public string Path { get; set; }

        /// <summary>
        /// 应用程序池名称
        /// </summary>
        [DataMember]
        public string ApplicationPoolName { get; set; }

        /// <summary>
        /// 物理路径
        /// </summary>
        [DataMember]
        public string PhysicalPath { get; set; }
    }
}