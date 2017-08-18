using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.WebSiteManager
{

    [Serializable]
    public class BizException : Exception
    {
        public BizException() { }
        public BizException(string message) : base(message) { }
        public BizException(string message, Exception inner) : base(message, inner) { }
        protected BizException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
