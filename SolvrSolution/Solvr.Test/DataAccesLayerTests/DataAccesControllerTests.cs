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
        [TestCleanup]
        public void TearDown()
        {
            MockDB.CloseDB();
        }

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

            //Assert
            AssertAreEqualWithMsg(expectedId, actualUser.Id, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualUser.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedEmail, actualUser.Email, "email");
            AssertAreEqualWithMsg(expectedIsAdmin, actualUser.IsAdmin, "isAdmin");
            AssertAreEqualWithMsg(expectedName, actualUser.Name, "name");
            AssertAreEqualWithMsg(expectedUsername, actualUser.Username, "username");
            AssertAreEqualWithMsg(expectedPassword, actualUser.Password, "password");
        }

        [TestMethod]
        [DataRow(1, "JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 1, 1, false, "", "", "")]
        [DataRow(2, "ICD-9", "Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus.", 2031, 10, 08, 17, 46, 54, 2031, 10, 08, 17, 46, 54, 2, 2, false, "", "", "")]
        [DataRow(3, "Olfaction", " Duis at velit eu est congue elementum. In hac habitasse platea dictumst.Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante.Nulla justo. Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.", 2022, 01, 07, 00, 14, 15, 2022, 01, 07, 00, 14, 15, 2, 2, false, "", "", "")]
        [DataRow(4, "Print On Demand ", "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit.", 2025, 09, 26, 11, 56, 51, 2025, 09, 26, 11, 56, 51, 1, 1, false, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.", "555", "atvej 15")]
        [DataRow(5, "Crisis Communications", "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue.Vestibulum rutrum rutrum neque. Aenean auctor gravida sem. Praesent id massa id nisl venenatis lacinia.Aenean sit amet justo. Morbi ut odio.Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo.", 2031, 07, 24, 12, 03, 12, 2031, 07, 24, 12, 03, 12, 2, 2, false, "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor.Morbi vel lectus in quam fringilla rhoncus.Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.", "704", "atvej 15")]
        [DataRow(6, "Policy Writing", "Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis.Donec semper sapien a libero.Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.", 2018, 02, 23, 17, 58, 50, 2018, 02, 23, 17, 58, 50, 2, 2, false, "Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim.", "705", "lectusvej 456")]
        public void GetPostTestPositive(int expectedId, string expectedTitle, string expectedDescription,
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
            Post actualPost = dbCtr.GetPost(expectedId);


            if (!expectedAltDescription.Equals(""))
            {
                //Act
                PhysicalPost actualPhysicalPost = (PhysicalPost)actualPost;
                bool actualIsLocked = actualPhysicalPost.IsLocked;

                //Assert
                AssertAreEqualWithMsg(expectedIsLocked, actualPhysicalPost.IsLocked, "isLocke");
                AssertAreEqualWithMsg(expectedAltDescription, actualPhysicalPost.AltDescription, "description");
                AssertAreEqualWithMsg(expectedZipcode, actualPhysicalPost.Zipcode, "zipcode");
                AssertAreEqualWithMsg(expectedAddress, actualPhysicalPost.Address, "address");
            }

            //Assert
            AssertAreEqualWithMsg(expectedId, actualPost.Id, "id");
            AssertAreEqualWithMsg(expectedTitle, actualPost.Title, "title");
            AssertAreEqualWithMsg(expectedDateCreated, actualPost.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedBumpTime, actualPost.BumpTime, "bumpTime");
            AssertAreEqualWithMsg(expectedCategoryId, actualPost.CategoryId, "categoryId");
            AssertAreEqualWithMsg(expectedDescription, actualPost.Description, "description");
            AssertAreEqualWithMsg(expectedUserId, actualPost.UserId, "userId");
            //AssertAreEqualWithMsg(expectedPostType, actualPostType, "postType");
        }

        [TestMethod]
        [DataRow(1, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis.", 1, 1, 0000, 00, 0, 0, 0, 0, false)]
        [DataRow(2, 2027, 11, 20, 16, 49, 43, "Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula.Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.Donec dapibus. Duis at velit eu est congue elementum.", 2, 2, 0000, 00, 0, 0, 0, 0, false)]
        [DataRow(3, 2024, 06, 26, 14, 25, 13, "Mauris lacinia sapien quis libero.Nullam sit amet turpis elementum ligula vehicula consequat.Morbi a ipsum.Integer a nibh.In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui.Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.", 2, 2, 0000, 00, 0, 0, 0, 0, false)]
        [DataRow(4, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim.In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy.Integer non velit.Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 1, 4, 2019, 06, 15, 15, 02, 42, false)]
        [DataRow(5, 2033, 11, 28, 02, 54, 41, "Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.Ut at dolor quis odio consequat varius.Integer ac leo.Pellentesque ultrices mattis odio. Donec vitae nisi.Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla.Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.Curabitur at ipsum ac tellus semper interdum.", 2, 5, 2028, 09, 12, 01, 12, 42, true)]
        [DataRow(6, 2025, 02, 06, 17, 46, 02, "Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam.Suspendisse potenti. Nullam porttitor lacus at turpis.Donec posuere metus vitae ipsum.Aliquam non mauris.Morbi non lectus.Aliquam sit amet diam in magna bibendum imperdiet.", 2, 5, 2029, 04, 16, 22, 28, 53, false)]
        public void GetCommentTestPositive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                           int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                           int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId,
                                           int expectedTimeAcceptedYear, int expectedTimeAcceptedMonth, int expectedTimeAcceptedDay,
                                           int expectedTimeAcceptedHour, int expectedTimeAcceptedMinute, int expectedTimeAcceptedSecond,
                                           Boolean expectedIsAccepted)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);

            //Act
            Comment actualComment = dbCtr.GetComment(expectedId);

            if (expectedTimeAcceptedYear != 0)
            {
                //Prepare
                DateTime ExpectedTimeAccepted = new DateTime(expectedTimeAcceptedYear, expectedTimeAcceptedMonth, expectedTimeAcceptedDay, expectedTimeAcceptedHour, expectedTimeAcceptedMinute, expectedTimeAcceptedSecond);

                //Act
                SolvrComment actualSolvrComment = (SolvrComment)actualComment;

                //Assert
                AssertAreEqualWithMsg(ExpectedTimeAccepted, actualSolvrComment.TimeAccepted, "timeAccepted");
                AssertAreEqualWithMsg(expectedIsAccepted, actualSolvrComment.IsAccepted, "isAccepted");
            }

            //Assert
            AssertAreEqualWithMsg(expectedId, actualComment.Id, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualComment.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualComment.Text, "text");
            AssertAreEqualWithMsg(expectedPostId, actualComment.PostId, "postId");
            AssertAreEqualWithMsg(expectedUserId, actualComment.UserId, "userId");
        }


        [TestMethod]
        [DataRow(1, "philosophy")]
        [DataRow(2, "reduction")]
        [DataRow(3, "tree")]
        public void GetCategoryTestPostitive(int expectedId, string expectedName)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);

            //Act
            Category actualCategory = dbCtr.GetCategory(expectedId);

            //Assert
            AssertAreEqualWithMsg(expectedId, actualCategory.Id, "id");
            AssertAreEqualWithMsg(expectedName, actualCategory.Name, "name");
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

            //Assert
            AssertAreEqualWithMsg(expectedId, actualReport.Id, "id");
            AssertAreEqualWithMsg(expectedTitle, actualReport.Title, "title");
            AssertAreEqualWithMsg(expectedDescription, actualReport.Description, "description");
            AssertAreEqualWithMsg(expectedIsResolved, actualReport.IsResolved, "isResolved");
            AssertAreEqualWithMsg(expectedDateCreated, actualReport.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedUserId, actualReport.UserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualReport.CommentId, "commentId");
            AssertAreEqualWithMsg(expectedPostId, actualReport.PostId, "postId");
            AssertAreEqualWithMsg(expectedReportType, actualReport.ReportType, "reportType");
        }


        [TestMethod]
        [DataRow(1, "JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 1, 1, false, "", "", "", 0, "", "", 0000, 00, 00, 00, 00, 00, 0000, 00, 00, 00, 00, 00, 0, 0, false, "", "", "")]
        [DataRow(2, "ICD-9", "Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus.", 2031, 10, 08, 17, 46, 54, 2031, 10, 08, 17, 46, 54, 2, 2, false, "", "", "",
                    3, "Olfaction", " Duis at velit eu est congue elementum. In hac habitasse platea dictumst.Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante.Nulla justo. Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.", 2022, 01, 07, 00, 14, 15, 2022, 01, 07, 00, 14, 15, 2, 2, false, "", "", "")]
        [DataRow(4, "Print On Demand ", "Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit.", 2025, 09, 26, 11, 56, 51, 2025, 09, 26, 11, 56, 51, 1, 1, false, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.Proin risus.Praesent lectus.Vestibulum quam sapien, varius ut, blandit non, interdum in, ante.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio.Curabitur convallis.Duis consequat dui nec nisi volutpat eleifend.", "555", "atvej 15", 0, "", "", 0000, 00, 00, 00, 00, 00, 0000, 00, 00, 00, 00, 00, 0, 0, false, "", "", "")]
        [DataRow(5, "Crisis Communications", "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue.Vestibulum rutrum rutrum neque. Aenean auctor gravida sem. Praesent id massa id nisl venenatis lacinia.Aenean sit amet justo. Morbi ut odio.Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo.", 2031, 07, 24, 12, 03, 12, 2031, 07, 24, 12, 03, 12, 2, 2, false, "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor.Morbi vel lectus in quam fringilla rhoncus.Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.", "704", "atvej 15",
                    6, "Policy Writing", "Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis.Donec semper sapien a libero.Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.", 2018, 02, 23, 17, 58, 50, 2018, 02, 23, 17, 58, 50, 2, 2, false, "Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim.", "705", "lectusvej 456")]

        public void GetPostListTestPositive(int expectedId, string expectedTitle, string expectedDescription,
                                            int expectedBumpTimeYear, int expectedBumpTimeMonth, int expectedBumpTimeDay,
                                            int expectedBumpTimeHour, int expectedBumpTimeMinute, int expectedBumpTimeSecond,
                                            int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                            int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                            int expectedCategoryId, int expectedUserId, bool expectedIsLocked,
                                            string expectedAltDescription, string expectedZipcode, string expectedAddress,
                                            int expectedId2, string expectedTitle2, string expectedDescription2,
                                            int expectedBumpTimeYear2, int expectedBumpTimeMonth2, int expectedBumpTimeDay2,
                                            int expectedBumpTimeHour2, int expectedBumpTimeMinute2, int expectedBumpTimeSecond2,
                                            int expectedDateCreatedYear2, int expectedDateCreatedMonth2, int expectedDateCreatedDay2,
                                            int expectedDateCreatedHour2, int expectedDateCreatedMinute2, int expectedDateCreatedSecond2,
                                            int expectedCategoryId2, int expectedUserId2, bool expectedIsLocked2,
                                            string expectedAltDescription2, string expectedZipcode2, string expectedAddress2)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedBumpTime = new DateTime(expectedBumpTimeYear, expectedBumpTimeMonth, expectedBumpTimeDay, expectedBumpTimeHour, expectedBumpTimeMinute, expectedBumpTimeSecond);

            //Act
            Post actualPost = dbCtr.GetPost(expectedId);

            if (!expectedAltDescription.Equals(""))
            {
                //Act
                PhysicalPost actualPhysicalPost = (PhysicalPost)actualPost;

                //Assert
                AssertAreEqualWithMsg(expectedIsLocked, actualPhysicalPost.IsLocked, "isLocke");
                AssertAreEqualWithMsg(expectedDescription, actualPhysicalPost.Description, "description");
                AssertAreEqualWithMsg(expectedZipcode, actualPhysicalPost.Zipcode, "zipcode");
                AssertAreEqualWithMsg(expectedAddress, actualPhysicalPost.Address, "address");
            }

            //Assert
            AssertAreEqualWithMsg(expectedId, actualPost.Id, "id");
            AssertAreEqualWithMsg(expectedTitle, actualPost.Title, "title");
            AssertAreEqualWithMsg(expectedDateCreated, actualPost.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedBumpTime, actualPost.BumpTime, "bumpTime");
            AssertAreEqualWithMsg(expectedCategoryId, actualPost.CategoryId, "categoryId");
            AssertAreEqualWithMsg(expectedDescription, actualPost.Description, "description");
            AssertAreEqualWithMsg(expectedUserId, actualPost.UserId, "userId");
            //AssertAreEqualWithMsg(expectedPostType, actualPost.PostType, "postType");

            if (expectedId2 != 0)
            {
                //Prepare
                DateTime expectedDateCreated2 = new DateTime(expectedDateCreatedYear2, expectedDateCreatedMonth2, expectedDateCreatedDay2, expectedDateCreatedHour2, expectedDateCreatedMinute2, expectedDateCreatedSecond2);
                DateTime expectedBumpTime2 = new DateTime(expectedBumpTimeYear2, expectedBumpTimeMonth2, expectedBumpTimeDay2, expectedBumpTimeHour2, expectedBumpTimeMinute2, expectedBumpTimeSecond2);

                //Act
                Post actualPost2 = dbCtr.GetPost(expectedId2);

                if (!expectedAltDescription2.Equals(""))
                {
                    //Act
                    PhysicalPost actualPhysicalPost2 = (PhysicalPost)actualPost2;

                    //Assert
                    AssertAreEqualWithMsg(expectedIsLocked2, actualPhysicalPost2.IsLocked, "isLocke");
                    AssertAreEqualWithMsg(expectedDescription2, actualPhysicalPost2.Description, "description");
                    AssertAreEqualWithMsg(expectedZipcode2, actualPhysicalPost2.Zipcode, "zipcode");
                    AssertAreEqualWithMsg(expectedAddress2, actualPhysicalPost2.Address, "address");
                }

                //Assert
                AssertAreEqualWithMsg(expectedId2, actualPost2.Id, "id");
                AssertAreEqualWithMsg(expectedTitle2, actualPost2.Title, "title");
                AssertAreEqualWithMsg(expectedDateCreated2, actualPost2.DateCreated, "dateCreated");
                AssertAreEqualWithMsg(expectedBumpTime2, actualPost2.BumpTime, "bumpTime");
                AssertAreEqualWithMsg(expectedCategoryId2, actualPost2.CategoryId, "categoryId");
                AssertAreEqualWithMsg(expectedDescription2, actualPost2.Description, "description");
                AssertAreEqualWithMsg(expectedUserId2, actualPost2.UserId, "userId");
                //AssertAreEqualWithMsg(expectedPostType, actualPost.PostType, "postType");
            }


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

            if (expectedId2 != 0)
            {
                //Act
                Vote actualVote2 = actualVoteList[1];

                //Assert
                AssertAreEqualWithMsg(expectedId2, actualVote2.Id, "id");
                AssertAreEqualWithMsg(expectedIsUpvoted2, actualVote2.IsUpvoted, "isUpvoted");
                AssertAreEqualWithMsg(expectedUserId2, actualVote2.UserId, "userId");
                AssertAreEqualWithMsg(expectedCommentId2, actualVote2.CommentId, "commentId");
            }

            //Assert
            AssertAreEqualWithMsg(expectedId, actualVote.Id, "id");
            AssertAreEqualWithMsg(expectedIsUpvoted, actualVote.IsUpvoted, "isUpvoted");
            AssertAreEqualWithMsg(expectedUserId, actualVote.UserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualVote.CommentId, "commentId");
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

            if (!expectedText2.Equals("") || expectedId2 != 0)
            {
                //Act
                Comment actualComment2 = actualComments[1];

                //Assert
                AssertAreEqualWithMsg(expectedId2, actualComment2.Id, "id");
                AssertAreEqualWithMsg(expectedDateCreated2, actualComment2.DateCreated, "dateCreated");
                AssertAreEqualWithMsg(expectedText2, actualComment2.Text, "text");
                AssertAreEqualWithMsg(expectedPostId2, actualComment2.PostId, "postId");
                AssertAreEqualWithMsg(expectedUserId2, actualComment2.UserId, "userId");
                AssertAreEqualWithMsg(expectedCommentType2, actualComment2.CommentType, "commentType");
            }

            //Assert
            AssertAreEqualWithMsg(expectedId, actualComment.Id, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualComment.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualComment.Text, "text");
            AssertAreEqualWithMsg(expectedPostId, actualComment.PostId, "postId");
            AssertAreEqualWithMsg(expectedUserId, actualComment.UserId, "userId");
            AssertAreEqualWithMsg(expectedCommentType, actualComment.CommentType, "commentType");
        }


        [TestMethod]
        [DataRow(1, "massa tempor convallis nulla neque", "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.", "user", true, 2019, 07, 24, 21, 48, 58, 1, 0, 0,
                    2, "eget rutrum", "Aenean fermentum.", "post", true, 2036, 12, 10, 15, 23, 35, 0, 0, 1,
                    3, "ullamcorper augue a suscipit nulla", "Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.", "comment", true, 2030, 02, 07, 17, 12, 05, 0, 1, 0)]
        public void GetReportListTestPostive(int expectedId, string expectedTitle, string expectedDescription, string expectedReportType, bool expectedIsResolved,
                                            int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                            int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                            int expectedUserId, int expectedCommentId, int expectedPostId,
                                            int expectedId2, string expectedTitle2, string expectedDescription2, string expectedReportType2, bool expectedIsResolved2,
                                            int expectedDateCreatedYear2, int expectedDateCreatedMonth2, int expectedDateCreatedDay2,
                                            int expectedDateCreatedHour2, int expectedDateCreatedMinute2, int expectedDateCreatedSecond2,
                                            int expectedUserId2, int expectedCommentId2, int expectedPostId2,
                                            int expectedId3, string expectedTitle3, string expectedDescription3, string expectedReportType3, bool expectedIsResolved3,
                                            int expectedDateCreatedYear3, int expectedDateCreatedMonth3, int expectedDateCreatedDay3,
                                            int expectedDateCreatedHour3, int expectedDateCreatedMinute3, int expectedDateCreatedSecond3,
                                            int expectedUserId3, int expectedCommentId3, int expectedPostId3)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);

            //Act
            List<Report> actualReportList = dbCtr.GetReportList();
            Report actualReport = actualReportList[0];

            //Assert
            AssertAreEqualWithMsg(3, actualReportList.Count, "reportList.Count");
            AssertAreEqualWithMsg(expectedId, actualReport.Id, "id");
            AssertAreEqualWithMsg(expectedTitle, actualReport.Title, "title");
            AssertAreEqualWithMsg(expectedDescription, actualReport.Description, "description");
            AssertAreEqualWithMsg(expectedReportType, actualReport.ReportType, "reportType");
            AssertAreEqualWithMsg(expectedIsResolved, actualReport.IsResolved, "isResolved");
            AssertAreEqualWithMsg(expectedDateCreated, actualReport.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedUserId, actualReport.UserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualReport.CommentId, "commentId");
            AssertAreEqualWithMsg(expectedPostId, actualReport.PostId, "postId");

            if (expectedId2 != 0)
            {
                //Prepare
                DateTime expectedDateCreated2 = new DateTime(expectedDateCreatedYear2, expectedDateCreatedMonth2, expectedDateCreatedDay2, expectedDateCreatedHour2, expectedDateCreatedMinute2, expectedDateCreatedSecond2);

                //Act
                Report actualReport2 = actualReportList[1];

                //Assert
                AssertAreEqualWithMsg(expectedId2, actualReport2.Id, "id");
                AssertAreEqualWithMsg(expectedTitle2, actualReport2.Title, "title");
                AssertAreEqualWithMsg(expectedDescription2, actualReport2.Description, "description");
                AssertAreEqualWithMsg(expectedReportType2, actualReport2.ReportType, "reportType");
                AssertAreEqualWithMsg(expectedIsResolved2, actualReport2.IsResolved, "isResolved");
                AssertAreEqualWithMsg(expectedDateCreated2, actualReport2.DateCreated, "dateCreated");
                AssertAreEqualWithMsg(expectedUserId2, actualReport2.UserId, "userId");
                AssertAreEqualWithMsg(expectedCommentId2, actualReport2.CommentId, "commentId");
                AssertAreEqualWithMsg(expectedPostId2, actualReport2.PostId, "postId");
            }

            if (expectedId3 != 0)
            {
                //Prepare
                DateTime expectedDateCreated3 = new DateTime(expectedDateCreatedYear3, expectedDateCreatedMonth3, expectedDateCreatedDay3, expectedDateCreatedHour3, expectedDateCreatedMinute3, expectedDateCreatedSecond3);

                //Act
                Report actualReport3 = actualReportList[2];

                //Assert
                AssertAreEqualWithMsg(expectedId3, actualReport3.Id, "id");
                AssertAreEqualWithMsg(expectedTitle3, actualReport3.Title, "title");
                AssertAreEqualWithMsg(expectedDescription3, actualReport3.Description, "description");
                AssertAreEqualWithMsg(expectedReportType3, actualReport3.ReportType, "reportType");
                AssertAreEqualWithMsg(expectedIsResolved3, actualReport3.IsResolved, "isResolved");
                AssertAreEqualWithMsg(expectedDateCreated3, actualReport3.DateCreated, "dateCreated");
                AssertAreEqualWithMsg(expectedUserId3, actualReport3.UserId, "userId");
                AssertAreEqualWithMsg(expectedCommentId3, actualReport3.CommentId, "commentId");
                AssertAreEqualWithMsg(expectedPostId3, actualReport3.PostId, "postId");
            }
        }


        [TestMethod]
        [DataRow(1, "philosophy",
                    2, "reduction",
                    3, "tree")]
        public void GetCategoryListTestPositive(int expectedId, string expectedName,
                                                int expectedId2, string expectedName2,
                                                int expectedId3, string expectedName3)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);

            //Act
            List<Category> actualCategoryList = dbCtr.GetCategoryList();
            Category actualCategory = actualCategoryList[0];

            //Assert
            AssertAreEqualWithMsg(3, actualCategoryList.Count, "categoryList.Count");
            AssertAreEqualWithMsg(expectedId, actualCategory.Id, "id");
            AssertAreEqualWithMsg(expectedName, actualCategory.Name, "name");

            if (expectedId2 != 0)
            {
                //Act
                Category actualCategory2 = actualCategoryList[1];

                //Assert
                AssertAreEqualWithMsg(expectedId2, actualCategory2.Id, "id");
                AssertAreEqualWithMsg(expectedName2, actualCategory2.Name, "name");
            }

            if (expectedId3 != 0)
            {
                //Act
                Category actualCategory3 = actualCategoryList[2];

                //Assert
                AssertAreEqualWithMsg(expectedId3, actualCategory3.Id, "id");
                AssertAreEqualWithMsg(expectedName3, actualCategory3.Name, "name");
            }
        }


        #endregion

        #region Create Methods Tests
        [TestMethod]
        [DataRow(7, "JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 1, 1)]
        [DataRow(7, "ICD-9", "Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus.", 2031, 10, 08, 17, 46, 54, 2031, 10, 08, 17, 46, 54, 2, 2)]
        [DataRow(7, "Olfaction", " Duis at velit eu est congue elementum. In hac habitasse platea dictumst.Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante.Nulla justo. Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.", 2022, 01, 07, 00, 14, 15, 2022, 01, 07, 00, 14, 15, 3, 3)]
        public void CreatePostPositive(int expectedId, string expectedTitle, string expectedDescription, int expectedDateCreatedYear,
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
            dbCtr.CreatePost(expectedPost);
            //AssertAreEqualWithMsg(1, 2, dbCtr.CreatePost(expectedPost).Id+"dfdsf");
            Post actualPost = dbCtr.GetPost(expectedId);
            int actualId = actualPost.Id;

            //Assert
            AssertAreEqualWithMsg(expectedId, actualPost.Id, "id");
            AssertAreEqualWithMsg(expectedTitle, actualPost.Title, "title");
            AssertAreEqualWithMsg(expectedDateCreated, actualPost.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedBumpTime, actualPost.BumpTime, "bumpTime");
            AssertAreEqualWithMsg(expectedCategoryId, actualPost.CategoryId, "categoryId");
            AssertAreEqualWithMsg(expectedDescription, actualPost.Description, "description");
            AssertAreEqualWithMsg(expectedUserId, actualPost.UserId, "userId");
        }


        [TestMethod]
        [DataRow(4, "Berte Chason", "bchason0@theglobeandmail.com", "ehinrichsen0", "uvLWXF", false, 2028, 06, 30, 15, 07, 52)]
        [DataRow(4, "Theo Rappaport", "trappaport1@squidoo.com", "breuss1", "uvCY72YNS", false, 2019, 03, 05, 05, 04, 03)]
        [DataRow(4, "Abbye Dovydenas", "adovydenas2@smh.com.au", "kalforde2", "NORGZG1", false, 2032, 11, 28, 10, 11, 12)]
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

            //Assert
            AssertAreEqualWithMsg(expectedId, actualUser.Id, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualUser.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedEmail, actualUser.Email, "email");
            AssertAreEqualWithMsg(expectedIsAdmin, actualUser.IsAdmin, "isAdmin");
            AssertAreEqualWithMsg(expectedName, actualUser.Name, "name");
            AssertAreEqualWithMsg(expectedUsername, actualUser.Username, "username");
            AssertAreEqualWithMsg(expectedPassword, actualUser.Password, "password");
        }

        [TestMethod]
        //Comments
        [DataRow(7, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis.", 1, 1, 0000, 00, 0, 0, 0, 0, false)]
        [DataRow(7, 2027, 11, 20, 16, 49, 43, "Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula.Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.Donec dapibus. Duis at velit eu est congue elementum.", 2, 2, 0000, 00, 0, 0, 0, 0, false)]
        [DataRow(7, 2024, 06, 26, 14, 25, 13, "Mauris lacinia sapien quis libero.Nullam sit amet turpis elementum ligula vehicula consequat.Morbi a ipsum.Integer a nibh.In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui.Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.", 2, 2, 0000, 00, 0, 0, 0, 0, false)]
        //SolvrComments
        [DataRow(7, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim.In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy.Integer non velit.Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 1, 4, 2019, 06, 15, 15, 02, 42, false)]
        [DataRow(7, 2033, 11, 28, 02, 54, 41, "Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.Ut at dolor quis odio consequat varius.Integer ac leo.Pellentesque ultrices mattis odio. Donec vitae nisi.Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla.Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.Curabitur at ipsum ac tellus semper interdum.", 2, 5, 2028, 09, 12, 01, 12, 42, true)]
        [DataRow(7, 2025, 02, 06, 17, 46, 02, "Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam.Suspendisse potenti. Nullam porttitor lacus at turpis.Donec posuere metus vitae ipsum.Aliquam non mauris.Morbi non lectus.Aliquam sit amet diam in magna bibendum imperdiet.", 2, 5, 2029, 04, 16, 22, 28, 53, false)]
        public void CreateCommentTestPostitive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                       int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                       int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId,
                                       int expectedTimeAcceptedYear, int expectedTimeAcceptedMonth, int expectedTimeAcceptedDay,
                                       int expectedTimeAcceptedHour, int expectedTimeAcceptedMinute, int expectedTimeAcceptedSecond,
                                       Boolean expectedIsAccepted)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedTimeAccepted = DateTime.MinValue;
            if (expectedTimeAcceptedYear != 0)
                expectedTimeAccepted = new DateTime(expectedTimeAcceptedYear, expectedTimeAcceptedMonth, expectedTimeAcceptedDay, expectedTimeAcceptedHour, expectedTimeAcceptedMinute, expectedTimeAcceptedSecond);

            SolvrComment comment = new SolvrComment()
            {
                Id = expectedId,
                DateCreated = expectedDateCreated,
                Text = expectedText,
                UserId = expectedUserId,
                PostId = expectedPostId,
                TimeAccepted = expectedTimeAccepted,
                IsAccepted = expectedIsAccepted
            };

            //Act
            dbCtr.CreateComment(comment);
            Comment actualComment = dbCtr.GetComment(expectedId);

            //Assert
            AssertAreEqualWithMsg(expectedId, actualComment.Id, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualComment.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualComment.Text, "text");
            AssertAreEqualWithMsg(expectedUserId, actualComment.UserId, "userId");
            AssertAreEqualWithMsg(expectedPostId, actualComment.PostId, "postId");

            if (expectedTimeAcceptedYear != 0)
            {
                //Act
                SolvrComment actualSolvrComment = (SolvrComment)dbCtr.GetComment(expectedId);

                //Assert
                AssertAreEqualWithMsg(expectedTimeAccepted, actualSolvrComment.TimeAccepted, "timeAccepted");
                AssertAreEqualWithMsg(expectedIsAccepted, actualSolvrComment.IsAccepted, "isAccepted");
            }
        }


        [TestMethod]
        [DataRow(4, "massa tempor convallis nulla neque", "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.", "user", true, 2019, 07, 24, 21, 48, 58, 1, 0, 0)]
        [DataRow(4, "eget rutrum", "Aenean fermentum.", "post", true, 2036, 12, 10, 15, 23, 35, 0, 0, 1)]
        [DataRow(4, "ullamcorper augue a suscipit nulla", "Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.", "comment", true, 2030, 02, 07, 17, 12, 05, 0, 1, 0)]
        public void CreateReportTestPositive(int expectedId, string expectedTitle, string expectedDescription, string expectedReportType, bool expectedIsResolved,
                                             int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                             int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                             int expectedUserId, int expectedCommentId, int expectedPostId)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            Report report = new Report()
            {
                Title = expectedTitle,
                Description = expectedDescription,
                ReportType = expectedReportType,
                IsResolved = expectedIsResolved,
                DateCreated = expectedDateCreated,
                UserId = expectedUserId,
                CommentId = expectedCommentId,
                PostId = expectedPostId
            };

            //Act
            dbCtr.CreateReport(report);
            Report actualReport = dbCtr.GetReport(expectedId);

            //Assert
            AssertAreEqualWithMsg(expectedId, actualReport.Id, "id");
            AssertAreEqualWithMsg(expectedTitle, actualReport.Title, "title");
            AssertAreEqualWithMsg(expectedDescription, actualReport.Description, "description");
            AssertAreEqualWithMsg(expectedIsResolved, actualReport.IsResolved, "isResolved");
            AssertAreEqualWithMsg(expectedDateCreated, actualReport.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedUserId, actualReport.UserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualReport.CommentId, "commentId");
            AssertAreEqualWithMsg(expectedPostId, actualReport.PostId, "postId");
            AssertAreEqualWithMsg(expectedReportType, actualReport.ReportType, "reportType");
        }

        #endregion

        #region Update Method Test
        [TestMethod]
        [DataRow(1, "JCIDS", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc.", 2028, 01, 29, 09, 23, 28, 2028, 01, 29, 09, 23, 28, 1, 1)]
        [DataRow(2, "ICD-9", "Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus.", 2031, 10, 08, 17, 46, 54, 2031, 10, 08, 17, 46, 54, 2, 2)]
        [DataRow(3, "Olfaction", " Duis at velit eu est congue elementum. In hac habitasse platea dictumst.Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante.Nulla justo. Aliquam quis turpis eget elit sodales scelerisque.Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.", 2022, 01, 07, 00, 14, 15, 2022, 01, 07, 00, 14, 15, 2, 2)]
        public void UpdatePostTestPositive(int expectedId, string expectedTitle, string expectedDescription, int expectedDateCreatedYear,
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
            dbCtr.UpdatePost(expectedPost);
            Post actualPost = dbCtr.GetPost(expectedId);
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
        //Comments
        [DataRow(1, 2036, 11, 09, 11, 21, 23, "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis.", 1, 1, 0000, 00, 0, 0, 0, 0, false)]
        [DataRow(2, 2027, 11, 20, 16, 49, 43, "Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula.Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.Donec dapibus. Duis at velit eu est congue elementum.", 2, 2, 0000, 00, 0, 0, 0, 0, false)]
        [DataRow(3, 2024, 06, 26, 14, 25, 13, "Mauris lacinia sapien quis libero.Nullam sit amet turpis elementum ligula vehicula consequat.Morbi a ipsum.Integer a nibh.In quis justo.Maecenas rhoncus aliquam lacus.Morbi quis tortor id nulla ultrices aliquet.Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui.Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.", 2, 2, 0000, 00, 0, 0, 0, 0, false)]
        //SolvrComments
        [DataRow(4, 2022, 05, 12, 21, 06, 16, "Proin eu mi. Nulla ac enim.In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy.Integer non velit.Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.", 1, 4, 2019, 06, 15, 15, 02, 42, false)]
        [DataRow(5, 2033, 11, 28, 02, 54, 41, "Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.Sed accumsan felis.Ut at dolor quis odio consequat varius.Integer ac leo.Pellentesque ultrices mattis odio. Donec vitae nisi.Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla.Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.Curabitur at ipsum ac tellus semper interdum.", 2, 5, 2028, 09, 12, 01, 12, 42, true)]
        [DataRow(6, 2025, 02, 06, 17, 46, 02, "Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.Pellentesque viverra pede ac diam.Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam.Suspendisse potenti. Nullam porttitor lacus at turpis.Donec posuere metus vitae ipsum.Aliquam non mauris.Morbi non lectus.Aliquam sit amet diam in magna bibendum imperdiet.", 2, 5, 2029, 04, 16, 22, 28, 53, false)]
        public void UpdateCommentTestPostitive(int expectedId, int expectedDateCreatedYear, int expectedDateCreatedMonth,
                                               int expectedDateCreatedDay, int expectedDateCreatedHour, int expectedDateCreatedMinute,
                                               int expectedDateCreatedSecond, string expectedText, int expectedUserId, int expectedPostId,
                                               int expectedTimeAcceptedYear, int expectedTimeAcceptedMonth, int expectedTimeAcceptedDay,
                                               int expectedTimeAcceptedHour, int expectedTimeAcceptedMinute, int expectedTimeAcceptedSecond,
                                               Boolean expectedIsAccepted)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            DateTime expectedTimeAccepted = DateTime.MinValue;
            if (expectedTimeAcceptedYear != 0)
                expectedTimeAccepted = new DateTime(expectedTimeAcceptedYear, expectedTimeAcceptedMonth, expectedTimeAcceptedDay, expectedTimeAcceptedHour, expectedTimeAcceptedMinute, expectedTimeAcceptedSecond);

            SolvrComment comment = new SolvrComment()
            {
                Id = expectedId,
                DateCreated = expectedDateCreated,
                Text = expectedText,
                UserId = expectedUserId,
                PostId = expectedPostId,
                TimeAccepted = expectedTimeAccepted,
                IsAccepted = expectedIsAccepted
            };

            //Act
            dbCtr.CreateComment(comment);
            Comment actualComment = dbCtr.GetComment(expectedId);

            //Assert
            AssertAreEqualWithMsg(expectedId, actualComment.Id, "id");
            AssertAreEqualWithMsg(expectedDateCreated, actualComment.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedText, actualComment.Text, "text");
            AssertAreEqualWithMsg(expectedUserId, actualComment.UserId, "userId");
            AssertAreEqualWithMsg(expectedPostId, actualComment.PostId, "postId");

            if (expectedTimeAcceptedYear != 0)
            {
                //Act
                SolvrComment actualSolvrComment = (SolvrComment)dbCtr.GetComment(expectedId);

                //Assert
                AssertAreEqualWithMsg(expectedTimeAccepted, actualSolvrComment.TimeAccepted, "timeAccepted");
                AssertAreEqualWithMsg(expectedIsAccepted, actualSolvrComment.IsAccepted, "isAccepted");
            }
        }



        [TestMethod]
        [DataRow(1, "massa tempor convallis nulla neque", "Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique.", "user", true, 2019, 07, 24, 21, 48, 58, 1, 0, 0)]
        [DataRow(2, "eget rutrum", "Aenean fermentum.", "post", true, 2036, 12, 10, 15, 23, 35, 0, 0, 1)]
        [DataRow(3, "ullamcorper augue a suscipit nulla", "Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.", "comment", true, 2030, 02, 07, 17, 12, 05, 0, 1, 0)]
        public void UpdateReportTestPositive(int expectedId, string expectedTitle, string expectedDescription, string expectedReportType, bool expectedIsResolved,
                                             int expectedDateCreatedYear, int expectedDateCreatedMonth, int expectedDateCreatedDay,
                                             int expectedDateCreatedHour, int expectedDateCreatedMinute, int expectedDateCreatedSecond,
                                             int expectedUserId, int expectedCommentId, int expectedPostId)
        {
            //Prepare
            DataAccesController dbCtr = new DataAccesController(true);
            DateTime expectedDateCreated = new DateTime(expectedDateCreatedYear, expectedDateCreatedMonth, expectedDateCreatedDay, expectedDateCreatedHour, expectedDateCreatedMinute, expectedDateCreatedSecond);
            Report report = new Report()
            {
                Title = expectedTitle,
                Description = expectedDescription,
                ReportType = expectedReportType,
                IsResolved = expectedIsResolved,
                DateCreated = expectedDateCreated,
                UserId = expectedUserId,
                CommentId = expectedCommentId,
                PostId = expectedPostId
            };

            //Act
            dbCtr.UpdateReport(report);
            Report actualReport = dbCtr.GetReport(expectedId);

            //Assert
            AssertAreEqualWithMsg(expectedId, actualReport.Id, "id");
            AssertAreEqualWithMsg(expectedTitle, actualReport.Title, "title");
            AssertAreEqualWithMsg(expectedDescription, actualReport.Description, "description");
            AssertAreEqualWithMsg(expectedIsResolved, actualReport.IsResolved, "isResolved");
            AssertAreEqualWithMsg(expectedDateCreated, actualReport.DateCreated, "dateCreated");
            AssertAreEqualWithMsg(expectedUserId, actualReport.UserId, "userId");
            AssertAreEqualWithMsg(expectedCommentId, actualReport.CommentId, "commentId");
            AssertAreEqualWithMsg(expectedPostId, actualReport.PostId, "postId");
            AssertAreEqualWithMsg(expectedReportType, actualReport.ReportType, "reportType");
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