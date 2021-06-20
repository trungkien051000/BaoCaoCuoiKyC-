Create database HoTenDB
go
Use HoTenDB
go
CREATE TABLE UserAccount(
ID int IDENTITY(1,1) primary key,
UsereName nvarchar(50) NULL,
Password varchar(50) NULL,
Status varchar(50) not null
)
insert into UserAccount values
('admin','21232f297a57a5a743894a0e4a801fc3','Admin'),
('kien','f2f70acc5e22914bcb3a36cc42cdfcc7','User'),
('bao','b4e1c6620073acda217d807627a78dae','Blocked')
CREATE TABLE Category(
ID int IDENTITY(1,1) primary key,
Namee nvarchar(100) NOT NULL,
Description nvarchar(250) NULL,
)
insert into Category values
(N'Màn hình máy tính',N'Màn hình máy tính là thiết bị điện tử gắn liền với máy tính với mục đích chính là hiển thị và giao tiếp giữa người sử dụng với máy tính.'),
(N'Bàn phím',N'Bàn phím máy tính là một thiết bị kiểu máy đánh chữ sử dụng cách sắp xếp các nút hoặc phím bấm để hoạt động như đòn bẩy cơ học hoặc công tắc điện tử.'),
(N'Chuột',N'Chuột máy tính là một thiết bị ngoại vi của máy tính dùng để điều khiển và làm việc với máy tính.')

CREATE TABLE Product(
ID int IDENTITY(1,1) primary key,
Name nvarchar(100) NOT NULL,
UnitCost money NULL,
Quantity int NOT NULL,
Image varchar(100) NULL,
Description nvarchar(250) NULL,
Status nvarchar(100) null,
ProductID int foreign key references Category(ID)
)
insert into Product values
(N'Màn hình Cong Gaming 27 GIGABYTE AORUS G27FC-EK','8990000','86','https://product.hstatic.net/1000333506/product/giga_g27fc_gear.png',N'Tấm nền VA, Full HD, 165HZ, 1MS, Freesync',N'Còn hàng',1),
(N'Màn hình cong Gaming 240HZ SamSung','9519000','100','https://xgear.vn/wp-content/uploads/2019/07/LC27RG50_6_compressed-1.jpg',N'Tầm nền VA, Độ cong 1500R cho đôi mắt thoải mái',N'Còn hàng',1),
(N'Màn hình Gaming 2K 27" LG 27GP850-B','11490000','23','https://cdn.cellphones.com.vn/media/catalog/product/cache/7/thumbnaigp850-27-inch-1.png',N'Tấm nền: Nano IPS;Độ phân giải: QHD (2560 x 1440)',N'Còn hàng',1),
(N'BÀN PHÍM CƠ ASUS ROG STRIX SCOPE PBT CHERRY','2890000','16','https://xgear.vn/wp-content/uploads/2021/02/Asus-Scope-PBT_compressed.jpg',N'Bàn phím cơ sử dụng switch Cherry MX;Keycap bằng PBT siêu bền',N'Còn hàng',2),
(N'Bàn phím cơ Newmen GM390','990000','135','https://hanoicomputercdn.com/media/product/51609_ban_phim_co_newmen_gm390_blue_1.jpg',N'Bàn phím cơ chơi game chuyên dụng',N'Còn hàng',2),
(N'Chuột chơi Game 6 nút LOGITECH G102 LIGHTSYNC','450000','23','https://philong.com.vn/media/product/22658-g102-white-9.jpg',N'Chuột chơi game chuyên dụng',N'Còn hàng',3)
create proc Sp_Product_ListAll
as
select * from Product 
order by [Quantity] asc, [UnitCost] desc