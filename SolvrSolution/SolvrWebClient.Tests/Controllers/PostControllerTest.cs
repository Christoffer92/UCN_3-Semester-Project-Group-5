using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolvrWebClient;
using SolvrWebClient.Controllers;
using DataAccesLayer.DAL;
using SolvrWebClient.Models;

namespace SolvrWebClient.Tests.Controllers
{
    [TestClass]
    public class PostControllerTest
    {

        private ISolvrDB DB;

        //[TestInitialize] and[TestCleanup] at the individual test level, [ClassInitialize] and[ClassCleanup] at the class level.
        [TestInitialize]
        public void Initialize()
        {
            DB = new MockDB();
        }

        [TestCleanup]
        public void Teardown()
        {
            MockDB.CloseDB();
            DB = null;
        }

        [TestMethod]
        [DataRow(1, "", "", "", "", 0, 0)]
        public void IndexTest(int postID, string eViewName, string eViewTitle, string eViewDescription, string eViewDateCreated, int eViewUserId, int eViewCommentCount)
        {
            // Arrange
            PostController controller = new PostController();

            // Act
            ViewResult result = controller.Index(postID) as ViewResult;

            // Assert
            string msg = "Expecter it to not be null and it is: " + result;
            Assert.IsNotNull(result, msg);

            msg = "Expecter it to not be "+ eViewName +" and it is: " + result.ViewName;
            Assert.AreEqual(eViewName, result.ViewName, msg);

            msg = "Expecter it to not be " + eViewTitle + " and it is: " + result.ViewBag.Title;
            Assert.AreEqual(eViewTitle, result.ViewBag.Title, msg);

            msg = "Expecter it to not be " + eViewDescription + " and it is: " + result.ViewBag.Description;
            Assert.AreEqual(eViewDescription, result.ViewBag.Description, msg);

            msg = "Expecter it to not be " + eViewDateCreated + " and it is: " + result.ViewBag.DateCreated;
            Assert.AreEqual(eViewDateCreated, result.ViewBag.DateCreated, msg);

            msg = "Expecter it to not be " + eViewUserId + " and it is: " + result.ViewBag.UserId;
            Assert.AreEqual(eViewUserId, result.ViewBag.UserId, msg);

            msg = "Expecter it to not be " + eViewCommentCount + " and it is: " + result.ViewBag.CommentList.count;
            Assert.AreEqual(eViewCommentCount, result.ViewBag.CommentList.count, msg);
        }

        [TestMethod]
        public void PhysicalIndexTest()
        {
            // Arrange
            PostController controller = new PostController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostCommentTest()
        {
            // Arrange
            PostController controller = new PostController();

            // Act
            ViewResult result = controller.PostComment(null) as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void ChooseSolvrTest()
        {
            // Arrange
            PostController controller = new PostController();

            // Act
            ViewResult result = controller.ChooseSolvr() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
