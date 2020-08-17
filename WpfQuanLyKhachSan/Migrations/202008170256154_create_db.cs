namespace WpfQuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_db : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TypeRooms", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TypeRooms", "Price", c => c.Single(nullable: false));
        }
    }
}
