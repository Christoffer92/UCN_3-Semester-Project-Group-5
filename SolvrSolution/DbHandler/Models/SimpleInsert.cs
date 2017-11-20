using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace DbHandler.Models
{
    public static class SimpleInsert
    {/*

        //IMPORTANT THIS CLASS IS NEVER USED AND CONTAINS A PLETHORA OF ERRORS

        public static void InsertDataIntoDB(SolvrDB context)
        {
            InsertUser(context);
            InsertCategory(context);
            InsertPost(context);
            InsertComment(context);
            InsertPhysicalPost(context);
            InsertSolvrComment(context);
            InsertVote(context);
            InsertReport(context);
        }

        public static void InsertUser(SolvrDB context)
        {
            User user = new User { Name = "Berte Chason", Email = "bchason0@theglobeandmail.com", Username = "ehinrichsen0", Password = "uvLWXF", IsAdmin = false, DateCreated = new DateTime(2028, 06, 30, 15, 07, 52) };
            context.Users.InsertOnSubmit(user);
            context.SubmitChanges();
        }

        public static void InsertCategory(SolvrDB context)
        {
            Category category = new Category { Name = "philosophy" };
            context.Categories.InsertOnSubmit(category);
            context.SubmitChanges();
        }

        public static void InsertPost(SolvrDB context)
        {
            Post post = new Post { Title = "Print On Demand", Description = "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit.", BumpTime = new DateTime(2025, 09, 26, 11, 56, 51), DateCreated = new DateTime(2025, 09, 26, 11, 56, 51), CategoryId = 1, UserId = 1 };
            context.Posts.InsertOnSubmit(post);
            context.SubmitChanges();
        }

        public static void InsertComment(SolvrDB context)
        {
            Comment comment = new Comment { DateCreated = new DateTime(2036, 11, 09, 11, 21, 23), Text = "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis.", UserId = 1, PostId = 1 };
            context.Comments.InsertOnSubmit(comment);
            context.SubmitChanges();
        }

        public static void InsertPhysicalPost(SolvrDB context)
        {
            PhysicalPost physicalPost = new PhysicalPost { IsLocked = false, AltDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.", Zipcode = "555", Address = "atvej 15", PostId = 1 };
           /* context.PhysicalPosts.InsertOnSubmit(physicalPost);
            context.SubmitChanges();*/
        /*}

        public static void InsertSolvrComment(SolvrDB context)
        {
            SolvrComment solvrComment = new SolvrComment { TimeAccepted = new DateTime(2019, 06, 15, 15, 02, 42), IsAccepted = false, PhysicalPostId = 1, CommentId = 1 };
            context.SolvrComments.InsertOnSubmit(solvrComment);
            context.SubmitChanges();
        }

        public static void InsertVote(SolvrDB context)
        {
            Vote vote = new Vote { IsUpvoted = false, UserId = 1, CommentId = 1 };
            context.Votes.InsertOnSubmit(vote);
            context.SubmitChanges();
        }

        public static void InsertReport(SolvrDB context)
        {
            Report report = new Report { Title = "massa tempor convallis nulla neque", Description = "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.", DateCreated = new DateTime(2019, 07, 24, 21, 48, 58), UserId = 1, CommentId = 1, PostId = 1 };
            context.Reports.InsertOnSubmit(report);
            context.SubmitChanges();
        }*/
    }
}

