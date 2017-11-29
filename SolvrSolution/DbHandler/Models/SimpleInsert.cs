using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace DbHandler.Models
{
    public static class SimpleInsert
    {
        public static void InsertDataIntoDB()
        {
            InsertCategory();
            InsertUser();
            InsertPost();
            InsertComment();
            InsertPhysicalPost();
            InsertSolvrComment();
            InsertVote();
            InsertReport();
        }

        public static void InsertUser()
        {
            Console.WriteLine("User to DB...");
            User user = new User();

            user.Name = "Berte Chason";
            Console.WriteLine("Name = " + user.Name);

            user.Email = "bchason0@theglobeandmail.com";
            Console.WriteLine("Email = " + user.Email);

            user.Username = "ehinrichsen0";
            Console.WriteLine("Username = " + user.Username);

            user.Password = "uvLWXF";
            Console.WriteLine("Password = " +user.Password);

            user.IsAdmin = false;
            Console.WriteLine("IsAdmin = " + user.IsAdmin);

            user.DateCreated = DateTime.Now;
            Console.WriteLine("Date Created = "+ user.DateCreated);

            using (var context = new SolvrDB())
            {
                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
            }

            Console.WriteLine("Done.\n");
        }

        public static void InsertCategory()
        {
            Console.WriteLine("Category to DB...");
            Category category = new Category();

            category.Name = "philosophy";
            Console.WriteLine("Name = " + category.Name);

            using (var context = new SolvrDB())
            {
                context.Categories.InsertOnSubmit(category);
                context.SubmitChanges();
            }

            Console.WriteLine("Done.\n");
        }

        public static void InsertPost()
        {
            Console.WriteLine("Post to DB...");
            Post post = new Post();

            post.Title = "Print On Demand";
            Console.WriteLine("Title = " + post.Title);

            post.Description = "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst.";
            Console.WriteLine("Description = " + post.Description);

            post.BumpTime = DateTime.Now;
            Console.WriteLine("BumpTime = " + post.BumpTime);

            post.DateCreated = DateTime.Now;
            Console.WriteLine("Date Created = " + post.DateCreated); ;

            post.CategoryId = 1;
            Console.WriteLine("Categor ID = " + post.CategoryId);

            post.UserId = 1;
            Console.WriteLine("User ID = " + post.UserId);

            using (var context = new SolvrDB())
            {
                context.Posts.InsertOnSubmit(post);
                context.SubmitChanges();
            }

            Console.WriteLine("Done.\n");
        }

        public static void InsertPhysicalPost()
        {
            Console.WriteLine("Physical Post to DB...");
            PhysicalPost physicalPost = new PhysicalPost();


            //Post info
            physicalPost.Title = "Print On Demand";
            Console.WriteLine("Title = " + physicalPost.Title);

            physicalPost.Description = "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst.";
            Console.WriteLine("Description = " + physicalPost.Description);

            physicalPost.BumpTime = DateTime.Now;
            Console.WriteLine("BumpTime = " + physicalPost.BumpTime);

            physicalPost.DateCreated = DateTime.Now;
            Console.WriteLine("Date Created = " + physicalPost.DateCreated); ;

            physicalPost.CategoryId = 1;
            Console.WriteLine("Categor ID = " + physicalPost.CategoryId);

            physicalPost.UserId = 1;
            Console.WriteLine("User ID = " + physicalPost.UserId);

            //Physical Post info
            physicalPost.IsLocked = false;
            Console.WriteLine("IsLocked = " + physicalPost.IsLocked);

            physicalPost.AltDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.";
            Console.WriteLine("AltDescription = " + physicalPost.AltDescription);

            physicalPost.Zipcode = "555";
            Console.WriteLine("Zipcode = " + physicalPost.Zipcode);

            physicalPost.Address = "atvej 15";
            Console.WriteLine("Address = " + physicalPost.Address);

            /*physicalPost.PostId = 1;
            Console.WriteLine("Post ID = " + physicalPost.PostId);*/

            using (var context = new SolvrDB())
            {
                context.Posts.InsertOnSubmit(physicalPost);
                context.SubmitChanges();
            }

Console.WriteLine("Done.\n");
        }

        public static void InsertComment()
{
    Console.WriteLine("Comment to DB...");
    Comment comment = new Comment();

    comment.DateCreated = DateTime.Now;
    Console.WriteLine("Date Created = " + comment.DateCreated);

    comment.Text = "Donec quis orci eget orci vehicula condimentum.";
    Console.WriteLine("Comment = " + comment.Text);

    comment.UserId = 1;
    Console.WriteLine("User ID = " + comment.UserId);

    comment.PostId = 1;
    Console.WriteLine("Post ID = " + comment.PostId);

    using (var context = new SolvrDB())
    {
        context.Comments.InsertOnSubmit(comment);
        context.SubmitChanges();
    }

    Console.WriteLine("Done.\n");
}

public static void InsertSolvrComment()
{
    Console.WriteLine("Solvr Comment to DB...");
    SolvrComment solvrComment = new SolvrComment();

    //Comment info
    solvrComment.DateCreated = DateTime.Now;
    Console.WriteLine("Date Created = " + solvrComment.DateCreated);

    solvrComment.Text = "Donec quis orci eget orci vehicula condimentum.";
    Console.WriteLine("Comment = " + solvrComment.Text);

    solvrComment.UserId = 1;
    Console.WriteLine("User ID = " + solvrComment.UserId);

    solvrComment.PostId = 1;
    Console.WriteLine("Post ID = " + solvrComment.PostId);

    //SolvrComment info
    solvrComment.TimeAccepted = DateTime.Now;
    Console.WriteLine("Time Accepted = " + solvrComment.TimeAccepted);

    solvrComment.IsAccepted = false;
    Console.WriteLine("Is Accepted = " + solvrComment.IsAccepted);

    /*solvrComment.PhysicalPostId = 1;
    Console.WriteLine("PhysicalPost ID = " + solvrComment.PhysicalPostId);*/

    /*solvrComment.CommentId = 1;
    Console.WriteLine("Comment ID = " + solvrComment.CommentId);*/

    using (var context = new SolvrDB())
    {
        context.Comments.InsertOnSubmit(solvrComment);
        context.SubmitChanges();
    }

    Console.WriteLine("Done.\n");
}

public static void InsertVote()
{
    Console.WriteLine("Vote to DB...");
    Vote vote = new Vote();

    vote.IsUpvoted = false;
    Console.WriteLine("Is Upvoted = " + vote.IsUpvoted);

    vote.UserId = 1;
    Console.WriteLine("User ID = " + vote.UserId);

    vote.CommentId = 1;
    Console.WriteLine("Comment ID = " + vote.CommentId);

    using (var context = new SolvrDB())
    {
        context.Votes.InsertOnSubmit(vote);
        context.SubmitChanges();
    }

    Console.WriteLine("Done.\n");
}

public static void InsertReport()
{
    Console.WriteLine("Report to DB...");
    Report report = new Report { DateCreated = new DateTime(2019, 07, 24, 21, 48, 58), UserId = 1, CommentId = 1, PostId = 1 };

    report.Title = "massa tempor.";
    Console.WriteLine("Title = " + report.Title);

    report.Description = "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.";
    Console.WriteLine("Description = " + report.Description);

    report.DateCreated = DateTime.Now;
    Console.WriteLine("Date Created = " + report.DateCreated);

    report.UserId = 1;
    Console.WriteLine("User ID = " + report.UserId);

    report.CommentId = 1;
    Console.WriteLine("Comment ID = " + report.CommentId);

    report.PostId = 1;
    Console.WriteLine("Post ID = " + report.PostId);

    using (var context = new SolvrDB())
    {
        context.Reports.InsertOnSubmit(report);
        context.SubmitChanges();
    }

    Console.WriteLine("Done.\n");
}
    }
}

