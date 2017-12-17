using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccesLayer;
using SolvrLibrary;
using DataAccesLayer.DAL;
using System.Collections.Generic;

namespace Solvr.Test.DataAccesLayer
{

    [TestClass]
    public class DataAccesControllerTests
    {

    #region Create Methods Tests
        [TestMethod]
        [DataRow("JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 1, 1)]
        [DataRow("ICD-9", "Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus.", 2031, 10, 08, 17, 46, 54, 2031, 10, 08, 17, 46, 54, 2, 2)]
        [DataRow("Olfaction", " Duis at velit eu est congue elementum. In hac habitasse platea dictumst.Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante.Nulla justo. Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.", 2022, 01, 07, 00, 14, 15, 2022, 01, 07, 00, 14, 15, 3, 3)]
        public void CreatePostPositive(string expectedTitle, string expectedDescription, int expectedDateCreatedYear,
                                int expectedDateCreatedMonth, int expectedDateCreatedDay, int expectedDateCreatedHour,
                                int expectedDateCreatedMinutes, int expectedDateCreatedSeconds, int expectedBumpTimeYear,
                                int expectedBumpTimeMonth, int expectedBumpTimeDay, int expectedBumpTimeHour,
                                int expectedBumpTimeMinute, int expectedBumpTimeSecond, int expectedCategoryId, int expectedUserId)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
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
            Post actualPost = dbCtr.CreatePost(expectedPost);
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
        [DataRow(1, "Berte Chason", "bchason0@theglobeandmail.com", "ehinrichsen0", "uvLWXF", false, 2028, 06, 30, 15, 07, 52)]
        [DataRow(2, "Theo Rappaport", "trappaport1@squidoo.com", "breuss1", "uvCY72YNS", false, 2019, 03, 05, 05, 04, 03)]
        [DataRow(3, "Abbye Dovydenas", "adovydenas2@smh.com.au", "kalforde2", "NORGZG1", false, 2032, 11, 28, 10, 11, 12)]
        public void CreateUserTestPositive(int expectedId, string expectedName, string expectedEmail, string expectedUsername,
                                           string expectedPassword, Boolean expectedIsAdmin, int expectedYear, int expectedMonth,
                                           int expectedDay, int expectedHour, int expectedMinutes, int expectedSeconds)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinutes, expectedSeconds);

            User expectedUser = new User
            {
                Id = expectedId,
                Name = expectedName,
                Email = expectedEmail,
                Username = expectedUsername,
                Password = expectedPassword,
                IsAdmin = expectedIsAdmin,
                DateCreated = expectedDateCreated
            };

            //Act
            dbCtr.CreateUser(expectedUser);
            User actualUser = dbCtr.GetUser(expectedId);
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
        #endregion


    #region Get Methods Tests
    [TestMethod]
    [DataRow(1, "Berte Chason", "bchason0@theglobeandmail.com", "ehinrichsen0", "uvLWXF", false, 2028, 06, 30, 15, 07, 52)]
    [DataRow(2, "Theo Rappaport", "trappaport1@squidoo.com", "breuss1", "uvCY72YNS", false, 2019, 03, 05, 05, 04, 03)]
    [DataRow(3, "Abbye Dovydenas", "adovydenas2@smh.com.au", "kalforde2", "NORGZG1", false, 2032, 11, 28, 10, 11, 12)]
    public void GetUserTestPostive(int expectedId, string expectedName, string expectedEmail, string expectedUsername,
                                     string expectedPassword, Boolean expectedIsAdmin, int expectedYear, int expectedMonth,
                                     int expectedDay, int expectedHour, int expectedMinutes, int expectedSeconds)
    {
        //Prepare
        DataAccesController dbCtr = new DataAccesController(true);
        User expectedUser = new User();
        DateTime expectedDateCreated = new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinutes, expectedSeconds);

        //Act
        User actualUser = dbCtr.GetUser(expectedId);
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
    [DataRow(1, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis.", 1, 1)]
    //[DataRow(2, 2027, 11, 20, 16, 49, 43, "Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula.Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.Donec dapibus. Duis at velit eu est congue elementum.", 2, 2)]
    //[DataRow(3, 2024, 06, 26, 14, 25, 13, "Mauris lacinia sapien quis libero.Nullam sit amet turpis elementum ligula vehicula consequat.Morbi a ipsum.Integer a nibh.In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui.Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.", 3, 3)]
    public void GetCommentTestPositive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                       int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                       int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId)
    {
        //prepare
        DataAccesController dbCtr = new DataAccesController(true);
        DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);

        //Act
        Comment actualComment = dbCtr.GetComment(expectedId);
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
    [DataRow(4, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim.In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy.Integer non velit.Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 1, 4, 2019, 06, 15, 15, 02, 42, false)]
    [DataRow(5, 2033, 11, 28, 02, 54, 41, "Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.Ut at dolor quis odio consequat varius.Integer ac leo.Pellentesque ultrices mattis odio. Donec vitae nisi.Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla.Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.Curabitur at ipsum ac tellus semper interdum.", 2, 5, 2028, 09, 12, 01, 12, 42, true)]
    [DataRow(6, 2025, 02, 06, 17, 46, 02, "Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam.Suspendisse potenti. Nullam porttitor lacus at turpis.Donec posuere metus vitae ipsum.Aliquam non mauris.Morbi non lectus.Aliquam sit amet diam in magna bibendum imperdiet.", 2, 5, 2029, 04, 16, 22, 28, 53, false)]
    public void GetSolvrCommentTestPositive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                                int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                                int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId,
                                                int expectedTimeAcceptedYear, int expectedTimeAcceptedMonth, int expectedTimeAcceptedDay,
                                                int expectedTimeAcceptedHour, int expectedTimeAcceptedMinute, int expectedTimeAcceptedSecond,
                                                Boolean expectedIsAccepte)
    {
        //Prepare
        DataAccesController dbCtr = new DataAccesController(true);
        DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
        DateTime ExpectedTimeAccepted = new DateTime(expectedTimeAcceptedYear, expectedTimeAcceptedMonth, expectedTimeAcceptedDay, expectedTimeAcceptedHour, expectedTimeAcceptedMinute, expectedTimeAcceptedSecond);

        //Act
        SolvrComment actualSolvrComment = (SolvrComment)dbCtr.GetComment(expectedId, false, false);
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
        [DataRow(4, "Print On Demand ", "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit.", 2025, 09, 26, 11, 56, 51, 2025, 09, 26, 11, 56, 51, 1, 1, false, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.Proin risus.Praesent lectus.Vestibulum quam sapien, varius ut, blandit non, interdum in, ante.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio.Curabitur convallis.Duis consequat dui nec nisi volutpat eleifend.", "555", "atvej 15")]
        [DataRow(5, "Crisis Communications", "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue.Vestibulum rutrum rutrum neque. Aenean auctor gravida sem. Praesent id massa id nisl venenatis lacinia.Aenean sit amet justo. Morbi ut odio.Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo.", 2031, 07, 24, 12, 03, 12, 2031, 07, 24, 12, 03, 12, 2, 2, false, "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor.Morbi vel lectus in quam fringilla rhoncus.Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.", "704", "atvej 15")]
        [DataRow(6, "Policy Writing", "Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis.Donec semper sapien a libero.Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.", 2018, 02, 23, 17, 58, 50, 2018, 02, 23, 17, 58, 50, 3, 3, false, "Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim.", "705", "lectusvej 456")]
        public void GetPhysicalPostTestPositive(int expectedId, string expectedTitle, string expectedDescription,
                                                  int expectedBumpTimeYear, int expectedBumpTimeMonth, int expectedBumpTimeDay,
                                                  int expectedBumpTimeHour, int expectedBumpTimeMinute, int expectedBumpTimeSecond,
                                                  int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                                  int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                                  int expectedCategoryId, int expectedUserId, bool expectedIsLocked,
                                                  string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedBumpTime = new DateTime(expectedBumpTimeYear, expectedBumpTimeMonth, expectedBumpTimeDay, expectedBumpTimeHour, expectedBumpTimeMinute, expectedBumpTimeSecond);

            //Act
            PhysicalPost actualPhysicalPost = (PhysicalPost)dbCtr.GetPost(expectedId);
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
            //AssertAreEqualWithMsg(expectePostType, actualPostType, "postType");
            AssertAreEqualWithMsg(expectedIsLocked, actualIsLocked, "isLocke");
            AssertAreEqualWithMsg(expectedDescription, actualDescription, "description");
            AssertAreEqualWithMsg(expectedZipcode, actualZipcode, "zipcode");
            AssertAreEqualWithMsg(expectedAddress, actualAdress, "address");
        }

        [TestMethod]
        [DataRow(1, "massa tempor convallis nulla neque", "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.", "user", true, 2019, 07, 24, 21, 48, 58, 1, 0, 0)]
        [DataRow(2, "eget rutrum", "Aenean fermentum.", "post", true, 2036, 12, 10, 15, 23, 35, 0, 0, 1)]
        [DataRow(3, "ullamcorper augue a suscipit nulla", "Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.", "comment", true, 2030, 02, 07, 17, 12, 05, 0, 1, 0)]
        public void GetReportTestPositive(int expectedId, string expectedTitle, string expectedDescription, string expectedReportType, bool expectedIsResolved,
                                            int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                            int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                            int expectedUserId, int expectedCommentId, int expectedPostId)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);

            //Act
            Report actualReport = dbCtr.GetReport(expectedId);
            int actualId = actualReport.Id;
            string actualTitle = actualReport.Title;
            string actualDesription = actualReport.Description;
            int actualPostId = actualReport.PostId;
            string actualReportType = actualReport.ReportType;
            bool actualIsResolved = actualReport.IsResolved;
            DateTime actualDateCreated = actualReport.DateCreated;
            int actualUserId = actualReport.UserId;
            int actualCommentId = actualReport.CommentId;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedTitle, actualTitle, "title");
            AssertAreEqualWithMsg(expectedDescription, actualDesription, "description");
            AssertAreEqualWithMsg(expectedIsResolved, actualIsResolved, "isResolved");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualCommentId, "commentId");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedReportType, actualReportType, "reportType");
        }
        

