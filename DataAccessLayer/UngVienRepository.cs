using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UngVienRepository
    {
        public readonly JobDbContext _context;
        public UngVienRepository(JobDbContext context)
        {
            _context = context;
        }
        public List<UngVien> GetUngViensByTinTuyenDung(int maTinTD)
        {
            var candidates = _context.tblUngTuyen
               .Where(ja => ja.sMaTinTD == maTinTD)
               .Select(ja => ja.UngVien)
               .ToList();

            return candidates;
        }
    }
}
