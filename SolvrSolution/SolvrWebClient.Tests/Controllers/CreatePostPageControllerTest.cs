using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolvrWebClient;
using SolvrWebClient.Controllers;
using SolvrLibrary;

namespace SolvrWebClient.Tests.Controllers
{
    //Hvilke tests skal med
    //Opret en postering = Opret title, tekst, kategori, tags og send til DB, Modtage en oprettet dato
    //Opret en fysiskpostering???? = Opret title, tekst, hemmelig tekst, kategori, tags og send til DB, Modtage en dato
    //View state = Er det der står på siden rigtigt
    //Tilføj en tag / Kategori
    //Skift til fysisk problem    


    [TestClass]
    public class CreatePostPageControllerTest
    {        
        #region Create Physical post test
        [TestMethod]
        [DataRow(1, "Gardening", null, 1, "Help planting a garden", "I have 70 acres of garden that needs planting", "GreenFingers", "TreeHugger", false, "I have beer", "6900", "Vestergade 14, Skjern")]
        [DataRow(10, "Electrical", null, 2, "Help installing lamp", "I need help with installing a new lamp", "Amplify", "PassMeLeftHandedPhillipsHead", false, "I have wine", "9000", "Borgergade 16, Aalborg")]
        [DataRow(23, "Moving", null, 4, "I need help!", "I need help moving a couch!", "WishIWasStronger", "SOS", false, "I have cola", "1100", "Svenskervej 2, København K")]
        public void CreatePhysicalPostTest(int expectedPostCategoryID, string expectedPostCategoryName, List<Comment> expectedPostComments,
                                        int expectedPostID, string expectedPostTitle, string expectedPostDescription, string tag1, string tag2, bool expectedPostIsLocked,
                                        string expectedPostAltDescription, string expectedPostZipCode, string expectedPostAddress)
        {
            // Arrange
            CreatePostCtr CPCtr = new CreatePostCtr();
            Category expectedPostCategory = new Category(expectedPostCategoryID, expectedPostCategoryName);
            DateTime expectedPostBumpTime = new DateTime();
            List<String> expectedPostTagsList = new List<String>();
            expectedPostTagsList.Add(tag1 + tag2);
            DateTime expectedPostDateCreated = new DateTime();

            PhysicalPost actualPhysicalPost = CPCtr.CreatePhysicalPost(expectedPostCategory, expectedPostComments, expectedPostID,
                                                 expectedPostTitle, expectedPostDescription, expectedPostBumpTime,
                                                 expectedPostTagsList, expectedPostDateCreated, expectedPostIsLocked,
                                                 expectedPostAltDescription, expectedPostZipCode, expectedPostAddress);

            // Act 
            int actualPostCategoryID = actualPhysicalPost.PostCategory.CategoryID;
            string actualPostCategoryName = actualPhysicalPost.PostCategory.CategoryName;
            List<Comment> actualPostComments = actualPhysicalPost.CommentsList;
            int actualPostID = actualPhysicalPost.PostID;
            string actualPostTitle = actualPhysicalPost.Title;
            string actualPostDescription = actualPhysicalPost.Description;
            DateTime actualPostBumpTime = actualPhysicalPost.BumpTime;
            List<String> actualPostTagsList = actualPhysicalPost.TagsList;
            DateTime actualPostDateCreated = actualPhysicalPost.DateCreated;

            bool actualPostIsLocked = actualPhysicalPost.IsLocked;
            string actualPostAltDescription = actualPhysicalPost.AltDescription;
            string actualPostZipCode = actualPhysicalPost.ZipCode;
            string actualPostAddress = actualPhysicalPost.Address;

            // Assert
            string msg = "Expected that post category ID was: " + expectedPostCategoryID + " But actual post category ID was: " + actualPostCategoryID;
            Assert.AreEqual(expectedPostCategoryID, actualPostCategoryID, msg);

            msg = "Expected that post category Name was: " + expectedPostCategoryName + " But actual post category Name was: " + actualPostCategoryName;
            Assert.AreEqual(expectedPostCategoryName, actualPostCategoryName, msg);

            msg = "Expected that post Comments was: " + expectedPostComments + " But actual post category Comment was: " + actualPostComments;
            Assert.AreEqual(expectedPostComments, actualPostComments, msg);

            msg = "Expected that post ID was: " + expectedPostID + " But actual post ID was: " + actualPostID;
            Assert.AreEqual(expectedPostID, actualPostID, msg);

            msg = "Expected that post Title was: " + expectedPostTitle + " But actual post Title was: " + actualPostTitle;
            Assert.AreEqual(expectedPostTitle, actualPostTitle, msg);

            msg = "Expected that post Description was: " + expectedPostDescription + " But actual post Description was: " + actualPostDescription;
            Assert.AreEqual(expectedPostDescription, actualPostDescription, msg);

            msg = "Expected that post BumpTime was: " + expectedPostBumpTime + " But actual post BumpTime was: " + actualPostBumpTime;
            Assert.AreEqual(expectedPostBumpTime, actualPostBumpTime, msg);

            msg = "Expected that post TagsList was: " + expectedPostTagsList + " But actual post TagsList was: " + actualPostTagsList;
            Assert.AreEqual(expectedPostTagsList, actualPostTagsList, msg);

            msg = "Expected that post DateCreated was: " + expectedPostDateCreated + " But actual post DateCreated was: " + actualPostDateCreated;
            Assert.AreEqual(expectedPostDateCreated, actualPostDateCreated, msg);

            msg = "Expected that post IsLocked was: " + expectedPostIsLocked + " But actual post IsLocked was: " + actualPostIsLocked;
            Assert.AreEqual(expectedPostIsLocked, actualPostIsLocked, msg);

            msg = "Expected that post AltDescription was: " + expectedPostAltDescription + " But actual post AltDescription was: " + actualPostAltDescription;
            Assert.AreEqual(expectedPostAltDescription, actualPostAltDescription, msg);

            msg = "Expected that post ZipCode was: " + expectedPostZipCode + " But actual post ZipCode was: " + actualPostZipCode;
            Assert.AreEqual(expectedPostZipCode, actualPostZipCode, msg);

            msg = "Expected that post Address was: " + expectedPostAddress + " But actual post Address was: " + actualPostAddress;
            Assert.AreEqual(expectedPostAddress, actualPostDateCreated, msg);
        }
        #endregion

