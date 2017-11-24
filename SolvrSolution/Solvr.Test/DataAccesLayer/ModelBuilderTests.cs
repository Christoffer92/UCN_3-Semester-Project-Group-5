using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccesLayer.ModelBuilds;
using SolvrLibrary;

namespace Solvr.Test.DataAccesLayer
{
    /// <summary>
    /// Summary description for ModelBuilderTests
    /// </summary>
    [TestClass]
    public class ModelBuilderTests
    {
        public ModelBuilderTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        [TestMethod]
        [DataRow("philosophy", 1)]
        [DataRow("soup", 736)]
        [DataRow("tree", 3)]
        [DataRow("test", 1000)]
        public void BuildCategoryTestPositive(string expectedName, int expectedId)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            Category expectedCategory = new Category
            {
                Id = expectedId,
                Name = expectedName
            };

            //Act
            Category actualCategory = modelBuilder.BuildCategory(expectedId);
            string actualName = actualCategory.Name;
            int actualId = actualCategory.Id;

            //Assert
            AssertAreEqualWithMsg(expectedName, actualName, "name");
            AssertAreEqualWithMsg(expectedId, actualId, "id");
        }

        [TestMethod]
        [DataRow("philosophy ", 1)]
        [DataRow("soup£", 736)]
        [DataRow("tree", 4)]
        [DataRow("test", 1001)]
        public void BuildCategoryTestNegative(string expectedName, int expectedId)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            Category expectedCategory = new Category
            {
                Id = expectedId,
                Name = expectedName
            };

            //Act
            Category actualCategory = modelBuilder.BuildCategory(expectedId);
            string actualName = actualCategory.Name;
            int actualId = actualCategory.Id;

