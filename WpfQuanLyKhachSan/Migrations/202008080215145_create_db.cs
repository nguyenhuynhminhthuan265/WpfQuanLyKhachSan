namespace WpfQuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCustomer = c.String(),
                        IDNumber = c.String(),
                        Address = c.String(),
                        TypeCustomer = c.String(),
                        dateRent = c.DateTime(nullable: false),
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
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameRoom = c.String(),
                        Note = c.String(),
                        TypeRoomId = c.Int(nullable: false),
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
                        Price = c.Single(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Revenues", "TypeRoom_Id", "dbo.TypeRooms");
            DropForeignKey("dbo.Revenues", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "TypeRoomId", "dbo.TypeRooms");
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropIndex("dbo.Rooms", new[] { "TypeRoomId" });
            DropIndex("dbo.Revenues", new[] { "TypeRoom_Id" });
            DropIndex("dbo.Revenues", new[] { "Room_Id" });
            DropIndex("dbo.Employees", new[] { "RoleId" });
            DropTable("dbo.TypeRooms");
            DropTable("dbo.Rooms");
            DropTable("dbo.Revenues");
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
        }
    }
}