        #region Add physical post test
        [TestMethod]
        [DataRow(1, "Computer", null, 1, "Overheated Processor", "My Processor has overheated help!", "Hardware", "Hot")]
        [DataRow(10, "Garden", null, 2, "Dead flowers", "My flowers have died help! what do?!", "Dead", "RipFlowers")]
        [DataRow(20, "Accessories", null, 3, "Bland jewels", "My jewels have become bland overtime. Any tips on shining them up?", "Jewels", "Bland")]
        [DataRow(23, "Moving", null, 4, "I need help!", "I need help moving a couch!", "WishIWasStronger", "SOS")]
        [DataRow(900, "Kitchen", null, 5, "Fridge noise!", "My Processor has overheated help!", "AlienNoises", "Fridge")]
        [DataRow(50, "Food", null, 6, "Burnt spaghetti", "I have burnt my spaghetti and my arms are heavy!", "MomsSpaghetti", "EminemCantFixThis")]
        [DataRow(60, "DIY handywork", null, 7, "3D hologram", "What angle does my inverted pyramid need to be in order to obtain 3d hologram", "FutureWaifu", "TeknologiIsTheFuture")]
        public void AddNonPhysicalPostTest(int expectedPostCategoryID, string expectedPostCategoryName, List<Comment> expectedPostComments,
                                        int expectedPostID, string expectedPostTitle, string expectedPostDescription, string tag1, string tag2, bool expectedPostIsLocked,
                                        string expectedPostAltDescription, string expectedPostZipCode, string expectedPostAddress)
        {
            // Arrange
            CreatePostCtr CPCtr = new CreatePostCtr();
            Category expectedPostCategory = new Category(expectedPostCategoryID, expectedPostCategoryName);
            DateTime expectedPostBumpTime = new DateTime();
            List<String> expectedPostTagsList = new List<String>();
            expectedPostTagsList.Add(tag1 + tag2);
            DateTime expectedPostDateCreated = new DateTime();

            PhysicalPost expectedPhysicalPost = CPCtr.CreatePhysicalPost(expectedPostCategory, expectedPostComments, expectedPostID,
                                                 expectedPostTitle, expectedPostDescription, expectedPostBumpTime,
                                                 expectedPostTagsList, expectedPostDateCreated, expectedPostIsLocked,
                                                 expectedPostAltDescription, expectedPostZipCode, expectedPostAddress);

            // Act         
            CPCtr.AddPost(expectedPhysicalPost);
            Post actualPhysicalPost = CPCtr.GetPostByID(expectedPostID);

            //Assert
            AssertTwoPostsAreEqual(expectedPhysicalPost, actualPhysicalPost);
        }



