using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class UngVien
    {
        [Key]
        public string sMaUV { get; set; }       // Mã ứng viên
        public string sTenUV { get; set; }      // Tên ứng viên
        public DateTime dNgaySinh { get; set; } // Ngày sinh
        public string sDiaChi { get; set; }     // Địa chỉ
        public string sSDT { get; set; }        // Số điện thoại
        public string sMaTK { get; set; }       // Mã tài khoản
        public string sEmail { get; set; }      // Email
    }
}
