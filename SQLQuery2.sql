CREATE DATABASE QuanLyNongThon
GO

USE QuanLyNongThon
GO

CREATE TABLE Huyen (
    HuyenID INT PRIMARY KEY IDENTITY(1,1),
    TenHuyen NVARCHAR(100) NOT NULL,
    MaHuyen VARCHAR(50) UNIQUE NOT NULL
);


go

CREATE TABLE Xa (
    XaID INT PRIMARY KEY IDENTITY(1,1),
    TenXa VARCHAR(255) NOT NULL,
    MaXa VARCHAR(50) UNIQUE NOT NULL,
    HuyenID INT NOT NULL,
    FOREIGN KEY (HuyenID) REFERENCES Huyen(HuyenID)
);

go
select * from Xa;


CREATE TABLE NguoiDung (
    NguoiDungID INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    MatKhau VARCHAR(255) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Hoạt động' CHECK (TrangThai IN (N'Hoạt động', N'Khóa')),
    NgayTao DATETIME DEFAULT GETDATE()
);

go

ALTER TABLE NguoiDung
ADD CapTk INT;
SELECT *FROM NguoiDung

UPDATE NguoiDung
SET CapTk = 0
WHERE CapTk IS NULL OR CapTk NOT IN (0, 1);


ALTER TABLE NguoiDung
ADD CONSTRAINT CK_CapTk CHECK (CapTk IN (0, 1));

ALTER TABLE NguoiDung
ADD CONSTRAINT DF_CapTk DEFAULT 0 FOR CapTk;

SELECT * FROM NguoiDung WHERE CapTk NOT IN (0, 1) OR CapTk IS NULL;
CREATE TABLE Quyen (
    QuyenID INT PRIMARY KEY IDENTITY(1,1),
    TenQuyen VARCHAR(255) NOT NULL,
    MoTa TEXT
);
go

CREATE TABLE NhomNguoiDung (
    NhomID INT PRIMARY KEY IDENTITY(1,1),
    TenNhom VARCHAR(255) NOT NULL,
    MoTa TEXT
);

go


CREATE TABLE PhanQuyenNguoiDung (
    NguoiDungID INT NOT NULL,
    QuyenID INT NOT NULL,
    PRIMARY KEY (NguoiDungID, QuyenID),
    FOREIGN KEY (NguoiDungID) REFERENCES NguoiDung(NguoiDungID),
    FOREIGN KEY (QuyenID) REFERENCES Quyen(QuyenID)
);

go

CREATE TABLE LichSuTruyCap (
    LichSuID INT PRIMARY KEY IDENTITY(1,1),
    NguoiDungID INT NOT NULL,
    ThoiGianTruyCap DATETIME DEFAULT GETDATE(),
    HoatDong VARCHAR(255),
    FOREIGN KEY (NguoiDungID) REFERENCES NguoiDung(NguoiDungID)
);

go


CREATE TABLE QuyHoachNuocSach (
    QuyHoachID INT PRIMARY KEY IDENTITY(1,1),
    TieuDe VARCHAR(255) NOT NULL,
    MoTa TEXT,
    NgayLap DATE,
    FileDinhKem VARCHAR(255)
);
go


CREATE TABLE CongTrinhNuocSach (
    CongTrinhID INT PRIMARY KEY IDENTITY(1,1),
    TenCongTrinh VARCHAR(255) NOT NULL,
    LoaiCongTrinh NVARCHAR(50) NOT NULL CHECK (LoaiCongTrinh IN (N'Tập trung', N'Nhỏ lẻ')),
    XaID INT NOT NULL,
    TrangThai NVARCHAR(50) DEFAULT N'Hoạt động' CHECK (TrangThai IN (N'Hoạt động', N'Không hoạt động')),
    FOREIGN KEY (XaID) REFERENCES Xa(XaID)
);
go
ALTER TABLE CongTrinhNuocSach
ALTER COLUMN TenCongTrinh NVARCHAR(100);
ALTER TABLE CongTrinhNuocSach
ADD Latitude FLOAT;

