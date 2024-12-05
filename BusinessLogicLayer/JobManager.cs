using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class JobManager
    {
        private readonly JobDbContext _context;

        public JobManager(JobDbContext context)
        {
            _context = context;
        }

        public List<TinTuyenDung> GetAllJobs()
        {
            return _context.tblTinTuyenDung.ToList(); 
        }

        // Phương thức thêm sản phẩm mới vào cơ sở dữ liệu
        public void AddJob(TinTuyenDung tinTuyenDung)
        {
            _context.tblTinTuyenDung.Add(tinTuyenDung);   
            _context.SaveChanges();          
        }
    }
}
