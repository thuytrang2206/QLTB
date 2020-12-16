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
    public partial class Form_Group_device : Form
    {
        Manager_deviceEntities db = new Manager_deviceEntities();
        BindingSource bind = new BindingSource();
        GROUP_DEVICE gd = new GROUP_DEVICE();
        public Form_Group_device()
        {
            InitializeComponent();
            Load_Data();
        }
        void Load_Data()
        {
            var list = from gr in db.GROUP_DEVICE select new { gr.ID_GROUP, gr.NAME };
            bind.DataSource = list.ToList();
            dataGridView1.DataSource = bind;
        }
    }
}