        #endregion

        #region Create non physical post test
        [TestMethod]
        [DataRow(1, "Computer", null, 1, "Overheated Processor", "My Processor has overheated help!", "Hardware", "Hot")]
        [DataRow(10, "Garden", null, 2, "Dead flowers", "My flowers have died help! what do?!", "Dead", "RipFlowers")]
        [DataRow(20, "Accessories", null, 3, "Bland jewels", "My jewels have become bland overtime. Any tips on shining them up?", "Jewels", "Bland")]
        [DataRow(900, "Kitchen", null, 5, "Fridge noise!", "My Processor has overheated help!", "AlienNoises", "Fridge")]
        [DataRow(50, "Food", null, 6, "Burnt spaghetti", "I have burnt my spaghetti and my arms are heavy!", "MomsSpaghetti", "EminemCantFixThis")]
        [DataRow(60, "DIY handywork", null, 7, "3D hologram", "What angle does my inverted pyramid need to be in order to obtain 3d hologram", "FutureWaifu", "TeknologiIsTheFuture")]
        public void CreateNonPhysicalPostTest(int expectedPostCategoryID, string expectedPostCategoryName, List<Comment> expectedPostComments,
                                        int expectedPostID, string expectedPostTitle, string expectedPostDescription, string tag1, string tag2)
        {
            // Arrange
            CreatePostCtr CPCtr = new CreatePostCtr();
            Category expectedPostCategory = new Category(expectedPostCategoryID, expectedPostCategoryName);
            DateTime expectedPostBumpTime = new DateTime();
            List<String> expectedPostTagsList = new List<String>();
            expectedPostTagsList.Add(tag1 + tag2);
            DateTime expectedPostDateCreated = new DateTime();

            Post actualPost = CPCtr.CreatePost(expectedPostCategory, expectedPostComments, expectedPostID,
                                                 expectedPostTitle, expectedPostDescription, expectedPostBumpTime,
                                                 expectedPostTagsList, expectedPostDateCreated);

            // Act 
            int actualPostCategoryID = actualPost.PostCategory.CategoryID;
            string actualPostCategoryName = actualPost.PostCategory.CategoryName;
            List<Comment> actualPostComments = actualPost.CommentsList;
            int actualPostID = actualPost.PostID;
            string actualPostTitle = actualPost.Title;
            string actualPostDescription = actualPost.Description;
            DateTime actualPostBumpTime = actualPost.BumpTime;
            List<String> actualPostTagsList = actualPost.TagsList;
            DateTime actualPostDateCreated = actualPost.DateCreated;

            // Assert
            string msg = "Expected that post category ID was: " + expectedPostCategoryID + " But actual post category ID was: " + actualPostCategoryID;
            Assert.AreEqual(expectedPostCategoryID, actualPostCategoryID, msg);

            msg = "Expected that post category Name was: " + expectedPostCategoryName + " But actual post category Name was: " + actualPostCategoryName;
            Assert.AreEqual(expectedPostCategoryName, actualPostCategoryName, msg);

            msg = "Expected that post Comments was: " + expectedPostComments + " But actual post category Comment was: " + actualPostComments;
            Assert.AreEqual(expectedPostComments, actualPostComments, msg);

            msg = "Expected that post ID was: " + expectedPostID + " But actual post ID was: " + actualPostID;
            Assert.AreEqual(expectedPostID, actualPostID, msg);

            msg = "Expected that post Title was: " + expectedPostTitle + " But actual post Title was: " + actualPostTitle;
            Assert.AreEqual(expectedPostTitle, actualPostTitle, msg);

            msg = "Expected that post Description was: " + expectedPostDescription + " But actual post Description was: " + actualPostDescription;
            Assert.AreEqual(expectedPostDescription, actualPostDescription, msg);

            msg = "Expected that post BumpTime was: " + expectedPostBumpTime + " But actual post BumpTime was: " + actualPostBumpTime;
            Assert.AreEqual(expectedPostBumpTime, actualPostBumpTime, msg);

            msg = "Expected that post TagsList was: " + expectedPostTagsList + " But actual post TagsList was: " + actualPostTagsList;
            Assert.AreEqual(expectedPostTagsList, actualPostTagsList, msg);

            msg = "Expected that post DateCreated was: " + expectedPostDateCreated + " But actual post DateCreated was: " + actualPostDateCreated;
            Assert.AreEqual(expectedPostDateCreated, actualPostDateCreated, msg);
        }
        #endregion

