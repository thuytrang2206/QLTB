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
    public partial class Form_History : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        HISTORY his = new HISTORY();
        BindingSource binds = new BindingSource();
     
        public Form_History()
        {
            InitializeComponent();
            var list_history = from h in db.HISTORies join d in db.DEVICEs on h.ID_DEVICE equals d.Id select new {DEVICE_NAME=d.DeviceName, h.QUANTITY, h.INFOCHECK, h.NOTE, h.STATUS, h.UPDATE_CHECK, h.ID_USER };
            binds.DataSource = list_history.ToList();
            dtgviewhistory.DataSource = binds;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            var list_date = from h in db.HISTORies join d in db.DEVICEs on h.ID_DEVICE equals d.Id where (date == h.UPDATE_CHECK) select new { DEVICE_NAME = d.DeviceName, h.QUANTITY, h.INFOCHECK, h.NOTE, h.STATUS, h.UPDATE_CHECK, h.ID_USER };
            binds.DataSource = list_date.ToList();
            dtgviewhistory.DataSource = binds;
        }
        void Load_search(string textBox1 = "")
        {
            var list = from h in db.HISTORies join d in db.DEVICEs on h.ID_DEVICE equals d.Id where (d.DeviceName.Contains(textBox1) ) select new { DEVICE_NAME = d.DeviceName, h.QUANTITY, h.INFOCHECK, h.NOTE, h.STATUS, h.UPDATE_CHECK, h.ID_USER };
            binds.DataSource = list.ToList();
            dtgviewhistory.DataSource = binds;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        { 
            Load_search(textBox1.Text.Trim());
        }
    }
}