            //Assert
            AssertAreEqualWithMsg(expectedName, actualName, "name");
            AssertAreEqualWithMsg(expectedId, actualId, "id");
        }

        //DateTime(2028, 06, 30, 15, 07, 52)
        [TestMethod]
        [DataRow(1, 2028, 6, 30, 15, 7, 52, "bchason0@attheglobe.com", false, "Berte Chason", "ehinrishsen0", "uvLWXF")]
        [DataRow(573, 2033, 05, 16, 19, 25, 39, "lcrockfw@altervista.org", false, "Leona Crock", "gupstellfw", "GA27D5lL")]
        [DataRow(1000, 2034, 09, 29, 06, 31, 09, "bmuntrr@cmu.edu", false, "bguagerr", "L22rm38Aoxn0")]
        public void BuildUserTestPostive(int expectedId, int expectedYear, int expectedMonth, int expectedDay, int expectedHour, int expectedMinutes, int expectedSeconds, string expectedEmail,
                                  Boolean expectedIsAdmin, string expectedName, string expectedUsername,
                                  string expectedPassword)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinutes, expectedSeconds);

            //Act
            User actualUser = modelBuilder.BuildUser(expectedId);
            int actualId = actualUser.Id;
            DateTime actualDateCreated = actualUser.DateCreated;
            string actualEmail = actualUser.Email;
            Boolean actualIsAdmin = actualUser.IsAdmin;
            string actualName = actualUser.Name;
            string actualUsername = actualUser.Username;
            string actualPassword = actualUser.Password;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedEmail, actualEmail, "email");
            AssertAreEqualWithMsg(expectedIsAdmin, actualIsAdmin, "isAdmin");
            AssertAreEqualWithMsg(expectedName, actualName, "name");
            AssertAreEqualWithMsg(expectedUsername, actualUsername, "username");
            AssertAreEqualWithMsg(expectedPassword, actualPassword, "password");
        }

        [TestMethod]
        [DataRow(1, 2028, 6, 30, 15, 7, 52, "bchason0@attheglobe.com", true, "Berte Chason", "ehinrishsen0", "uvLWXF")] //Testing IsAdmin
        [DataRow(573, 2033, 05, 16, 19, 25, 39, "lcrockfw@altervista.org", false, "Leona COll", "gupstellfw", "GA27D5lL")] //Testing Username
        [DataRow(999, 2034, 09, 29, 06, 31, 09, "bmuntrr@cmu.edu", false, "bguagerr", "L22rm38Aoxn0")] //Testing ID
        public void BuildUserTestNegative(int expectedId, int expectedYear, int expectedMonth, int expectedDay, int expectedHour, int expectedMinutes, int expectedSeconds, string expectedEmail,
                                  Boolean expectedIsAdmin, string expectedName, string expectedUsername,
                                  string expectedPassword)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinutes, expectedSeconds);

            //Act
            User actualUser = modelBuilder.BuildUser(expectedId);
            int actualId = actualUser.Id;
            DateTime actualDateCreated = actualUser.DateCreated;
            string actualEmail = actualUser.Email;
            Boolean actualIsAdmin = actualUser.IsAdmin;
            string actualName = actualUser.Name;
            string actualUsername = actualUser.Username;
            string actualPassword = actualUser.Password;

            //Assert

            AssertAreNotEqualWithMsg(expectedId, actualId, "id");
            AssertAreNotEqualWithMsg(expectedDateCreated, actualDateCreated, "datedCreated");
            AssertAreNotEqualWithMsg(expectedEmail, actualEmail, "email");
            AssertAreNotEqualWithMsg(expectedIsAdmin, actualIsAdmin, "isAdmin");
            AssertAreNotEqualWithMsg(expectedName, actualName, "name");
            AssertAreNotEqualWithMsg(expectedUsername, actualUsername, "username");
            AssertAreNotEqualWithMsg(expectedPassword, actualPassword, "password");
        }


        [TestMethod]
        [DataRow(1, "JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 103, 504)]
        [DataRow(420, "OAS Gold", "Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst.", 2021, 07, 25, 02, 47, 33, 2021, 07, 25, 02, 47, 33, 22, 187)]
        [DataRow(500, "Zero Waste", "Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.", 2030, 09, 01, 18, 00, 38, 2030, 09, 01, 18, 00, 38, 791, 109)]
        public void BuildPostTestPositive(int expectedId, string expectedTitle, string expectedDescription, int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinutes, int expectedDateCreatedSeconds,
                                          int expectedBumpTimeYear, int expectedBumpTimeMonth, int expectedBumpTimeDay, int expectedBumpTimeHour, int expectedBumpTimeMinute, int expectedBumpTimeSecond, 
                                          int expectedCategoryId, int expectedUserId)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinutes, expectedDateCreatedSeconds);
            DateTime expectedBumpTime = new DateTime(expectedBumpTimeYear, expectedBumpTimeMonth, expectedBumpTimeDay, expectedBumpTimeHour, expectedBumpTimeMinute, expectedBumpTimeSecond);

            //Act
            Post actualPost = modelBuilder.BuildPost<Post>(expectedId);
            int actualId = actualPost.Id;
            string actualTitle = actualPost.Title;
            DateTime actualDateCreated = actualPost.DateCreated;
            DateTime actualBumpTime = actualPost.BumpTime;
            int actualCategoryId = actualPost.CategoryId;
            string actualDescription = actualPost.Description;
            int actualUserId = actualPost.UserId;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedBumpTime, actualBumpTime, "bumpTime");
            AssertAreEqualWithMsg(expectedCategoryId, actualCategoryId, "categoryId");
            AssertAreEqualWithMsg(expectedDescription, actualDescription, "description");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
        }

        [TestMethod]
        //Forkert primaryKey
        [DataRow(3, "JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 103, 504)]
        //Forkert Title og årstal
        [DataRow(420, "Osa Gold", "Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst.", 2021, 07, 25, 02, 47, 33, 2031, 07, 25, 02, 47, 33, 22, 187)]
        //Forkerte foreign keys
        [DataRow(500, "Zero Waste", "Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.", 2030, 09, 01, 18, 00, 38, 2030, 09, 01, 18, 00, 38, 721, 139)]
        public void BuildPostTestNegative(int expectedId, string expectedTitle, int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinutes, int expectedDateCreatedSeconds,
                                         int expectedBumpTimeYear, int expectedBumpTimeMonth, int expectedBumpTimeDay, int expectedBumpTimeHour, int expectedBumpTimeMinute, int expectedBumpTimeSecond,
                                         int expectedCategoryId, string expectedDescription, int expectedUserId)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinutes, expectedDateCreatedSeconds);
            DateTime expectedBumpTime = new DateTime(expectedBumpTimeYear, expectedBumpTimeMonth, expectedBumpTimeDay, expectedBumpTimeHour, expectedBumpTimeMinute, expectedBumpTimeSecond);

            //Act
            Post actualPost = modelBuilder.BuildPost<Post>(expectedId);
            int actualId = actualPost.Id;
            string actualTitle = actualPost.Title;
            DateTime actualDateCreated = actualPost.DateCreated;
            DateTime actualBumpTime = actualPost.BumpTime;
            int actualCategoryId = actualPost.CategoryId;
            string actualDescription = actualPost.Description;
            int actualUserId = actualPost.UserId;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedBumpTime, actualBumpTime, "bumpTime");
            AssertAreEqualWithMsg(expectedCategoryId, actualCategoryId, "categoryId");
            AssertAreEqualWithMsg(expectedDescription, actualDescription, "description");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
        }

        [TestMethod]
        [DataRow(1, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum.Curabitur in libero ut massa volutpat convallis.", 714, 16)]
        [DataRow(350, 2036, 05, 05, 21, 27, 25, "Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam.", 65, 825)]
        [DataRow(500, 2020, 09, 11, 14, 53, 18, "Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum. In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.", 226, 347)]
        public void BuildCommentTestPositive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond, string expectedText, int expectedPostId, int expectedUserId)
        {
            //prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);

            //Act
            Comment actualComment = modelBuilder.BuildComment<Comment>(expectedId);
            int actualId = actualComment.Id;
            DateTime actualDateCreated = actualComment.DateCreated;
            string actualText = actualComment.Text;
            int actualPostId = actualComment.PostId;
            int actualUserId = actualComment.UserId;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualText, "text");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
        }

        #region AssertAreEqualWithMsg methods

        public void AssertAreEqualWithMsg(string expected, string actual, string name)
        {
            string msg = "expected " + name + " was: " + expected +
                         ". Actual " + name + " is: " + actual;
            Assert.AreEqual(expected, actual, msg);
        }

        public void AssertAreEqualWithMsg(int expected, int actual, string name)
        {
            string msg = "expected " + name + " was: " + expected +
                         ". Actual " + name + " is: " + actual;
            Assert.AreEqual(expected, actual, msg);
        }

        public void AssertAreEqualWithMsg(bool expected, bool actual, string name)
        {
            string msg = "expected " + name + " was: " + expected +
                         ". Actual " + name + " is: " + actual;
            Assert.AreEqual(expected, actual, msg);
        }
        public void AssertAreEqualWithMsg(DateTime expected, DateTime actual, string name)
        {
            int expectedYear = expected.Year;
            int expectedMonth = expected.Month;
            int expectedDay = expected.Day;
            int expectedHour = expected.Hour;
            int expectedMinute = expected.Minute;
            int expectedSecond = expected.Second;

            int actualYear = actual.Year;
            int actualMonth = actual.Month;
            int actualDay = actual.Day;
            int actualHour = actual.Hour;
            int actualMinute = actual.Minute;
            int actualSecond = actual.Second;

            AssertAreEqualWithMsg(expectedYear, actualYear, "year");
            AssertAreEqualWithMsg(expectedMonth, actualMonth, "month");
            AssertAreEqualWithMsg(expectedDay, actualDay, "day");
            AssertAreEqualWithMsg(expectedHour, actualHour, "hour");
            AssertAreEqualWithMsg(expectedMinute, actualMinute, "minute");
            AssertAreEqualWithMsg(expectedSecond, actualSecond, "second");
        }
        #endregion

        #region AssertAreNotEqualWithMsg methods
        public void AssertAreNotEqualWithMsg(string expected, string actual, string name)
        {
            string msg = "expected " + name + " was: " + expected +
                         ". Actual " + name + " is: " + actual;
            Assert.AreEqual(expected, actual, msg);
        }

        public void AssertAreNotEqualWithMsg(int expected, int actual, string name)
        {
            string msg = "expected " + name + " was: " + expected +
                         ". Actual " + name + " is: " + actual;
            Assert.AreEqual(expected, actual, msg);
        }

        public void AssertAreNotEqualWithMsg(bool expected, bool actual, string name)
        {
            string msg = "expected " + name + " was: " + expected +
                         ". Actual " + name + " is: " + actual;
            Assert.AreEqual(expected, actual, msg);
        }
        
        public void AssertAreNotEqualWithMsg(DateTime expected, DateTime actual, string name)
        {
            int expectedYear = expected.Year;
            int expectedMonth = expected.Month;
            int expectedDay = expected.Day;
            int expectedHour = expected.Hour;
            int expectedMinute = expected.Minute;
            int expectedSecond = expected.Second;

            int actualYear = actual.Year;
            int actualMonth = actual.Month;
            int actualDay = actual.Day;
            int actualHour = actual.Hour;
            int actualMinute = actual.Minute;
            int actualSecond = actual.Second;

            AssertAreNotEqualWithMsg(expectedYear, actualYear, "year");
            AssertAreNotEqualWithMsg(expectedMonth, actualMonth, "month");
            AssertAreNotEqualWithMsg(expectedDay, actualDay, "day");
            AssertAreNotEqualWithMsg(expectedHour, actualHour, "hour");
            AssertAreNotEqualWithMsg(expectedMinute, actualMinute, "minute");
            AssertAreNotEqualWithMsg(expectedSecond, actualSecond, "second");
        }
        #endregion
    }
}
