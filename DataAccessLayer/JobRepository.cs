using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
namespace DataAccessLayer
{
    public class JobRepository
    {
        private readonly JobDbContext _context;

        // Sửa constructor để nhận DbContext qua Dependency Injection
        public JobRepository(JobDbContext context)
        {
            _context = context;
        }

        public List<TinTuyenDung> GetAllJobs()
        {
            return _context.tblTinTuyenDung.ToList();
        }

        public void AddJob(TinTuyenDung tinTuyenDung)
        {
            _context.tblTinTuyenDung.Add(tinTuyenDung);
            _context.SaveChanges();
        }
    }
}
