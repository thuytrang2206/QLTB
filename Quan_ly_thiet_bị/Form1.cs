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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Manager_deviceEntities db = new Manager_deviceEntities();
        MD5 md5 = MD5.Create();
        private string getMD5(string txt)
        {
            txt = txtpass.Text;
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
        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
        USER user = new USER();
        List<USER> listuser;
        BindingSource bind = new BindingSource();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = getMD5(txtpass.Text);
            try
            {
                var u = db.USERs.Where(r => r.NAME == txtName.Text && r.PASSWORD == password).FirstOrDefault();
                if (u != null)
                {
                     txtUser.Text=u.ID_USER;

                    Form2 frm = new Form2(txtUser.Text);
                    this.Hide();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Login is not correct!");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
