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
    public partial class Form_Rules : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        BindingSource binds;
        RULE rule = new RULE();
        public Form_Rules(string name)
        {
            InitializeComponent();
            txt_User_Login.Visible = false;
            txt_User_Login.Text = name;
            binds = new BindingSource();
            Load_rule();
        }

        void Check_user()
        {
            string id = txt_User_Login.Text;
            rule = db.RULEs.Where(x => x.ID_RULE == id).FirstOrDefault();
            if (rule.ID_RULE == "R002")
            {
                groupBox1.Visible = false;

            }
        }
        void Load_rule()
        {
            var list = from r in db.RULEs select new { r.ID_RULE, r.NAME };
            binds.DataSource = list.ToList();
            dataGridView1.DataSource = binds;
        }
        private string Matang()
        {
            string ma = "";
            if (dataGridView1.RowCount < 0)
            {
                rule.ID_RULE = "R001";
            }
            else
            {
                ma = "R";
                int k = int.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString().Substring(1,3));
                k = k + 1;
                if (k < 10)
                {
                    ma = ma + "00";
                }
                else if (k < 100)
                {
                    ma = ma + "0";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            rule.ID_RULE = Matang();
            rule.NAME = txtName.Text;
            db.RULEs.Add(rule);
            db.SaveChanges();
            Load_rule();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //txtId.Enabled = false;
            string Id = dataGridView1.SelectedCells[0].OwningRow.Cells["ID_RULE"].Value.ToString();
            rule = db.RULEs.Find(Id);
            rule.NAME = txtName.Text;
            db.SaveChanges();
            Load_rule();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int selectIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectIndex];
            txtName.Text = row.Cells[1].Value.ToString();
        }
    }
}
