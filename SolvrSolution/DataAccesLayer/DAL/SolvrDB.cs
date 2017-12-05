﻿using DataAccesLayer.ModelBuilds;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvrLibrary;

namespace SolvrLibrary
{
    public class SolvrDB : DataContext, ISolvrDB
    {
        //General Connection String. Kan ikke være Const pga. Enviroment.MachineName.
        private static string ConnectionString = @"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;" 
        +"Initial Catalog=SolvrDb;" 
        +"Integrated Security=True;" 
        +"Connect Timeout=30;" 
        +"Encrypt=False;" 
        +"TrustServerCertificate=True;" 
        +"ApplicationIntent=ReadWrite;" 
        +"MultiSubnetFailover=False";

        //Here are the tables for the project. These tables are in the database.
        public Table<Post> Posts;// { get; private set; }
        public Table<User> Users;// { get; private set; }
        public Table<Comment> Comments;// { get; private set; }
        public Table<Category> Categories;// { get; set; }
        public Table<Report> Reports;// { get; private set; }
        public Table<Vote> Votes;// { get; private set; }

        /// <summary>
        /// Used to create a connection to the database through a connection string.
        /// Base is an inheritance that creates a new instance of the datacontext class (In here SolvrDB)
        /// </summary>
        /// <param name="connection"></param>
        public SolvrDB() : base(ConnectionString) { }

        //Queries after this:
        public Category GetCategory(int id)
        {
            return new ModelBuilder().BuildCategory(id);
        }

        public Category GetCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Report GetReport(int id)
        {
            return new ModelBuilder().BuildReport(id);
        }

        public Post CreatePost(Post post)
        {
            Posts.InsertOnSubmit(post);
            SubmitChanges();
            return post;
        }

        public PhysicalPost CreatePhysicalPost(PhysicalPost physicalPost)
        {
            Posts.InsertOnSubmit(physicalPost);
            SubmitChanges();
            return GetPhysicalPost(physicalPost.Id);
        }

        public Post GetPost(int id)
        {
            return new ModelBuilder().BuildPost<Post>(id);
        }

        public PhysicalPost GetPhysicalPost(int id)
        {
            return new ModelBuilder().BuildPost<PhysicalPost>(id);
        }

        public Post GetPost()
        {
            return Posts.OfType<Post>().Last();
        }

        public PhysicalPost GetPhysicalPost()
        {
            return Posts.OfType<PhysicalPost>().Last();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return Categories.ToList<Category>();
        }

        public User GetUser()
        {
            //TODO Improve
            int lastID = Users.Count();
            return new ModelBuilder().BuildUser(lastID);
        }
    }
}
