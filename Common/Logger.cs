using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.SiteManager.Common
{
    public class Logger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void Info(string msg)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args)
        {
            this.Info(string.Format(format, args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public void Error(string msg, Exception ex)
        {

        }
    }
}