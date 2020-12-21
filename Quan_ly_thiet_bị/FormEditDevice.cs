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
    public partial class FormEditDevice : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        DEVICE dev = new DEVICE();
        HISTORY his = new HISTORY();
        TaskType task;
        public FormEditDevice(string name)
        {
            InitializeComponent();
            txt_User_Login.Text = name;
            txt_User_Login.Visible = false;
        }
        private List<GROUP_DEVICE> listgr;

        private void FormEditDevice_Load(object sender, EventArgs e)
        {
            try
            {
                listgr = db.GROUP_DEVICE.ToList();
                foreach (var item in listgr)
                {
                    cmbGroup.Items.Add(item.NAME);
                    if (DeviceGroup == item.ID_GROUP)
                    {
                        cmbGroup.Text = item.NAME;
                    }
                }
                txtId.Visible = false;
                txtId.Text = Id;
                txtName.Text = DeviceName;
                txtModel.Text = Model;
                txtSerial.Text = Serial;
                txtVendor.Text = VendorName;
                txtPurpose.Text = Purpose;
                txtQty.Text = Qty + "";
                txtUser.Text = Creator;
                //dateTimeplan.Text = DateMaintenance+"";
                if (IsUsing == true)
                {
                    checkBox1.Text = IsUsing + "";
                }
                else
                {
                    checkBox1.Checked = false;
                }
                
                txtUser.Text = Creator;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        public string Id { get; set; }
        public string FullCode { get; set; }
        public string ScortCode { get; set; }
        public Nullable<bool> IsUsing { get; set; }
        public string DeviceGroup { get; set; }
        public string DeviceName { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string VendorName { get; set; }
        public string Purpose { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> DateMaintenance { get; set; }
        public string Updater { get; set; }
        public Nullable<System.DateTime> Updatetime { get; set; }
        public Nullable<int> Qty { get; set; }
        public string Remark { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }

        public virtual GROUP_DEVICE GROUP_DEVICE { get; set; }
        public virtual USER USER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORY> HISTORies { get; set; }
        int pageNumber = 1;
        int numberRecord = 5;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Id;
                dev = db.DEVICEs.Find(id);
                dev.DeviceName = txtName.Text;
                dev.VendorName = txtVendor.Text;
                dev.IsUsing = checkBox1.Checked;
                dev.Creator = txt_User_Login.Text;
                dev.DeviceGroup = listgr[cmbGroup.SelectedIndex].ID_GROUP;
                dev.Remark = txtRemark.Text;
                dev.Updatetime = DateTime.Parse(datetimerepair.Value.ToString());
                task = TaskType.Update;
                var Id_history = Guid.NewGuid().ToString();
                his.ID_HISTORY = Id_history;
                his.ID_DEVICE = dev.Id;
                his.UPDATE_CHECK = dev.DateMaintenance;
                his.ID_USER = dev.Creator;
                his.STATUS = (int)task;
                his.NOTE = txtRemark.Text;
                his.QUANTITY = int.Parse(txtQty.Text);
                his.UPDATE_CHECK = dev.Updatetime;
                int count = Qty.Value - his.QUANTITY.Value;
                if (dev.Qty >= his.QUANTITY)
                {
                    dev.Qty = count;
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập quá số lượng thiết bị sửa!");
                }
  
                db.HISTORies.Add(his);
                db.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        
        
        void Close()
        {
            try
            {
                FormEditDevice frme = new FormEditDevice(txt_User_Login.Text);
                //Form2 frm2 = (Form2)Application.OpenForms["Form2"];
                Form2 frm2 = new Form2(txt_User_Login.Text);
                frm2.dtgvdevice.DataSource = frm2.LoadRecord(pageNumber, numberRecord);
                frm2.dtgvdevice.Update();
                frm2.Refresh();
                this.Hide();
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
