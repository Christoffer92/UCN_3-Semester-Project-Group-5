using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;
using DataAccesLayer.ModelBuilds;

namespace DataAccesLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestPost();
            Console.ReadLine();
        }

        public static void TestUser()
        {
            ModelBuilder modelBuilder = new ModelBuilder();
            User user = modelBuilder.BuildUser(1);

            Console.WriteLine(user.Name + user.Email + user.DateCreated + user.IsAdmin + user.Password);
        }
        public static void TestPost()
        {
            ModelBuilder modelBuilder = new ModelBuilder();
            Post post = modelBuilder.BuildPost<Post>(16);

            Console.WriteLine(post.Title + post.Comments[0].Text);
        }
    }
}