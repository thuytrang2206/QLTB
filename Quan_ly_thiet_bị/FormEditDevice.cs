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
 
        public FormEditDevice(string name)
        {
            InitializeComponent();
            txt_User_Login.Text = name;
            txt_User_Login.Visible = false;
        }

        private void FormEditDevice_Load(object sender, EventArgs e)
        {
            txtId.Visible = false;
            txtId.Text = Id;
            txtName.Text = DeviceName;
            txtModel.Text = Model;
            txtSerial.Text = Serial;
            txtVendor.Text = VendorName;
            txtPurpose.Text = Purpose;
            txtQty.Text = Qty+"";
            txtUser.Text = Creator;
            txtRemark.Text = Remark;
            cbbIsUsing.Text = IsUsing+"";
            cmbGroup.Text = DeviceGroup;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Id;
                dev = db.DEVICEs.Find(id);
                dev.DeviceName = txtName.Text;
                dev.VendorName = txtVendor.Text;
                dev.IsUsing = bool.Parse(cbbIsUsing.Text);
                dev.Creator = txt_User_Login.Text;
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
            FormEditDevice frme = new FormEditDevice(txt_User_Login.Text);
            this.Hide();
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
        //    FormEditDevice frme = new FormEditDevice(txt_User_Login.Text);
        //    frme.FormClosed += new FormClosedEventHandler(FormEditDevice_FormClosed);
        //    this.Hide();

        }
        private void FormEditDevice_FormClosed(object sender, FormClosedEventArgs e)
        {
        //    Form2 frm2 = new Form2(txt_User_Login.Text);
            
        //    this.Show();
        //    FormEditDevice frme = new FormEditDevice(txt_User_Login.Text);
        //    frme.Close();
        }
    }
}
