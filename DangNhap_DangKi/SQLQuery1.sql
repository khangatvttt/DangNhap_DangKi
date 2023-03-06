create database QLCD

use QLCD

create table CongDan(
	HoTen nvarchar(50),
	NgaySinh date,
	DiaChiThuongTru nvarchar(100),
	DiaChiHienTai nvarchar(100),
	CCCD nvarchar(12) primary key,
	DanToc nvarchar(50),
	TonGiao nvarchar(20),
	GioiTinh nvarchar(5),
	NgheNghiep nvarchar(50),
	TrinhDoHocVan nvarchar(20)
)

insert into CongDan values (N'Nguyễn Văn Sang','2003-1-1',N'HCM',N'Vũng Tàu','012345678900',N'Kinh',
								N'Không',N'Nam',N'Sinh Viên',N'Đại học')
insert into CongDan values (N'Nguyễn Thị Tuyết','2003-2-2',N'Hà Nội',N'Hải Phòng','111111111111',N'Kinh',
								N'Không',N'Nữ',N'Sinh Viên',N'Đại học')
insert into CongDan values (N'Nguyễn Văn Hải','2003-3-3',N'Cần Thơ',N'Tây Ninh','022222222222',N'Kinh',
								N'Không',N'Nam',N'Kinh Doanh',N'12/12')
insert into CongDan values (N'Nguyễn Thị Cúc','2003-4-4',N'Vĩnh Long',N'Hà Nội','022233344455','Kinh',
								N'Thiên Chúa',N'Nữ',N'Thiết kế',N'Thạc sĩ')

select *from CongDan