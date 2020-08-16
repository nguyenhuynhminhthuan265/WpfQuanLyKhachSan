/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id]
      ,[NameTypeRoom]
      ,[Price]
      ,[isDeleted]
  FROM [QuanLyKhachSan].[dbo].[TypeRooms]



  /*reset id = 0 */
  DBCC CHECKIDENT ('[TypeRooms]', RESEED, 0);
  GO

  USE QuanLyKhachSanUpdate
  INSERT INTO dbo.TypeRooms (NameTypeRoom, Price, isDeleted) VALUES ('Type Room A', 200000, 0);
  INSERT INTO dbo.TypeRooms (NameTypeRoom, Price, isDeleted) VALUES ('Type Room B', 300000, 0);
  INSERT INTO dbo.TypeRooms (NameTypeRoom, Price, isDeleted) VALUES ('Type Room C', 400000, 0);

  /*UPDATE TypeRooms SET Id = 1 WHERE NameTypeRoom='Type Room A'*/
  /*DELETE FROM TypeRooms*/
   /*DELETE FROM TypeRooms WHERE Id = 2;*/

	/*DELETE FROM dbo.Rooms
	DBCC CHECKIDENT ('[Rooms]', RESEED, 0);*/
  INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 1','Note 1', 1,'empty' , 0);
  INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 2','Note 2', 2, 'booked' ,0);
  INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 3','Note 3', 3, 'empty',0);
  INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 4','Note 4', 1, 'empty',0);

  INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 5','Note 5', 2, 'booked',0);
  INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 6','Note 6', 3,'booked' ,0);
  INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 7','Note 7', 1, 'empty',0);
  INSERT INTO dbo.Rooms (NameRoom, Note, TypeRoomId, [Status], isDeleted) VALUES ('Room 8','Note 8', 2, 'empty',0);



  INSERT INTO dbo.Roles (Name,[Description],isDeleted ) VALUES ('ROLE_ADMIN','Quản trị',0)
  INSERT INTO dbo.Roles (Name,[Description],isDeleted ) VALUES ('ROLE_MANAGER','Quản trị',0)
  INSERT INTO dbo.Roles (Name,[Description],isDeleted ) VALUES ('ROLE_EMPLOYEE','Quản trị',0)
  INSERT INTO dbo.Roles (Name,[Description],isDeleted ) VALUES ('Test','Test',0)


  





  SELECT * FROM dbo.Rooms;