using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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
        public Form_Device(string Name)
        {
            InitializeComponent();
            txt_User_Login.Text = Name;
            txt_User_Login.Visible = false;
            txtId.Visible = false;
            Load_Data();
            Check_user();
        }
        void Load_Data()
        {
            try
            {
                var list = from d in db.DEVICEs select new { d.Id, d.DeviceName, d.Model, d.Serial, d.VendorName, d.Qty, d.Remark, d.Image1,d.Image2,d.DeviceGroup};
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
            txtCreator.Text = "";
            txtName.Text = "";
            txtModel.Text = "";
            txtPurpose.Text = "";
            txtQty.Text = "";
            txtRemark.Text = "";
            txtserial.Text = "";
            txtUpdate.Text = "";
            txtVendor.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
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
                Load_Data();
                Clear();
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

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
       
    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DEVICE> list = ((DataParameter)e.Argument).listdevice;
            string fileName = ((DataParameter)e.Argument).FileName;
            int index = 1;
            int process = list.Count();
            using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID_DEVICE,NAME,UPDATETIME,DATEPLAN,ID_GROUP,ID_USER");
                foreach (DEVICE d in list)
                {
                    if (!backgroundWorker1.CancellationPending)
                    {
                        backgroundWorker1.ReportProgress(index++ * 100 / process);
                        sb.AppendLine(string.Format("{0},{1},{2},{3},{4},{5}", d.Id));
                    }
                }
                sw.Write(sb.ToString());
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Thread.Sleep(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }
        private void Form_Device_Load(object sender, EventArgs e)
        {
            listgr = db.GROUP_DEVICE.ToList();
            foreach (var item in listgr)
            {
                cmbGroup.Items.Add(item.NAME);
            }
        }
        private List<GROUP_DEVICE> listgr;
        void Load_gr(string groupID)
        {
            var listd = from d in db.DEVICEs where (d.DeviceGroup.Contains(groupID)) select new { d.Id, d.DeviceName, d.Model, d.Serial, d.VendorName, d.Qty, d.Remark, d.Image1, d.Image2, d.DeviceGroup };
            binds.DataSource = listd.ToList();
            dtgviewdevice.DataSource = binds;

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
    }
}
