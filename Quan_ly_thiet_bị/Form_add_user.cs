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
    public partial class Form_add_user : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        BindingSource binds = new BindingSource();
        Form_user_ frmu;
        USER users = new USER();
        List<RULE> listrule;
        public Form_add_user(Form_user_ frmu1)
        {
            InitializeComponent();
            this.frmu = frmu1;
        }

        private void Form_add_user_Load(object sender, EventArgs e)
        {
            listrule = db.RULEs.ToList();
            foreach (var item in listrule)
            {
                cmm_rule.Items.Add(item.NAME);
            }
        }

        private string Matang()
        {
            string ma = "";
            if (frmu.dataGridView1.RowCount < 0)
            {
                users.ID_USER = "U00001";
            }
            else
            {
                int k = int.Parse(frmu.dataGridView1.Rows[frmu.dataGridView1.Rows.Count - 1].Cells[0].Value.ToString().Substring(1, 5));
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
        private void btnSave_Click(object sender, EventArgs e)
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
                Load_Data();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        void Load_Data()
        {
            var list = from u in db.USERs select new {u.ID_USER,u.NAME,u.PASSWORD,u.ID_RULE };
            binds.DataSource = list.ToList();
            frmu.dataGridView1.DataSource = binds;
            this.Hide();
        }
    }
}
