create database TestKTPM

use TestKTPM

CREATE TABLE tblTinTuyenDung (
    sMaTinTD INT IDENTITY(1,1) PRIMARY KEY,
    sTenTinTD NVARCHAR(255) NOT NULL,
    dNgayDang DATE NOT NULL,
    sMoTa NVARCHAR(1000),
    iMucLuong INT,
    iSoNguoiTuyen INT,
    sNoiLamViec NVARCHAR(255)
);

INSERT INTO tblTinTuyenDung (sTenTinTD, dNgayDang, sMoTa, iMucLuong, iSoNguoiTuyen, sNoiLamViec)
VALUES 
(N'Công việc lập trình viên', '2024-12-05', 'Mô tả công việc lập trình viên', 15000000, 3, N'Hà Nội'),
(N'Nhân viên bán hàng', '2024-12-05', 'Mô tả công việc nhân viên bán hàng', 10000000, 5, N'TP. Hồ Chí Minh'),
(N'Chuyên viên marketing', '2024-12-05', 'Mô tả công việc chuyên viên marketing', 12000000, 2, N'Đà Nẵng');

select * from tblTinTuyenDung

drop table tblTinTuyenDung