ALTER TABLE CongTrinhNuocSach
ADD Longitude FLOAT;

Select *From CongTrinhNuocSach;

CREATE TABLE BaoCao (
    BaoCaoID INT PRIMARY KEY IDENTITY(1,1),
    LoaiBaoCao NVARCHAR(50) NOT NULL CHECK (LoaiBaoCao IN (N'Chỉ số nước sạch', N'Thực hiện chỉ tiêu', N'Tổng hợp')),
    NoiDung TEXT NOT NULL,
    NgayLap DATETIME DEFAULT GETDATE(),
    FileDinhKem VARCHAR(255)
);

go

CREATE TABLE VanBanPhapLuat (
    VanBanID INT PRIMARY KEY IDENTITY(1,1),
    TieuDe VARCHAR(255) NOT NULL,
    NoiDung TEXT,
    FileDinhKem VARCHAR(255),
    NgayBanHanh DATE
);
go


CREATE TABLE CoSoChanNuoi (
    CoSoID INT PRIMARY KEY IDENTITY(1,1),
    TenCoSo VARCHAR(255) NOT NULL,
    ChuSoHuu VARCHAR(255) NOT NULL,
    DiaChi TEXT,
    TrangThai NVARCHAR(50) DEFAULT N'Hoạt động' CHECK (TrangThai IN (N'Hoạt động', N'Không hoạt động'))
);
go


CREATE TABLE GiayChungNhan (
    GiayID INT PRIMARY KEY IDENTITY(1,1),
    CoSoID INT NOT NULL,
    TenGiay VARCHAR(255) NOT NULL,
    NgayCap DATE,
    NgayHetHan DATE,
    FOREIGN KEY (CoSoID) REFERENCES CoSoChanNuoi(CoSoID)
);
go

ALTER TABLE NguoiDung ADD ResetCode VARCHAR(10);


SELECT * FROM dbo.NguoiDung 
ALTER TABLE Huyen
ALTER COLUMN TenHuyen NVARCHAR(100);
ALTER TABLE NguoiDung
ALTER COLUMN HoTen NVARCHAR(100);
ALTER TABLE Xa
ALTER COLUMN TenXa NVARCHAR(100);
ALTER TABLE NguoiDung
ADD LastLoginTime DATETIME DEFAULT GETDATE();

SELECT * FROM  dbo.NguoiDung ;

UPDATE NguoiDung
SET LastLoginTime = GETDATE()
WHERE Email = '07071970';
SELECT NguoiDungID, HoTen, Email, TrangThai FROM NguoiDung 


UPDATE QuyHoachNuocSach2
SET Longitude=105.719546
WHERE TenQuyHoach=N'Nhà máy nước';

UPDATE QuyHoachNuocSach2
SET Latitude=19.813899
WHERE TenQuyHoach=N'Nhà máy nước';

SELECT TenQuyHoach, Latitude, Longitude, TrangThai FROM QuyHoachNuocSach2
CREATE TABLE QuyHoachNuocSach2 (
    QuyHoachID INT PRIMARY KEY IDENTITY(1,1),
    TenQuyHoach NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(100),
    NgayThucHien DATE,
    Latitude DECIMAL(9, 6),
    Longitude DECIMAL(9, 6),
    TrangThai NVARCHAR(50) DEFAULT N'Hoạt động' CHECK (TrangThai IN (N'Hoạt động', N'Không hoạt động'))
);

CREATE TABLE BaoCaoQuyHoach (
    BaoCaoID INT PRIMARY KEY IDENTITY(1,1),
    QuyHoachID INT NOT NULL,
    TieuDe NVARCHAR(255) NOT NULL,
    NoiDung TEXT,
    FileDinhKem VARCHAR(255),
    NgayTao DATE DEFAULT GETDATE(),
    FOREIGN KEY (QuyHoachID) REFERENCES QuyHoachNuocSach2(QuyHoachID)
);


