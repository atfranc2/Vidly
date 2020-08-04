namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertRentalChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "MovieId");
            AddForeignKey("dbo.Rentals", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "MovieId", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "MovieId" });
            DropColumn("dbo.Rentals", "MovieId");
        }
    }
}
