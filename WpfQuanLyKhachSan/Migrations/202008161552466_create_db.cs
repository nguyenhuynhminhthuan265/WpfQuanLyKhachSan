namespace WpfQuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeRooms", "NumberOfCustomer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeRooms", "NumberOfCustomer");
        }
    }
}
