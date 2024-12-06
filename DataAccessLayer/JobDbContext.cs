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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-KPVI1J9T;Initial Catalog=KTPM;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }
}
