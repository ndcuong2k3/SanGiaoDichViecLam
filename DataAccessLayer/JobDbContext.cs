using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options)
           : base(options) // Truyền options cho constructor của DbContext
        {
        }
        public DbSet<TinTuyenDung> tblTinTuyenDung { get; set; }

        public DbSet<UngTuyen> tblUngTuyen { get; set; }
        public DbSet<UngVien> TBLUngVien { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UngTuyen>()
                .HasKey(ut => new { ut.sMaUV, ut.sMaTinTD });

            // Cấu hình quan hệ với UngVien
            modelBuilder.Entity<UngTuyen>()
                .HasOne(ut => ut.UngVien)
                .WithMany()  // Nếu một UngVien có thể ứng tuyển nhiều lần
                .HasForeignKey(ut => ut.sMaUV)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ với TinTuyenDung
            modelBuilder.Entity<UngTuyen>()
                .HasOne(ut => ut.TinTuyenDung)
                .WithMany()  // Nếu một TinTuyenDung có thể nhận nhiều ứng viên
                .HasForeignKey(ut => ut.sMaTinTD)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = CUONG\\MSSQLSERVER01;Initial Catalog=TestKTPM;Persist Security Info = True;TrustServerCertificate=True; User=sa;Password=cuong");
        }
    }
}
