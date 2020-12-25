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
    public partial class Form_edit_group : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        GROUP_DEVICE gr = new GROUP_DEVICE();
        BindingSource bind = new BindingSource();
        Form_Group_device fm;
        public Form_edit_group(Form_Group_device frmgd)
        {
            InitializeComponent();
            this.fm = frmgd;
        }

        private void Form_edit_group_Load(object sender, EventArgs e)
        {
           txtid.Text = ID_GROUP;
            txtName.Text = NAME;
            txtdes.Text = DESCIPTION;
        }
        public string ID_GROUP { get; set; }
        public string NAME { get; set; }
        public string  DESCIPTION { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = ID_GROUP;
            gr = db.GROUP_DEVICE.Find(id);
            gr.NAME=txtName.Text;
            gr.DESCIPTION=txtdes.Text;
            db.SaveChanges();
            ReLoad_Data();
        }
        void ReLoad_Data()
        {
            var list = from g in db.GROUP_DEVICE select new {g.ID_GROUP, g.NAME, g.DESCIPTION };
            bind.DataSource = list.ToList();
            fm.dataGridView1.DataSource = bind;
            this.Hide();
        }
    }
}
