﻿using System;
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
        void Load_data()
        {
            var list = from d in db.DEVICEs select new { d.Id, d.DeviceName, d.Model, d.Serial, d.VendorName, d.Qty };
            binds.DataSource = list.ToList();
            dtgvdevice.DataSource = binds;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dtgvdevice.DataSource = LoadRecord(pageNumber, numberRecord);
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectIndex = e.RowIndex;
            DataGridViewRow row = dtgvdevice.Rows[selectIndex];

        }

        private void deviceGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Group_device frm_d = new Form_Group_device(label2.Text);
            frm_d.ShowDialog();
        }

        private void deviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Device frm_d = new Form_Device(label2.Text);
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
        int pageNumber = 1;
        int numberRecord = 5;
        List<DEVICE> LoadRecord(int page,int recordNum)
        {
            List<DEVICE> resulf = new List<DEVICE>();
            resulf = db.DEVICEs.OrderBy(a=>a.Id).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            return resulf;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageNumber-1> 0)
            {
                pageNumber--;
                dtgvdevice.DataSource = LoadRecord(pageNumber, numberRecord);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalRecord = 0;
            totalRecord = db.DEVICEs.Count();
            if (pageNumber-1<totalRecord/numberRecord)
            {
                pageNumber++;
                dtgvdevice.DataSource = LoadRecord(pageNumber, numberRecord);
            }
        }
        USER user = new USER();
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = label2.Text;
            user = db.USERs.Where(x => x.ID_USER == id).FirstOrDefault();
            if (user.ID_RULE == "R001")
            {
                FormEditDevice frmedit = new FormEditDevice(label2.Text);
                frmedit.Id = dtgvdevice.CurrentRow.Cells["Id"].Value.ToString();
                frmedit.DeviceName = dtgvdevice.CurrentRow.Cells["DeviceName"].Value.ToString();
                frmedit.Model = dtgvdevice.CurrentRow.Cells["Model"].Value.ToString();
                frmedit.Serial = dtgvdevice.CurrentRow.Cells["Serial"].Value.ToString();
                frmedit.VendorName = dtgvdevice.CurrentRow.Cells["VendorName"].Value.ToString();
                frmedit.Purpose = dtgvdevice.CurrentRow.Cells["Purpose"].Value.ToString();
                frmedit.Qty = int.Parse(dtgvdevice.CurrentRow.Cells["Qty"].Value.ToString());
                frmedit.Creator = dtgvdevice.CurrentRow.Cells["Creator"].Value.ToString();
                frmedit.Remark = dtgvdevice.CurrentRow.Cells["Remark"].Value.ToString();
                frmedit.DeviceGroup = dtgvdevice.CurrentRow.Cells["DeviceGroup"].Value.ToString();
                frmedit.IsUsing = bool.Parse(dtgvdevice.CurrentRow.Cells["IsUsing"].Value.ToString());
                frmedit.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sửa dữ liệu!");
            }
            
        }
        FormEditDevice frmeditd = (FormEditDevice)Application.OpenForms["FormEditDevice"];
    }
}
