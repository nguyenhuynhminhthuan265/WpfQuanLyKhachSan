/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT TOP 1000 [Id]
--      ,[NameTypeRoom]
--      ,[Price]
--      ,[isDeleted]
--  FROM [QuanLyKhachSanUpdate].[dbo].[TypeRooms]

USE QuanLyKhachSanUpdate

SET DATEFORMAT dmy; /*day-month-year*/
GO

  /*reset id = 0 */

DBCC CHECKIDENT ('[Employees]', RESEED, 0);
GO

DBCC CHECKIDENT ('[TypeRooms]', RESEED, 0);
GO

INSERT INTO dbo.TypeRooms (NameTypeRoom, Price, NumberOfCustomer, isDeleted) VALUES ('Type Room A', 300000, 3, 0);
INSERT INTO dbo.TypeRooms (NameTypeRoom, Price, NumberOfCustomer, isDeleted) VALUES ('Type Room B', 220000, 3, 0);
INSERT INTO dbo.TypeRooms (NameTypeRoom, Price, NumberOfCustomer, isDeleted) VALUES ('Type Room C', 150000, 3, 0);


DBCC CHECKIDENT ('[Rooms]', RESEED, 0);
GO

INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 1','Note 1', 1,'empty' , 0);
INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 2','Note 2', 2, 'booked' ,0);
INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 3','Note 3', 3, 'empty',0);
INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 4','Note 4', 1, 'empty',0);
INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 5','Note 5', 2, 'booked',0);
INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 6','Note 6', 3,'booked' ,0);
INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 7','Note 7', 1, 'empty',0);
INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 8','Note 8', 2, 'empty',0);

DBCC CHECKIDENT ('[Roles]', RESEED, 0);
GO

INSERT INTO dbo.Roles (Name,[Description],isDeleted ) VALUES ('ROLE_ADMIN',N'Quản trị',0);
INSERT INTO dbo.Roles (Name,[Description],isDeleted ) VALUES ('ROLE_MANAGER',N'Giám đốc',0);
INSERT INTO dbo.Roles (Name,[Description],isDeleted ) VALUES ('ROLE_EMPLOYEE',N'Nhân viên',0);
INSERT INTO dbo.Roles (Name,[Description],isDeleted ) VALUES ('Test','Test',0);

DBCC CHECKIDENT ('[Customers]', RESEED, 0);
GO
INSERT INTO dbo.Customers (NameCustomer, IDNumber, [Address], TypeCustomer, isDeleted)
VALUES ('Le Dinh Thanh', '025868208', N'109 Đinh Tiên Hoàng', N'Nước Ngoài', 0);

INSERT INTO dbo.Customers (NameCustomer, IDNumber, [Address], TypeCustomer, isDeleted)
VALUES ('Nguyen Huynh Minh Thuan', '01234567', N'862 Cách Mạng Tháng 8', N'Việt Nam', 0);

INSERT INTO dbo.Customers (NameCustomer, IDNumber, [Address], TypeCustomer, isDeleted)
VALUES ('Nguyen Khanh Hoang', '09876543', N'357 Nguyễn Tri Phương', N'Việt Nam', 0);

DBCC CHECKIDENT ('[CardBookRooms]', RESEED, 0);
GO


INSERT INTO dbo.CardBookRooms (DateBookRoom, DateReturnRoom, PriceBookRoom, CountCustomers, RoomId, CustomerId, isDelete)
VALUES ('08-08-2020', '10-08-2020', 300000, 1, 2, 1, 0);

INSERT INTO dbo.CardBookRooms (DateBookRoom, DateReturnRoom, PriceBookRoom, CountCustomers, RoomId, CustomerId, isDelete)
VALUES ('08-08-2020', '11-08-2020', 220000, 1, 5, 2, 0);

INSERT INTO dbo.CardBookRooms (DateBookRoom, DateReturnRoom, PriceBookRoom, CountCustomers, RoomId, CustomerId, isDelete)
VALUES ('08-08-2020', '13-08-2020', 150000, 1, 6, 3, 0);