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
    public partial class Form2 : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        DEVICE dev = new DEVICE();
        BindingSource binds = new BindingSource();
        public Form2(string strname)
        {
            InitializeComponent();
            Form1 frm1 = new Form1();
            frm1.Hide();
            label2.Text = strname;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var list = from d in db.DEVICEs select new {d.Id, d.DeviceName, d.Model, d.Serial, d.VendorName, d.Qty };
            binds.DataSource = list.ToList();
            dataGridView1.DataSource = binds;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deviceGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Group_device frm_d = new Form_Group_device();
            frm_d.ShowDialog();
        }

        private void deviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Device frm_d = new Form_Device();
            frm_d.ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_User frm_d = new Form_User();
            frm_d.ShowDialog();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Rules frm_d = new Form_Rules();
            frm_d.ShowDialog();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_History frm_d = new Form_History();
            frm_d.ShowDialog();
        }
    }
}
