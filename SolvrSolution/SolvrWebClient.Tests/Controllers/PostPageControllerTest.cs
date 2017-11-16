using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolvrLibrary;
using System.Collections.Generic;

namespace SolvrWebClient.Tests.Controllers
{
    [TestClass]
    public class PostPageControllerTest
    {
        [ClassCleanup]
        public void CleanUp()
        {
            //Databasen skal resetes her, hvordan vides ikke endnu.
            DBctr.Reset();
        }

        //ReadPost(); maybe not.
        //UpdatePost(); done
        //DeletePost(); done
        //ReportPost(); done

        //ReadComments();    out
        //UpdateComments();  out
        //DeleteComment();   out
        //VoteComment();     out
        //ReportComment();   out

        //For Physical posts.
        //LockPost();               done
        //ChooseAplicants();        ?
        //UnChooseAplicant();       ?

        #region UpdatePostDescriptionTest
        [TestMethod]
        [DataRow(1, "Description1")]
        [DataRow(2, "Description2")]
        [DataRow(3, "Description3")]
        [DataRow(4, "Description4")]
        [DataRow(5, "Description5")]
        public void UpdatePostTest(int postID, string newDescriptionString)
        {
            //Arrange
            PostCtr postCtr = new PostCtr();
            Post postToUpdate = postCtr.getPostById(postID);

            string expectedDescription = newDescriptionString;
            postToUpdate.Description = newDescriptionString;

            //Act
            postCtr.UpdatePost(postToUpdate);
            Post updatedPost = postCtr.getPostById(postID);
            string actualDescription = updatedPost.Description;

            DateTime dt = new DateTime(year month day hour minute second millisecond)

            //Assert
            string msg = "Expected that post Description was: " + expectedDescription + " But actual post Description was: " + actualDescription;
            Assert.AreEqual(expectedDescription, actualDescription, msg);
        }
        #endregion

        #region UpdatePostTitleTest(...)
        [TestMethod]
        [DataRow(1, "Title1")]
        [DataRow(2, "Title2")]
        [DataRow(3, "Title3")]
        [DataRow(4, "Title4")]
        [DataRow(5, "Title5")]
        public void UpdatePostTitleTest(int postID, string newTitleString)
        {
            //Arrange
            PostCtr postCtr = new PostCtr();
            Post postToUpdate = postCtr.getPostById(postID);
            string expectedTitle = newTitleString;
            postToUpdate.Title = newTitleString;

            //Act
            postCtr.UpdatePost(postToUpdate);
            Post updatedPost = postCtr.getPostById(postID);
            string actualTitle = updatedPost.Title;

            //Assert
            string msg = "Expected that post Title was: " + expectedTitle + " But actual post Title was: " + actualTitle;
            Assert.AreEqual(expectedTitle, actualTitle, msg);
        }
        #endregion

        #region UpdatePostBumpTimeTest(...)
        /*I programmet vil vi kun sende DateTime.Now med, men regner også med vi vil brue postUpdate på ctr til dette.
          Men for at kunne teste at fremtidige datoer virker sender vi en DateTime med*/
        [TestMethod]
        [DataRow(1, 2018, 8, 19, 19, 28, 15)]
        [DataRow(2, 2022, 7, 14, 15, 24, 12)]
        [DataRow(3, 2035, 4, 2, 14, 23, 55)]
        [DataRow(4, 2090, 5, 6, 12, 52, 44)]
        [DataRow(5, 2150, 5, 4, 23, 35, 24)]
        public void UpdatePostBumpTimeTest(int postID, int year, int mounth, int day, int hour, int minute, int second)
        {
            //Arrange
            PostCtr postCtr = new PostCtr();
            Post postToUpdate = postCtr.getPostById(postID);
            DateTime expectedBumpTime = new DateTime(year, mounth, day, hour, minute, second); //DateTime( year, mounth, day, hour, minute, sec) 
            postToUpdate.BumpTime = expectedBumpTime;

            //Act
            postCtr.UpdatePost(postToUpdate);
            Post updatedPost = postCtr.getPostById(postID);
            DateTime actualBumpTime = updatedPost.BumpTime;

            //Assert
            string msg = "Expected that post BumpTime was: " + expectedBumpTime + " But actual post BumpTime was: " + actualBumpTime;
            Assert.AreEqual(expectedBumpTime, actualBumpTime, msg);
        }
        #endregion

        #region UpdatePostCategoryTest(...)
        [TestMethod]
        [DataRow(1, 2)]
        [DataRow(2, 3)]
        [DataRow(3, 2)]
        [DataRow(4, 1)]
        [DataRow(5, 5)]
        public void UpdatePostCategoryTest(int postID, int categoryID)
        {
            //Arrange
            PostCtr postCtr = new PostCtr();
            Post postToUpdate = postCtr.getPostById(postID);
            Category newCategory = postCtr.getCategoryById(categoryID);

            Category expectedCategory = newCategory;
            postToUpdate.PostCategory = newCategory;

            //Act
            postCtr.UpdatePost(postToUpdate);
            Post updatedPost = postCtr.getPostById(postID);
            Category actualCategory = updatedPost.PostCategory;

            //Assert
            string msg = "Expected that post Category was: " + expectedCategory + " But actual post Category was: " + actualCategory;
            Assert.AreEqual(expectedCategory, actualCategory, msg);
        }
        #endregion(...)

        #region ReportPostTest(...)
        [TestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        [DataRow(3, false)]
        public void ReportPostTest(int postId, bool isReported)
        {
            //Arrange
            PostCtr postCtr = new PostCtr();
            bool expectedIsReported = isReported;

            //Act
            if (isReported)
            {
                postCtr.ReportPost(postId);
            }
            Post post = postCtr.FindPostById(postId);
            bool actualIsReported = post.IsReported;

            //Assert
            string msg = "Expected that post isReported was: " + expectedIsReported + " But actual post isReported was: " + actualIsReported;
            Assert.IsTrue(expectedIsReported == actualIsReported);
        }
        #endregion

        #region LockPostTest(...)
        [TestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        [DataRow(3, false)]
        public void LockPostTest(int physicalPostId, bool isLocked)
        {
            //Arrange
            PostCtr postCtr = new PostCtr();
            bool expectedIsLocked = isLocked;

            //Act
            if (isLocked)
            {
                postCtr.LockPost(physicalPostId);
            }
            Post post = postCtr.FindPostById(physicalPostId);
            bool actualIsLocked = post.IsLocked;

            //Assert
            string msg = "Expected that post isLocked was: " + expectedIsLocked + " But actual post isLocked was: " + actualIsLocked;
            Assert.IsTrue(expectedIsLocked == actualIsLocked);
        }
        #endregion

        #region AddAplicantToPhysicalPostTest(...)
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        [DataRow(1, 3)]
        [DataRow(1, 4)]
        [DataRow(1, 5)]
        public void AddAplicantToPhysicalPostTest(int physicalPostId, int userId)
        {
            //Arrange
            PostCtr postCtr = new PostCtr();
            DatabaseCtr dbCtr = new DatabaseCtr();                   //Database line, idk how yet.

            User expetedAplicant = dbPersonCtr.FindUserById(userId); //Database line, idk how yet.

            //Act
            postCtr.AddAplicantToPhysicalPost(userId, physicalPostId);

            //Assert
            Assert.AreEqual(actualAplicants, expectedAplicants);
        }
        #endregion
    }
}
