using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTLWin.Model;

namespace BTLWin
{
    public partial class FormMain : Form
    {
        private string _id;
        public FormMain()
        {
            InitializeComponent();
        }
        public FormMain(string id) : this()
        {
            _id = id;
        }

        private void mnPhongBan_Click(object sender, EventArgs e)
        {
            FormQlyPhongBan qlyPhongBan = new FormQlyPhongBan();
            qlyPhongBan.MdiParent = this;
            qlyPhongBan.Show();
        }

        private void mnHoSo_Click(object sender, EventArgs e)
        {
            FormQlyHoSo qlyHoSo = new FormQlyHoSo();
            qlyHoSo.MdiParent = this;
            qlyHoSo.Show();
        }

        private void mnTDCM_Click(object sender, EventArgs e)
        {
            FormTDChuyenMon tDChuyenMon = new FormTDChuyenMon();
            tDChuyenMon.MdiParent = this;
            tDChuyenMon.Show();
        }

        private void mnInHS_Click(object sender, EventArgs e)
        {
            FormInHS inHS = new FormInHS(_id);
            inHS.MdiParent = this;
            MessageBox.Show("Chức năng này hiện chưa mở","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                frmDangNhap frmDangNhap = new frmDangNhap();
                frmDangNhap.Show();
                this.Hide();
            }
        }

        private void mnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            QLNSDB db = new QLNSDB();
            var role = db.HoSoes.Where(n => n.MaNhanVien.Equals(_id)).First().Quyen;
            if (role == false)
            {
                mnPhongBan.Visible = false;
                mnHoSo.Visible = false;
                mnTDCM.Visible = false;
            }
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mnParent_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnTDNN_Click(object sender, EventArgs e)
        {
            FormTDNgoaiNgu tDNgoaiNgu= new FormTDNgoaiNgu();
            tDNgoaiNgu.MdiParent = this;
            tDNgoaiNgu.Show();
        }

        private void mnQuaTrinhCongTac_Click(object sender, EventArgs e)
        {
            FormQTCongTac quaTrinhCongTac = new FormQTCongTac();
            quaTrinhCongTac.MdiParent = this;
            quaTrinhCongTac.Show();
        }

        private void mnNhanVienChucVu_Click(object sender, EventArgs e)
        {
            FormChucVuNhanVien chucVuNhanVien= new FormChucVuNhanVien();
            chucVuNhanVien.MdiParent = this;
            MessageBox.Show("Chức năng này hiện chưa mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