        #region Add non physical post test
        [TestMethod]
        [DataRow(1, "Computer", null, 1, "Overheated Processor", "My Processor has overheated help!", "Hardware", "Hot")]
        [DataRow(10, "Garden", null, 2, "Dead flowers", "My flowers have died help! what do?!", "Dead", "RipFlowers")]
        [DataRow(20, "Accessories", null, 3, "Bland jewels", "My jewels have become bland overtime. Any tips on shining them up?", "Jewels", "Bland")]
        [DataRow(23, "Moving", null, 4, "I need help!", "I need help moving a couch!", "WishIWasStronger", "SOS")]
        [DataRow(900, "Kitchen", null, 5, "Fridge noise!", "My Processor has overheated help!", "AlienNoises", "Fridge")]
        [DataRow(50, "Food", null, 6, "Burnt spaghetti", "I have burnt my spaghetti and my arms are heavy!", "MomsSpaghetti", "EminemCantFixThis")]
        [DataRow(60, "DIY handywork", null, 7, "3D hologram", "What angle does my inverted pyramid need to be in order to obtain 3d hologram", "FutureWaifu", "TeknologiIsTheFuture")]
        public void AddNonPhysicalPostTest(int expectedPostCategoryID, string expectedPostCategoryName, List<Comment> expectedPostComments, 
                                        int expectedPostID, string expectedPostTitle, string expectedPostDescription, string tag1, string tag2)
        {
            // Arrange
            CreatePostCtr CPCtr = new CreatePostCtr();
            Category expectedPostCategory = new Category(expectedPostCategoryID, expectedPostCategoryName);
            DateTime expectedPostBumpTime = new DateTime();
            List<String> expectedPostTagsList = new List<String>();
            expectedPostTagsList.Add(tag1 + tag2);
            DateTime expectedPostDateCreated = new DateTime();
            
            Post expectedPost = CPCtr.CreatePost(expectedPostCategory, expectedPostComments, expectedPostID,
                                                 expectedPostTitle, expectedPostDescription, expectedPostBumpTime,
                                                 expectedPostTagsList, expectedPostDateCreated);
            
            // Act         
            CPCtr.AddPost(expectedPost);
            Post actualPost = CPCtr.GetPostByID(expectedPostID);

            //Assert
            AssertTwoPostsAreEqual(expectedPost, actualPost);
        }
#endregion

