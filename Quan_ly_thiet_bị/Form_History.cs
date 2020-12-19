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
            var list_history = from h in db.HISTORies select new { h.ID_HISTORY, h.ID_DEVICE,h.QUANTITY, h.INFOCHECK, h.NOTE, h.STATUS, h.UPDATE_CHECK, h.ID_USER };
            binds.DataSource = list_history.ToList();
            dtgviewhistory.DataSource = binds;
        }

        private void Form_History_Load(object sender, EventArgs e)
        {

        }
    }
}
