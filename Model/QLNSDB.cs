using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTLWin.Model
{
    public partial class QLNSDB : DbContext
    {
        public QLNSDB()
            : base("name=QLNSDB")
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<HoSo> HoSoes { get; set; }
        public virtual DbSet<NhanVien_ChucVu> NhanVien_ChucVu { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<QuaTrinhCongTac> QuaTrinhCongTacs { get; set; }
        public virtual DbSet<TrinhDoChuyenMon> TrinhDoChuyenMons { get; set; }
        public virtual DbSet<TrinhDoNgoaiNgu> TrinhDoNgoaiNgus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .Property(e => e.MaChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.NhanVien_ChucVu)
                .WithRequired(e => e.ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoSo>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<HoSo>()
                .Property(e => e.SoDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoSo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HoSo>()
                .Property(e => e.MaPhongBan)
                .IsUnicode(false);

            modelBuilder.Entity<HoSo>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<HoSo>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<HoSo>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<HoSo>()
                .HasMany(e => e.NhanVien_ChucVu)
                .WithRequired(e => e.HoSo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoSo>()
                .HasMany(e => e.QuaTrinhCongTacs)
                .WithRequired(e => e.HoSo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoSo>()
                .HasMany(e => e.TrinhDoChuyenMons)
                .WithRequired(e => e.HoSo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoSo>()
                .HasMany(e => e.TrinhDoNgoaiNgus)
                .WithRequired(e => e.HoSo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien_ChucVu>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien_ChucVu>()
                .Property(e => e.MaChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.MaPhongBan)
                .IsUnicode(false);

            modelBuilder.Entity<QuaTrinhCongTac>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<TrinhDoChuyenMon>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<TrinhDoNgoaiNgu>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<TrinhDoNgoaiNgu>()
                .Property(e => e.NgoaiNgu)
                .IsUnicode(false);
        }
    }
}
