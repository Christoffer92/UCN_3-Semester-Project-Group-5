using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccesLayer.DAL;
using SolvrLibrary;

namespace Solvr.Test.SolvrServicesTests
{
    [TestClass]
    public class RemoteSolvrReferenceTests
    {
        private static RemoteSolvrReference.ISolvrServices solvrProxy = new RemoteSolvrReference.SolvrServicesClient();

        [TestInitialize]
        public void SetUp()
        {
            MockDB.CloseDB();
        }

        [TestCleanup]
        public void TearDown()
        {
            MockDB.CloseDB();
        }

        [TestMethod]
        public void IsConnnectedToDatabaseTest()
        {
            //Prepare
            bool expectedConnected = true;

            //Act
            bool actualConnected = solvrProxy.IsConnectedToDatabase();

            //Assert
            AssertAreEqualWithMsg(expectedConnected, actualConnected, "IsConnected");
        }


        #region Get Methods Tests

        [TestMethod]
        [DataRow(1, "Print On Demand", "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit.", 2025, 09, 26, 11, 56, 51, 2025, 09, 26, 11, 56, 51, 451, 535, false, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.Proin risus.Praesent lectus.Vestibulum quam sapien, varius ut, blandit non, interdum in, ante.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio.Curabitur convallis.Duis consequat dui nec nisi volutpat eleifend.", "555", "atvej 15")]
        [DataRow(2, "Furnishings", "Donec vitae nisi. Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus. Curabitur at ipsum ac tellus semper interdum.", 2034, 07, 25, 20, 25, 57, 2034, 07, 25, 20, 25, 57, 48, 351, false, "Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.", "2170", "malesuadavej 328")]
        [DataRow(3, "Sports Coaching", "Aenean lectus.", 2028, 01, 02, 08, 56, 40, 2028, 01, 02, 08, 56, 40, 658, 875, true, "Etiam vel augue.Vestibulum rutrum rutrum neque.", "8401", "accumsanvej 80")]
        public void BuildPhysicalPostTestPositive(int expectedId, string expectedTitle, string expectedDescription,
                                                  int expectedBumpTimeYear, int expectedBumpTimeMonth, int expectedBumpTimeDay,
                                                  int expectedBumpTimeHour, int expectedBumpTimeMinute, int expectedBumpTimeSecond,
                                                  int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                                  int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                                  int expectedCategoryId, int expectedUserId, bool expectedIsLocked,
                                                  string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            //Prepare
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedBumpTime = new DateTime(expectedBumpTimeYear, expectedBumpTimeMonth, expectedBumpTimeDay, expectedBumpTimeHour, expectedBumpTimeMinute, expectedBumpTimeSecond);

            //Act
            Post actualPost = solvrProxy.GetPost(expectedId, false, false, false);
            int actualId = actualPost.Id;
            string actualTitle = actualPost.Title;
            string actualDescription = actualPost.Description;
            DateTime actualBumpTime = actualPost.BumpTime;
            DateTime actualDateCreated = actualPost.DateCreated;
            int actualCategoryId = actualPost.CategoryId;
            int actualUserId = actualPost.UserId;
            string actualPostType = actualPost.PostType;


            //Assert
            //AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedBumpTime, actualBumpTime, "bumpTime");
            AssertAreEqualWithMsg(expectedCategoryId, actualCategoryId, "categoryId");
            AssertAreEqualWithMsg(expectedDescription, actualDescription, "description");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            //AssertAreEqualWithMsg(expectePostType, actualPostType, "postType");
        }

        [TestMethod]
        [DataRow("JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 1, 1)]
        [DataRow("ICD-9", "Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus.", 2031, 10, 08, 17, 46, 54, 2031, 10, 08, 17, 46, 54, 2, 2)]
        [DataRow("Olfaction", " Duis at velit eu est congue elementum. In hac habitasse platea dictumst.Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante.Nulla justo. Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.", 2022, 01, 07, 00, 14, 15, 2022, 01, 07, 00, 14, 15, 3, 3)]
        public void GetPostTests(string expectedTitle, string expectedDescription, int expectedDateCreatedYear,
                                 int expectedDateCreatedMonth, int expectedDateCreatedDay, int expectedDateCreatedHour,
                                 int expectedDateCreatedMinutes, int expectedDateCreatedSeconds, int expectedBumpTimeYear,
                                 int expectedBumpTimeMonth, int expectedBumpTimeDay, int expectedBumpTimeHour,
                                 int expectedBumpTimeMinute, int expectedBumpTimeSecond, int expectedCategoryId, int expectedUserId)
        {
            //Prepare
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinutes, expectedDateCreatedSeconds);
            DateTime expectedBumpTime = new DateTime(expectedBumpTimeYear, expectedBumpTimeMonth, expectedBumpTimeDay, expectedBumpTimeHour, expectedBumpTimeMinute, expectedBumpTimeSecond);
            Post expectedPost = new Post
            {
                Title = expectedTitle,
                DateCreated = expectedDateCreated,
                BumpTime = expectedBumpTime,
                CategoryId = expectedCategoryId,
                Description = expectedDescription,
                UserId = expectedUserId
            };

            //Act
            Post actualPost = solvrProxy.GetPost(1, false, false, true);
            int actualId = actualPost.Id;
            string actualTitle = actualPost.Title;
            DateTime actualDateCreated = actualPost.DateCreated;
            DateTime actualBumpTime = actualPost.BumpTime;
            int actualCategoryId = actualPost.CategoryId;
            string actualDescription = actualPost.Description;
            int actualUserId = actualPost.UserId;

            //Assert
            AssertAreEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedBumpTime, actualBumpTime, "bumpTime");
            AssertAreEqualWithMsg(expectedCategoryId, actualCategoryId, "categoryId");
            AssertAreEqualWithMsg(expectedDescription, actualDescription, "description");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
        }

        [TestMethod]
        public void GetReportListTest()
        {
            //Prepare


            //Act
            solvrProxy.GetReportList(false);

            //Assert
            Assert.IsFalse(false);
        }

        #endregion


        //GetReportList(bool onlyNotResolved = false);

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
            Assert.AreNotEqual(expected, actual, msg);
        }

        public void AssertAreNotEqualWithMsg(int expected, int actual, string name)
        {
            string msg = "expected " + name + " was: " + expected +
                         ". Actual " + name + " is: " + actual;
            Assert.AreNotEqual(expected, actual, msg);
        }

        public void AssertAreNotEqualWithMsg(bool expected, bool actual, string name)
        {
            string msg = "expected " + name + " was: " + expected +
                         ". Actual " + name + " is: " + actual;
            Assert.AreNotEqual(expected, actual, msg);
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
