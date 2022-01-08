using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.IO;
using Common.Tools;
using Database.FileConfigs;
using Common.Utils;
using System.Configuration;
using System.Diagnostics;

namespace WebApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Creater: system
        /// Created: 
        /// UpdatedBy:Wai Khai Sheng
        /// Updated:20220108
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            new FileSystemWatcherConfig().SetupFileSystemWatcherConfig();
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = this.Server.GetLastError();
            Debug.WriteLine(ex);
            if (ex.InnerException != null)
                Debug.WriteLine(ex.InnerException);
        }
    }
}