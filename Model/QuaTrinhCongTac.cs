namespace BTLWin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuaTrinhCongTac")]
    public partial class QuaTrinhCongTac
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaNhanVien { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime TuNgay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DenNgay { get; set; }

        [StringLength(255)]
        public string NoiCongTac { get; set; }

        [StringLength(255)]
        public string ChucVu { get; set; }

        public virtual HoSo HoSo { get; set; }
    }
}
