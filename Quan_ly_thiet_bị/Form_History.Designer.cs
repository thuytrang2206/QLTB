namespace Quan_ly_thiet_bị
{
    partial class Form_History
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
            this.dtgviewhistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewhistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgviewhistory
            // 
            this.dtgviewhistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgviewhistory.Location = new System.Drawing.Point(12, 12);
            this.dtgviewhistory.Name = "dtgviewhistory";
            this.dtgviewhistory.Size = new System.Drawing.Size(707, 177);
            this.dtgviewhistory.TabIndex = 1;
            // 
            // Form_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 201);
            this.Controls.Add(this.dtgviewhistory);
            this.Name = "Form_History";
            this.Text = "Form_History";
            this.Load += new System.EventHandler(this.Form_History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewhistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgviewhistory;
    }
}