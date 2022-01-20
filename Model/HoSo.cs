namespace BTLWin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoSo")]
    public partial class HoSo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoSo()
        {
            NhanVien_ChucVu = new HashSet<NhanVien_ChucVu>();
            QuaTrinhCongTacs = new HashSet<QuaTrinhCongTac>();
            TrinhDoChuyenMons = new HashSet<TrinhDoChuyenMon>();
            TrinhDoNgoaiNgus = new HashSet<TrinhDoNgoaiNgu>();
        }

        [Key]
        [StringLength(50)]
        public string MaNhanVien { get; set; }

        [StringLength(255)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(25)]
        public string SoDT { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTuyenDung { get; set; }

        [StringLength(50)]
        public string MaPhongBan { get; set; }

        [StringLength(30)]
        public string TaiKhoan { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        public bool? Quyen { get; set; }

        public bool? XoaMem { get; set; }

        [Column(TypeName = "text")]
        public string Anh { get; set; }

        public virtual PhongBan PhongBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien_ChucVu> NhanVien_ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuaTrinhCongTac> QuaTrinhCongTacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrinhDoChuyenMon> TrinhDoChuyenMons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrinhDoNgoaiNgu> TrinhDoNgoaiNgus { get; set; }
    }
}
