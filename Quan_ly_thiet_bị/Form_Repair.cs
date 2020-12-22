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
    public partial class Form_Repair : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        DEVICE dev = new DEVICE();
        HISTORY his = new HISTORY();
        USER user = new USER();
        TaskType task;
        public Form_Repair(string name)
        {
            InitializeComponent();
            txt_User_Login.Text = name;
            txt_User_Login.Visible = false;
        }
        
        List<DEVICE> listdevice;
        private void Form_Repair_Load(object sender, EventArgs e)
        {
            listdevice = db.DEVICEs.ToList();
            foreach(var item in listdevice)
            {
                cbbId_Device.Items.Add(item.Id);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try {
                task = TaskType.Repair;
                var id = Guid.NewGuid().ToString();
                his.ID_HISTORY = id;
                his.ID_DEVICE = listdevice[cbbId_Device.SelectedIndex].Id;
                txtName.Text= listdevice[cbbId_Device.SelectedIndex].DeviceName;
                his.UPDATE_CHECK = DateTime.Parse(dateTimerepair.Value.ToString());
                his.NOTE = txtNote.Text;
                his.STATUS =(int) task;
                 if (checkBox1.Checked == true)
                {
                    his.INFOCHECK = 1;
                }
                  else if(checkBox2.Checked== true)
                {
                    his.INFOCHECK = 0;
                }
                his.QUANTITY = int.Parse(txtQty.Text);
                int count = dev.Qty.Value- his.QUANTITY.Value ;
                if (dev.Qty >= his.QUANTITY)
                {
                    dev.Qty = count;
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập quá số lượng thiết bị sửa!");
                }
                his.ID_USER = txt_User_Login.Text;
                db.HISTORies.Add(his);
                db.SaveChanges();
                this.Hide();
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        private void cbbId_Device_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbId_Device.SelectedIndex != -1)
            {
               string id = listdevice[cbbId_Device.SelectedIndex].Id;
                dev = db.DEVICEs.Find(id);
                txtName.Text = dev.DeviceName;
                txtName.Enabled = false;
            }
        }
    }
}
