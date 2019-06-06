namespace WebServSendSMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittablelogSend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WSSS_LogSend", "Message", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.WSSS_LogSend", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WSSS_LogSend", "Text", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.WSSS_LogSend", "Message");
        }
    }
}
