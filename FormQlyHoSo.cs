using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTLWin.Model;

namespace BTLWin
{
    public partial class FormQlyHoSo : Form
    {
        QLNSDB db = new QLNSDB();
        public FormQlyHoSo()
        {
            InitializeComponent();
        }

        private void FormQlyHoSo_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            HoSoLoad();
            LoadPhongBan();
            cboGioiTinh.SelectedIndex = -1;
            cboPhongBan.SelectedIndex = -1;
        }
        private void LoadPhongBan()
        {
            var lst = db.PhongBans.Where(p => p.XoaMem == false).ToList();
            cboPhongBan.DataSource = lst;
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "MaPhongBan";
        }
        private void ResetValues()
        {
            txtMaNhanVien.Text = "";
            txtHoTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = -1;
            txtSDT.Text = "";
            txtEmail.Text = "";
            dtpNgayTuyenDung.Value = DateTime.Now;
            cboPhongBan.SelectedIndex = -1;
            txtTenTK.Text = "";
            txtMatKhau.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
            txtMaNhanVien.Focus();
        }
        private void HoSoLoad()
        {
            var lst = db.HoSoes.Where(h => h.XoaMem == false).ToList();
            
            dgvHoSo.DataSource = lst;
            dgvHoSo.Columns["XoaMem"].Visible=false;
            dgvHoSo.Columns["NhanVien_ChucVu"].Visible = false;
            dgvHoSo.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dgvHoSo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoSo.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHoSo.Columns["NgayTuyenDung"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //foreach (DataGridViewRow row in dgvHoSo.Rows)
            //{
            //    if (Convert.ToBoolean(row.Cells["Gender"].Value) == true)
            //    {
            //        row.Cells["Gender"].Value = "True";
            //    }
            //    else row.Cells["Gender"].Value = "False";
            //}
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboGioiTinh.Text == "")
            {
                MessageBox.Show("Hãy chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboPhongBan.Text == "")
            {
                MessageBox.Show("Hãy chọn phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenTK.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtAnh.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn Ảnh bằng nút Mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var mt = db.HoSoes.Where(d=>d.XoaMem == false && d.MaNhanVien == txtMaNhanVien.Text.Trim()).ToList();
            if (mt.Count>0)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var tt = db.HoSoes.Where(d => d.TaiKhoan.Equals(txtTenTK.Text.Trim())).Select(d => d);
            if (tt.Count() != 0)
            {
                MessageBox.Show("Tên tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool gender;
            if (cboGioiTinh.Text.Equals("Nam")|| cboGioiTinh.Text.Equals(false))
            {
                gender = false;
            }
            else
            {
                gender = true;
            }
            using (var db = new QLNSDB())
            {
                try
                {
                    HoSo h = new HoSo();
                    h.MaNhanVien = txtMaNhanVien.Text.Trim();
                    h.HoTen = txtHoTen.Text.Trim();
                    h.NgaySinh = Convert.ToDateTime(dtpNgaySinh.Value.ToString());
                    h.GioiTinh = gender;
                    h.SoDT = txtSDT.Text.Trim();
                    h.Email = txtEmail.Text.Trim();
                    h.NgayTuyenDung = Convert.ToDateTime(dtpNgayTuyenDung.Value.ToString());
                    h.MaPhongBan = cboPhongBan.SelectedValue.ToString();
                    h.TaiKhoan = txtTenTK.Text.Trim();
                    h.MatKhau = txtMatKhau.Text.Trim();
                    h.Quyen = false;
                    h.Anh = txtAnh.Text.Trim();
                    h.XoaMem = false;
                    db.HoSoes.Add(h);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm phòng ban lỗi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            HoSoLoad();
            ResetValues();
        }

        private void dgvHoSo_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = dgvHoSo.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txtHoTen.Text = dgvHoSo.CurrentRow.Cells["HoTen"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(dgvHoSo.CurrentRow.Cells["NgaySinh"].Value.ToString());
            cboGioiTinh.Text = dgvHoSo.CurrentRow.Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dgvHoSo.CurrentRow.Cells["SoDT"].Value.ToString();
            txtEmail.Text = dgvHoSo.CurrentRow.Cells["Email"].Value.ToString();
            dtpNgayTuyenDung.Value = Convert.ToDateTime(dgvHoSo.CurrentRow.Cells["NgayTuyenDung"].Value.ToString());
            cboPhongBan.SelectedValue = dgvHoSo.CurrentRow.Cells["MaPhongBan"].Value.ToString();
            txtTenTK.Text = dgvHoSo.CurrentRow.Cells["TaiKhoan"].Value.ToString();
            txtAnh.Text = dgvHoSo.CurrentRow.Cells["Anh"].Value.ToString();
            picAnh.Load(txtAnh.Text);
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                if (dlgOpen.FileName.Contains(@"\image\"))
                {
                    string delete = dlgOpen.FileName.Substring(0, dlgOpen.FileName.LastIndexOf(@"\image\"));
                    string relativePath = dlgOpen.FileName.Replace(delete, @"..\..");
                    picAnh.Image = Image.FromFile(relativePath);
                    txtAnh.Text = relativePath;
                }
                else
                {
                    string sourceDir = dlgOpen.FileName.Substring(0, dlgOpen.FileName.LastIndexOf(@"\"));
                    string backupDir = @"..\..\image";
                    string file = dlgOpen.FileName.Substring(dlgOpen.FileName.LastIndexOf(@"\") + 1);
                    File.Copy(Path.Combine(sourceDir, file), Path.Combine(backupDir, file));
                    string relativePath = backupDir + @"\" + file;
                    picAnh.Image = Image.FromFile(relativePath);
                    txtAnh.Text = relativePath;
                }
            }
        }

        private void picAnh_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboGioiTinh.Text == "")
            {
                MessageBox.Show("Hãy chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboPhongBan.Text == "")
            {
                MessageBox.Show("Hãy chọn phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenTK.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtAnh.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn Ảnh bằng nút Mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var tt = db.HoSoes.Where(d => d.TaiKhoan.Equals(txtTenTK.Text.Trim())).Select(d => d);
            if (tt.Count() != 0)
            {
                DialogResult dlr = MessageBox.Show("Vẫn giữ tên tài khoản cũ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dlr == DialogResult.OK)
                {
                    bool gender;
                    if (cboGioiTinh.Text.Equals("Nam") || cboGioiTinh.Text.Equals(false))
                    {
                        gender = false;
                    }
                    else
                    {
                        gender = true;
                    }
                    
                    using (var db = new QLNSDB())
                    {
                        try
                        {
                            var h = db.HoSoes.Where(p => p.MaNhanVien == txtMaNhanVien.Text).FirstOrDefault();
                            h.MaNhanVien = txtMaNhanVien.Text.Trim();
                            h.HoTen = txtHoTen.Text.Trim();
                            h.NgaySinh = Convert.ToDateTime(dtpNgaySinh.Value.ToString());
                            h.GioiTinh = gender;
                            h.SoDT = txtSDT.Text.Trim();
                            h.Email = txtEmail.Text.Trim();
                            h.NgayTuyenDung = Convert.ToDateTime(dtpNgayTuyenDung.Value.ToString());
                            h.MaPhongBan = cboPhongBan.SelectedValue.ToString();
                            h.TaiKhoan = txtTenTK.Text.Trim();
                            h.MatKhau = txtMatKhau.Text.Trim();
                            h.Quyen = false;
                            h.Anh = txtAnh.Text.Trim();
                            h.XoaMem = false;
                            db.Entry(h).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Sửa hồ sơ lỗi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    HoSoLoad();
                }
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var ck = db.HoSoes.Where(p => p.MaNhanVien == txtMaNhanVien.Text).FirstOrDefault();
            if (ck == null)
            {
                MessageBox.Show("Mã nhân viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (var db = new QLNSDB())
                {
                    try
                    {
                        var x = db.HoSoes.Where(p => p.MaNhanVien == txtMaNhanVien.Text).FirstOrDefault();
                        x.XoaMem = true;
                        db.Entry(x).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa hồ sơ lỗi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                HoSoLoad();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var lst = db.HoSoes.Where(h => h.XoaMem == false && h.MaNhanVien == txtMaNhanVien.Text.Trim()).ToList();
            if (lst.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvHoSo.DataSource = lst;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            HoSoLoad();
            ResetValues();
        }

        private void btnChuyenMon_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormTDChuyenMon formTDChuyenMon = new FormTDChuyenMon(txtMaNhanVien.Text);
            formTDChuyenMon.MdiParent = this.MdiParent;
            this.Close();
            formTDChuyenMon.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void btnNhapLai_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnNhapLai_MouseEnter(object sender, EventArgs e)
        {
            btnNhapLai.BackColor = Color.OrangeRed;
            btnNhapLai.Font = new Font("Arial", 9, FontStyle.Bold);
        }

        private void btnNhapLai_MouseLeave(object sender, EventArgs e)
        {
            btnNhapLai.BackColor = Color.White;
            btnNhapLai.Font = default;
        }

        private void btnThem_MouseEnter(object sender, EventArgs e)
        {
            btnThem.BackColor = Color.OrangeRed;
            btnThem.Font = new Font("Arial", 9, FontStyle.Bold);
        }

        private void btnThem_MouseLeave(object sender, EventArgs e)
        {
            btnThem.BackColor = Color.White;
            btnThem.Font = default;
        }

        private void btnSua_MouseEnter(object sender, EventArgs e)
        {
            btnSua.BackColor = Color.OrangeRed;
            btnSua.Font = new Font("Arial", 9, FontStyle.Bold);
        }

        private void btnSua_MouseLeave(object sender, EventArgs e)
        {
            btnSua.BackColor = Color.White;
            btnSua.Font = default;
        }

        private void btnXoa_MouseEnter(object sender, EventArgs e)
        {
            btnXoa.BackColor = Color.OrangeRed;
            btnXoa.Font = new Font("Arial", 9, FontStyle.Bold);
        }

        private void btnXoa_MouseLeave(object sender, EventArgs e)
        {
            btnXoa.BackColor = Color.White;
            btnXoa.Font = default;
        }

        private void btnTim_MouseEnter(object sender, EventArgs e)
        {
            btnTim.BackColor = Color.OrangeRed;
            btnTim.Font = new Font("Arial", 9, FontStyle.Bold);
        }

        private void btnTim_MouseLeave(object sender, EventArgs e)
        {
            btnTim.BackColor = Color.White;
            btnTim.Font = default;
        }

        private void btnXem_MouseEnter(object sender, EventArgs e)
        {
            btnXem.BackColor = Color.OrangeRed;
            btnXem.Font = new Font("Arial", 9, FontStyle.Bold);
        }

        private void btnXem_MouseLeave(object sender, EventArgs e)
        {
            btnXem.BackColor = Color.White;
            btnXem.Font = default;
        }

        private void btnThoat_MouseEnter(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.OrangeRed;
            btnThoat.Font = new Font("Arial", 9, FontStyle.Bold);
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.White;
            btnThoat.Font = default;
        }

        private void btnChuyenMon_MouseEnter(object sender, EventArgs e)
        {
            btnChuyenMon.BackColor = Color.OrangeRed;
            btnChuyenMon.Font = new Font("Arial", 9, FontStyle.Bold);
        }

        private void btnChuyenMon_MouseLeave(object sender, EventArgs e)
        {
            btnChuyenMon.BackColor = Color.White;
            btnChuyenMon.Font = default;
        }

        private void dgvHoSo_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void dgvHoSo_MouseHover(object sender, EventArgs e)
        {
        }

        private void dgvHoSo_MouseClick(object sender, MouseEventArgs e)
        {
            dgvHoSo.CurrentRow.Height = 50;
        }

        private void dgvHoSo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dgvHoSo.CurrentRow.Height = 25;
        }
    }
}
