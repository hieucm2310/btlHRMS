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
    public partial class FormChucVuNhanVien : Form
    {
        QLNSDB db = new QLNSDB();
        private List<NhanVien_ChucVu> NVCV;
        public FormChucVuNhanVien()
        {
            InitializeComponent();
        }
        private void CreateNode(NhanVien_ChucVu nv)
        {
            var tn = tvwCVNV.Nodes.Find(nv.MaNhanVien, true);
            if (tn.Length == 0 && nv.MaNhanVien != string.Empty)
                CreateNode(NVCV.Find(NVCV => NVCV.MaNhanVien == nv.MaNhanVien));
            else
                if (nv.MaNhanVien!= string.Empty)
                tn[0].Nodes.Add(nv.MaChucVu, nv.TuNgay.ToString(), 0, 1);
            else
                tvwCVNV.Nodes.Add(nv.MaChucVu, nv.TuNgay.ToString(), 0, 1);
        }
        private void ShowNVCV()
        {
            NVCV = db.NhanVien_ChucVu.AsNoTracking().ToList();
            NVCV.ForEach(nv =>
            {
                if (tvwCVNV.Nodes.Find(nv.MaChucVu, true).Length == 0) CreateNode(nv);
            });
        }

        private void FormChucVuNhanVien_Load(object sender, EventArgs e)
        {
            ShowNVCV();
        }
    }
}
