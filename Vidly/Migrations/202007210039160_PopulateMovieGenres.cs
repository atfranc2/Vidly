namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MovieGenres ON"); 
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES(1, 'Action')");
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES(2, 'Comedy')");
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES(3, 'Family')");
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES(4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
