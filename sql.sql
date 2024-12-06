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

CREATE TABLE tblUngVien (
    sMaUV NVARCHAR(50) NOT NULL PRIMARY KEY,  -- Mã ứng viên, khóa chính
    sTenUV NVARCHAR(100) NOT NULL,            -- Tên ứng viên
    dNgaySinh DATE NOT NULL,                  -- Ngày sinh
    sDiaChi NVARCHAR(255),                    -- Địa chỉ
    sSDT NVARCHAR(15) NOT NULL,               -- Số điện thoại
    sMaTK NVARCHAR(50),                       -- Mã tài khoản (có thể liên kết đến bảng tài khoản)
    sEmail NVARCHAR(100) UNIQUE               -- Email (duy nhất)
);
go
INSERT INTO tblUngVien (sMaUV, sTenUV, dNgaySinh, sDiaChi, sSDT, sMaTK, sEmail) 
VALUES 
('UV001', 'Nguyễn Văn A', '1990-01-01', '123 Đường Láng, Hà Nội', '0912345678', 'TK001', 'nguyenvana@example.com'),
('UV002', 'Trần Thị Bích', '1995-05-10', '456 Đường Cầu Giấy, Hà Nội', '0934567890', 'TK002', 'tranthibich@example.com'),
('UV003', 'Lê Văn Hoàng', '1988-12-20', '789 Đường Nguyễn Trãi, TP.HCM', '0923456781', 'TK003', 'levanhoang@example.com'),
('UV004', 'Phạm Thị Thu Hà', '1992-03-15', '321 Đường Lý Thường Kiệt, Đà Nẵng', '0945678901', 'TK004', 'phamthithuha@example.com'),
('UV005', 'Hoàng Minh Tuấn', '1998-07-25', '987 Đường Pasteur, Cần Thơ', '0916782345', 'TK005', 'hoangminhtuan@example.com');

select * from tblUngTuyen
CREATE TABLE tblUngTuyen (
    sMaUV NVARCHAR(50) NOT NULL,
    sMaTinTD int NOT NULL,
    dNgayNop DATETIME NOT NULL,
    sTrangThai NVARCHAR(50) NULL,
    PRIMARY KEY (sMaUV, sMaTinTD),
    FOREIGN KEY (sMaUV) REFERENCES tblUngVien(sMaUV),
    FOREIGN KEY (sMaTinTD) REFERENCES tblTinTuyenDung(sMaTinTD)
);
INSERT INTO tblUngTuyen (sMaUV, sMaTinTD, dNgayNop)
VALUES 
('UV001', 1, '2024-12-06'),
('UV002', 1, '2024-12-06'),
('UV003', 2, '2024-12-06'),
('UV004', 2, '2024-12-06'),
('UV005', 3, '2024-12-06');
