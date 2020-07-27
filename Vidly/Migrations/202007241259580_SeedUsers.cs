namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'71b86cf7-2786-4d02-b27c-f20ed6c1a971', N'admin@vidly.com', 0, N'AG+018fZeBKv/5fbdI7rXkMROfWds0ShOglplCMlVXKpVj2adY2zAcGP0IF8ltyLbg==', N'9c093d46-e90a-483e-b4cc-42cc9c5bc568', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'7f4d34f5-174a-402c-8698-dc206c5d63fe', N'guest@vidly.com', 0, N'AGjgB+p27XEQGQyVZoOAS/67+CmIIJ/NOwgLAmNFLCtIfbtVnhEhNW0Pf4EOf7pMtQ==', N'fae7c516-196f-4791-aecc-3da9f31a73fb', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bfcbef82-8b90-422a-bd9b-524201d35b18', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'71b86cf7-2786-4d02-b27c-f20ed6c1a971', N'bfcbef82-8b90-422a-bd9b-524201d35b18')
                ");

        }
        
        public override void Down()
        {
        }
    }
}
