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
    public partial class FormTDNgoaiNgu : Form
    {
        private QLNSDB db = new QLNSDB();
        public FormTDNgoaiNgu()
        {
            InitializeComponent();
            initCombobox();
            initCbxNgoaiNgu();
            initTable();
        }
        private void initTable()
        {
            var table = db.TrinhDoNgoaiNgus.Select(n => new
            {
                n.MaNhanVien,
                n.NgoaiNgu,
                n.TrinhDo
            });
            dgvTDNgoaiNgu.DataSource = table.ToList();
        }
        private void initCombobox()
        {
            var manv = db.HoSoes.Select(s => s.MaNhanVien).ToList();
            cboMaNhanVien.DataSource = manv;

        }
        private void initCbxNgoaiNgu()
        {
            cboNgoaiNgu.Items.Add("English");
            cboNgoaiNgu.Items.Add("Japanes");
            cboNgoaiNgu.Items.Add("Korean");
            cboNgoaiNgu.Items.Add("Chinases");
        }
        private void FormTDNgoaiNgu_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtTrinhDo.Text = "";
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string manv = cboMaNhanVien.Text;
                    TrinhDoNgoaiNgu trinhDoNgoaiNgu = db.TrinhDoNgoaiNgus.FirstOrDefault(nv => nv.MaNhanVien == manv);
                    db.TrinhDoNgoaiNgus.Remove(trinhDoNgoaiNgu);
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
            string nn = cboNgoaiNgu.Text.ToString();
            string td = txtTrinhDo.Text.ToString();
            if (nn.Equals("") || td.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thêm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TrinhDoNgoaiNgu trinhDo = new TrinhDoNgoaiNgu()
                {
                    MaNhanVien = cboMaNhanVien.Text.ToString(),
                    TrinhDo = txtTrinhDo.Text.ToString(),
                    NgoaiNgu = cboNgoaiNgu.Text.ToString()
                };
                try
                {
                    db.TrinhDoNgoaiNgus.Add(trinhDo);
                    MessageBox.Show("Thêm thành công!!!");
                    btnNhapLai_Click(sender, e);
                    db.SaveChanges();
                    initTable();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm không thành công " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string manv = cboMaNhanVien.Text.ToString();
            var tenNv = db.HoSoes.FirstOrDefault(nv => nv.MaNhanVien == manv);
            txtHoTen.Text = tenNv.HoTen.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string nn = cboNgoaiNgu.Text.ToString();
            string td = txtTrinhDo.Text.ToString();
            if (nn.Equals("") || td.Equals(""))
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
                    string ngoaiNgu = cboNgoaiNgu.Text.ToString();
                    var s = db.TrinhDoNgoaiNgus.Where(p => p.MaNhanVien == manv && p.NgoaiNgu == ngoaiNgu).FirstOrDefault();
                    s.TrinhDo = txtTrinhDo.Text.ToString();
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

        private void cboNgoaiNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string manv = cboMaNhanVien.Text.ToString();
                string ngoaiNgu = cboNgoaiNgu.Text.ToString();
                var trinhDo = db.TrinhDoNgoaiNgus.Where(p => p.MaNhanVien == manv && p.NgoaiNgu == ngoaiNgu).FirstOrDefault();
                txtTrinhDo.Text = trinhDo.TrinhDo.ToString();
            }
            catch (Exception ignore) { }
        }

        private void dgvTDNgoaiNgu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                cboMaNhanVien.Text = dgvTDNgoaiNgu.Rows[row].Cells[0].Value.ToString();

                cboNgoaiNgu.Text = dgvTDNgoaiNgu.Rows[row].Cells[1].Value.ToString();
                txtTrinhDo.Text = dgvTDNgoaiNgu.Rows[row].Cells[2].Value.ToString();
            }
            catch (Exception exx)
            {

            }
        }
    }
}
