using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccesLayer.ModelBuilds;
using SolvrLibrary;

namespace Solvr.Test.DataAccesLayer
{
    /// <summary>
    /// This TestClass is for testing all the methods in the ModelBuilder.
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
        [DataRow(1, "philosophy")]
        [DataRow(736, "soup")]
        [DataRow(3, "tree")]
        [DataRow(1000, "test")]
        public void BuildCategoryTestPositive(int expectedId, string expectedName)
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
        //Testing title, right one is "philosophy"
        [DataRow(1, "philosophy ")]
        //Testing title, right one is "soup".
        [DataRow(736, "soup£")]
        //Testing -1 to id.
        [DataRow(2, "tree")]
        //Testing +1 to id.
        [DataRow(1001, "test")]
        public void BuildCategoryTestNegative(int expectedId, string expectedName)
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
            AssertAreNotEqualWithMsg(expectedName, actualName, "name");

            if (expectedId != 1 || expectedId != 736)
            {
                AssertAreNotEqualWithMsg(expectedId, actualId, "id");
            }
        }

        [TestMethod]
        [DataRow(1, "Berte Chason", "bchason0@theglobeandmail.com", "ehinrichsen0", "uvLWXF", false, 2028, 06, 30, 15, 07, 52)]
        [DataRow(573, "Leona Crock", "lcrockfw@altervista.org", "gupstellfw", "GA27D5lL", false, 2033, 05, 16, 19, 25, 39)]
        [DataRow(1000, "Brigitta Munt", "bmuntrr@cmu.edu", "bguagerr", "L22rm38Aoxn0", false, 2034, 09, 29, 06, 31, 09)]
        public void BuildUserTestPostive(int expectedId, string expectedName, string expectedEmail, string expectedUsername,
                                         string expectedPassword, Boolean expectedIsAdmin, int expectedYear, int expectedMonth, 
                                         int expectedDay, int expectedHour, int expectedMinutes, int expectedSeconds)
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
        //Testing +1 to id.
        [DataRow(2, "Berte Chason", "bchason0@theglobeandmail.com", "ehinrichsen0", "uvLWXF", false, 2028, 06, 30, 15, 07, 52)]
        //Testing -1 to id.
        [DataRow(0, "Berte Chason", "bchason0@theglobeandmail.com", "ehinrichsen0", "uvLWXF", false, 2028, 06, 30, 15, 07, 52)]
        //Testing +1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(573, "Leona Croc", "Lcrockfw@altervista.org", "Gupstellfw", "gA27D5lL", true, 2034, 06, 17, 20, 26, 40)]
        //Testing -1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(573, "Leona Croc", "Lcrockfw@altervista.org", "Gupstellfw", "gA27D5lL", true, 2032, 04, 15, 18, 24, 38)]
        //Testing +1 to id.
        [DataRow(1001, "Brigitta Munt", "bmuntrr@cmu.edu", "bguagerr", "L22rm38Aoxn0", false, 2034, 09, 29, 06, 31, 09)]
        //Testing -1 to id.
        [DataRow(999, "Brigitta Munt", "bmuntrr@cmu.edu", "bguagerr", "L22rm38Aoxn0", false, 2034, 09, 29, 06, 31, 09)]
        public void BuildUserTestNegative(int expectedId, string expectedName, string expectedEmail, string expectedUsername,
                                         string expectedPassword, Boolean expectedIsAdmin, int expectedYear, int expectedMonth,
                                         int expectedDay, int expectedHour, int expectedMinutes, int expectedSeconds)
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
            if (expectedId != 0 || expectedId != 2 || expectedId != 1001 || expectedId != 999)
            {
                AssertAreNotEqualWithMsg(expectedId, actualId, "id");
            }
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
        public void BuildPostTestPositive(int expectedId, string expectedTitle, string expectedDescription, int expectedDateCreatedYear, 
                                          int expectedDateCreatedMonth, int expectedDateCreatedDay, int expectedDateCreatedHour, 
                                          int expectedDateCreatedMinutes, int expectedDateCreatedSeconds, int expectedBumpTimeYear, 
                                          int expectedBumpTimeMonth, int expectedBumpTimeDay, int expectedBumpTimeHour, 
                                          int expectedBumpTimeMinute, int expectedBumpTimeSecond, int expectedCategoryId, int expectedUserId)
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
        //Testing -1 to id.
        [DataRow(0, "JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 103, 504)]
        //Testing +1 to id.
        [DataRow(2, "JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 103, 504)]
        //Testing -1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(439, "OASGold", "Etiamjusto. Etiam<pretium iaculis justo. In hac habitasse platea dictumst.", 2020, 06, 24, 01, 46, 32, 2030, 06, 24, 01, 46, 32, 21, 186)]
        //Testing +1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(421, "Osa Gold", "etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst.", 2021, 07, 25, 02, 47, 33, 2021, 07, 25, 02, 47, 33, 22, 187)]
        //Testing -1 to id.
        [DataRow(499, "Zero Waste", "Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.", 2030, 09, 01, 18, 00, 38, 2030, 09, 01, 18, 00, 38, 721, 109)]
        //Testing +1 to id.
        [DataRow(501, "Zero Waste", "Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.", 2030, 09, 01, 18, 00, 38, 2030, 09, 01, 18, 00, 38, 721, 109)]
        public void BuildPostTestNegative(int expectedId, string expectedTitle, int expectedDateCreatedYear, 
                                          int expectedDateCreatedMonth, int expectedDateCreatedDay, int expectedDateCreatedHour, 
                                          int expectedDateCreatedMinutes, int expectedDateCreatedSeconds, int expectedBumpTimeYear, 
                                          int expectedBumpTimeMonth, int expectedBumpTimeDay, int expectedBumpTimeHour, 
                                          int expectedBumpTimeMinute, int expectedBumpTimeSecond, int expectedCategoryId, 
                                          string expectedDescription, int expectedUserId)
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
            if (expectedId != 439 || expectedId != 421)
            {
                AssertAreNotEqualWithMsg(expectedId, actualId, "id");
            }
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
        public void BuildCommentTestPositive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth, 
                                             int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute, 
                                             int expectedDateCreatedSecond, string expectedText, int expectedPostId, int expectedUserId)
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

        [TestMethod]
        //Testing -1 to id.
        [DataRow(0, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum.Curabitur in libero ut massa volutpat convallis.", 714, 16)]
        //Testing +1 to id.
        [DataRow(2, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum.Curabitur in libero ut massa volutpat convallis.", 714, 16)]
        //Testing -1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(350, 2034, 04, 04, 20, 26, 24, "mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam.", 64, 824)]
        //Testing +1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(350, 2037, 07, 07, 23, 29, 26, "mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam.", 66, 826)]
        //Testing -1 to id.
        [DataRow(499, 2020, 09, 11, 14, 53, 18, "Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum. In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.", 226, 347)]
        //Testing +1 to id.
        [DataRow(501, 2020, 09, 11, 14, 53, 18, "Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum. In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.", 226, 347)]
        public void BuildCommentTestNegative(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth, 
                                             int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute, 
                                             int expectedDateCreatedSecond, string expectedText, int expectedPostId, int expectedUserId)
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
            if (expectedId != 350)
            {
                AssertAreNotEqualWithMsg(expectedId, actualId, "id");
            }
            AssertAreNotEqualWithMsg(expectedId, actualId, "id");
            AssertAreNotEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreNotEqualWithMsg(expectedText, actualText, "text");
            AssertAreNotEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreNotEqualWithMsg(expectedUserId, actualUserId, "userId");
        }

        [TestMethod]
        [DataRow(1, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 52, 892, 2019, 06, 15, 15, 02, 42, false)]
        [DataRow(404, 2033, 10, 02, 00, 25, 04, "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius.", 454, 307, 2028, 02, 19, 14, 54, 22, true)]
        [DataRow(500, 2029, 12, 13, 10, 22, 24, "In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.", 627, 852, 2036, 02, 22, 05, 49, 38, true)]
        public void BuildSolvrCommentTestPositive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth, 
                                                  int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute, 
                                                  int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId, 
                                                  int expectedTimeAcceptedYear, int expectedTimeAcceptedMonth, int expectedTimeAcceptedDay, 
                                                  int expectedTimeAcceptedHour, int expectedTimeAcceptedMinute, int expectedTimeAcceptedSecond, 
                                                  Boolean expectedIsAccepte)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime ExpectedTimeAccepted = new DateTime(expectedTimeAcceptedYear, expectedTimeAcceptedMonth, expectedTimeAcceptedDay, expectedTimeAcceptedHour, expectedTimeAcceptedMinute, expectedTimeAcceptedSecond);


            //Act
            SolvrComment actualSolvrComment = modelBuilder.BuildComment<SolvrComment>(expectedId);
            int actualId = actualSolvrComment.Id;
            DateTime actualDateCreated = actualSolvrComment.DateCreated;
            string actualText = actualSolvrComment.Text;
            int actualPostId = actualSolvrComment.PostId;
            int actualUserId = actualSolvrComment.UserId;
            bool actualIsAccepted = actualSolvrComment.IsAccepted;
            DateTime actualTimeAccepted = actualSolvrComment.TimeAccepted;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualText, "text");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedIsAccepte, actualIsAccepted, "isAccepted");
            AssertAreEqualWithMsg(ExpectedTimeAccepted, actualTimeAccepted, "timeAccepted");
        }

        [TestMethod]
        //Wrong id, right one is 1
        [DataRow(502, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 52, 892, 2019, 06, 15, 15, 02, 42, false)]
        //Wrong text, right one starts with capitalized v
        [DataRow(404, 2033, 10, 02, 00, 25, 04, "vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius.", 454, 307, 2028, 02, 19, 14, 54, 22, false)]
        //wrong isAccepted, right one is true 
        [DataRow(500, 2029, 12, 13, 10, 22, 24, "In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.", 627, 852, 2036, 02, 22, 05, 49, 38, true)]
        public void BuildSolvrCommentTestNegative(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth, 
                                                  int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute, 
                                                  int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId,
                                                  int expectedTimeAcceptedYear, int expectedTimeAcceptedMonth, int expectedTimeAcceptedDay, 
                                                  int expectedTimeAcceptedHour, int expectedTimeAcceptedMinute, int expectedTimeAcceptedSecond, 
                                                  Boolean expectedIsAccepte)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime ExpectedTimeAccepted = new DateTime(expectedTimeAcceptedYear, expectedTimeAcceptedMonth, expectedTimeAcceptedDay, expectedTimeAcceptedHour, expectedTimeAcceptedMinute, expectedTimeAcceptedSecond);


            //Act
            SolvrComment actualSolvrComment = modelBuilder.BuildComment<SolvrComment>(expectedId);
            int actualId = actualSolvrComment.Id;
            DateTime actualDateCreated = actualSolvrComment.DateCreated;
            string actualText = actualSolvrComment.Text;
            int actualPostId = actualSolvrComment.PostId;
            int actualUserId = actualSolvrComment.UserId;
            bool actualIsAccepted = actualSolvrComment.IsAccepted;
            DateTime actualTimeAccepted = actualSolvrComment.TimeAccepted;

            //Assert
            AssertAreNotEqualWithMsg(expectedId, actualId, "id");
            AssertAreNotEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreNotEqualWithMsg(expectedText, actualText, "text");
            AssertAreNotEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreNotEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreNotEqualWithMsg(expectedIsAccepte, actualIsAccepted, "isAccepted");
            AssertAreNotEqualWithMsg(ExpectedTimeAccepted, actualTimeAccepted, "timeAccepted");
        }

        [TestMethod]
        [DataRow(1, false, 275, 70)]
        [DataRow(509, true, 155, 766)]
        [DataRow(1000, false, 47, 540)]
        public void BuildVoteTestPosetive(int expectedId, bool expectedIsUpvoted, int expectedUserId, int expecteCommentId)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();

            //Act
            Vote actualVote = modelBuilder.BuildVote(expectedId);
            int actualId = actualVote.Id;
            bool actualIsUpvoted = actualVote.IsUpvoted;
            int actualUserId = actualVote.UserId;
            int actualCommentId = actualVote.CommentId;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedIsUpvoted, actualIsUpvoted, "isUpvoted");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expecteCommentId, actualCommentId, "commentId");
        }

        [TestMethod]
        [DataRow(2, false, 275, 70)]        //Testing +1 to id.
        [DataRow(0, false, 275, 70)]        //Testing -1 to id.
        [DataRow(509, false, 156, 767)]     //Testing +1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(509, false, 154, 764)]     //Testing -1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(1001, false, 47, 540)]     //Testing +1 to id.
        [DataRow(999, false, 47, 540)]      //Testing -1 to id.
        public void BuildVoteTestNegative(int expectedId, bool expectedIsUpvoted, int expectedUserId, int expecteCommentId)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();

            //Act
            Vote actualVote = modelBuilder.BuildVote(expectedId);
            int actualId = actualVote.Id;
            bool actualIsUpvoted = actualVote.IsUpvoted;
            int actualUserId = actualVote.UserId;
            int actualCommentId = actualVote.CommentId;

            //Assert
            if (expectedId != 509)
            {
                AssertAreEqualWithMsg(expectedId, actualId, "id");
            }
            AssertAreNotEqualWithMsg(expectedIsUpvoted, actualIsUpvoted, "isUpvoted");
            AssertAreNotEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreNotEqualWithMsg(expecteCommentId, actualCommentId, "commentId");
        }

        [TestMethod]
        [DataRow(1, "Print On Demand", "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit.|2025, 09, 26, 11, 56, 51|2025, 09, 26, 11, 56, 51|451|535|false|Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.", 2025, 09, 26, 11, 56, 51, 2025, 09, 26, 11, 56, 51, 451, 535, false, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.", 555, "atvej 15")]
        [DataRow(362, "Nunc rhoncus dui vel sem. Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.", 2028, 04, 10, 13, 58, 10, 2028, 04, 10, 13, 58, 10, 639, 10, false, "Nunc rhoncus dui vel sem. Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.", 2858, "antevej 748")]
        [DataRow(500, "Sports Coaching", "Aenean lectus.", 2028, 01, 02, 08, 56, 40, 2028, 01, 02, 08, 56, 40, 658, 875, true, "Etiam vel augue.Vestibulum rutrum rutrum neque.", 8401, "accumsanvej 80")]
        public void BuildPhysicalPostTestPositive(int expectedId, string expectedTitle, string expectedDescription,
                                                  int expectedBumpTimeYear, int expectedBumpTimeMonth, int expectedBumpTimeDay,
                                                  int expectedBumpTimeHour, int expectedBumpTimeMinute, int expectedBumpTimeSecond,
                                                  int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                                  int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                                  int expectedCategoryId, int expectedUserId, string expectePostType, bool expectedIsLocked,
                                                  string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedBumpTime = new DateTime(expectedBumpTimeYear, expectedBumpTimeMonth, expectedBumpTimeDay, expectedBumpTimeHour, expectedBumpTimeMinute, expectedBumpTimeSecond);

            //Act
            PhysicalPost actualPhysicalPost = modelBuilder.BuildPost<PhysicalPost>(expectedId);
            int actualId = actualPhysicalPost.Id;
            string actualTitle = actualPhysicalPost.Title;
            string actualDescription = actualPhysicalPost.Description;
            DateTime actualBumpTime = actualPhysicalPost.BumpTime;
            DateTime actualDateCreated = actualPhysicalPost.DateCreated;
            int actualCategoryId = actualPhysicalPost.CategoryId;
            int actualUserId = actualPhysicalPost.UserId;
            string actualPostType = actualPhysicalPost.PostType;
            bool actualIsLocked = actualPhysicalPost.IsLocked;
            string actualAltDescription = actualPhysicalPost.Description;
            string actualZipcode = actualPhysicalPost.Zipcode;
            string actualAdress = actualPhysicalPost.Address;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedBumpTime, actualBumpTime, "bumpTime");
            AssertAreEqualWithMsg(expectedCategoryId, actualCategoryId, "categoryId");
            AssertAreEqualWithMsg(expectedDescription, actualDescription, "description");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectePostType, actualPostType, "postType");
            AssertAreEqualWithMsg(expectedIsLocked, actualIsLocked, "isLocke");
            AssertAreEqualWithMsg(expectedDescription, actualDescription, "description");
            AssertAreEqualWithMsg(expectedZipcode, actualZipcode, "zipcode");
            AssertAreEqualWithMsg(expectedAddress, actualAdress, "address");
        }

        [TestMethod]
        //Testing -1 to id.
        [DataRow(0, "Print On Demand", "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit.|2025, 09, 26, 11, 56, 51|2025, 09, 26, 11, 56, 51|451|535|false|Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.", 2025, 09, 26, 11, 56, 51, 2025, 09, 26, 11, 56, 51, 451, 535, false, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.", 555, "atvej 15")]
        //Testing +1 to id.
        [DataRow(2, "Print On Demand", "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit.|2025, 09, 26, 11, 56, 51|2025, 09, 26, 11, 56, 51|451|535|false|Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.", 2025, 09, 26, 11, 56, 51, 2025, 09, 26, 11, 56, 51, 451, 535, false, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.", 555, "atvej 15")]
        //Testing +1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(362, "Nunc rhoncus dui vel sem. Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus", 2028, 04, 10, 13, 58, 10, 2028, 04, 10, 13, 58, 10, 639, 10, false, "Nunc rhoncus dui vel sem. Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus", 2858, "antevej748")]
        //Testing -1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(362, "nunc rhoncus dui vel sem. Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.", 2028, 04, 10, 13, 58, 10, 2028, 04, 10, 13, 58, 10, 639, 10, false, "nunc rhoncus dui vel sem. Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus", 2858, "Antevej 748")]
        //Testing +1 to id.
        [DataRow(501, "Sports Coaching", "Aenean lectus.", 2028, 01, 02, 08, 56, 40, 2028, 01, 02, 08, 56, 40, 658, 875, true, "Etiam vel augue.Vestibulum rutrum rutrum neque.", 8401, "accumsanvej 80")]
        //Testing -1 to id.
        [DataRow(499, "Sports Coaching", "Aenean lectus.", 2028, 01, 02, 08, 56, 40, 2028, 01, 02, 08, 56, 40, 658, 875, true, "Etiam vel augue.Vestibulum rutrum rutrum neque.", 8401, "accumsanvej 80")]
        public void BuildPhysicalPostTestNegative(int expectedId, string expectedTitle, string expectedDescription,
                                                  int expectedBumpTimeYear, int expectedBumpTimeMonth, int expectedBumpTimeDay,
                                                  int expectedBumpTimeHour, int expectedBumpTimeMinute, int expectedBumpTimeSecond,
                                                  int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                                  int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                                  int expectedCategoryId, int expectedUserId, string expectePostType, bool expectedIsLocked,
                                                  string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedBumpTime = new DateTime(expectedBumpTimeYear, expectedBumpTimeMonth, expectedBumpTimeDay, expectedBumpTimeHour, expectedBumpTimeMinute, expectedBumpTimeSecond);


            //Act
            PhysicalPost actualPhysicalPost = modelBuilder.BuildPost<PhysicalPost>(expectedId);
            int actualId = actualPhysicalPost.Id;
            string actualTitle = actualPhysicalPost.Title;
            string actualDescription = actualPhysicalPost.Description;
            DateTime actualBumpTime = actualPhysicalPost.BumpTime;
            DateTime actualDateCreated = actualPhysicalPost.DateCreated;
            int actualCategoryId = actualPhysicalPost.CategoryId;
            int actualUserId = actualPhysicalPost.UserId;
            string actualPostType = actualPhysicalPost.PostType;
            bool actualIsLocked = actualPhysicalPost.IsLocked;
            string actualAltDescription = actualPhysicalPost.Description;
            string actualZipcode = actualPhysicalPost.Zipcode;
            string actualAdress = actualPhysicalPost.Address;

            //Assert
            if (expectedId != 362)
            {
                AssertAreNotEqualWithMsg(expectedId, actualId, "id");
            }
            AssertAreNotEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreNotEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreNotEqualWithMsg(expectedBumpTime, actualBumpTime, "bumpTime");
            AssertAreNotEqualWithMsg(expectedCategoryId, actualCategoryId, "categoryId");
            AssertAreNotEqualWithMsg(expectedDescription, actualDescription, "description");
            AssertAreNotEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreNotEqualWithMsg(expectePostType, actualPostType, "postType");
            AssertAreNotEqualWithMsg(expectedIsLocked, actualIsLocked, "isLocke");
            AssertAreNotEqualWithMsg(expectedDescription, actualDescription, "description");
            AssertAreNotEqualWithMsg(expectedZipcode, actualZipcode, "zipcode");
            AssertAreNotEqualWithMsg(expectedAddress, actualAdress, "address");
        }

        [TestMethod]
        [DataRow(1, "massa tempor convallis nulla neque", "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.", 2019, 07, 24, 21, 48, 58, 337, 831, 158)]
        [DataRow(847, "eget rutrum", "Aenean fermentum.", 2036, 12, 10, 15, 23, 35, 946, 14, 765)]
        [DataRow(1000, "ullamcorper augue a suscipit nulla", "Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.", 2030, 02, 07, 17, 12, 05, 928, 778, 958)]
        public void BuildReportTestPositive(int expectedId, string expectedTitle, string expectedDescription,
                                            int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                            int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                            int expectedUserId, int expectedCommentId, int expectedPostId, string expectedReportType)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);

            //Act
            Report actualReport = modelBuilder.BuildReport(expectedId);
            int actualId = actualReport.Id;
            string actualTitle = actualReport.Title;
            string actualDesription = actualReport.Description;
            DateTime actualDateCreated = actualReport.DateCreated;
            int actualUserId = actualReport.UserId;
            int actualCommentId = actualReport.CommentId;
            int actualPostId = actualReport.PostId;
            string actualReportType = actualReport.ReportType;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreEqualWithMsg(expectedDescription, actualDesription, "description");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualCommentId, "commentId");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedReportType, actualReportType, "reportType");
        }

        [TestMethod]
        //Testing -1 to id.
        [DataRow(0, "massa tempor convallis nulla neque", "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.", 2019, 07, 24, 21, 48, 58, 337, 831, 158)]
        //Testing +1 to id.
        [DataRow(2, "massa tempor convallis nulla neque", "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.", 2019, 07, 24, 21, 48, 58, 337, 831, 158)]
        //Testing -1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(847, "egetrutrum", "Aeneanfermentum.", 2035, 11, 9, 14, 22, 34, 945, 13, 764)]
        //Testing +1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(847, "eget rutrum ", "Aenean fermentum. ", 2037, 13, 11, 16, 24, 36, 947, 15, 766)]
        //Testing -1 to id.
        [DataRow(999, "ullamcorper augue a suscipit nulla", "Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.", 2030, 02, 07, 17, 12, 05, 928, 778, 958)]
        //Testing +1 to id.
        [DataRow(1001, "ullamcorper augue a suscipit nulla", "Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.", 2030, 02, 07, 17, 12, 05, 928, 778, 958)]
        public void BuildReportTestNegative(int expectedId, string expectedTitle, string expectedDescription,
                                            int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                            int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                            int expectedUserId, int expectedCommentId, int expectedPostId, string expectedReportType)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);

            //Act
            Report actualReport = modelBuilder.BuildReport(expectedId);
            int actualId = actualReport.Id;
            string actualTitle = actualReport.Title;
            string actualDesription = actualReport.Description;
            DateTime actualDateCreated = actualReport.DateCreated;
            int actualUserId = actualReport.UserId;
            int actualCommentId = actualReport.CommentId;
            int actualPostId = actualReport.PostId;
            string actualReportType = actualReport.ReportType;

            //Assert
            if (expectedId != 847)
                {
                    AssertAreNotEqualWithMsg(expectedId, actualId, "id");
                }
            AssertAreNotEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreNotEqualWithMsg(expectedDescription, actualDesription, "description");
            AssertAreNotEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreNotEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreNotEqualWithMsg(expectedCommentId, actualCommentId, "commentId");
            AssertAreNotEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreNotEqualWithMsg(expectedReportType, actualReportType, "reportType");
        }

        [TestMethod]
        [DataRow(1, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum.Curabitur in libero ut massa volutpat convallis.", 714, 16, 142, "Etiam pretium iaculis justo.In hac habitasse platea dictumst.Etiam faucibus cursus urna.Ut tellus.Nulla ut erat id mauris vulputate elementum.Nullam varius.Nulla facilisi.", 714, 166)]
        [DataRow(350, 2036, 05, 05, 21, 27, 25, "Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam.", 65, 825)]
        [DataRow(500, 2020, 09, 11, 14, 53, 18, "Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum. In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.", 226, 347)]
        public void BuildCommentListTestPositive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                                 int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                                 int expectedDateCreatedSecond, string expectedText, int expectedPostId, int expectedUserId,
                                                 int expectedId2, int expectedDateCreatedYear2, int expectedDateCreatedMonth2,
                                                 int expectedDateCreatedDay2, int expectedDateCreatedHour2, int expectedDateCreatedMinute2,
                                                 int expectedDateCreatedSecond2, string expectedText2, int expectedPostId2, int expectedUserId2)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedDateCreated2 = new DateTime(expectedDateCreatedYear2, expectedDateCreatedMonth2, expectedDateCreatedDay2, expectedDateCreatedHour2, expectedDateCreatedMinute2, expectedDateCreatedSecond2);
            Post post = modelBuilder.BuildPost<Post>(expectedPostId);
        
            //Act
            List <Comment> actualComments = post.Comments;
            Comment actualComment = actualComments[0];
            int actualId = actualComment.Id;
            DateTime actualDateCreated = actualComment.DateCreated;
            string actualText = actualComment.Text;
            int actualPostId = actualComment.PostId;
            int actualUserId = actualComment.UserId;

            if (expectedText2 != null)
            {
                //Act
                Comment actualComment2 = actualComments[1];
                int actualId2 = actualComment2.Id;
                DateTime actualDateCreated2 = actualComment2.DateCreated;
                string actualText2 = actualComment2.Text;
                int actualPostId2 = actualComment2.PostId;
                int actualUserId2 = actualComment2.UserId;

                //Assert
                AssertAreEqualWithMsg(expectedId2, actualId2, "id");
                AssertAreEqualWithMsg(expectedDateCreated2, actualDateCreated2, "dateCreated");
                AssertAreEqualWithMsg(expectedText2, actualText2, "text");
                AssertAreEqualWithMsg(expectedPostId2, actualPostId2, "postId");
                AssertAreEqualWithMsg(expectedUserId2, actualUserId2, "userId");
            }

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualText, "text");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
        }


        [TestMethod]
        //Testing -1 to id
        [DataRow(0, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum.Curabitur in libero ut massa volutpat convallis.", 714, 16, 142, "Etiam pretium iaculis justo.In hac habitasse platea dictumst.Etiam faucibus cursus urna.Ut tellus.Nulla ut erat id mauris vulputate elementum.Nullam varius.Nulla facilisi.", 714, 166)]
        //Testing +1 to id
        [DataRow(2, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum.Curabitur in libero ut massa volutpat convallis.", 714, 16, 142, "Etiam pretium iaculis justo.In hac habitasse platea dictumst.Etiam faucibus cursus urna.Ut tellus.Nulla ut erat id mauris vulputate elementum.Nullam varius.Nulla facilisi.", 714, 166)]
        //Testing -1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(350, 2035, 04, 04, 20, 26, 24, "mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam.", 64, 824)]
        //Testing +1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(350, 2037, 06, 06, 22, 28, 26, "mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam", 66, 826)]
        //Testing -1 to id
        [DataRow(499, 2020, 09, 11, 14, 53, 18, "Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum. In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.", 226, 347)]
        //Testing +1 to id
        [DataRow(501, 2020, 09, 11, 14, 53, 18, "Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum. In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo. Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.", 226, 347)]
        public void BuildCommentListTestNegative(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                                 int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                                 int expectedDateCreatedSecond, string expectedText, int expectedPostId, int expectedUserId,
                                                 int expectedId2, int expectedDateCreatedYear2, int expectedDateCreatedMonth2,
                                                 int expectedDateCreatedDay2, int expectedDateCreatedHour2, int expectedDateCreatedMinute2,
                                                 int expectedDateCreatedSecond2, string expectedText2, int expectedPostId2, int expectedUserId2)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedDateCreated2 = new DateTime(expectedDateCreatedYear2, expectedDateCreatedMonth2, expectedDateCreatedDay2, expectedDateCreatedHour2, expectedDateCreatedMinute2, expectedDateCreatedSecond2);
            Post post = modelBuilder.BuildPost<Post>(expectedPostId);

            //Act
            List<Comment> actualComments = post.Comments;
            Comment actualComment = actualComments[0];
            int actualId = actualComment.Id;
            DateTime actualDateCreated = actualComment.DateCreated;
            string actualText = actualComment.Text;
            int actualPostId = actualComment.PostId;
            int actualUserId = actualComment.UserId;

            if (expectedText2 != null)
            {
                //Act
                Comment actualComment2 = actualComments[1];
                int actualId2 = actualComment2.Id;
                DateTime actualDateCreated2 = actualComment2.DateCreated;
                string actualText2 = actualComment2.Text;
                int actualPostId2 = actualComment2.PostId;
                int actualUserId2 = actualComment2.UserId;

                //Assert
                if (expectedId != 350)
                {
                    AssertAreEqualWithMsg(expectedId2, actualId2, "id");
                }
                AssertAreEqualWithMsg(expectedDateCreated2, actualDateCreated2, "dateCreated");
                AssertAreEqualWithMsg(expectedText2, actualText2, "text");
                AssertAreEqualWithMsg(expectedPostId2, actualPostId2, "postId");
                AssertAreEqualWithMsg(expectedUserId2, actualUserId2, "userId");
            }

            //Assert
            if (expectedId != 350)
            {
                AssertAreEqualWithMsg(expectedId, actualId, "id");
            }
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualText, "text");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
        }

        [TestMethod]
        [DataRow(1, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 52, 892, 2019, 06, 15, 15, 02, 42, false, 113, 2022, 02, 19, 01, 24, 45, "Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi.", 635, 892, 2025, 07, 12, 17, 24, 45, true)]
        [DataRow(404, 2033, 10, 02, 00, 25, 04, "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius.", 454, 307, 2028, 02, 19, 14, 54, 22, true)]
        [DataRow(500, 2029, 12, 13, 10, 22, 24, "In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.", 627, 852, 2036, 02, 22, 05, 49, 38, true, 2035, 12, 22, 00, 47, 51, "Nulla justo.Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros.Suspendisse accumsan tortor quis turpis.Sed ante.Vivamus tortor.Duis mattis egestas metus.Aenean fermentum.Donec ut mauris eget massa tempor convallis.", 875, 852, 2025, 03, 10, 02, 16, 23, true)]
        public void BuildSolvrCommentListTestPositive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                                      int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                                      int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId,
                                                      int expectedTimeAcceptedYear, int expectedTimeAcceptedMonth, int expectedTimeAcceptedDay,
                                                      int expectedTimeAcceptedHour, int expectedTimeAcceptedMinute, int expectedTimeAcceptedSecond,
                                                      Boolean expectedIsAccepted, int expectedId2, int expectedDateCreatedYear2, int expectedDateCreatedMonth2,
                                                      int expectedDateCreatedDay2, int expectedDateCreatedHour2, int expectedDateCreatedMinute2,
                                                      int expectedDateCreatedSecond2, string expectedText2, int expectedUserId2, int expectedPostId2,
                                                      int expectedTimeAcceptedYear2, int expectedTimeAcceptedMonth2, int expectedTimeAcceptedDay2,
                                                      int expectedTimeAcceptedHour2, int expectedTimeAcceptedMinute2, int expectedTimeAcceptedSecond2,
                                                      Boolean expectedIsAccepted2)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedTimeAccepted = new DateTime(expectedTimeAcceptedYear, expectedTimeAcceptedMonth, expectedTimeAcceptedDay, expectedTimeAcceptedHour, expectedTimeAcceptedMinute, expectedTimeAcceptedSecond);
            DateTime expectedDateCreated2 = new DateTime(expectedDateCreatedYear2, expectedDateCreatedMonth2, expectedDateCreatedDay2, expectedDateCreatedHour2, expectedDateCreatedMinute2, expectedDateCreatedSecond2);
            DateTime expectedTimeAccepted2 = new DateTime(expectedTimeAcceptedYear2, expectedTimeAcceptedMonth2, expectedTimeAcceptedDay2, expectedTimeAcceptedHour2, expectedTimeAcceptedMinute2, expectedTimeAcceptedSecond2);
            Post post = modelBuilder.BuildPost<Post>(expectedPostId);

            //Act
            List<Comment> actualComments = post.Comments;
            SolvrComment actualSolvrComment = (SolvrComment)actualComments[0];
            int actualId = actualSolvrComment.Id;
            DateTime actualDateCreated = actualSolvrComment.DateCreated;
            string actualText = actualSolvrComment.Text;
            int actualPostId = actualSolvrComment.PostId;
            int actualUserId = actualSolvrComment.UserId;
            bool actualIsAccepted = actualSolvrComment.IsAccepted;
            DateTime actualTimeAccepted = actualSolvrComment.TimeAccepted;

            if (expectedText2 != null)
            {
                //Act
                SolvrComment actualSolvrComment2 = (SolvrComment)actualComments[1];
                int actualId2 = actualSolvrComment.Id;
                DateTime actualDateCreated2 = actualSolvrComment2.DateCreated;
                string actualText2 = actualSolvrComment2.Text;
                int actualPostId2 = actualSolvrComment2.PostId;
                int actualUserId2 = actualSolvrComment2.UserId;
                bool actualIsAccepted2 = actualSolvrComment2.IsAccepted;
                DateTime actualTimeAccepted2 = actualSolvrComment2.TimeAccepted;

                //Assert
                AssertAreEqualWithMsg(expectedId2, actualId2, "id");
                AssertAreEqualWithMsg(expectedDateCreated2, actualDateCreated2, "dateCreated");
                AssertAreEqualWithMsg(expectedText2, actualText2, "text");
                AssertAreEqualWithMsg(expectedPostId2, actualPostId2, "postId");
                AssertAreEqualWithMsg(expectedUserId2, actualUserId2, "userId");
                AssertAreEqualWithMsg(expectedIsAccepted2, actualIsAccepted2, "isAccepted");
                AssertAreEqualWithMsg(expectedTimeAccepted2, actualTimeAccepted2, "timeAccepted");
            }

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualText, "text");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedIsAccepted, actualIsAccepted, "isAccepted");
            AssertAreEqualWithMsg(expectedTimeAccepted, actualTimeAccepted, "timeAccepted");
        }

        [TestMethod]
        //Testing -1 to id
        [DataRow(0, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 52, 892, 2019, 06, 15, 15, 02, 42, false, 113, 2022, 02, 19, 01, 24, 45, "Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi.", 635, 892, 2025, 07, 12, 17, 24, 45, true)]
        //Testing +1 to id
        [DataRow(1, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 52, 892, 2019, 06, 15, 15, 02, 42, false, 113, 2022, 02, 19, 01, 24, 45, "Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi.", 635, 892, 2025, 07, 12, 17, 24, 45, true)]

        //Testing -1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(404, 2032, 9, 01, -1, 24, 03, "vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius.", 453, 306, 2027, 01, 18, 13, 53, 21, false)]
        //Testing +1 to all values, except id. Also changed the strings and flipped the bool.
        [DataRow(404, 2034, 11, 03, 01, 26, 05, "vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius.", 455, 308, 2029, 03, 20, 15, 55, 23, false)]
        //Testing -1 to id
        [DataRow(499, 2029, 12, 13, 10, 22, 24, "In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.", 627, 852, 2036, 02, 22, 05, 49, 38, true, 2035, 12, 22, 00, 47, 51, "Nulla justo.Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros.Suspendisse accumsan tortor quis turpis.Sed ante.Vivamus tortor.Duis mattis egestas metus.Aenean fermentum.Donec ut mauris eget massa tempor convallis.", 875, 852, 2025, 03, 10, 02, 16, 23, true)]
        //Testing +1 to id
        [DataRow(501, 2029, 12, 13, 10, 22, 24, "In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.", 627, 852, 2036, 02, 22, 05, 49, 38, true, 2035, 12, 22, 00, 47, 51, "Nulla justo.Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros.Suspendisse accumsan tortor quis turpis.Sed ante.Vivamus tortor.Duis mattis egestas metus.Aenean fermentum.Donec ut mauris eget massa tempor convallis.", 875, 852, 2025, 03, 10, 02, 16, 23, true)]


        public void BuildSolvrCommentListTestNegative(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                                      int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                                      int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId,
                                                      int expectedTimeAcceptedYear, int expectedTimeAcceptedMonth, int expectedTimeAcceptedDay,
                                                      int expectedTimeAcceptedHour, int expectedTimeAcceptedMinute, int expectedTimeAcceptedSecond,
                                                      Boolean expectedIsAccepted, int expectedId2, int expectedDateCreatedYear2, int expectedDateCreatedMonth2,
                                                      int expectedDateCreatedDay2, int expectedDateCreatedHour2, int expectedDateCreatedMinute2,
                                                      int expectedDateCreatedSecond2, string expectedText2, int expectedUserId2, int expectedPostId2,
                                                      int expectedTimeAcceptedYear2, int expectedTimeAcceptedMonth2, int expectedTimeAcceptedDay2,
                                                      int expectedTimeAcceptedHour2, int expectedTimeAcceptedMinute2, int expectedTimeAcceptedSecond2,
                                                      Boolean expectedIsAccepted2)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedTimeAccepted = new DateTime(expectedTimeAcceptedYear, expectedTimeAcceptedMonth, expectedTimeAcceptedDay, expectedTimeAcceptedHour, expectedTimeAcceptedMinute, expectedTimeAcceptedSecond);
            DateTime expectedDateCreated2 = new DateTime(expectedDateCreatedYear2, expectedDateCreatedMonth2, expectedDateCreatedDay2, expectedDateCreatedHour2, expectedDateCreatedMinute2, expectedDateCreatedSecond2);
            DateTime expectedTimeAccepted2 = new DateTime(expectedTimeAcceptedYear2, expectedTimeAcceptedMonth2, expectedTimeAcceptedDay2, expectedTimeAcceptedHour2, expectedTimeAcceptedMinute2, expectedTimeAcceptedSecond2);
            Post post = modelBuilder.BuildPost<Post>(expectedPostId);

            //Act
            List<Comment> actualComments = post.Comments;
            SolvrComment actualSolvrComment = (SolvrComment)actualComments[0];
            int actualId = actualSolvrComment.Id;
            DateTime actualDateCreated = actualSolvrComment.DateCreated;
            string actualText = actualSolvrComment.Text;
            int actualPostId = actualSolvrComment.PostId;
            int actualUserId = actualSolvrComment.UserId;
            bool actualIsAccepted = actualSolvrComment.IsAccepted;
            DateTime actualTimeAccepted = actualSolvrComment.TimeAccepted;

            if (expectedText2 != null)
            {
                //Act
                SolvrComment actualSolvrComment2 = (SolvrComment)actualComments[1];
                int actualId2 = actualSolvrComment.Id;
                DateTime actualDateCreated2 = actualSolvrComment2.DateCreated;
                string actualText2 = actualSolvrComment2.Text;
                int actualPostId2 = actualSolvrComment2.PostId;
                int actualUserId2 = actualSolvrComment2.UserId;
                bool actualIsAccepted2 = actualSolvrComment2.IsAccepted;
                DateTime actualTimeAccepted2 = actualSolvrComment2.TimeAccepted;

                //Assert
                if (expectedId != 404)
                {
                    AssertAreEqualWithMsg(expectedId2, actualId2, "id");
                }
                AssertAreEqualWithMsg(expectedDateCreated2, actualDateCreated2, "dateCreated");
                AssertAreEqualWithMsg(expectedText2, actualText2, "text");
                AssertAreEqualWithMsg(expectedPostId2, actualPostId2, "postId");
                AssertAreEqualWithMsg(expectedUserId2, actualUserId2, "userId");
                AssertAreEqualWithMsg(expectedIsAccepted2, actualIsAccepted2, "isAccepted");
                AssertAreEqualWithMsg(expectedTimeAccepted2, actualTimeAccepted2, "timeAccepted");
            }

            //Assert
            if (expectedId != 404)
            {
                AssertAreEqualWithMsg(expectedId, actualId, "id");
            }
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualText, "text");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedIsAccepted, actualIsAccepted, "isAccepted");
            AssertAreEqualWithMsg(expectedTimeAccepted, actualTimeAccepted, "timeAccepted");
        }

        [TestMethod]
        [DataRow(1, false, 275, 70, 412, false, 219, 70)]
        [DataRow(509, true, 155, 766, 323, false, 46, 766)]
        [DataRow(1000, false, 47, 540, 406, true, 149, 540, 666, false, 292, 540)]
        public void BuildVoteListTestPosetive(int expectedId, bool expectedIsUpvoted, int expectedUserId, 
                                              int expectedCommentId, int expectedId2, bool expectedIsUpvoted2, 
                                              int expectedUserId2, int expectedCommentId2, int expectedId3, 
                                              bool expectedIsUpvoted3, int expectedUserId3, int expectedCommentId3)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();

            //Act
            Comment comment = modelBuilder.BuildComment<Comment>(expectedCommentId);
            List<Vote> actualVoteList = comment.Votes;
            Vote actualVote = actualVoteList[0];
            int actualId = actualVote.Id;
            bool actualIsUpvoted = actualVote.IsUpvoted;
            int actualUserId = actualVote.UserId;
            int actualCommentId = actualVote.CommentId;

            if (expectedId2 != 0)
            {
                //Act
                Vote actualVote2 = actualVoteList[1];
                int actualId2 = actualVote2.Id;
                bool actualIsUpvoted2 = actualVote2.IsUpvoted;
                int actualUserId2 = actualVote2.UserId;
                int actualCommentId2 = actualVote2.CommentId;

                //Assert
                AssertAreEqualWithMsg(expectedId2, actualId2, "id");
                AssertAreEqualWithMsg(expectedIsUpvoted2, actualIsUpvoted2, "isUpvoted");
                AssertAreEqualWithMsg(expectedUserId2, actualUserId2, "userId");
                AssertAreEqualWithMsg(expectedCommentId2, actualCommentId2, "commentId");
            }

            if (expectedId3 != 0)
            {
                //Act
                Vote actualVote3 = actualVoteList[2];
                int actualId3 = actualVote3.Id;
                bool actualIsUpvoted3 = actualVote3.IsUpvoted;
                int actualUserId3 = actualVote3.UserId;
                int actualCommentId3 = actualVote3.CommentId;

                //Assert
                AssertAreEqualWithMsg(expectedId3, actualId3, "id");
                AssertAreEqualWithMsg(expectedIsUpvoted3, actualIsUpvoted3, "isUpvoted");
                AssertAreEqualWithMsg(expectedUserId3, actualUserId3, "userId");
                AssertAreEqualWithMsg(expectedCommentId3, actualCommentId3, "commentId");
            }

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedIsUpvoted, actualIsUpvoted, "isUpvoted");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualCommentId, "commentId");
        }

        [TestMethod]
        //Testing -1 to id
        [DataRow(0, false, 275, 70, 412, false, 219, 69)]
        //Testing +1 to id
        [DataRow(2, false, 275, 70, 412, false, 219, 69)]
        //Testing -1 to all values except commentId. Also flipped bools values.
        [DataRow(509, false, 154, 765, 322, true, 45, 769)]
        //Testing +1 to all values except commentId. Also flipped bools values.
        [DataRow(509, false, 156, 767, 324, true, 47, 771)]
        //Testing -1 to commentId.
        [DataRow(999, false, 47, 539, 406, true, 149, 539, 666, false, 292, 539)]
        //Testing +1 to commentId.
        [DataRow(1001, false, 47, 539, 406, true, 149, 539, 666, false, 292, 539)]
        public void BuildVoteListTestNegative(int expectedId, bool expectedIsUpvoted, int expectedUserId,
                                              int expectedCommentId, int expectedId2, bool expectedIsUpvoted2,
                                              int expectedUserId2, int expectedCommentId2, int expectedId3,
                                              bool expectedIsUpvoted3, int expectedUserId3, int expectedCommentId3)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();

            //Act
            Comment comment = modelBuilder.BuildComment<Comment>(expectedCommentId);
            List<Vote> actualVoteList = comment.Votes;
            Vote actualVote = actualVoteList[0];
            int actualId = actualVote.Id;
            bool actualIsUpvoted = actualVote.IsUpvoted;
            int actualUserId = actualVote.UserId;
            int actualCommentId = actualVote.CommentId;

            if (expectedId2 != 0)
            {
                //Act
                Vote actualVote2 = actualVoteList[1];
                int actualId2 = actualVote2.Id;
                bool actualIsUpvoted2 = actualVote2.IsUpvoted;
                int actualUserId2 = actualVote2.UserId;
                int actualCommentId2 = actualVote2.CommentId;

                //Assert
                if (expectedId != 509)
                {
                    AssertAreEqualWithMsg(expectedId2, actualId2, "id");
                }
                AssertAreEqualWithMsg(expectedIsUpvoted2, actualIsUpvoted2, "isUpvoted");
                AssertAreEqualWithMsg(expectedUserId2, actualUserId2, "userId");
                AssertAreEqualWithMsg(expectedCommentId2, actualCommentId2, "commentId");
            }

            if (expectedId3 != 0)
            {
                //Act
                Vote actualVote3 = actualVoteList[2];
                int actualId3 = actualVote3.Id;
                bool actualIsUpvoted3 = actualVote3.IsUpvoted;
                int actualUserId3 = actualVote3.UserId;
                int actualCommentId3 = actualVote3.CommentId;

                //Assert
                if (expectedId != 509)
                {
                    AssertAreEqualWithMsg(expectedId3, actualId3, "id");
                }
                AssertAreEqualWithMsg(expectedIsUpvoted3, actualIsUpvoted3, "isUpvoted");
                AssertAreEqualWithMsg(expectedUserId3, actualUserId3, "userId");
                AssertAreEqualWithMsg(expectedCommentId3, actualCommentId3, "commentId");
            }

            //Assert
            if (expectedId != 509)
            {
                AssertAreEqualWithMsg(expectedId, actualId, "id");
            }
            AssertAreEqualWithMsg(expectedIsUpvoted, actualIsUpvoted, "isUpvoted");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualCommentId, "commentId");
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