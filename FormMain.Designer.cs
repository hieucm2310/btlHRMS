
namespace BTLWin
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mnParent = new System.Windows.Forms.MenuStrip();
            this.mnPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHoSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTDCM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTDNN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnInHS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.mnQuaTrinhCongTac = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNhanVienChucVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnParent
            // 
            this.mnParent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPhongBan,
            this.mnHoSo,
            this.mnTDCM,
            this.mnTDNN,
            this.mnThongTin,
            this.mnInHS,
            this.toolStripMenuItem1,
            this.mnThoat});
            this.mnParent.Location = new System.Drawing.Point(0, 0);
            this.mnParent.Name = "mnParent";
            this.mnParent.Size = new System.Drawing.Size(706, 24);
            this.mnParent.TabIndex = 1;
            this.mnParent.Text = "menuStrip1";
            this.mnParent.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnParent_ItemClicked);
            // 
            // mnPhongBan
            // 
            this.mnPhongBan.Name = "mnPhongBan";
            this.mnPhongBan.Size = new System.Drawing.Size(77, 20);
            this.mnPhongBan.Text = "&Phòng ban";
            this.mnPhongBan.Click += new System.EventHandler(this.mnPhongBan_Click);
            // 
            // mnHoSo
            // 
            this.mnHoSo.Name = "mnHoSo";
            this.mnHoSo.Size = new System.Drawing.Size(50, 20);
            this.mnHoSo.Text = "&Hồ sơ";
            this.mnHoSo.Click += new System.EventHandler(this.mnHoSo_Click);
            // 
            // mnTDCM
            // 
            this.mnTDCM.Name = "mnTDCM";
            this.mnTDCM.Size = new System.Drawing.Size(132, 20);
            this.mnTDCM.Text = "&Trình độ chuyên môn";
            this.mnTDCM.Click += new System.EventHandler(this.mnTDCM_Click);
            // 
            // mnTDNN
            // 
            this.mnTDNN.Name = "mnTDNN";
            this.mnTDNN.Size = new System.Drawing.Size(119, 20);
            this.mnTDNN.Text = "Trình độ ngoại ngữ";
            this.mnTDNN.Click += new System.EventHandler(this.mnTDNN_Click);
            // 
            // mnThongTin
            // 
            this.mnThongTin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnQuaTrinhCongTac,
            this.mnNhanVienChucVu});
            this.mnThongTin.Name = "mnThongTin";
            this.mnThongTin.Size = new System.Drawing.Size(67, 20);
            this.mnThongTin.Text = "Công tác";
            // 
            // mnInHS
            // 
            this.mnInHS.Name = "mnInHS";
            this.mnInHS.Size = new System.Drawing.Size(61, 20);
            this.mnInHS.Text = "&In hồ sơ";
            this.mnInHS.Click += new System.EventHandler(this.mnInHS_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(73, 20);
            this.toolStripMenuItem1.Text = "Đăng &xuất";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // mnThoat
            // 
            this.mnThoat.Name = "mnThoat";
            this.mnThoat.Size = new System.Drawing.Size(49, 20);
            this.mnThoat.Text = "Th&oát";
            this.mnThoat.Click += new System.EventHandler(this.mnThoat_Click);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // mnQuaTrinhCongTac
            // 
            this.mnQuaTrinhCongTac.Name = "mnQuaTrinhCongTac";
            this.mnQuaTrinhCongTac.Size = new System.Drawing.Size(180, 22);
            this.mnQuaTrinhCongTac.Text = "Quá trình công tác";
            this.mnQuaTrinhCongTac.Click += new System.EventHandler(this.mnQuaTrinhCongTac_Click);
            // 
            // mnNhanVienChucVu
            // 
            this.mnNhanVienChucVu.Name = "mnNhanVienChucVu";
            this.mnNhanVienChucVu.Size = new System.Drawing.Size(180, 22);
            this.mnNhanVienChucVu.Text = "Chức vụ nhân viên";
            this.mnNhanVienChucVu.Click += new System.EventHandler(this.mnNhanVienChucVu_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 292);
            this.Controls.Add(this.mnParent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnParent;
            this.Name = "FormMain";
            this.Text = "Hệ thống quản lý nhân sự";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.mnParent.ResumeLayout(false);
            this.mnParent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnParent;
        private System.Windows.Forms.ToolStripMenuItem mnPhongBan;
        private System.Windows.Forms.ToolStripMenuItem mnHoSo;
        private System.Windows.Forms.ToolStripMenuItem mnTDCM;
        private System.Windows.Forms.ToolStripMenuItem mnInHS;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnThoat;
        private System.Windows.Forms.ToolStripMenuItem mnThongTin;
        private System.Windows.Forms.ToolStripMenuItem mnTDNN;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.ToolStripMenuItem mnQuaTrinhCongTac;
        private System.Windows.Forms.ToolStripMenuItem mnNhanVienChucVu;
    }
}