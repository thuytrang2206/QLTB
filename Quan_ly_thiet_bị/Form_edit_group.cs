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
    public partial class Form_edit_group : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        GROUP_DEVICE gr = new GROUP_DEVICE();

        public Form_edit_group()
        {
            InitializeComponent();
        }

        private void Form_edit_group_Load(object sender, EventArgs e)
        {
           txtid.Text = ID_GROUP;
            txtName.Text = NAME;
            txtdes.Text = DESCIPTION;
        }
        public string ID_GROUP { get; set; }
        public string NAME { get; set; }
        public string  DESCIPTION { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = ID_GROUP;
            gr = db.GROUP_DEVICE.Find(id);
            txtName.Text = NAME;
            txtdes.Text = DESCIPTION;
            db.SaveChanges();
        }
        void ReLoad_Data() { }
    }
}
