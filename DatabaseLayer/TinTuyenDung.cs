using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class TinTuyenDung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sMaTinTD { get; set; } // Khóa chính, tự tăng
        public string ?sTenTinTD { get; set; }
        public DateTime dNgayDang { get; set; }
        public string ?sMoTa { get; set; }
        public int iMucLuong { get; set; }
        public int iSoNguoiTuyen { get; set; }
        public string ?sNoiLamViec { get; set; }
    }
}
