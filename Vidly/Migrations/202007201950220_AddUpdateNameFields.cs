namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateNameFields : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go'"); 
            Sql("UPDATE MembershipTypes SET Name = 'Monthly'"); 
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly'"); 
            Sql("UPDATE MembershipTypes SET Name = 'Annual'"); 
        }
        
        public override void Down()
        {
        }
    }
}
