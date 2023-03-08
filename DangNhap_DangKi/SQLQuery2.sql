use QLCD

create table Thue(
	CCCD nvarchar(12),
	LoaiThue nvarchar(50),
	SoTien bigint,
	NgayDenHan date,
	TinhTrang nvarchar(10),
	QuaHan int,
	TienQuaHan int,
	Tong int
	primary key (CCCD, LoaiThue)
)
insert into Thue values ('012345678900',N'Thuế sử dụng đất','100000','2023-4-30',N'Đã đóng',NULL,NULL,NULL)
insert into Thue values ('012345678900',N'Thuế môi trường','50000','2023-3-31',N'Chưa đóng',NULL,NULL,NULL)
insert into Thue values ('022222222222',N'Thuế thu nhập cá nhân','800000','2023-2-22',N'Chưa đóng',NULL,NULL,NULL)
insert into Thue values ('022222222222',N'Thuế sử dụng đất','100000','2023-4-30',N'Đã đóng',NULL,NULL,NULL)
insert into Thue values ('022222222222',N'Thuế kinh doanh','1000000','2023-4-22',N'Đã đóng',NULL,NULL,NULL)
insert into Thue values ('111111111111',N'Thuế kinh doanh','1000000','2023-4-22',N'Đã đóng',NULL,NULL,NULL)

update Thue set QuaHan=1 where NgayDenHan<'2023-4-28' and TinhTrang=N'Chưa đóng'
update Thue set TienQuaHan = SoTien*0.1 where QuaHan=1
update Thue set TienQuaHan = 0 where QuaHan is NULL
update Thue set Tong = SoTien+TienQuaHan
