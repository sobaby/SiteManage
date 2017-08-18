using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuoMall.IISClientTest
{
    public partial class SiteInfoForm : Form
    {
        private string siteName;
        public SiteInfoForm(string siteName)
        {
            InitializeComponent();
            this.siteName = siteName;
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void SiteInfoForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(siteName) == false)
            {
                var impl = new SiteManagerImpl();

                var site = impl.GetWebSiteInfo(siteName);
                if (site != null)
                {
                    txtSiteName.Text = site.Name;
                    txtPhysicalPath.Text = site.PhysicalPath;

                    StringBuilder s = new StringBuilder();

                    //        s.AppendFormat("模式名：{0}", site.Schema.Name).AppendLine();
                    s.AppendFormat("编号：{0}", site.Id).AppendLine();
                    s.AppendFormat("网站名称：{0}", site.Name).AppendLine();
                    s.AppendFormat("物理路径：{0}", site.PhysicalPath).AppendLine();
                    //        s.AppendFormat("物理路径凭据：{0}", site.Methods.ToString()).AppendLine();
                    s.AppendFormat("应用程序池：{0}", site.ApplicationPoolName).AppendLine();
                    //        s.AppendFormat("已启用的协议：{0}", site.Applications["/"].EnabledProtocols).AppendLine();
                    s.AppendFormat("自动启动：{0}", site.ServerAutoStart).AppendLine();
                    s.AppendFormat("运行状态：{0}", site.State.ToString()).AppendLine();

                    s.AppendFormat("网站绑定：").AppendLine();
                    foreach (var tmp in site.Bindings)
                    {
                        s.AppendFormat("\t类型：{0}", tmp.Protocol).AppendLine();
                        s.AppendFormat("\tIP 地址：{0}", tmp.IPAddress).AppendLine();
                        s.AppendFormat("\t端口：{0}", tmp.Port.ToString()).AppendLine();
                        s.AppendFormat("\t主机名：{0}", tmp.HostName).AppendLine();
                        s.Append(tmp.ToString()).AppendLine();
                        //            s.Append(tmp.CertificateStoreName).AppendLine();
                        //            //s.AppendFormat(tmp.IsIPPortHostBinding).AppendLine();
                        //            //s.AppendFormat(tmp.IsLocallyStored).AppendLine();
                        //            //s.AppendFormat(tmp.UseDsMapper).AppendLine();
                    }

                    //        //site.VirtualDirectoryDefaults.SetAttributeValue("physicalPath", physicalPath);

                    //        s.AppendFormat("------获取Attributes--------").AppendLine();
                    //        foreach (var item in site.Attributes)
                    //        {
                    //            s.Append(item.Name).Append( "=").Append( item.Value).AppendLine();
                    //        }
                    //        s.AppendFormat("------获取Applications=/的Attributes--------").AppendLine();
                    //        foreach (var item in site.Applications["/"].Attributes)
                    //        {
                    //            s.Append(item.Name).Append("=").Append(item.Value).AppendLine();
                    //        }
                    //        s.AppendFormat("------获取Applications=/ VirtualDirectories=/的Attributes--------").AppendLine();
                    //        foreach (var item in site.Applications["/"].VirtualDirectories["/"].Attributes)
                    //        {
                    //            s.Append(item.Name).Append("=").Append(item.Value).AppendLine();
                    //        }

                    //        s.AppendFormat("------获取默认目录属性--------").AppendLine();
                    //                    foreach (var item in site.VirtualDirectoryDefaults.Attributes)
                    //        {
                    //            s.Append(item.Name).Append( "=").Append( item.Value).AppendLine();
                    //        }
                    //        s.AppendFormat("----虚拟目录的默认物理路径凭据登录类型：{0}", site.VirtualDirectoryDefaults.LogonMethod.ToString()).AppendLine();
                    //        s.AppendFormat("----虚拟目录的默认用户名：{0}", site.VirtualDirectoryDefaults.UserName).AppendLine();
                    //        s.AppendFormat("----虚拟目录的默认用户密码：{0}", site.VirtualDirectoryDefaults.Password).AppendLine();
                    //        s.Append("应用程序 列表：").AppendLine();

                    foreach (var tmp in site.Applications)
                    {
                        if (tmp.Path != "/")
                        {
                            //s.AppendFormat("\t模式名：{0}", tmp.Schema.Name).AppendLine();
                            s.AppendFormat("\t虚拟路径：{0}", tmp.Path).AppendLine();
                            s.AppendFormat("\t物理路径：{0}", tmp.PhysicalPath).AppendLine();
                            //                s.AppendFormat("\t物理路径凭据：{0}", tmp.Methods.ToString()).AppendLine();
                            //                s.AppendFormat("\t应用程序池：{0}", tmp.ApplicationPoolName).AppendLine();
                            //                s.AppendFormat("\t已启用的协议：{0}", tmp.EnabledProtocols).AppendLine();
                        }
                    }

                    //        s.Append("--------APP-----------").AppendLine();
                    //        var app = IISManager.GetApplicationPool(site.Applications["/"].ApplicationPoolName);
                    //        s.AppendFormat("app：{0}", app.Name).AppendLine();
                    //        s.AppendFormat("运行状态：{0}", app.State.ToString()).AppendLine();
                    //        s.AppendFormat("AutoStart：{0}", app.AutoStart.ToString()).AppendLine();
                    //        s.AppendFormat("StartMode：{0}", app.StartMode.ToString()).AppendLine();
                    //        s.AppendFormat("------Attributes--------").AppendLine();
                    //        foreach (var item in app.Attributes)
                    //        {
                    //            s.Append(item.Name).Append("=").Append(item.Value).AppendLine();
                    //        }
                    //        s.AppendFormat("------WorkerProcesses.Attributes--------").AppendLine();
                    //        foreach (var item in app.WorkerProcesses.Attributes)
                    //        {
                    //            s.Append(item.Name).Append("=").Append(item.Value).AppendLine();
                    //        }

                    textBox1.AppendText(s.ToString());
                }
            }
        }
    }
}