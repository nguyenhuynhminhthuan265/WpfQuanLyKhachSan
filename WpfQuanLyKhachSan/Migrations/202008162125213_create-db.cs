namespace WpfQuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                        IdCardBookRoom = c.Int(nullable: false),
                        IdEmployee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CardBookRooms", t => t.IdCardBookRoom, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.IdEmployee, cascadeDelete: true)
                .Index(t => t.IdCardBookRoom)
                .Index(t => t.IdEmployee);
            
            CreateTable(
                "dbo.CardBookRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateBookRoom = c.DateTime(nullable: false),
                        DateReturnRoom = c.DateTime(nullable: false),
                        PriceBookRoom = c.Double(nullable: false),
                        CountCustomers = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCustomer = c.String(),
                        IDNumber = c.String(),
                        Address = c.String(),
                        TypeCustomer = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        isBooking = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameRoom = c.String(),
                        Note = c.String(),
                        TypeRoomId = c.Int(nullable: false),
                        Status = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeRooms", t => t.TypeRoomId, cascadeDelete: true)
                .Index(t => t.TypeRoomId);
            
            CreateTable(
                "dbo.TypeRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameTypeRoom = c.String(),
                        Price = c.Double(nullable: false),
                        NumberOfCustomer = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Revenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RevenueOfDay = c.Single(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        Room_Id = c.Int(),
                        TypeRoom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .ForeignKey("dbo.TypeRooms", t => t.TypeRoom_Id)
                .Index(t => t.Room_Id)
                .Index(t => t.TypeRoom_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Revenues", "TypeRoom_Id", "dbo.TypeRooms");
            DropForeignKey("dbo.Revenues", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Bills", "IdEmployee", "dbo.Employees");
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Bills", "IdCardBookRoom", "dbo.CardBookRooms");
            DropForeignKey("dbo.Rooms", "TypeRoomId", "dbo.TypeRooms");
            DropForeignKey("dbo.CardBookRooms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.CardBookRooms", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Revenues", new[] { "TypeRoom_Id" });
            DropIndex("dbo.Revenues", new[] { "Room_Id" });
            DropIndex("dbo.Employees", new[] { "RoleId" });
            DropIndex("dbo.Rooms", new[] { "TypeRoomId" });
            DropIndex("dbo.CardBookRooms", new[] { "CustomerId" });
            DropIndex("dbo.CardBookRooms", new[] { "RoomId" });
            DropIndex("dbo.Bills", new[] { "IdEmployee" });
            DropIndex("dbo.Bills", new[] { "IdCardBookRoom" });
            DropTable("dbo.Revenues");
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
            DropTable("dbo.TypeRooms");
            DropTable("dbo.Rooms");
            DropTable("dbo.Customers");
            DropTable("dbo.CardBookRooms");
            DropTable("dbo.Bills");
        }
    }
}
