namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRentalModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "MovieId", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropIndex("dbo.Rentals", new[] { "MovieId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Rentals", "MovieId");
            CreateIndex("dbo.Rentals", "CustomerId");
            AddForeignKey("dbo.Rentals", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
