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
    public class OpretPosteringSideControllerTest
    {
        [TestMethod]
        [DataRow(null, 1, "Overheated Processor", "My Processor has overheated help!")]
        public void OpretPostering(List<Comment> Comments, int PostID, string Title, string Description)
        {
            // Arrange
            OpretPosteringSideController OPController = new OpretPosteringSideController();
            Category PostCategory = new Category();
            DateTime BumpTime = new DateTime();
            string tag1 = "Hardware";
            string tag2 = "Hot";
            List<String> TagsList = new List<String>();
            TagsList.Add(tag1 + tag2);
            DateTime DateCreated = new DateTime();

            // Act
            Post post = OPController.CreatePost(PostCategory, Comments, PostID, Title, Description, BumpTime, TagsList, DateCreated)
            OPController.AddPost(post);

            // Assert
            Assert.Equals(OPController.GetPostID(1), post);
        }
    }
}
