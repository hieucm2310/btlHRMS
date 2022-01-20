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
    public partial class FormInHS : Form
    {
        QLNSDB db = new QLNSDB();
        private string _manhanvien;
        public FormInHS()
        {
            InitializeComponent();
        }
        public FormInHS(string manhanvien) : this()
        {
            _manhanvien = manhanvien;
        }

        private void FormInHS_Load(object sender, EventArgs e)
        {

        }

        private void btnTao_Click(object sender, EventArgs e)
        {

        }
    }
}
