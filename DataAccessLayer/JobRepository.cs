using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseLayer;

namespace DataAccessLayer
{
    public class JobRepository
    {
        private readonly JobDbContext _context;

        // Constructor nhận DbContext thông qua Dependency Injection
        public JobRepository(JobDbContext context)
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

        // Lấy tin tuyển dụng theo ID
        public TinTuyenDung GetById(int id)
        {
            return _context.tblTinTuyenDung.FirstOrDefault(t => t.sMaTinTD == id);
        }

        // Xóa tin tuyển dụng
        public void Delete(TinTuyenDung job)
        {
            _context.tblTinTuyenDung.Remove(job);
            _context.SaveChanges();
        }
    }
}
