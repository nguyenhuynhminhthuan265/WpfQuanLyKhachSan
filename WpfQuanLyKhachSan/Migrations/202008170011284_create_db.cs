namespace WpfQuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CardBookRooms", "CountCustomers", c => c.Int(nullable: false));
            AlterColumn("dbo.Bills", "TotalPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.CardBookRooms", "PriceBookRoom", c => c.Double(nullable: false));
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.CardBookRooms", "IndexCardBookRoom", c => c.Int(nullable: false));
            AlterColumn("dbo.CardBookRooms", "PriceBookRoom", c => c.Single(nullable: false));
            AlterColumn("dbo.Bills", "TotalPrice", c => c.Single(nullable: false));
            DropColumn("dbo.CardBookRooms", "CountCustomers");
        }
    }
}
