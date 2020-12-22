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
    public partial class Form_User : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        USER user = new USER();
        RULE rule = new RULE();
        BindingSource binds;
        List<RULE> listrule;
        
        public Form_User(string name)
        {
            InitializeComponent();
            txtid.Visible = false;
            txt_User_Login.Visible = false;
            txt_User_Login.Text = name;
            binds = new BindingSource();
            
            Check_user();
            listrule = db.RULEs.ToList();
            foreach(var name_rule in listrule)
            {
                cmbrule.Items.Add(name_rule.NAME);
                if (user.ID_RULE == name_rule.ID_RULE)
                {
                    cmbrule.Text = name_rule.NAME;
                }
            }

        }
        void LoadData()
        {
            var list = from u in db.USERs select new { u.ID_USER, u.NAME, u.PASSWORD ,u.ID_RULE};
            binds.DataSource = list.ToList();
            dataGridView1.DataSource = binds;
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

        private string Matang()
        {
            string ma = "";
            if (dataGridView1.RowCount < 0)
            {
                user.ID_USER = "U00001";
            }
            else
            {
                int k =int.Parse( dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString().Substring(1, 5));
                k = k + 1;
                ma = "U";
                if(k<10)
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtid.Enabled = false;
            string Id = dataGridView1.SelectedCells[0].OwningRow.Cells["ID_USER"].Value.ToString();
            user = db.USERs.Find(Id);
            user.NAME = txtname.Text;
            user.PASSWORD = txtpass.Text;
            user.ID_RULE = listrule[cmbrule.SelectedIndex].ID_RULE;
            db.SaveChanges();
            LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Enabled = false;
            int selectIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectIndex];
            txtid.Text = row.Cells[0].Value.ToString();
            txtname.Text = row.Cells[1].Value.ToString();
            txtpass.Text = row.Cells[2].Value.ToString();
            cmbrule.Text = row.Cells[3].Value.ToString();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                user.ID_USER = Matang();
                user.NAME = txtname.Text;
                user.PASSWORD = txtpass.Text;
                user.ID_RULE = listrule[cmbrule.SelectedIndex].ID_RULE;
                db.USERs.Add(user);
                db.SaveChanges();
                LoadData();
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
