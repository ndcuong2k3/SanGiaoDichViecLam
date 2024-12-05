using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
           : base(options) // Truyền options cho constructor của DbContext
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = CUONG\\MSSQLSERVER01;Initial Catalog=TestKTPM;Persist Security Info = True;TrustServerCertificate=True; User=sa;Password=cuong");
        }
    }   
}
