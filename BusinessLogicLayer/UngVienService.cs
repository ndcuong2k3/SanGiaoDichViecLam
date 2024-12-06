using DataAccessLayer;
using DatabaseLayer;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class UngVienService
    {
        private readonly UngVienRepository _context;

        public UngVienService(UngVienRepository ungVienRepository)
        {
            _context = ungVienRepository ?? throw new ArgumentNullException(nameof(ungVienRepository));
        }

        public List<UngVien> GetUngViensForJob(int maTinTD)
        {
            if (maTinTD <= 0)
            {
                throw new ArgumentException("Mã tin tuyển dụng không hợp lệ.", nameof(maTinTD));
            }

            try
            {
                return _context.GetUngViensByTinTuyenDung(maTinTD);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Có lỗi khi lấy dữ liệu ứng viên.", ex);
            }
        }

        // Thêm phương thức GetCandidatesByJobId
        public List<UngVien> GetCandidatesByJobId(int maTinTD)
        {
           
            return GetUngViensForJob(maTinTD);
        }
    }
}
