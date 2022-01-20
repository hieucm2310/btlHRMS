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
    public partial class FormQTCongTac : Form
    {
        private QLNSDB db = new QLNSDB();
        public FormQTCongTac()
        {
            InitializeComponent();
            initCombobox();
            initTable();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtChucVu.Text = "";
            txtHoTen.Text = "";
            txtNoiCongTac.Text = "";
        }
        private void initCombobox()
        {
            var manv = db.HoSoes.Select(s => s.MaNhanVien).ToList();
            cboMaNhanVien.DataSource = manv;

        }
        private void initTable()
        {
            var table = db.QuaTrinhCongTacs.Select(n => new
            {
                n.MaNhanVien,
                n.ChucVu,
                n.DenNgay,
                n.TuNgay,
                n.NoiCongTac,
            });
            dgvNoiCongTac.DataSource = table.ToList();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string manv = cboMaNhanVien.Text.ToString();
            var tenNv = db.HoSoes.FirstOrDefault(nv => nv.MaNhanVien == manv);
            txtHoTen.Text = tenNv.HoTen.ToString();
        }

        private void dgvNoiCongTac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtChucVu.Text = dgvNoiCongTac.Rows[row].Cells[1].Value.ToString();
            txtNoiCongTac.Text = dgvNoiCongTac.Rows[row].Cells[4].Value.ToString();
            cboMaNhanVien.Text = dgvNoiCongTac.Rows[row].Cells[0].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string manv = cboMaNhanVien.Text;
                    QuaTrinhCongTac qtct = db.QuaTrinhCongTacs.FirstOrDefault(nv => nv.MaNhanVien == manv);
                    db.QuaTrinhCongTacs.Remove(qtct);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                    initTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công :" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string noiCT = txtNoiCongTac.Text.ToString();
            string cv = txtChucVu.Text.ToString();
            if (noiCT.Equals("") || cv.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thêm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                QuaTrinhCongTac qtrinh = new QuaTrinhCongTac()
                {
                    MaNhanVien = cboMaNhanVien.Text.ToString(),
                    ChucVu = txtChucVu.Text.ToString(),
                    NoiCongTac = txtNoiCongTac.Text.ToString(),
                    TuNgay = dtpTuNgay.Value,
                    DenNgay = dtpDenNgay.Value

                };
                try
                {
                    db.QuaTrinhCongTacs.Add(qtrinh);
                    btnNhapLai_Click(sender, e);
                    db.SaveChanges();
                    initTable();
                    MessageBox.Show("Thêm thành công!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm không thành công " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string noiCT = txtNoiCongTac.Text.ToString();
            string cv = txtChucVu.Text.ToString();
            if (noiCT.Equals("") || cv.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (dr == DialogResult.Yes)
                {
                    string manv = cboMaNhanVien.Text.ToString();
                    DateTime tuNgay = dtpTuNgay.Value;
                    DateTime denNgay = dtpDenNgay.Value;
                    var s = db.QuaTrinhCongTacs.Where(p => p.MaNhanVien == manv).FirstOrDefault();
                    s.NoiCongTac = txtNoiCongTac.Text.ToString();
                    s.ChucVu = txtChucVu.Text.ToString();
                    s.DenNgay = denNgay;
                    db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                    MessageBox.Show("Sửa thành công!!!");
                    btnNhapLai_Click(sender, e);
                    db.SaveChanges();
                    initTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
