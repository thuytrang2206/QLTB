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
    public partial class Form_add_device : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        BindingSource binds = new BindingSource();
        DEVICE dev = new DEVICE();
        HISTORY his = new HISTORY();
        USER user = new USER();
        TaskType task;
        Form2 frm2;
        Form_Device fmd;
        public Form_add_device(string Name, Form_Device fmd1,Form2 form2)
        {
            InitializeComponent();
            txt_User_Login.Text = Name;
            txt_User_Login.Visible = false;
            txtId.Visible = false;
            this.fmd = fmd1;
            this.frm2 = form2;
        }
        void Clear()
        {
            txtName.Text = "";
            txtModel.Text = "";
            txtPurpose.Text = "";
            txtQty.Text = "";
            txtRemark.Text = "";
            txtserial.Text = "";
 
            txtVendor.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtModel.Text == "" || txtserial.Text == "" || txtVendor.Text == "" || txtRemark.Text == "" || txtQty.Text == "" || txtPurpose.Text == "" || cmbGroup.Text == null)
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
                   // his.ID_USER = dev.Creator;
                    var user = db.USERs.Where(u => u.ID_USER == txt_User_Login.Text).FirstOrDefault();
                    if (user != null)
                    {
                        string name = user.NAME;
                        his.ID_USER =name;
                    }
                    his.STATUS = TaskType.New.ToString(); ;
                    his.QUANTITY = dev.Qty;
                    db.HISTORies.Add(his);
                    db.SaveChanges();
                    Load_Data();
                    Load_Data_frmMain();

                    Clear();
                    this.Hide();
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
        int numberRecord = 10;
        void Load_Data()
        {
            var list = from d in db.DEVICEs where (d.IsUsing == true) select new { d.Id, d.DeviceName, d.Model, d.Serial, d.VendorName, d.Qty, d.Remark, d.Image1, d.Image2, d.DeviceGroup };
            binds.DataSource = list.ToList();
            fmd.dtgviewdevice.DataSource = binds;
        }
        void Load_Data_frmMain()
        {
            binds.DataSource = LoadRecord(pageNumber, numberRecord);
            frm2.dtgvdevice.DataSource = binds;
        }
        private List<GROUP_DEVICE> listgr;
        private void Form_add_device_Load(object sender, EventArgs e)
        {
            listgr = db.GROUP_DEVICE.ToList();
            foreach (var item in listgr)
            {
                cmbGroup.Items.Add(item.NAME);
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
