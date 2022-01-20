namespace BTLWin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrinhDoChuyenMon")]
    public partial class TrinhDoChuyenMon
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaNhanVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Nganh { get; set; }

        [StringLength(255)]
        public string TrinhDo { get; set; }

        [StringLength(255)]
        public string LoaiHinhDaoTao { get; set; }

        [StringLength(255)]
        public string TruongDaoTao { get; set; }

        public virtual HoSo HoSo { get; set; }
    }
}
