using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvrLibrary
{
    public class SolvrDB : DataContext
    {
        //General Connection String. Kan ikke være Const pga. Enviroment.MachineName.
        private static string ConnectionString = @"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;"+
                                                 "Initial Catalog=SolvrDb;" +
                                                 "Integrated Security=True;"+
                                                 "Connect Timeout=30;"+
                                                 "Encrypt=False;"+
                                                 "TrustServerCertificate=True;"+
                                                 "ApplicationIntent=ReadWrite;"+
                                                 "MultiSubnetFailover=False";

        //Here are the tables for the project. These tables are in the database.
        public Table<Post> Posts;
        public Table<User> Users;
        public Table<Comment> Comments;
        public Table<Category> Categories;
        public Table<Report> Reports;
        public Table<Vote> Votes;

        /// <summary>
        /// Used to create a connection to the database through a connection string.
        /// Base is an inheritance that creates a new instance of the datacontext class (In here SolvrDB)
        /// </summary>
        /// <param name="connection"></param>
        /// 
        public SolvrDB() : base(ConnectionString) {}
    }
}
