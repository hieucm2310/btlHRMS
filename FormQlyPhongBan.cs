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
    public partial class FormQlyPhongBan : Form
    {
        private QLNSDB db = new QLNSDB();
        public FormQlyPhongBan()
        {
            InitializeComponent();
        }

        public void PhongBanLoad()
        {
            
            var lst = db.PhongBans.Where(p => p.XoaMem == false).Select(n => new { n.MaPhongBan, n.TenPhongBan, n.NgayThanhLap }).ToList();
            dgvPhongBan.DataSource = lst;
            dgvPhongBan.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dgvPhongBan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhongBan.Columns["MaPhongBan"].HeaderText = "Mã phòng ban";
            dgvPhongBan.Columns["MaPhongBan"].Width = 200;
            dgvPhongBan.Columns["MaPhongBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhongBan.Columns["TenPhongBan"].HeaderText = "Tên phòng ban";
            dgvPhongBan.Columns["TenPhongBan"].Width = 250;
            dgvPhongBan.Columns["TenPhongBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhongBan.Columns["NgayThanhLap"].HeaderText = "Ngày thành lập";
            dgvPhongBan.Columns["NgayThanhLap"].Width = 250;
            dgvPhongBan.Columns["NgayThanhLap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void FormQlyPhongBan_Load(object sender, EventArgs e)
        {
            PhongBanLoad();

        }

        private void dgvPhongBan_SelectionChanged(object sender, EventArgs e)
        {
            txtMaPhongBan.Text = dgvPhongBan.CurrentRow.Cells["MaPhongBan"].Value.ToString();
            txtTenPhongBan.Text = dgvPhongBan.CurrentRow.Cells["TenPhongBan"].Value.ToString();
            dtpNgayThanhLap.Value = Convert.ToDateTime(dgvPhongBan.CurrentRow.Cells["NgayThanhLap"].Value.ToString());
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {

            txtMaPhongBan.Text = "";
            txtTenPhongBan.Text = "";
            dtpNgayThanhLap.Value = DateTime.Now;
            txtMaPhongBan.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaPhongBan.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenPhongBan.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập tên phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var chk = db.PhongBans.Where(d => d.XoaMem == false && d.MaPhongBan == txtMaPhongBan.Text.Trim()).ToList();
            if (chk.Count > 0)
            {
                MessageBox.Show("Mã phòng ban đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var db = new QLNSDB())
            {
                try
                {
                    PhongBan pb = new PhongBan();
                    pb.MaPhongBan = txtMaPhongBan.Text.Trim();
                    pb.TenPhongBan = txtTenPhongBan.Text.Trim();
                    pb.NgayThanhLap = Convert.ToDateTime(dtpNgayThanhLap.Value.ToString());
                    pb.XoaMem = false;
                    db.PhongBans.Add(pb);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm phòng ban lỗi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            PhongBanLoad();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var lst = db.PhongBans.Where(p => p.XoaMem == false && p.MaPhongBan == txtMaPhongBan.Text.Trim()).ToList();
            if (txtMaPhongBan.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lst.Count() == 0)
            {
                MessageBox.Show("Mã phòng ban không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenPhongBan.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập tên phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var db = new QLNSDB())
            {
                try
                {
                    var ck = db.PhongBans.Where(p => p.MaPhongBan == txtMaPhongBan.Text).FirstOrDefault();
                    ck.TenPhongBan = txtTenPhongBan.Text;
                    ck.NgayThanhLap = Convert.ToDateTime(dtpNgayThanhLap.Value.ToString());
                    ck.XoaMem = false;
                    db.Entry(ck).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa phòng ban lỗi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            PhongBanLoad();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaPhongBan.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var ck = db.PhongBans.Where(p=>p.MaPhongBan == txtMaPhongBan.Text).FirstOrDefault();
            if ( ck== null)
            {
                MessageBox.Show("Mã phòng ban không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (var db = new QLNSDB())
                {
                    try
                    {
                        //var x = db.PhongBans.Where(p => p.MaPhongBan == txtMaPhongBan.Text).FirstOrDefault();
                        var selectedRows = dgvPhongBan.SelectedRows
                            .OfType<DataGridViewRow>()
                            .Where(row => !row.IsNewRow)
                            .ToList();
                        foreach (var row in selectedRows)
                        {
                            string ma = row.Cells[0].Value.ToString();
                            PhongBan pb = db.PhongBans.FirstOrDefault(p => p.MaPhongBan == ma.Trim());
                            pb.XoaMem = true;
                            db.Entry(pb).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        //x.XoaMem = true;
                        //db.Entry(x).State = System.Data.Entity.EntityState.Modified;
                        //db.SaveChanges();
                        MessageBox.Show("Xóa thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa phòng ban lỗi.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                PhongBanLoad();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTenPhongBan.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập tên phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var ds = db.PhongBans.Where(d=>d.TenPhongBan.Contains(txtTenPhongBan.Text) && d.XoaMem.ToString() == "false").Select(d=>new { d.MaPhongBan,d.TenPhongBan,d.NgayThanhLap}).ToList();
            if (ds == null)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvPhongBan.DataSource = ds;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            PhongBanLoad();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.Font = new Font("Arial", 9,FontStyle.Bold);
            label3.Font = new Font("Arial", 9,FontStyle.Bold);
            label4.Font = new Font("Arial", 9,FontStyle.Bold);
        }
    }
}
