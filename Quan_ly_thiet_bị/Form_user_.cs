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
        USER user = new USER();
        List<RULE> listrule;
        RULE rule = new RULE();
        BindingSource binds;
        MD5 md5= MD5.Create();
        public Form_user_(string name)
        {
            InitializeComponent();
            textBox3.Text = name;
            textBox3.Visible = false;
            binds = new BindingSource();
            Load_User();
            
            
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
                user.ID_USER = "U00001";
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
            txt = textBox2.Text;
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
            user.ID_USER = Matang();
            user.NAME = textBox1.Text;
            user.PASSWORD =getMD5(textBox2.Text);
            user.ID_RULE = listrule[comboBox1.SelectedIndex].ID_RULE;
            db.USERs.Add(user);
            db.SaveChanges();
            Load_User();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id= dataGridView1.SelectedCells[0].OwningRow.Cells["ID_USER"].Value.ToString();
            user = db.USERs.Find(id);
            user.NAME = textBox1.Text;
            user.PASSWORD = getMD5(textBox2.Text);
            user.ID_RULE = listrule[comboBox1.SelectedIndex].ID_RULE;
            db.SaveChanges();
            Load_User();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectIndex];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            comboBox1.Text = row.Cells[3].Value.ToString();
        }
        private void Form_user__Load(object sender, EventArgs e)
        { 
            foreach (var item in listrule)
            {
                comboBox1.Items.Add(item.NAME);
               
            }
        }
    }
}