CREATE TABLE BanDoQuyHoach (
    BanDoID INT PRIMARY KEY IDENTITY(1,1),
    QuyHoachID INT NOT NULL,
    TenBanDo VARCHAR(255) NOT NULL,
    ToaDo TEXT,
    FileBanDo VARCHAR(255),
    FOREIGN KEY (QuyHoachID) REFERENCES QuyHoachNuocSach(QuyHoachID)
);

ALTER TABLE QuyHoachNuocSach2
ALTER COLUMN MoTa NVARCHAR(100);
ALTER TABLE BaoCaoQuyHoach
ALTER COLUMN NoiDung NVARCHAR(100);
select *from QuyHoachNuocSach2;

ALTER TABLE BaoCaoQuyHoach
ADD CONSTRAINT FK_BaoCaoQuyHoach_QuyHoachID 
FOREIGN KEY (QuyHoachID)
REFERENCES QuyHoachNuocSach2(QuyHoachID);

CREATE TABLE CongTrinhNuocSach2 (
    MaCongTrinh INT PRIMARY KEY IDENTITY(1,1),
    TenCongTrinh NVARCHAR(255) NOT NULL,
    ViTri NVARCHAR(255) NOT NULL,
    ViDo DECIMAL(9, 6) NOT NULL,
    KinhDo DECIMAL(9, 6) NOT NULL,
    CongSuat INT NOT NULL, -- Công suất tính bằng mét khối
    NgayLapDat DATE NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL CHECK (TrangThai IN (N'Hoạt động', N'Đang bảo trì', N'Ngừng hoạt động')),
    GhiChu NVARCHAR(MAX)
);

-- Tạo bảng Công trình Vệ sinh
CREATE TABLE CongTrinhVeSinh (
    MaCongTrinh INT PRIMARY KEY IDENTITY(1,1),
    TenCongTrinh NVARCHAR(255) NOT NULL,
    ViTri NVARCHAR(255) NOT NULL,
    ViDo FLOAT NOT NULL,
    KinhDo FLOAT NOT NULL,
    CongSuat INT NOT NULL, -- Công suất tính bằng số người phục vụ
    NgayLapDat DATE NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL CHECK (TrangThai IN (N'Hoạt động', N'Đang bảo trì', N'Ngừng hoạt động')),
    GhiChu NVARCHAR(MAX)
);

