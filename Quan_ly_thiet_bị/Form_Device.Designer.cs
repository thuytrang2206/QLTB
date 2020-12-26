namespace Quan_ly_thiet_bị
{
    partial class Form_Device
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_User_Login = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbseach = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnExport_file = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgviewdevice = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewdevice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_User_Login);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbseach);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.btnExport_file);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác";
            // 
            // txt_User_Login
            // 
            this.txt_User_Login.Location = new System.Drawing.Point(9, 72);
            this.txt_User_Login.Name = "txt_User_Login";
            this.txt_User_Login.Size = new System.Drawing.Size(104, 20);
            this.txt_User_Login.TabIndex = 54;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(732, 72);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(104, 20);
            this.txtId.TabIndex = 53;
            // 
            // button1
            // 
            this.button1.Image = global::Quan_ly_thiet_bị.Properties.Resources.iconfinder_2040_searchpad_change_c12_24004941;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(626, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 32);
            this.button1.TabIndex = 43;
            this.button1.Text = "      Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbseach
            // 
            this.cmbseach.FormattingEnabled = true;
            this.cmbseach.Location = new System.Drawing.Point(715, 45);
            this.cmbseach.Name = "cmbseach";
            this.cmbseach.Size = new System.Drawing.Size(121, 21);
            this.cmbseach.TabIndex = 41;
            this.cmbseach.SelectedIndexChanged += new System.EventHandler(this.cmbseach_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(736, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 40;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(274, 35);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(274, 23);
            this.progressBar.TabIndex = 36;
            // 
            // btnExport_file
            // 
            this.btnExport_file.Image = global::Quan_ly_thiet_bị.Properties.Resources.iconfinder_Export_ui_ux_mobile_web_4960710;
            this.btnExport_file.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport_file.Location = new System.Drawing.Point(193, 31);
            this.btnExport_file.Name = "btnExport_file";
            this.btnExport_file.Size = new System.Drawing.Size(75, 31);
            this.btnExport_file.TabIndex = 23;
            this.btnExport_file.Text = "    Xuất file";
            this.btnExport_file.UseVisualStyleBackColor = true;
            this.btnExport_file.Click += new System.EventHandler(this.btnExport_file_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::Quan_ly_thiet_bị.Properties.Resources.iconfinder_expand_color_web2_22_5049209;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(85, 31);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(66, 31);
            this.btnDel.TabIndex = 22;
            this.btnDel.Text = "   Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAdd.FlatAppearance.BorderSize = 10;
            this.btnAdd.Image = global::Quan_ly_thiet_bị.Properties.Resources.iconfinder_Add_Circle_Plus_Download_1343436__1_;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(9, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 31);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "      Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgviewdevice);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(845, 253);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dtgviewdevice
            // 
            this.dtgviewdevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgviewdevice.Location = new System.Drawing.Point(9, 19);
            this.dtgviewdevice.Name = "dtgviewdevice";
            this.dtgviewdevice.Size = new System.Drawing.Size(830, 228);
            this.dtgviewdevice.TabIndex = 0;
            this.dtgviewdevice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgviewdevice_CellContentClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged_1);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted_1);
            // 
            // Form_Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 381);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Device";
            this.Text = "Form_Device";
            this.Load += new System.EventHandler(this.Form_Device_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewdevice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExport_file;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbseach;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_User_Login;
        private System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.DataGridView dtgviewdevice;
    }
}