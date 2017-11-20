using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace DbHandler
{
    public class Insert
    {

        public void InsertData()
        {
            InsertUser();
            InsertCategory();
            InsertPost();
            InsertPhysPost();

            /*Models.UserInsert.InsertUsersIntoDB(context);
            Models.CategoryInsert.InsertCategoriesIntoDb(context);
            Models.PostInsert.InsertPostsIntoDb(context);
            Models.CommentInsert.CommentInsertIntoDb(context);
            Models.PhysicalPostInsert.InsertPhysicalPostIntoDb(context);
            Models.SolvrCommentInsert.InsertSolvrCommentIntoDb(context);
            Models.VoteInsert.InsertVoteIntoDb(context);
            Models.ReportInsert.InsertReportIntoDb(context);*/
        }

        /*public void InserSimpleData()
        {
            Models.SimpleInsert.InsertDataIntoDB();
        }*/

        public void InsertUser()
        {
            
            Console.WriteLine("User to db....");

            User u = new User();

            u.Name = "Berte Chason";
            Console.WriteLine("Name: " + u.Name);

            u.Email = "bchason0@theglobeandmail.com";
            Console.WriteLine("Email: " + u.Email);

            u.Username = "ehinrichsen0";
            Console.WriteLine("User name: " + u.Username);

            u.Password = "uvLWXF";
            Console.WriteLine("Pass: " + u.Password);

            u.IsAdmin = false;
            Console.WriteLine("IsAdmin: " + u.IsAdmin);

            u.DateCreated = new DateTime(2068, 06, 30, 15, 07, 52);
            Console.WriteLine("Date created:  " + u.DateCreated);

            using (var con = new SolvrDB())
            {
                con.Users.InsertOnSubmit(u);
                con.SubmitChanges();

            }

            Console.WriteLine("Done.\n");
        }

        public void InsertCategory()
        {
            Console.WriteLine("Category to db....");

            Category c = new Category();

            c.Name = "philosophy";
            Console.WriteLine("Name: " + c.Name);

            using (var con = new SolvrDB())
            {

                con.Categories.InsertOnSubmit(c);
                con.SubmitChanges();
            }

            Console.WriteLine("Done.\n");
        }

        public void InsertPost()
        {
            Console.WriteLine("Post to db....");

            Post p = new Post();

            p.Title = "Print On Demand";
            Console.WriteLine("Title: " + p.Title);

            p.Description = "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst.";
            Console.WriteLine("Description: " + p.Description);

            p.BumpTime = DateTime.Now;
            Console.WriteLine("Bumptime: " + p.BumpTime);

            p.DateCreated = DateTime.Now;
            Console.WriteLine("Date created: " + p.DateCreated);

            p.CategoryId = 1;
            Console.WriteLine("Category ID: " + p.CategoryId);

            p.UserId = 1;
            Console.WriteLine("User ID: " + p.UserId);

            using (var con = new SolvrDB())
            {
                con.Posts.InsertOnSubmit(p as Post);
                con.SubmitChanges();
            }

            Console.WriteLine("Done.\n");
        }

        public void InsertPhysPost()
        {
            Console.WriteLine("Physical Post to db....");

            PhysicalPost pp = new PhysicalPost();

            pp.IsLocked = false;
            Console.WriteLine("IsLocked: " + pp.IsLocked);

            pp.AltDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.";
            Console.WriteLine("AltDescription: " + pp.AltDescription);

            pp.Zipcode = "555";
            Console.WriteLine("Zipcode: " + pp.Zipcode);

            pp.Address = "atvej 15";
            Console.WriteLine("Address: " + pp.Address);



            pp.Title = "Print On Demand";
            Console.WriteLine("Title: " + pp.Title);

            pp.Description = "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst.";
            Console.WriteLine("Description: " + pp.Description);

            pp.BumpTime = DateTime.Now;
            Console.WriteLine("Bumptime: " + pp.BumpTime);

            pp.DateCreated = DateTime.Now;
            Console.WriteLine("Date created: " + pp.DateCreated);

            pp.CategoryId = 1;
            Console.WriteLine("Category ID: " + pp.CategoryId);

            pp.UserId = 1;
            Console.WriteLine("User ID: " + pp.UserId);


            using (var con = new SolvrDB())
            {
                con.Posts.InsertOnSubmit(pp as PhysicalPost);
                con.SubmitChanges();
            }


            Console.WriteLine("Done.\n");
        }

    }
}
