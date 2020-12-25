using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_thiet_bị
{
    public partial class Form_add_group : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        GROUP_DEVICE gr = new GROUP_DEVICE();
        Form_Group_device fm;
        BindingSource bind = new BindingSource();
        public Form_add_group(Form_Group_device frmgd)
        {
            InitializeComponent();
            this.fm = frmgd;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            gr.ID_GROUP = id;
            gr.NAME = txtName.Text ;
            gr.DESCIPTION = txtdes.Text;
            db.GROUP_DEVICE.Add(gr);
            db.SaveChanges();
            Load();
        }
        void Load()
        {
            var list = from g in db.GROUP_DEVICE select new { g.ID_GROUP,g.NAME, g.DESCIPTION };
            bind.DataSource = list.ToList();
            fm.dataGridView1.DataSource = bind;
            this.Hide();
        }
    }
}
