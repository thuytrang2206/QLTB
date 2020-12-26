using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Quan_ly_thiet_bị
{
    public partial class Form_user_ : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        USER users = new USER();
        List<RULE> listrule;
        RULE rule = new RULE();
        BindingSource binds;
        MD5 md5= MD5.Create();
        public Form_user_(string name)
        {
            InitializeComponent();
            txt_User_Login.Text = name;
            txt_User_Login.Visible = false;
            txtId.Visible = false;
            binds = new BindingSource();
            Load_User();
            Check_user(); 
        }
        void Check_user()
        {
            string id = txt_User_Login.Text;
            users = db.USERs.Where(x => x.ID_USER == id).FirstOrDefault();
            if (users.ID_RULE == "R002")
            {
                groupBox2.Visible = false;
            }
        }
        void Load_User()
        {
            var listuser = from u in db.USERs select new { u.ID_USER, u.NAME, u.PASSWORD, u.ID_RULE };
            binds.DataSource = listuser.ToList();
            dataGridView1.DataSource = binds;
        }
       
       

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string password = txt_pass.Text;
            //    string id = dataGridView1.SelectedCells[0].OwningRow.Cells["ID_USER"].Value.ToString();
            //    users = db.USERs.Find(id);
            //    users.NAME = txt_Name.Text;
            //    users.PASSWORD = password;
            //    users.ID_RULE = listrule[cmm_rule.SelectedIndex].ID_RULE;
            //    db.SaveChanges();
            //    Load_User();
            //}
            //catch(Exception ex)
            //{
            //    Console.Write(ex.ToString());
            //}
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectIndex];
            //txt_Name.Text = row.Cells[1].Value.ToString();
            //txt_pass.Text = row.Cells[2].Value.ToString();
            //cmm_rule.Text = row.Cells[3].Value.ToString();
        }
        private void Form_user__Load(object sender, EventArgs e)
        {
          
        }
       

        private void btnAdd_user_Click_1(object sender, EventArgs e)
        {
            Form_add_user frm_add_user = new Form_add_user(this);
            frm_add_user.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_edit_user feu = new Form_edit_user(this);
            feu.ID_USER = dataGridView1.CurrentRow.Cells["ID_USER"].Value.ToString();
            feu.NAME = dataGridView1.CurrentRow.Cells["NAME"].Value.ToString();
            feu.PASSWORD = dataGridView1.CurrentRow.Cells["PASSWORD"].Value.ToString();
            feu.ID_RULE = dataGridView1.CurrentRow.Cells["ID_RULE"].Value.ToString();
            feu.Show();
        }
    }
}
