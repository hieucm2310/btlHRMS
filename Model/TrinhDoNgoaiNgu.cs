namespace BTLWin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrinhDoNgoaiNgu")]
    public partial class TrinhDoNgoaiNgu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaNhanVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string NgoaiNgu { get; set; }

        [StringLength(10)]
        public string TrinhDo { get; set; }

        public virtual HoSo HoSo { get; set; }
    }
}