        private void AssertTwoPostsAreEqual(Post expectedPost, Post actualPost)
        {
            int expectedPostCategoryID = expectedPost.PostCategory.CategoryID;
            string expectedPostCategoryName = expectedPost.PostCategory.CategoryName;
            List<Comment> expectedPostComments = expectedPost.CommentsList;
            int expectedPostID = expectedPost.PostID;
            string expectedPostTitle = expectedPost.Title;
            string expectedPostDescription = expectedPost.Description;
            DateTime expectedPostBumpTime = expectedPost.BumpTime;
            List<String> expectedPostTagsList = expectedPost.TagsList;
            DateTime expectedPostDateCreated = expectedPost.DateCreated;

            int actualPostCategoryID = actualPost.PostCategory.CategoryID;
            string actualPostCategoryName = actualPost.PostCategory.CategoryName;
            List<Comment> actualPostComments = actualPost.CommentsList;
            int actualPostID = actualPost.PostID;
            string actualPostTitle = actualPost.Title;
            string actualPostDescription = actualPost.Description;
            DateTime actualPostBumpTime = actualPost.BumpTime;
            List<String> actualPostTagsList = actualPost.TagsList;
            DateTime actualPostDateCreated = actualPost.DateCreated;

            // Assert
            string msg = "Expected that post category ID was: " + expectedPostCategoryID + " But actual post category ID was: " + actualPostCategoryID;
            Assert.AreEqual(expectedPostCategoryID, actualPostCategoryID, msg);

            msg = "Expected that post category Name was: " + expectedPostCategoryName + " But actual post category Name was: " + actualPostCategoryName;
            Assert.AreEqual(expectedPostCategoryName, actualPostCategoryName, msg);

            msg = "Expected that post Comments was: " + expectedPostComments + " But actual post category Comment was: " + actualPostComments;
            Assert.AreEqual(expectedPostComments, actualPostComments, msg);

            msg = "Expected that post ID was: " + expectedPostID + " But actual post ID was: " + actualPostID;
            Assert.AreEqual(expectedPostID, actualPostID, msg);

            msg = "Expected that post Title was: " + expectedPostTitle + " But actual post Title was: " + actualPostTitle;
            Assert.AreEqual(expectedPostTitle, actualPostTitle, msg);

            msg = "Expected that post Description was: " + expectedPostDescription + " But actual post Description was: " + actualPostDescription;
            Assert.AreEqual(expectedPostDescription, actualPostDescription, msg);

            msg = "Expected that post BumpTime was: " + expectedPostBumpTime + " But actual post BumpTime was: " + actualPostBumpTime;
            Assert.AreEqual(expectedPostBumpTime, actualPostBumpTime, msg);

            msg = "Expected that post TagsList was: " + expectedPostTagsList + " But actual post TagsList was: " + actualPostTagsList;
            Assert.AreEqual(expectedPostTagsList, actualPostTagsList, msg);

            msg = "Expected that post DateCreated was: " + expectedPostDateCreated + " But actual post DateCreated was: " + actualPostDateCreated;
            Assert.AreEqual(expectedPostDateCreated, actualPostDateCreated, msg);
        }

