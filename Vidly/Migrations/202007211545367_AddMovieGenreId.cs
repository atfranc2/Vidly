namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieGenreId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "MovieGenre_Id", newName: "MovieGenreId");
            RenameIndex(table: "dbo.Movies", name: "IX_MovieGenre_Id", newName: "IX_MovieGenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_MovieGenreId", newName: "IX_MovieGenre_Id");
            RenameColumn(table: "dbo.Movies", name: "MovieGenreId", newName: "MovieGenre_Id");
        }
    }
}
