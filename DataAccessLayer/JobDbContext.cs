using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options)
           : base(options) // Truyền options cho constructor của DbContext
        {
        }
        public DbSet<TinTuyenDung> tblTinTuyenDung { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = CUONG\\MSSQLSERVER01;Initial Catalog=TestKTPM;Persist Security Info = True;TrustServerCertificate=True; User=sa;Password=cuong");
        }
    }
}