        private void AssertTwoPhysicalPostAreEqual(PhysicalPost expectedPhysicalPost, PhysicalPost actualPhysicalPost)
        {
            int expectedPhysicalPostCategoryID = expectedPhysicalPost.PostCategory.CategoryID;
            string expectedPhysicalPostCategoryName = expectedPhysicalPost.PostCategory.CategoryName;
            List<Comment> expectedPhysicalPostComments = expectedPhysicalPost.CommentsList;
            int expectedPhysicalPostID = expectedPhysicalPost.PostID;
            string expectedPhysicalPostTitle = expectedPhysicalPost.Title;
            string expectedPhysicalPostDescription = expectedPhysicalPost.Description;
            DateTime expectedPhysicalPostBumpTime = expectedPhysicalPost.BumpTime;
            List<String> expectedPhysicalPostTagsList = expectedPhysicalPost.TagsList;
            DateTime expectedPhysicalPostDateCreated = expectedPhysicalPost.DateCreated;
            bool expectedPhysicalPostIsLocked = expectedPhysicalPost.IsLocked;
            string expectedPhysicalPostAltDescription = expectedPhysicalPost.AltDescription;
            string expectedPhysicalPostZipCode = expectedPhysicalPost.ZipCode;
            string expectedPhysicalPostAddress = expectedPhysicalPost.Address;

            int actualPostCategoryID = actualPhysicalPost.PostCategory.CategoryID;
            string actualPostCategoryName = actualPhysicalPost.PostCategory.CategoryName;
            List<Comment> actualPostComments = actualPhysicalPost.CommentsList;
            int actualPostID = actualPhysicalPost.PostID;
            string actualPostTitle = actualPhysicalPost.Title;
            string actualPostDescription = actualPhysicalPost.Description;
            DateTime actualPostBumpTime = actualPhysicalPost.BumpTime;
            List<String> actualPostTagsList = actualPhysicalPost.TagsList;
            DateTime actualPostDateCreated = actualPhysicalPost.DateCreated;
            bool actualPostIsLocked = actualPhysicalPost.IsLocked;
            string actualPostAltDescription = actualPhysicalPost.AltDescription;
            string actualPostZipCode = actualPhysicalPost.ZipCode;
            string actualPostAddress = actualPhysicalPost.Address;

            // Assert
            string msg = "Expected that post category ID was: " + expectedPhysicalPostCategoryID + " But actual post category ID was: " + actualPostCategoryID;
            Assert.AreEqual(expectedPhysicalPostCategoryID, actualPostCategoryID, msg);

            msg = "Expected that post category Name was: " + expectedPhysicalPostCategoryName + " But actual post category Name was: " + actualPostCategoryName;
            Assert.AreEqual(expectedPhysicalPostCategoryName, actualPostCategoryName, msg);

            msg = "Expected that post Comments was: " + expectedPhysicalPostComments + " But actual post category Comment was: " + actualPostComments;
            Assert.AreEqual(expectedPhysicalPostComments, actualPostComments, msg);

            msg = "Expected that post ID was: " + expectedPhysicalPostID + " But actual post ID was: " + actualPostID;
            Assert.AreEqual(expectedPhysicalPostID, actualPostID, msg);

            msg = "Expected that post Title was: " + expectedPhysicalPostTitle + " But actual post Title was: " + actualPostTitle;
            Assert.AreEqual(expectedPhysicalPostTitle, actualPostTitle, msg);

            msg = "Expected that post Description was: " + expectedPhysicalPostDescription + " But actual post Description was: " + actualPostDescription;
            Assert.AreEqual(expectedPhysicalPostDescription, actualPostDescription, msg);

            msg = "Expected that post BumpTime was: " + expectedPhysicalPostBumpTime + " But actual post BumpTime was: " + actualPostBumpTime;
            Assert.AreEqual(expectedPhysicalPostBumpTime, actualPostBumpTime, msg);

            msg = "Expected that post TagsList was: " + expectedPhysicalPostTagsList + " But actual post TagsList was: " + actualPostTagsList;
            Assert.AreEqual(expectedPhysicalPostTagsList, actualPostTagsList, msg);

            msg = "Expected that post DateCreated was: " + expectedPhysicalPostDateCreated + " But actual post DateCreated was: " + actualPostDateCreated;
            Assert.AreEqual(expectedPhysicalPostDateCreated, actualPostDateCreated, msg);

            msg = "Expected that post IsLocked was: " + expectedPhysicalPostIsLocked + " But actual post IsLocked was: " + actualPostIsLocked;
            Assert.AreEqual(expectedPhysicalPostIsLocked, actualPostIsLocked, msg);

            msg = "Expected that post AltDescription was: " + expectedPhysicalPostAltDescription + " But actual post AltDescription was: " + actualPostAltDescription;
            Assert.AreEqual(expectedPhysicalPostAltDescription, actualPostAltDescription, msg);

            msg = "Expected that post ZipCode was: " + expectedPhysicalPostZipCode + " But actual post ZipCode was: " + actualPostZipCode;
            Assert.AreEqual(expectedPhysicalPostZipCode, actualPostZipCode, msg);

            msg = "Expected that post Address was: " + expectedPhysicalPostAddress + " But actual post Address was: " + actualPostAddress;
            Assert.AreEqual(expectedPhysicalPostAddress, actualPostDateCreated, msg);
        }
    }
}