-- Tạo bảng Báo cáo Hàng tháng
CREATE TABLE BaoCaoHangThang (
    MaBaoCao INT PRIMARY KEY IDENTITY(1,1),
    NgayBaoCao DATE NOT NULL,
    MaCongTrinh INT NOT NULL,
    LoaiCongTrinh NVARCHAR(50) NOT NULL CHECK (LoaiCongTrinh IN (N'Cung cấp nước', N'Vệ sinh')),
    LuongNuocSanXuat FLOAT NULL, -- Lượng nước sản xuất (nếu là công trình nước sạch)
    LuongNuocTieuThu FLOAT NULL, -- Lượng nước tiêu thụ (nếu là công trình nước sạch)
    SoNguoiPhucVu INT NULL, -- Số người phục vụ (nếu là công trình vệ sinh)
    VanDeBaoCao NVARCHAR(MAX),
    FOREIGN KEY (MaCongTrinh) REFERENCES CongTrinhNuocSach2(MaCongTrinh)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Tạo bảng Nhật ký Bảo trì
CREATE TABLE NhatKyBaoTri (
    MaBaoTri INT PRIMARY KEY IDENTITY(1,1),
    MaCongTrinh INT NOT NULL,
    LoaiCongTrinh NVARCHAR(50) NOT NULL CHECK (LoaiCongTrinh IN (N'Cung cấp nước', N'Vệ sinh')),
    NgayBaoTri DATE NOT NULL,
    MoTaSuCo NVARCHAR(MAX),
    GiaiPhap NVARCHAR(MAX),
    TrangThai NVARCHAR(50) NOT NULL CHECK (TrangThai IN (N'Hoàn thành', N'Đang xử lý', N'Chưa xử lý')),
    FOREIGN KEY (MaCongTrinh) REFERENCES CongTrinhNuocSach2(MaCongTrinh)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- Chèn dữ liệu mẫu vào bảng Công trình Cung cấp Nước
INSERT INTO CongTrinhNuocSach2 (TenCongTrinh, ViTri, ViDo, KinhDo, CongSuat, NgayLapDat, TrangThai, GhiChu)
VALUES 
(N'Nhà máy nước thị trấn A', N'Trung tâm thị trấn', 20.9716, 105.8545, 5000, '2015-05-20', N'Hoạt động', N'Phục vụ khu vực trung tâm'),
(N'Máy bơm làng B', N'Khu phía Bắc làng', 20.9790, 105.8567, 800, '2018-07-15', N'Đang bảo trì', N'Đang thay thế máy bơm');

-- Chèn dữ liệu mẫu vào bảng Công trình Vệ sinh
INSERT INTO CongTrinhVeSinh (TenCongTrinh, ViTri, ViDo, KinhDo, CongSuat, NgayLapDat, TrangThai, GhiChu)
VALUES 
(N'Nhà vệ sinh cộng đồng A', N'Khu vực chợ', 20.9720, 105.8550, 200, '2016-03-10', N'Hoạt động', N'Được dọn dẹp hàng ngày'),
(N'Khu vệ sinh trường học', N'Đường vào trường', 20.9735, 105.8580, 500, '2017-08-25', N'Ngừng hoạt động', N'Lên kế hoạch sửa chữa');

CREATE TABLE BaoCaoThangCTNuocSach (
    MaBaoCao INT IDENTITY PRIMARY KEY,           -- Mã báo cáo (tự tăng)
    Thang INT NOT NULL CHECK (Thang BETWEEN 1 AND 12),  -- Tháng báo cáo
    Nam INT NOT NULL,                            -- Năm báo cáo
    TongSoCongTrinh INT NOT NULL,                -- Tổng số công trình
    SoCongTrinhHoatDong INT NOT NULL,            -- Số công trình đang hoạt động
    SoCongTrinhNgungHoatDong INT NOT NULL,       -- Số công trình ngừng hoạt động
    TongCongSuat INT NOT NULL                    -- Tổng công suất
);
GO

CREATE TABLE ChiTietBaoCaoThangCTNuocSach (
    MaChiTiet INT IDENTITY PRIMARY KEY,          -- Mã chi tiết báo cáo (tự tăng)
    MaBaoCao INT NOT NULL FOREIGN KEY REFERENCES BaoCaoThangCTNuocSach(MaBaoCao), -- Liên kết tới báo cáo
    MaCongTrinh INT NOT NULL FOREIGN KEY REFERENCES CongTrinhNuocSach2(MaCongTrinh), -- Liên kết tới công trình
    TrangThai NVARCHAR(50) NOT NULL,             -- Trạng thái công trình trong báo cáo
    CongSuat INT NOT NULL                        -- Công suất công trình trong báo cáo
);
GO

-- Thêm công trình nước sạch
INSERT INTO CongTrinhNuocSach2 (TenCongTrinh, ViTri, ViDo, KinhDo, CongSuat, NgayLapDat, TrangThai)
VALUES 
(N'Công trình 1', N'Xã A', 10.123456, 105.123456, 100, '2023-01-01', N'Hoạt động'),
(N'Công trình 2', N'Xã B', 11.234567, 106.234567, 200, '2023-02-01', N'Ngừng hoạt động'),
(N'Công trình 3', N'Xã C', 12.345678, 107.345678, 150, '2023-03-01', N'Hoạt động');
-- Thêm báo cáo tháng
INSERT INTO BaoCaoThangCTNuocSach (Thang, Nam, TongSoCongTrinh, SoCongTrinhHoatDong, SoCongTrinhNgungHoatDong, TongCongSuat)
VALUES 
(1, 2023, 3, 2, 1, 450);

-- Thêm chi tiết báo cáo
INSERT INTO ChiTietBaoCaoThangCTNuocSach (MaBaoCao, MaCongTrinh, TrangThai, CongSuat)
VALUES 
(1, 1, N'Hoạt động', 100),
(1, 2, 'Ngừng hoạt động', 200),
(1, 3, N'Hoạt động', 150);
GO



SELECT COUNT(*)
FROM CongTrinhNuocSach2
WHERE MaCongTrinh IN (1, 2, 3);

SELECT 
    MONTH(NgayLapDat) AS Thang, 
    YEAR(NgayLapDat) AS Nam,
    COUNT(MaCongTrinh) AS TongSoCongTrinh,
    SUM(CASE WHEN TrangThai = 'Đang hoạt động' THEN 1 ELSE 0 END) AS SoCongTrinhHoatDong,
    SUM(CASE WHEN TrangThai = 'Ngừng hoạt động' THEN 1 ELSE 0 END) AS SoCongTrinhNgungHoatDong,
    SUM(CongSuat) AS TongCongSuat
FROM CongTrinhNuocSach2
WHERE NgayLapDat BETWEEN '2023-01-01' AND '2023-12-31'
GROUP BY MONTH(NgayLapDat), YEAR(NgayLapDat)
ORDER BY Nam, Thang;

SELECT 
    bc.Thang, 
    bc.Nam, 
    ct.MaCongTrinh, 
    ct.TrangThai, 
    ct.CongSuat, 
    cn.TenCongTrinh, 
    cn.ViTri
FROM BaoCaoThangCTNuocSach bc
JOIN ChiTietBaoCaoThangCTNuocSach ct ON bc.MaBaoCao = ct.MaBaoCao
JOIN CongTrinhNuocSach2 cn ON ct.MaCongTrinh = cn.MaCongTrinh
WHERE bc.Thang = 1 AND bc.Nam = 2023;

-- Bảng lưu thông tin hoạt động của công trình nước sạch
CREATE TABLE HoatDongCongTrinhNuocSach (
    MaHoatDong INT PRIMARY KEY IDENTITY(1,1),
    MaCongTrinh INT NOT NULL FOREIGN KEY REFERENCES CongTrinhNuocSach2(MaCongTrinh),
    ThangBatDau DATE NOT NULL,
    ThangKetThuc DATE NOT NULL,
    SanLuong AS (DATEDIFF(MONTH, ThangBatDau, ThangKetThuc) * CongSuat) PERSISTED, -- Tính sản lượng
    CongSuat INT NOT NULL -- Công suất tại thời điểm hoạt động
);

-- Thêm dữ liệu hoạt động
INSERT INTO HoatDongCongTrinhNuocSach (MaCongTrinh, ThangBatDau, ThangKetThuc, CongSuat)
VALUES
(1, '2023-01-01', '2023-06-01', 500), -- Công trình 1: 6 tháng x 500 m³
(2, '2023-02-01', '2023-07-01', 300), -- Công trình 2: 5 tháng x 300 m³
(3, '2023-03-01', '2023-12-01', 400); -- Công trình 3: 9 tháng x 400 m³

SELECT 
    ct.TenCongTrinh,
    hd.ThangBatDau,
    hd.ThangKetThuc,
    hd.SanLuong
FROM HoatDongCongTrinhNuocSach hd
JOIN CongTrinhNuocSach2 ct ON hd.MaCongTrinh = ct.MaCongTrinh
WHERE hd.ThangBatDau >= '2023-01-01' AND hd.ThangKetThuc <= '2023-12-31'
ORDER BY hd.ThangBatDau;

ALTER TABLE HoatDongCongTrinhNuocSach
ADD CONSTRAINT CK_ThoiGian CHECK (ThangBatDau <= ThangKetThuc);

CREATE TABLE ChiSoNuoc (
    MaChiSo INT PRIMARY KEY IDENTITY(1,1), -- Khoá chính tự tăng
    MaCongTrinh INT NOT NULL,              -- Mã công trình (không được null)
    ThangNam DATE NOT NULL,                -- Tháng Năm (không được null)
    ChiSo DECIMAL(10,2) NOT NULL,          -- Giá trị chỉ số
    GhiChu NVARCHAR(255),                  -- Ghi chú
    FOREIGN KEY (MaCongTrinh) REFERENCES CongTrinhNuocSach2(MaCongTrinh) 
        ON DELETE CASCADE ON UPDATE CASCADE -- Đảm bảo xóa hoặc cập nhật liên kết khi thay đổi trong bảng CongTrinhNuocSach
);


INSERT INTO ChiSoNuoc (MaCongTrinh, ThangNam, ChiSo, GhiChu)
VALUES (1, '2023-12-01', 150.25, 'Chỉ số đầu tiên');

CREATE TABLE FileBCChiSoNuoc (
    MaFile INT PRIMARY KEY IDENTITY(1,1), -- Khoá chính tự tăng
    MaChiSo INT NOT NULL,                 -- Liên kết với bảng ChiSoNuoc
    TenFile NVARCHAR(255) NOT NULL,      -- Tên file
    DuongDan NVARCHAR(MAX) NOT NULL,     -- Đường dẫn tới file
    NgayTai DATE NOT NULL DEFAULT GETDATE(), -- Ngày tải file
    FOREIGN KEY (MaChiSo) REFERENCES ChiSoNuoc(MaChiSo) 
    ON DELETE CASCADE ON UPDATE CASCADE -- Đảm bảo xóa hoặc cập nhật liên kết khi thay đổi
);

CREATE TABLE ChiTieuNuocSach (
    MaChiTieu INT PRIMARY KEY IDENTITY(1,1),
    TenChiTieu NVARCHAR(255),
    DonVi NVARCHAR(50)  -- Đơn vị của chỉ tiêu, ví dụ m³, lít, v.v.
);

CREATE TABLE BaoCaoChiTieuNuocSach (
    MaBaoCao INT PRIMARY KEY IDENTITY(1,1), -- Mã báo cáo
    MaCongTrinh INT, -- Mã công trình
    MaChiTieu INT, -- Mã chỉ tiêu
    SanLuongThucTe DECIMAL(18, 2), -- Sản lượng thực tế
    ChiTieuDatDuoc DECIMAL(18, 2), -- Chỉ tiêu đạt được
    MaNguoi INT, -- Mã người thực hiện báo cáo
    TenNguoi NVARCHAR(255), -- Tên người thực hiện báo cáo
    VaiTro NVARCHAR(255), -- Vai trò người thực hiện
    Thang DATE, -- Thời gian báo cáo (tháng)
    CONSTRAINT FK_BaoCaoCongTrinh FOREIGN KEY (MaCongTrinh) REFERENCES CongTrinhNuocSach2(MaCongTrinh),
    CONSTRAINT FK_BaoCaoChiTieu FOREIGN KEY (MaChiTieu) REFERENCES ChiTieuNuocSach(MaChiTieu) -- Tham chiếu tới ChiTieuNuocSach
);


SELECT MaChiTieu, TenChiTieu FROM ChiTieuNuocSach;

INSERT INTO ChiTieuNuocSach (TenChiTieu, DonVi) 
VALUES ('Nong do pH', 'mg/l'),
       ('Ham luong Amoni', 'mg/l'),
	   ('Ham luong Hg tong so', 'mg/l'),
	   ('Ham luong Fe tong so', 'mg/l'),
	   ('Ham luong Asen tong so', 'mg/l');

CREATE TABLE FileChiTieuNuocSachDinhKem (
    MaFileDinhKem INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính, tự tăng
    MaBaoCao INT NOT NULL,                      -- Khóa ngoại đến bảng BaoCaoChiTieuNuocSach
    TenFile NVARCHAR(255) NOT NULL,            -- Tên file
    LoaiFile NVARCHAR(50) NULL,                -- Loại file (pdf, docx, jpg, v.v.)
    DuongDan NVARCHAR(MAX) NULL,               -- Đường dẫn file
    NoiDungFile VARBINARY(MAX) NULL,           -- Lưu dữ liệu nhị phân của file
    NgayTai DATETIME DEFAULT GETDATE(),        -- Ngày tải lên, mặc định là ngày hiện tại
    FOREIGN KEY (MaBaoCao) REFERENCES BaoCaoChiTieuNuocSach(MaBaoCao) -- Ràng buộc khóa ngoại
);

CREATE TABLE livestock_facility (
    id INT PRIMARY KEY IDENTITY(1,1) , -- ID cơ sở chăn nuôi, tự động tăng
    name_facilities VARCHAR(255) NOT NULL, -- Tên cơ sở, bắt buộc
    name_s VARCHAR(255) NOT NULL, -- Tên cá nhân, tổ chức, c
    address TEXT NOT NULL, -- Địa chỉ cơ sở, bắt buộc
    phone VARCHAR(20) NOT NULL, -- Số điện thoại, bắt buộc
    email VARCHAR(255), -- Email liên hệ, có thể NULL
    district_id INT NOT NULL, -- ID Huyện, bắt buộc
    commune_id INT NOT NULL, -- ID Xã, bắt buộc
    product_types TEXT NOT NULL, -- Loại hình chăn nuôi, bắt buộc
    scale VARCHAR(20) NOT NULL, -- Quy mô (lớn, vừa, nhỏ), bắt buộc
    FOREIGN KEY (district_id) REFERENCES Huyen(HuyenID), -- Liên kết với bảng huyện
    FOREIGN KEY (commune_id) REFERENCES Xa(XaID) -- Liên kết với bảng xã
);


go

CREATE TABLE livestock_conditions (
    id INT PRIMARY KEY IDENTITY(1,1), -- Mã định danh điều kiện chăn nuôi
    organization_id INT NOT NULL, -- Mã tổ chức liên kết (tham chiếu tới bảng livestock_facility)
    environment_condition TINYINT NOT NULL, -- Điều kiện môi trường (1 là đạt, 0 là chưa đạt)
    infrastructure_condition TINYINT NOT NULL, -- Điều kiện cơ sở vật chất (1 là đạt, 0 là chưa đạt)
    breed_condition TINYINT NOT NULL, -- Điều kiện giống vật nuôi (1 là đạt, 0 là chưa đạt)
    feed_condition TINYINT NOT NULL, -- Điều kiện thức ăn (1 là đạt, 0 là chưa đạt)
    veterinary_condition TINYINT NOT NULL, -- Điều kiện thú y và phòng dịch (1 là đạt, 0 là chưa đạt)
    labor_condition TINYINT NOT NULL, -- Điều kiện lao động (1 là đạt, 0 là chưa đạt)
    created_at DATE NOT NULL, -- Thời gian cập nhật
    FOREIGN KEY (organization_id) REFERENCES livestock_facility(id) -- Liên kết với bảng livestock_facility
);
GO

CREATE TABLE certifications (
    id INT PRIMARY KEY IDENTITY(1,1), -- Mã định danh giấy chứng nhận
    organization_id INT NOT NULL, -- Mã tổ chức liên kết (tham chiếu tới bảng livestock_facility)
    certificate_type VARCHAR(255) NOT NULL, -- Loại giấy chứng nhận
    issue_date DATE NOT NULL, -- Ngày cấp giấy chứng nhận
    expiry_date DATE NOT NULL, -- Ngày hết hạn giấy chứng nhận
    issued_by VARCHAR(255) NOT NULL, -- Tổ chức cấp giấy chứng nhận
    FOREIGN KEY (organization_id) REFERENCES livestock_facility(id) -- Liên kết với bảng livestock_facility
);
GO
ALTER TABLE certifications
ADD id_org INT NOT NULL; -- Thêm cột mã tổ chức chứng nhận

ALTER TABLE certifications
ADD FOREIGN KEY (id_org) REFERENCES certification_organizations(id);


CREATE TABLE certification_organizations (
    id INT PRIMARY KEY IDENTITY(1,1), -- Mã định danh tổ chức chứng nhận
    name VARCHAR(255) NOT NULL, -- Tên của tổ chức chứng nhận
    address VARCHAR(255) NOT NULL, -- Địa chỉ của tổ chức chứng nhận
    phone_number VARCHAR(20) NOT NULL, -- Số điện thoại liên hệ
    email VARCHAR(20), -- Địa chỉ email
    authorized_by VARCHAR(20) NOT NULL -- Cơ quan cấp phép cho tổ chức
);
GO

CREATE TABLE processing_facilities (
    id INT PRIMARY KEY IDENTITY(1,1), -- ID cơ sở chế biến, tự động tăng
    name_facilities VARCHAR(255) NOT NULL, -- Tên cơ sở, bắt buộc
    address TEXT NOT NULL, -- Địa chỉ cơ sở, bắt buộc
    phone VARCHAR(20) NOT NULL, -- Số điện thoại, bắt buộc
    email VARCHAR(255), -- Email liên hệ, có thể NULL
    district_id INT NOT NULL, -- ID Huyện, bắt buộc
    commune_id INT NOT NULL, -- ID Xã, bắt buộc
    product_types TEXT NOT NULL, -- Loại sản phẩm chế biến, bắt buộc
    FOREIGN KEY (district_id) REFERENCES Huyen(HuyenID), -- Liên kết với bảng Huyện
    FOREIGN KEY (commune_id) REFERENCES Xa(XaID) -- Liên kết với bảng Xã
);
go
CREATE TABLE legal_documents (
    id INT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    type VARCHAR(50) NOT NULL,
    issued_date DATE NOT NULL,
    effective_date DATE NOT NULL,
    issued_by VARCHAR(255) NOT NULL,
    file_path VARCHAR(255) NOT NULL,
    status TINYINT NOT NULL
);


CREATE TABLE files (
    id_file INT PRIMARY KEY,
    id_legal_documents INT NOT NULL,
    name_file VARCHAR(255) NOT NULL,
    upload_date DATE NOT NULL,
    FOREIGN KEY (id_legal_documents) REFERENCES legal_documents(id)
);

-- Tạo bảng livestock_facility
CREATE TABLE livestock_facility (
    id INT PRIMARY KEY IDENTITY(1,1),            -- ID cơ sở chăn nuôi, tự động tăng
    name_facilities VARCHAR(255) NOT NULL,        -- Tên cơ sở, bắt buộc
    name_s VARCHAR(255) NOT NULL,                 -- Tên cá nhân, tổ chức
    address TEXT NOT NULL,                        -- Địa chỉ cơ sở, bắt buộc
    phone VARCHAR(20) NOT NULL,                   -- Số điện thoại, bắt buộc
    email VARCHAR(255),                           -- Email liên hệ, có thể NULL
    district_id INT NOT NULL,                     -- ID Huyện, bắt buộc
    commune_id INT NOT NULL,                      -- ID Xã, bắt buộc
    product_types TEXT NOT NULL,                  -- Loại hình chăn nuôi, bắt buộc
    scale NVARCHAR(20) NOT NULL,                   -- Quy mô (lớn, vừa, nhỏ), bắt buộc
    FOREIGN KEY (district_id) REFERENCES Huyen(HuyenID),    -- Liên kết với bảng Huyện
    FOREIGN KEY (commune_id) REFERENCES Xa(XaID)            -- Liên kết với bảng Xã
);

INSERT INTO Huyen (TenHuyen, MaHuyen) VALUES 
(N'Huyện 1', 'H01'),
(N'Huyện 2', 'H02'),
(N'Huyện 3', 'H03');
SELECT * FROM Huyen;
-- Chèn dữ liệu mẫu vào bảng Xa
INSERT INTO Xa (TenXa, MaXa, HuyenID) VALUES 
(N'Xã A', 'XA01', 1), 
(N'Xã B', 'XA02', 1),
(N'Xã C', 'XA03', 2),
(N'Xã D', 'XA04', 2),
(N'Xã E', 'XA05', 3),
(N'Xã F', 'XA06', 3);
SELECT *FROM NguoiDung;

UPDATE NguoiDung
SET CapTk= 1
WHERE Email = 'cong';

