﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Quan_ly_thiet_bị
{
    public partial class Form_Device : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        DEVICE dev = new DEVICE();
        BindingSource binds = new BindingSource();
        HISTORY his = new HISTORY();
        USER user = new USER();
        TaskType task;
        Form2 frm2;
        public Form_Device(string Name, Form2 form2)
        {
            InitializeComponent();
            txt_User_Login.Text = Name;
            txt_User_Login.Visible = false;
            txtId.Visible = false;
            Check_user();
            this.frm2 = form2;
        }
        void Load_Data()
        {
            try
            {
                var list = from d in db.DEVICEs where(d.IsUsing==true ) select new { d.Id, d.DeviceName, d.Model, d.Serial, d.VendorName, d.Qty, d.Remark, d.Image1,d.Image2,d.DeviceGroup};
                binds.DataSource = list.ToList();
                dtgviewdevice.DataSource = binds;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        void Clear()
        {
            txtName.Text = "";
            txtModel.Text = "";
            txtPurpose.Text = "";
            txtQty.Text = "";
            txtRemark.Text = "";
            txtserial.Text = "";
            txtUpdate.Text = "";
            txtVendor.Text = "";
        }
  
        private bool check_data()
        {
            bool okk = false;
            foreach(Control ctr in this.Controls)
            {
                if(ctr is TextBox)
                {
                    TextBox text = ctr as TextBox;
                    if (string.IsNullOrEmpty(text.Text))
                    {
                        okk = false;
                    }
                }
            }
            return okk;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text==""||txtModel.Text==""||txtserial.Text==""||txtVendor.Text==""||txtUpdate.Text==""||txtRemark.Text==""||txtQty.Text==""||txtPurpose.Text==""||cmbGroup.Text==null)
                {
                    MessageBox.Show("Dữ liệu không được để trống");
                }
                else
                {
                    var id = Guid.NewGuid().ToString();
                    dev.Id = id;
                    dev.DeviceName = txtName.Text;
                    dev.IsUsing = true;
                    dev.Model = txtModel.Text;
                    dev.Serial = txtserial.Text;
                    dev.VendorName = txtVendor.Text;
                    dev.Qty = int.Parse(txtQty.Text);
                    dev.Creator = txt_User_Login.Text;
                    dev.Remark = txtRemark.Text;
                    dev.Purpose = txtPurpose.Text;
                    dev.CreateDate = DateTime.Now;
                    dev.DeviceGroup = listgr[cmbGroup.SelectedIndex].ID_GROUP;
                    dev.DateMaintenance = DateTime.Parse(dateTimeplan.Value.ToString());
                    db.DEVICEs.Add(dev);
                    task = TaskType.New;
                    var Id_history = Guid.NewGuid().ToString();
                    his.ID_HISTORY = Id_history;
                    his.ID_DEVICE = dev.Id;
                    his.UPDATE_CHECK = dev.DateMaintenance;
                    his.ID_USER = dev.Creator;
                    his.STATUS = (int)task;
                    his.QUANTITY = dev.Qty;
                    db.HISTORies.Add(his);
                    db.SaveChanges();
                    Load_Data_frmMain();
                    //Load_Data();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

        }
        public List<DEVICE> LoadRecord(int page, int recordNum)
        {
            List<DEVICE> resulf = new List<DEVICE>();
            resulf = db.DEVICEs.Where(a => a.IsUsing == true).OrderBy(a => a.Id).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            return resulf;
        }
        int pageNumber = 1;
        int numberRecord = 5;
        void Load_Data_frmMain()
        {
            binds.DataSource = LoadRecord(pageNumber, numberRecord);
            frm2.dtgvdevice.DataSource = binds;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            string id= dtgviewdevice.SelectedCells[0].OwningRow.Cells["Id"].Value.ToString();
            dev = db.DEVICEs.Find(id);
            dev.IsUsing = false;
            db.SaveChanges();
            Load_Data();
        }
        struct DataParameter
        {
            public List<DEVICE> listdevice;
            public string FileName { get; set; }
        }
        DataParameter _inputParamater;
        private void btnExport_file_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    binds.DataSource = db.DEVICEs.ToList();
                    _inputParamater.listdevice = binds.DataSource as List<DEVICE>;
                    _inputParamater.FileName = sfd.FileName;
                    progressBar.Minimum = 0;
                    progressBar.Value = 0;
                    backgroundWorker1.RunWorkerAsync(_inputParamater);
                }
            }

        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            List<DEVICE> list = ((DataParameter)e.Argument).listdevice;
            string fileName = ((DataParameter)e.Argument).FileName;
            int index = 1;
            int process = list.Count();
            using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Id,DeviceName,IsUsing,DeviceGroup,Qty,Model,Serial,VendorName,DateMaintenance");
                foreach (DEVICE d in list)
                {
                    if (!backgroundWorker1.CancellationPending)
                    {
                        backgroundWorker1.ReportProgress(index++ * 100 / process);
                        sb.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", d.Id,d.DeviceName,d.IsUsing, d.DeviceGroup, d.Qty, d.Model, d.Serial, d.VendorName, d.DateMaintenance));
                    }
                }
                sw.Write(sb.ToString());
            }
        }

        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(100);
        }
       
        private void Form_Device_Load(object sender, EventArgs e)
        {
            Load_Data();
            listgr = db.GROUP_DEVICE.ToList();
            foreach (var item in listgr)
            {
                cmbGroup.Items.Add(item.NAME);
            }
            listGroupDevices = db.GROUP_DEVICE.ToList();

            foreach (var groupDevice in listGroupDevices)
            {
                cmbseach.Items.Add(groupDevice.NAME);
            }
        }
        private List<GROUP_DEVICE> listgr;
        void Load_gr(string groupID)
        {
            if (dev.IsUsing == true)
            {
                var listd = from d in db.DEVICEs where (d.DeviceGroup.Contains(groupID)) select new { d.DeviceName, d.Model, d.Serial, d.VendorName, d.Qty, d.DateMaintenance, d.Remark, d.Image1, d.Image2, d.DeviceGroup };
                binds.DataSource = listd.ToList();
                dtgviewdevice.DataSource = binds;
            }
        }
        private string selectgroupID;
        private List<GROUP_DEVICE> listGroupDevices;
        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbGroup.SelectedIndex != -1)
            //    {
            //        selectgroupID = listgr[cmbGroup.SelectedIndex].ID_GROUP;
            //        Load_gr(selectgroupID);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex.ToString());
            //}
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
        void Load_search(string txtSearch = "")
        {
            
            var list = from d in db.DEVICEs where (d.Id.Contains(txtSearch) && d.IsUsing==true) select new { d.DeviceName, d.Model, d.Serial, d.VendorName, d.Qty, d.DateMaintenance, d.Remark, d.Image1, d.Image2, d.DeviceGroup };

            binds.DataSource = list.ToList();
            dtgviewdevice.DataSource = binds;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Load_search(txtSearch.Text.Trim());
        }

        
        int selecIndex;
        private void dtgviewdevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selecIndex = e.RowIndex;
            DataGridViewRow row = dtgviewdevice.Rows[selecIndex];
        }
        void Load_DataByGroupId(string groupID)
        {
            var listd = from d in db.DEVICEs where (d.DeviceGroup.Contains(groupID) && d.IsUsing == true) select new { d.Id, d.DeviceName, d.Model, d.Serial, d.VendorName, d.Qty, d.Remark, d.Image1, d.Image2, d.DeviceGroup };
            binds.DataSource = listd.ToList();
            dtgviewdevice.DataSource = binds;
        }

        private void cmbseach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbseach.SelectedIndex != -1)
            {
                selectgroupID = listGroupDevices[cmbseach.SelectedIndex].ID_GROUP;
                Load_DataByGroupId(selectgroupID);
            }
        }
      
    }
}
