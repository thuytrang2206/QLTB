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
    public partial class Form_edit_user : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        RULE rule = new RULE();
        USER user = new USER();
        List<RULE> listrule;
        BindingSource bind = new BindingSource();
        Form_user_ fruser;
        public string ID_USER { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        public string ID_RULE { get; set; }
        public Form_edit_user(Form_user_ frmuser)
        {
            InitializeComponent();
            this.fruser = frmuser;
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
            string id = ID_USER;
            user = db.USERs.Find(id);
            user.NAME = txt_Name.Text;
            user.PASSWORD = getMD5(txt_pass.Text);
            user.ID_RULE = listrule[cmm_rule.SelectedIndex].ID_RULE;
            db.SaveChanges();
            Load_Data();
        }

        private void Form_edit_user_Load(object sender, EventArgs e)
        {
            txtId.Text = ID_USER;
            txt_Name.Text = NAME;
            txt_pass.Text = PASSWORD;
            listrule = db.RULEs.ToList();
            foreach (var item in listrule)
            {
                cmm_rule.Items.Add(item.NAME);
                if (ID_RULE == item.ID_RULE)
                {
                    cmm_rule.Text =item.NAME;
                }
            }
        }
        void Load_Data()
        {
            var list = from u in db.USERs select new { u.ID_USER, u.NAME, u.PASSWORD, u.ID_RULE };
            bind.DataSource = list.ToList();
            fruser.dataGridView1.DataSource = bind;
            this.Hide();
        }
    }
}
