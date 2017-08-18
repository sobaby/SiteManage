using DuoMall.SiteManager.Common;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoMall.WebSiteManager
{
    class Util
    {
        public static SiteState ConvertoObjectState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Starting:
                    return SiteState.Starting;
                case ObjectState.Started:
                    return SiteState.Started;
                case ObjectState.Stopping:
                    return SiteState.Stopping;
                case ObjectState.Stopped:
                    return SiteState.Stopped;
                default:
                    return SiteState.Unknown;
            }
        }

        public static string GetManagedRuntimeVersion(ManagedRuntimeVersion s)
        {
            switch (s)
            {
                case ManagedRuntimeVersion.V20:
                    return "v2.0";
                case ManagedRuntimeVersion.V40:
                    return "v4.0";
                case ManagedRuntimeVersion.V45:
                    return "v4.5";
                default:
                    return "v4.0";
            }
        }
    }
}
