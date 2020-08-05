namespace WpfQuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "TypeRoomId", "dbo.TypeRooms");
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropIndex("dbo.Rooms", new[] { "TypeRoomId" });
            DropIndex("dbo.Employees", new[] { "RoleId" });
            DropTable("dbo.TypeRooms");
            DropTable("dbo.Rooms");
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
        }
    }
}
