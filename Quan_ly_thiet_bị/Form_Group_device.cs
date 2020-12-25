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
    public partial class Form_Group_device : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        BindingSource bind = new BindingSource();
        GROUP_DEVICE gd = new GROUP_DEVICE();
        USER user = new USER();
        public Form_Group_device(string name)
        {
            InitializeComponent();
            Load_Data();
            txtId.Visible = false;
            txt_User_Login.Visible = false;
            txt_User_Login.Text = name;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["ID_GROUP"].Visible = false;
        }
        void Check_user()
        {
            string id = txt_User_Login.Text;
            user = db.USERs.Where(x => x.ID_USER == id).FirstOrDefault();
            if (user.ID_RULE == "R002")
            {
                groupBox1.Visible = false;

            }
        }
        void Load_Data()
        {
            var list = from gr in db.GROUP_DEVICE select new { gr.ID_GROUP,gr.NAME,gr.DESCIPTION };
            bind.DataSource = list.ToList();
            dataGridView1.DataSource = bind;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_add_group fag = new Form_add_group(this);
            fag.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_edit_group feg = new Form_edit_group();
            feg.ID_GROUP = dataGridView1.CurrentRow.Cells["ID_GROUP"].Value.ToString();
            feg.NAME = dataGridView1.CurrentRow.Cells["NAME"].Value.ToString();
            feg.DESCIPTION = dataGridView1.CurrentRow.Cells["DESCIPTION"].Value.ToString();
            feg.Show();
            
        }

        private void Form_Group_device_Load(object sender, EventArgs e)
        {

        }
    }
}
