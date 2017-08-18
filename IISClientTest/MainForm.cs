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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitSite();
        }
        private void InitSite()
        {
            listView1.Items.Clear();
            var impl = new SiteManagerImpl();
            foreach (var site in impl.GetAllSite())
            {
                ListViewItem lvi = new ListViewItem(new string[] { site.Id.ToString(),
                    site.Name,
                    site.PhysicalPath
                });
                //lvi.Tag = site;
                listView1.Items.Add(lvi);
            }
        }

        private void 站点信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                var sel = listView1.SelectedItems[0];

                SiteInfoForm frm = new SiteInfoForm(sel.SubItems[1].Text);
                frm.ShowDialog();
            }
        }
    }
}
