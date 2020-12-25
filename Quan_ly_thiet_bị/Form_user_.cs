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
        private string Matang()
        {
            string ma = "";
            if (dataGridView1.RowCount < 0)
            {
                users.ID_USER = "U00001";
            }
            else
            {
                int k = int.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString().Substring(1, 5));
                k = k + 1;
                ma = "U";
                if (k < 10)
                {
                    ma = ma + "0000";
                }
                else if (k < 100)
                {
                    ma = ma + "000";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }
        private string getMD5(string txt)
        {
            txt = txt_pass.Text;
            string str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string password = txt_pass.Text;
                string id = dataGridView1.SelectedCells[0].OwningRow.Cells["ID_USER"].Value.ToString();
                users = db.USERs.Find(id);
                users.NAME = txt_Name.Text;
                users.PASSWORD = password;
                users.ID_RULE = listrule[cmm_rule.SelectedIndex].ID_RULE;
                db.SaveChanges();
                Load_User();
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectIndex];
            txt_Name.Text = row.Cells[1].Value.ToString();
            txt_pass.Text = row.Cells[2].Value.ToString();
            cmm_rule.Text = row.Cells[3].Value.ToString();
        }
        private void Form_user__Load(object sender, EventArgs e)
        {
            listrule = db.RULEs.ToList();
            foreach (var item in listrule)
            {
                cmm_rule.Items.Add(item.NAME);
            }
        }
        void Add()
        {
            try
            {
                string id = Matang();
                users.ID_USER = id;
                users.NAME = txt_Name.Text;
                users.PASSWORD = getMD5(txt_pass.Text);
                users.ID_RULE = listrule[cmm_rule.SelectedIndex].ID_RULE;
                db.USERs.Add(users);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        private void btnAdd_user_Click(object sender, EventArgs e)
        {
            Add();
            Load_User();
        }
    }
}
