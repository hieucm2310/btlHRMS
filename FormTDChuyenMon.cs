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
    public partial class FormTDChuyenMon : Form
    {
        QLNSDB db = new QLNSDB();
        private string _manhanvien = "";
        public FormTDChuyenMon()
        {
            InitializeComponent();
        }
        public FormTDChuyenMon(string manhanvien) : this()
        {
            _manhanvien = manhanvien;
        }

        private void FormTDChuyenMon_Load(object sender, EventArgs e)
        {
            cboTrinhDo.Items.Add("Trung cấp");
            cboTrinhDo.Items.Add("Cao đẳng");
            cboTrinhDo.Items.Add("Đại học");
            cboTrinhDo.Items.Add("Thạc sĩ");
            cboTrinhDo.Items.Add("Tiến sĩ");
            cboLHDT.Items.Add("Chính quy");
            cboLHDT.Items.Add("Vừa học vừa làm");
            cboLHDT.Items.Add("Liên thông");
            txtMaNhanVien.Text = _manhanvien;
            cboLHDT.SelectedIndex = -1;
            cboTrinhDo.SelectedIndex = -1;
            if (dgvChuyenMon.RowCount == 0)
            {
                TrinhDoChuyenMonLoad();
            }
        }
        private void TrinhDoChuyenMonLoad()
        {
            dgvChuyenMon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            var lst = db.HoSoes.Where(h => h.XoaMem == false)
                .Join(db.TrinhDoChuyenMons, h => h.MaNhanVien, t => t.MaNhanVien, (h, t) =>
                 new { t.MaNhanVien, t.Nganh, t.TrinhDo, t.LoaiHinhDaoTao, t.TruongDaoTao }).ToList();
            if (dgvChuyenMon.RowCount == 0)
            {
                MessageBox.Show("Nhập mã nhân viên để tìm thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Text = "";
                dgvChuyenMon.DataSource = lst;
            }

        }

        private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        {
            var tm = db.HoSoes.Where(t => t.XoaMem == false && t.MaNhanVien == txtMaNhanVien.Text).FirstOrDefault();
            var lst = db.TrinhDoChuyenMons.Where(l => l.MaNhanVien == txtMaNhanVien.Text).ToList();
            if (tm != null)
            {
                txtHoTen.Text = tm.HoTen.ToString();
                dgvChuyenMon.DataSource = lst;
            }
            else
            {
                txtHoTen.Text = "";
                cboTrinhDo.SelectedIndex = -1;
                cboLHDT.SelectedIndex = -1;
                txtNganh.Text = "";
                txtTruong.Text = "";
                dgvChuyenMon.DataSource = null;
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            cboTrinhDo.SelectedIndex = -1;
            cboLHDT.SelectedIndex = -1;
            txtNganh.Text = "";
            txtTruong.Text = "";
            txtMaNhanVien.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNganh.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập ngành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboTrinhDo.Text == "")
            {
                MessageBox.Show("Hãy chọn trình độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboLHDT.Text == "")
            {
                MessageBox.Show("Hãy chọn loại hình đào tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTruong.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập trường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //var tm = db.HoSoes.Where(h => h.XoaMem == false && h.MaNhanVien == txtMaNhanVien.Text).ToList();
            //if (tm.Count() == 0)
            //{
            //    MessageBox.Show("Mã nhân viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            var dm = db.TrinhDoChuyenMons.Where(t => t.MaNhanVien.Equals(txtMaNhanVien.Text) && t.Nganh.Equals(txtNganh.Text)).ToList();
            if (dm.Count() != 0)
            {
                MessageBox.Show("Nhân viên đã có thông tin về ngành này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (QLNSDB db = new QLNSDB())
            {
                try
                {



                    TrinhDoChuyenMon t = new TrinhDoChuyenMon();
                    t.MaNhanVien = txtMaNhanVien.Text.Trim();
                    t.Nganh = txtNganh.Text.Trim();
                    t.TrinhDo = cboTrinhDo.Text;
                    t.LoaiHinhDaoTao = cboLHDT.Text;
                    t.TruongDaoTao = txtTruong.Text;
                    db.TrinhDoChuyenMons.Add(t);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm trinh độ chuyên môn lỗi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            txtMaNhanVien.Text = "";
            TrinhDoChuyenMonLoad();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dgvChuyenMon_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNganh.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập ngành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var c = db.TrinhDoChuyenMons.Where(d => d.MaNhanVien.Equals(txtMaNhanVien.Text) && d.Nganh.Equals(txtNganh.Text)).ToList();
            if (c.Count() == 0)
            {
                MessageBox.Show("Nhân viên chưa có thông tin về ngành này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var x = db.TrinhDoChuyenMons.Where(t => t.MaNhanVien == txtMaNhanVien.Text.Trim() && t.Nganh == txtNganh.Text.Trim()).FirstOrDefault();
            try
            {
                db.TrinhDoChuyenMons.Remove(x);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa lỗi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtMaNhanVien.Text = "";
            MessageBox.Show("Bạn đã xóa thành công");
            TrinhDoChuyenMonLoad();
        }

        private void dgvChuyenMon_Click(object sender, EventArgs e)
        {
            if (db.TrinhDoChuyenMons.Where(l => l.MaNhanVien == txtMaNhanVien.Text).ToList().Count() == 0 && dgvChuyenMon.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNhanVien.Text = dgvChuyenMon.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txtNganh.Text = dgvChuyenMon.CurrentRow.Cells["Nganh"].Value.ToString();
            cboTrinhDo.Text = dgvChuyenMon.CurrentRow.Cells["TrinhDo"].Value.ToString();
            cboLHDT.Text = dgvChuyenMon.CurrentRow.Cells["LoaiHinhDaoTao"].Value.ToString();
            txtTruong.Text = dgvChuyenMon.CurrentRow.Cells["TruongDaoTao"].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtHoTen.Text = "";
            cboLHDT.SelectedIndex = -1;
            cboTrinhDo.SelectedIndex = -1;
            //TrinhDoChuyenMonLoad();
            dgvChuyenMon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            var lst = db.HoSoes.Where(h => h.XoaMem == false)
                .Join(db.TrinhDoChuyenMons, h => h.MaNhanVien, t => t.MaNhanVien, (h, t) =>
                 new { t.MaNhanVien, t.Nganh, t.TrinhDo, t.LoaiHinhDaoTao, t.TruongDaoTao }).ToList();
            dgvChuyenMon.DataSource = lst;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNganh.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập ngành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboTrinhDo.Text == "")
            {
                MessageBox.Show("Hãy chọn trình độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboLHDT.Text == "")
            {
                MessageBox.Show("Hãy chọn loại hình đào tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTruong.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập trường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var c = db.TrinhDoChuyenMons.Where(d => d.MaNhanVien.Equals(txtMaNhanVien.Text) && d.Nganh.Equals(txtNganh.Text)).ToList();
            if (c.Count() == 0)
            {
                MessageBox.Show("Nhân viên chưa có thông tin về ngành này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (QLNSDB db = new QLNSDB())
            {
                try
                {
                    var s = db.TrinhDoChuyenMons.Where(p => p.MaNhanVien == txtMaNhanVien.Text.Trim() && p.Nganh == txtNganh.Text.Trim()).FirstOrDefault();
                    s.TrinhDo = cboTrinhDo.Text;
                    s.LoaiHinhDaoTao = cboLHDT.Text;
                    s.TruongDaoTao = txtTruong.Text;
                    db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa trình độ chuyên môn lỗi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            txtMaNhanVien.Text = "";
            TrinhDoChuyenMonLoad();
        }
    }
}
