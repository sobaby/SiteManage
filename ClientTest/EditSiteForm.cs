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
    public partial class EditSiteForm : Form
    {
        public EditSiteForm()
        {
            InitializeComponent();
        }
               

        private void button1_Click(object sender, EventArgs e)
        {
            //创建应用程序池
            //if (IISManager.CreateWebSite(txtSiteName.Text, txtPhysicalPath.Text))
            //{
            //    IISManager.AddSiteBinding(txtSiteName.Text, "", txtPort.Text, "", "http");
            //}
        }
    }
}
