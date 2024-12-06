using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
        public class UngTuyen
    {
        public string sMaUV { get; set; }
        public int sMaTinTD { get; set; }
        public DateTime dNgayNop { get; set; }
        public string sTrangThai { get; set; }

        // Navigation properties
        public UngVien UngVien { get; set; }
        public TinTuyenDung TinTuyenDung { get; set; }
    }
}
