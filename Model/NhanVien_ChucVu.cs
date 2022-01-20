namespace BTLWin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NhanVien_ChucVu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaNhanVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaChucVu { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime TuNgay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DenNgay { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual HoSo HoSo { get; set; }
    }
}
