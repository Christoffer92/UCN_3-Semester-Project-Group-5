using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolvrLibrary;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.SqlClient;

namespace Solvr.Test
{
    [TestClass]
    public class DBConnectionTest
    {
        [TestMethod]
        public void TestConnection()
        {
            using (var db = new ModelContext()) {

                List<Post> posts = new List<Post>();
                string name = "John";
                string email = "hotm@il.com";
                string username = "bent";
                string password = "pass";
                bool adminuser = true;

                var user = new User { Name = name, Email = email, UserName = username, Password = password, AdminUser = adminuser };
                db.Users.Add(user);
                db.SaveChanges();

               var query = from Q in db.Users orderby Q.Name select Q;
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
               

            }
            


        }
    }
}
