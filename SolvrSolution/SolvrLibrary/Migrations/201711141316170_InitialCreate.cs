namespace SolvrLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Text = c.String(),
                        SolvrCommentID = c.Int(),
                        TimeAccepted = c.DateTime(),
                        IsAccepted = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Post_PostID = c.Int(),
                        UserComment_UserID = c.Int(),
                        PPComment_PostID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Posts", t => t.Post_PostID)
                .ForeignKey("dbo.Users", t => t.UserComment_UserID)
                .ForeignKey("dbo.Posts", t => t.PPComment_PostID)
                .Index(t => t.Post_PostID)
                .Index(t => t.UserComment_UserID)
                .Index(t => t.PPComment_PostID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        AdminUser = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Tite = c.String(),
                        Description = c.String(),
                        BumpTime = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        PhysicalID = c.Int(),
                        Locked = c.Boolean(),
                        AltDescription = c.String(),
                        ZipCode = c.String(),
                        Address = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        PostCategory_CategoryID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Categories", t => t.PostCategory_CategoryID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.PostCategory_CategoryID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteID = c.Int(nullable: false, identity: true),
                        IsUpvoted = c.Boolean(nullable: false),
                        UserVote_UserID = c.Int(),
                        Comment_CommentID = c.Int(),
                    })
                .PrimaryKey(t => t.VoteID)
                .ForeignKey("dbo.Users", t => t.UserVote_UserID)
                .ForeignKey("dbo.Comments", t => t.Comment_CommentID)
                .Index(t => t.UserVote_UserID)
                .Index(t => t.Comment_CommentID);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        ReportedComment_CommentID = c.Int(),
                        ReportedPost_PostID = c.Int(),
                        ReportUser_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.Comments", t => t.ReportedComment_CommentID)
                .ForeignKey("dbo.Posts", t => t.ReportedPost_PostID)
                .ForeignKey("dbo.Users", t => t.ReportUser_UserID)
                .Index(t => t.ReportedComment_CommentID)
                .Index(t => t.ReportedPost_PostID)
                .Index(t => t.ReportUser_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "ReportUser_UserID", "dbo.Users");
            DropForeignKey("dbo.Reports", "ReportedPost_PostID", "dbo.Posts");
            DropForeignKey("dbo.Reports", "ReportedComment_CommentID", "dbo.Comments");
            DropForeignKey("dbo.Comments", "PPComment_PostID", "dbo.Posts");
            DropForeignKey("dbo.Votes", "Comment_CommentID", "dbo.Comments");
            DropForeignKey("dbo.Votes", "UserVote_UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserComment_UserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "PostCategory_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Comments", "Post_PostID", "dbo.Posts");
            DropIndex("dbo.Reports", new[] { "ReportUser_UserID" });
            DropIndex("dbo.Reports", new[] { "ReportedPost_PostID" });
            DropIndex("dbo.Reports", new[] { "ReportedComment_CommentID" });
            DropIndex("dbo.Votes", new[] { "Comment_CommentID" });
            DropIndex("dbo.Votes", new[] { "UserVote_UserID" });
            DropIndex("dbo.Posts", new[] { "User_UserID" });
            DropIndex("dbo.Posts", new[] { "PostCategory_CategoryID" });
            DropIndex("dbo.Comments", new[] { "PPComment_PostID" });
            DropIndex("dbo.Comments", new[] { "UserComment_UserID" });
            DropIndex("dbo.Comments", new[] { "Post_PostID" });
            DropTable("dbo.Reports");
            DropTable("dbo.Votes");
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
