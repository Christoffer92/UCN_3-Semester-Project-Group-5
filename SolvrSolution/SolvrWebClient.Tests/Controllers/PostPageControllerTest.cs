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
        //UpdatePost();
        //DeletePost();
        //ReportPost();

        //ReadComments();
        //UpdateComments();
        //DeleteComment();
        //VoteComment();
        //ReportComment();

        //For Physical posts.
        //LockPost();
        //ChooseAplicants();
        //UnChooseAplicant();


        [TestMethod]
        [DataRow(1, "Description1")]
        [DataRow(2, "Description2")]
        [DataRow(3, "Description3")]
        [DataRow(4, "Description4")]
        [DataRow(5, "Description5")]
        public void UpdatePostDesciptionTest(int postID, string newDescriptionString)
        {
            //Arrange
            PostCtr postCtr = new PostCtr();
            Post postToUpdate = postCtr.getPostById(postID);

            Description expectedDescription = postCtr.getDescription(newDescriptionString);

            postToUpdate.PostDescription = expectedDescription;

            //Act
            postCtr.UpdatePost(postToUpdate);
            Post updatedPost = postCtr.getPostById(2);
            string actualDescription = updatedPost.Description;

            //Assert
            string msg = "Expected that post Description was: " + expectedDescription + " But actual post Description was: " + actualDescription;
            Assert.AreEqual(expectedDescription, actualDescription, msg);
        }



        public void UpdatePostTitleTest(int postID, string newTitleString)
        {
            //Arrange
            PostCtr postCtr = new PostCtr();
            Post postToUpdate = postCtr.getPostById(postID);

            string expectedTitle = postCtr.getTitle(newTitleString);

            postToUpdate.PostTitle = expectedTitle;

            //Act
            postCtr.UpdatePost(postToUpdate);
            Post updatedPost = postCtr.getPostById(2);
            string actualTitle = updatedPost.Title;

            //Assert
            string msg = "Expected that post Title was: " + expectedTitle + " But actual post Title was: " + actualTitle;
            Assert.AreEqual(expectedTitle, actualTitle, msg);
        }
    }
}
