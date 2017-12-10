using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolvrDesktopClient;
using SolvrLibrary;
using DataAccesLayer.DAL;

namespace Solvr.Test.DesktopTests
{
    /// <summary>
    /// Summary description for DesktopControllerTests
    /// </summary>
    [TestClass]
    public class DesktopControllerTests
    {
        MockDB mockDB;
        public DesktopControllerTests()
        {
            mockDB = new MockDB();
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

        [TestMethod]
        [DataRow(1, "massa tempor convallis nulla neque", "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.", "user", true, 2019, 07, 24, 21, 48, 58, 337, 831, 158)]
        [DataRow(847, "eget rutrum", "Aenean fermentum.", "post", true, 2036, 12, 10, 15, 23, 35, 946, 14, 765)]
        [DataRow(1000, "ullamcorper augue a suscipit nulla", "Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.", "user", true, 2030, 02, 07, 17, 12, 05, 928, 778, 958)]
        public void GetReportTestPositive(int expectedId, string expectedTitle, string expectedDescription,
                                            string expectedReportType, bool expectedIsResolved,
                                            int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                            int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                            int expectedUserId, int expectedCommentId, int expectedPostId)
        {
            //Prepare
            DesktopController desktopController = new DesktopController();
            DateTime expectedDateCreated        = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);

            //Act
            Report actualReport = desktopController.GetReport(expectedId);
            int actualId = actualReport.Id;
            string actualTitle = actualReport.Title;
            string actualDesription = actualReport.Description;
            DateTime actualDateCreated = actualReport.DateCreated;
            int actualUserId = actualReport.UserId;
            int actualCommentId = actualReport.CommentId;
            int actualPostId = actualReport.PostId;
            string actualReportType = actualReport.ReportType;
            bool actualIsResolved = actualReport.IsResolved;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreEqualWithMsg(expectedDescription, actualDesription, "description");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualCommentId, "commentId");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedReportType, actualReportType, "reportType");
            AssertAreEqualWithMsg(expectedIsResolved, actualIsResolved, "isResolved");
        }


        [DataRow(1)]
        [DataRow(653)]
        [DataRow(1000)]
        public void DisablePostTestPositive(int reportId)
        {
            //Prepare
            DesktopController desktopController = new DesktopController(true);
            Post post = desktopController.GetReport(reportId).Post;

            //Act
            desktopController.DisablePost(post.Id);
            Post postAfterDisabled = desktopController.GetReport(reportId).Post;

            //Assert
            AssertAreEqualWithMsg(false, postAfterDisabled.IsDisabled, "isDisable");
        }

        //needs to have the exact numbers of whats in the mockDB. Look at the fillTestData method in mockDB
        [TestMethod]
        //[DataRow(0, 3, 3,   1, 1, 5,    1, 
        public void GetReportCountsTestsPositive(int reportUnresolvedAmount, int reportResolvedAmount,   int reportTotalAmount, 
                                                 int postsReportedAmount,    int postsResolvedAmount,    int postsTotalAmount,
                                                 int commentsReportedAmount, int commentsResolvedAmount, int commentsTotalAmount,
                                                 int usersReportedAmount,    int usersResolvedAmount,    int usersTotalAmount)
        {
            //Prepare
            DesktopController desktopController = new DesktopController(true);
            int[] expectedCounts = new int[12] {reportUnresolvedAmount, reportResolvedAmount, reportTotalAmount,
                                                postsReportedAmount, postsResolvedAmount, postsTotalAmount,
                                                commentsReportedAmount, commentsResolvedAmount, commentsTotalAmount,
                                                usersReportedAmount, usersResolvedAmount, usersTotalAmount};

            //Act
            int [] actuallyCounts = desktopController.GetReportCounts();

            //Assert
            for (int i = 0; i <= 12; i++)
            {
                AssertAreEqualWithMsg(expectedCounts[0], actuallyCounts[0], "counts[" + i +"]");
            }
        }

        #region AssertAreEqualWithMsg methods

        public void AssertAreEqualWithMsg(int expected, int actual, string name)
        {
            string msg = "expected " + name + " was: " + expected +
                         ". Actual " + name + " is: " + actual;
            Assert.AreEqual(expected, actual, msg);
        }

        public void AssertAreEqualWithMsg(string expected, string actual, string name)
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


        [TestInitialize()]
        public void SetUp()
        {
            mockDB.FillTestData();
        }

        [TestCleanup()]
        public void TearDown()
        {
            MockDB.CloseDB();
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
    }
}