        [TestMethod]//0, 0001, 01, 01, 01, 01, 01, "", 0, 0 is just used to not get parameter mismatch, not used in the test.
        [DataRow(1, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis.", 1, 1, "Comment", 0, 0001, 01, 01, 01, 01, 01, "", 0, 0, "")]
        [DataRow(2, 2027, 11, 20, 16, 49, 43, "Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula.Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.Donec dapibus. Duis at velit eu est congue elementum.", 2, 2, "Comment", 3, 2024, 06, 26, 14, 25, 13, "Mauris lacinia sapien quis libero.Nullam sit amet turpis elementum ligula vehicula consequat.Morbi a ipsum.Integer a nibh.In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui.Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.", 2, 2, "Comment")]
        [DataRow(4, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim.In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy.Integer non velit.Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 1, 4, "Solvr", 0, 0001, 01, 01, 01, 01, 01, "", 0, 0, "")]
        [DataRow(5, 2033, 11, 28, 02, 54, 41, "Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.Ut at dolor quis odio consequat varius.Integer ac leo.Pellentesque ultrices mattis odio. Donec vitae nisi.Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla.Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.Curabitur at ipsum ac tellus semper interdum.", 2, 5, "Solvr", 6, 2025, 02, 06, 17, 46, 02, "Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam.Suspendisse potenti. Nullam porttitor lacus at turpis.Donec posuere metus vitae ipsum.Aliquam non mauris.Morbi non lectus.Aliquam sit amet diam in magna bibendum imperdiet.", 2, 5, "Solvr")]
        public void GetCommentListTestPositive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                                 int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                                 int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId, string expectedCommentType,
                                                 int expectedId2, int expectedDateCreatedYear2, int expectedDateCreatedMonth2,
                                                 int expectedDateCreatedDay2, int expectedDateCreatedHour2, int expectedDateCreatedMinute2,
                                                 int expectedDateCreatedSecond2, string expectedText2, int expectedUserId2, int expectedPostId2, string expectedCommentType2)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedDateCreated2 = new DateTime(expectedDateCreatedYear2, expectedDateCreatedMonth2, expectedDateCreatedDay2, expectedDateCreatedHour2, expectedDateCreatedMinute2, expectedDateCreatedSecond2);

            //Act
            List<Comment> actualComments = dbCtr.GetCommentList(expectedPostId, false);
            Comment actualComment = actualComments[0];
            int actualId = actualComment.Id;
            DateTime actualDateCreated = actualComment.DateCreated;
            string actualText = actualComment.Text;
            int actualUserId = actualComment.UserId;
            int actualPostId = actualComment.PostId;
            string actualCommentType = actualComment.CommentType;

            if (!expectedText2.Equals("") || expectedId2 != 0)
            {
                //Act
                Comment actualComment2 = actualComments[1];
                int actualId2 = actualComment2.Id;
                DateTime actualDateCreated2 = actualComment2.DateCreated;
                string actualText2 = actualComment2.Text;
                int actualPostId2 = actualComment2.PostId;
                int actualUserId2 = actualComment2.UserId;
                string actualCommentType2 = actualComment2.CommentType;

                //Assert
                AssertAreEqualWithMsg(expectedId2, actualId2, "id");
                AssertAreEqualWithMsg(expectedDateCreated2, actualDateCreated2, "dateCreated");
                AssertAreEqualWithMsg(expectedText2, actualText2, "text");
                AssertAreEqualWithMsg(expectedPostId2, actualPostId2, "postId");
                AssertAreEqualWithMsg(expectedUserId2, actualUserId2, "userId");
                AssertAreEqualWithMsg(expectedCommentType2, actualComment2.CommentType, "commentType");
            }

            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualDateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualText, "text");
            AssertAreEqualWithMsg(expectedPostId, actualPostId, "postId");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedCommentType, actualComment.CommentType, "commentType");
        }


        [TestMethod]
        [DataRow(1, false, 1, 1, 0, false, 0, 0)]
        [DataRow(2, false, 2, 2, 3, true, 2, 2)]
        public void GetVoteListTestPosetive(int expectedId, bool expectedIsUpvoted, int expectedUserId, int expectedCommentId,
                                              int expectedId2, bool expectedIsUpvoted2, int expectedUserId2, int expectedCommentId2
                                              )
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);

            //Act
            List<Vote> actualVoteList = dbCtr.GetVoteList(expectedCommentId);
            Vote actualVote = actualVoteList[0];
            int actualId = actualVote.Id;
            bool actualIsUpvoted = actualVote.IsUpvoted;
            int actualUserId = actualVote.UserId;
            int actualCommentId = actualVote.CommentId;

            if (expectedId2 != 0)
            {
                //Act
                Vote actualVote2 = actualVoteList[1];
                Console.WriteLine("actualvoteID: " + actualVote2.Id);
                Console.WriteLine("expectedvoteID: " + expectedCommentId);
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
            
            //Assert
            AssertAreEqualWithMsg(expectedId, actualId, "id");
            AssertAreEqualWithMsg(expectedIsUpvoted, actualIsUpvoted, "isUpvoted");
            AssertAreEqualWithMsg(expectedUserId, actualUserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualCommentId, "commentId");
        }
        #endregion

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