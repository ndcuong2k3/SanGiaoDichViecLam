using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    public class JobManager
    {
        private readonly JobDbContext _context;

        public JobManager(JobDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách tất cả tin tuyển dụng
        public List<TinTuyenDung> GetAllJobs()
        {
            return _context.tblTinTuyenDung.ToList();
        }

        // Thêm tin tuyển dụng mới
        public void AddJob(TinTuyenDung tinTuyenDung)
        {
            _context.tblTinTuyenDung.Add(tinTuyenDung);
            _context.SaveChanges();
        }

        // Xóa tin tuyển dụng
        public void DeleteJob(int jobId)
        {
            var job = _context.tblTinTuyenDung.FirstOrDefault(j => j.sMaTinTD == jobId);
            if (job == null)
            {
                throw new Exception("Tin tuyển dụng không tồn tại.");
            }

            _context.tblTinTuyenDung.Remove(job);
            _context.SaveChanges();
        }
    }
}
