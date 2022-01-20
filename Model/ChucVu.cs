namespace BTLWin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucVu")]
    public partial class ChucVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChucVu()
        {
            NhanVien_ChucVu = new HashSet<NhanVien_ChucVu>();
        }

        [Key]
        [StringLength(50)]
        public string MaChucVu { get; set; }

        [StringLength(255)]
        public string TenChucVu { get; set; }

        public float? HeSoPhuCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien_ChucVu> NhanVien_ChucVu { get; set; }
    }
}
