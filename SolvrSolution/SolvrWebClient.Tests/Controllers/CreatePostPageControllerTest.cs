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
    [TestClass]
    public class CreatePostPageControllerTest
    {
        private const string fiveHundredCharacters = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sit amet dictum purus. Morbi at vestibulum est, non porttitor ante. Ut in erat quis felis sodales varius. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In facilisis sem non purus auctor molestie. Curabitur dictum ante eu turpis volutpat pretium. Proin dui tortor, viverra ut felis vel, condimentum ornare massa. Duis dapibus, dui vel blandit vestibulum, massa ex iaculis ipsum, id posuere.";
        private const string fiveHundredCharactersMinusOne = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sit amet dictum purus. Morbi at vestibulum est, non porttitor ante. Ut in erat quis felis sodales varius. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In facilisis sem non purus auctor molestie. Curabitur dictum ante eu turpis volutpat pretium. Proin dui tortor, viverra ut felis vel, condimentum ornare massa. Duis dapibus, dui vel blandit vestibulum, massa ex iaculis ipsum, id posuere";


        private MockDB _DB;

        //[TestInitialize] and[TestCleanup] at the individual test level, [ClassInitialize] and[ClassCleanup] at the class level.
        [TestInitialize]
        public void Initialize()
        {
            _DB = new MockDB();
        }


        #region Create Physical post tests

        [TestMethod]

        //AltDescription min nr of characters
        [DataRow(1, "Lorem", "9000", "Solskinsvej 5")]
        //AltDescription min+1 nr of characters
        [DataRow(2, "Lorem.", "9210", "Blåbærvej 10")]
        //AltDescription max   nr of characters
        [DataRow(3, fiveHundredCharacters+fiveHundredCharacters, "7700", "Gedesvinget 2, 2 TV")]
        //AltDescription max-1 nr of characters
        [DataRow(4, fiveHundredCharacters+fiveHundredCharactersMinusOne, "8865", "Fugl Allé 5A")]

        //Zipcode min   nr of characters
        [DataRow(5, "Lorem ipsum dolor sit amet.", "DEN", "Solskinsvej 5")]
        //Zipcode min+1 nr of characters
        [DataRow(6, "Consectetur adipiscing elit.", "1234", "Blåbærvej 10")]
        //Zipcode max   nr of characters
        [DataRow(7, "Donec sit amet dictum purus.", "ORE 005487", "Gedesvinget 2, 2 TV")]
        //Zipcode max-1 nr of characters
        [DataRow(8, "Morbi at vestibulum est, non porttitor ante.", "UK 645827", "Fugl Allé 5A")]

        //Address min   nr of characters
        [DataRow(9, "Lorem ipsum dolor sit amet.", "9000", "Ø 1")]
        //Address min+1 nr of characters
        [DataRow(10, "Consectetur adipiscing elit.", "9210", "Gade")]
        //Address max   nr of characters
        [DataRow(11, "Donec sit amet dictum purus.", "7700", "Phasellus viverra ullamcorper metus et massa nunc.")]
        //Address max-1 nr of characters
        [DataRow(12, "Morbi at vestibulum est, non porttitor ante.", "8865", "Phasellus viverra ullamcorper metus et massa nunc")]

        public void CreatePhysicalPostTest(int nrOfTags, string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            // Arrange
            string expectedTitle = "Morbi cursus.";

            string expectedDescription = "Lorem ipsum dolor sit amet.";

            List<string> expectedTags = new List<string>() { "Hardware", "Hot", "Dead", "RipFlowers", "Jewels", "Bland", "AlienNoises", "Fridge", "MomsSpaghetti", "EminemCantFixThis", "FutureWaifu", "TeknologiIsTheFuture" };
            for (int i = 0; nrOfTags < expectedTags.Count; i++)
            {
                expectedTags.Remove(expectedTags.First());
            }

            User expectedUser = new User("Tester", "TT@DD.SS", "TestUser123", "TestPass");

            Category expectedCategory = new Category();

            var controller = new CreatePostController(_DB);

            // Act 

            PhysicalPost actualPost = controller.CreatePhysicalPostModel(expectedUser, expectedTitle, expectedDescription, expectedCategory, expectedTags, expectedAltDescription, expectedZipcode, expectedAddress); // this method has to return the newly created object after its ID is set from the DB

            DateTime expectedBumpTime = new DateTime();

            DateTime expectedDateCreated = new DateTime();


            // Assert

            //PostID should be 1 as there is already 0 test posts in the Mock DB.
            string msg = "Expected that post Id was: 1 But actual post ID was: " + actualPost.Id;
            Assert.AreEqual(1, actualPost.Id, msg);

            //TItle Assert
            msg = "Expected that post Title was: " + expectedTitle + " But actual post Title was: " + actualPost.Title;
            Assert.AreEqual(expectedTitle, actualPost.Title, msg);

            //Description Assert
            msg = "Expected that post Description was: " + expectedDescription + " But actual post Description was: " + actualPost.Description;
            Assert.AreEqual(expectedDescription, actualPost.Description, msg);

            //Tags assert. Number of tags defined in the Datarow, tags are predefined.
            msg = "Expected that post Tags.Count was: " + expectedTags + " But actual post TagsList.Count was: " + actualPost.Tags.Count;
            Assert.AreEqual(expectedTags.Count, actualPost.Tags.Count, msg);

            //BumpTime Assert, check if theres a better way to test this
            msg = "Expected that post BumpTime.TimeOfDay was around: " + expectedBumpTime.TimeOfDay + " But actual post BumpTime was: " + actualPost.BumpTime.TimeOfDay;
            Assert.AreEqual(expectedBumpTime.TimeOfDay, actualPost.BumpTime.TimeOfDay, msg);

            //DateCreated Assert,  check if theres a better way to test this
            msg = "Expected that post DateCreated.TimeOfDay was around: " + expectedDateCreated.TimeOfDay + " But actual post DateCreated was: " + actualPost.DateCreated.TimeOfDay;
            Assert.AreEqual(expectedDateCreated.TimeOfDay, actualPost.DateCreated.TimeOfDay, msg);

            //Owner Assert
            msg = "Expected that post User was around: " + expectedUser + " But actual post User was: " + actualPost.User;
            Assert.AreEqual(expectedUser, actualPost.User, msg);

            //Category Assert
            msg = "Expected that post Category was: " + expectedCategory + " But actual post category Name was: " + actualPost.Category;
            Assert.AreEqual(expectedCategory, actualPost.Category, msg);

            //Comments Assert
            msg = "Expected that post Comments was empty. But actual post category Comments was: " + actualPost.Comments.Count;
            Assert.AreEqual(0, actualPost.Comments.Count, msg);

            //PhysicalID should be 1 as there is already 0 test posts in the Mock DB.
            msg = "Expected that post PhysId was: 1 But actual post ID was: " + actualPost.PhysId;
            Assert.AreEqual(1, actualPost.PhysId, msg);

            //IsLocked Assert
            msg = "Expected that post Islocked was False. But actual post IsLocked was: " + actualPost.IsLocked;
            Assert.AreEqual(0, actualPost.IsLocked, msg);

            //AltDescription Assert
            msg = "Expected that post AltDescription was: " + expectedAltDescription + " But actual post AltDescription was: " + actualPost.AltDescription;
            Assert.AreEqual(expectedAltDescription, actualPost.AltDescription, msg);

            //Zipcode Assert
            msg = "Expected that post Zipcode was " + expectedZipcode + ". But actual post Zipcode Comment was: " + actualPost.ZipCode;
            Assert.AreEqual(expectedZipcode, actualPost.ZipCode, msg);

            //Address Assert
            msg = "Expected that post Address was " + expectedAddress + ". But actual post category Comment was: " + actualPost.Address;
            Assert.AreEqual(expectedAddress, actualPost.Address, msg);
        }

        [TestMethod]
        //AltDescription min-1 nr of characters
        [DataRow(2, "Lore", "9210", "Blåbærvej 10")]
        //AltDescription max+1 nr of characters
        [DataRow(4, "1"+fiveHundredCharacters + fiveHundredCharactersMinusOne, "8865", "Fugl Allé 5A")]
        
        //Zipcode min-1 nr of characters
        [DataRow(6, "Consectetur adipiscing elit.", "12", "Blåbærvej 10")]
        //Zipcode max+1 nr of characters
        [DataRow(8, "Morbi at vestibulum est, non porttitor ante.", "USA 6458273", "Fugl Allé 5A")]
        
        //Address min-1 nr of characters
        [DataRow(10, "Consectetur adipiscing elit.", "9210", "Ål")]
        //Address max+1 nr of characters
        [DataRow(12, "Morbi at vestibulum est, non porttitor ante.", "8865", "Phasellus viverra ullamcorper metus et massa nunc..")]
        public void CreatePhysicalPostNegativeTest(int nrOfTags, string expectedAltDescription, string expectedZipcode, string expectedAddress)
        {
            // Arrange
            string expectedTitle = "Morbi cursus.";

            string expectedDescription = "Lorem ipsum dolor sit amet.";

            List<string> expectedTagsList = new List<string>() { "Hardware", "Hot", "Dead", "RipFlowers", "Jewels", "Bland", "AlienNoises", "Fridge", "MomsSpaghetti", "EminemCantFixThis", "FutureWaifu", "TeknologiIsTheFuture" };
            for (int i = 0; nrOfTags < expectedTagsList.Count; i++)
            {
                expectedTagsList.Remove(expectedTagsList.First());
            }

            User expectedUser = new User("Tester", "TT@DD.SS", "TestUser123", "TestPass");

            Category expectedCategory = new Category();

            var controller = new CreatePostController(_DB);

            bool success = true;


            // Act 

            try
            {
                controller.CreatePhysicalPostModel(expectedUser, expectedTitle, expectedDescription, expectedCategory, expectedTagsList, expectedAltDescription, expectedZipcode, expectedAddress); // this method has to return the newly created object after its ID is set from the DB

            }
            catch (Exception)
            {
                success = false;
            }


            // Assert

            Assert.IsFalse(success);
        }
        #endregion

        #region Create post test

        [TestMethod]

        //Title min nr of characters
        [DataRow("Car", "Lorem ipsum dolor sit amet.", 1)]
        //Title min+1 nr of characters
        [DataRow("Bird", "Consectetur adipiscing elit.", 2)]
        //Title max nr of characters
        [DataRow("Lorem ipsum dolor sit amet, consectetur cras amet.", "Donec sit amet dictum purus.", 3)]
        //Title max-1 nr of characters
        [DataRow("Lorem ipsum dolor sit amet, consectetur volutpat.", "Morbi at vestibulum est, non porttitor ante.", 4)]


        //Description min nr of characters
        [DataRow("Ut mauris.", "Lorum", 5)]
        //Description min+1 nr of characters
        [DataRow("Morbi cursus.", "Semper", 6)]
        //Description max nr of characters
        [DataRow("Nam quis.", fiveHundredCharacters+fiveHundredCharacters+fiveHundredCharacters, 7)]
        //Description max-1 nr of characters
        [DataRow("Lorem ipsum.", fiveHundredCharacters+fiveHundredCharacters+fiveHundredCharactersMinusOne, 8)]  
        
        public void CreatePostTest(string expectedPostTitle, string expectedPostDescription, int nrOfTags)
        {
            // Arrange
            List<string> expectedTags = new List<string>() { "Hardware", "Hot", "Dead", "RipFlowers", "Jewels", "Bland", "AlienNoises", "Fridge", "MomsSpaghetti", "EminemCantFixThis", "FutureWaifu", "TeknologiIsTheFuture" };
            for (int i = 0; nrOfTags < expectedTags.Count; i++)
            {
                expectedTags.Remove(expectedTags.First());
            }

            User expectedUser = new User("Tester", "TT@DD.SS", "TestUser123", "TestPass");

            Category expectedCategory = new Category();

            var controller = new CreatePostController(_DB);

            // Act 

            Post actualPost = controller.CreatePostModel(expectedUser, expectedPostTitle, expectedPostDescription, expectedCategory, expectedTags); // this method has to return the newly created object after its ID is set from the DB

            DateTime expectedBumpTime = new DateTime();

            DateTime expectedDateCreated = new DateTime();


            // Assert

            //ID should be 1 as there is already 0 test posts in the Mock DB.
            string msg = "Expected that post ID was: 1 But actual post ID was: " + actualPost.Id;
            Assert.AreEqual(1, actualPost.Id, msg);

            //TItle Assert
            msg = "Expected that post Title was: " + expectedPostTitle + " But actual post Title was: " + actualPost.Title;
            Assert.AreEqual(expectedPostTitle, actualPost.Title, msg);

            //Description Assert
            msg = "Expected that post Description was: " + expectedPostDescription + " But actual post Description was: " + actualPost.Description;
            Assert.AreEqual(expectedPostDescription, actualPost.Description, msg);

            //Tags assert. Number of tags defined in the Datarow, tags are predefined.
            msg = "Expected that post Tags.Count was: " + expectedTags + " But actual post Tags.Count was: " + actualPost.Tags.Count;
            Assert.AreEqual(expectedTags, actualPost.Tags.Count, msg);

            //BumpTime Assert, check if theres a better way to test this
            msg = "Expected that post BumpTime.TimeOfDay was around: " + expectedBumpTime.TimeOfDay + " But actual post BumpTime was: " + actualPost.BumpTime.TimeOfDay;
            Assert.AreEqual(expectedBumpTime.TimeOfDay, actualPost.BumpTime.TimeOfDay, msg);

            //DateCreated Assert,  check if theres a better way to test this
            msg = "Expected that post DateCreated.TimeOfDay was around: " + expectedDateCreated.TimeOfDay + " But actual post DateCreated was: " + actualPost.DateCreated.TimeOfDay;
            Assert.AreEqual(expectedDateCreated.TimeOfDay, actualPost.DateCreated.TimeOfDay, msg);

            //Owner Assert
            msg = "Expected that post User was around: " + expectedUser + " But actual post User was: " + actualPost.User;
            Assert.AreEqual(expectedUser, actualPost.User, msg);

            //Category Assert
            msg = "Expected that post Category was: " + expectedCategory + " But actual post category Name was: " + actualPost.Category;
            Assert.AreEqual(expectedCategory, actualPost.Category, msg);

            //Comments Assert
            msg = "Expected that post Comments.Count was empty. But actual post category Comment.Count was: " + actualPost.Comments.Count;
            Assert.AreEqual(0, actualPost.Comments.Count, msg);
        }

        [TestMethod]
        //Title min-1 nr of characters
        [DataRow("Ca", "Lorem ipsum dolor sit amet.", 1)]
        //Title max+1 nr of characters
        [DataRow("Lorem ipsum dolor sit amet, consectetur cras amet..", "Consectetur adipiscing elit.", 2)]

        //Description min-1 nr of characters
        [DataRow("Ut mauris.", "Loru", 3)]
        //Description max+1 nr of characters
        [DataRow("Nam quis.", "1"+fiveHundredCharacters + fiveHundredCharacters + fiveHundredCharacters, 4)]
        public void CreatePostNegativeTest(string expectedPostTitle, string expectedPostDescription, int nrOfTags)
        {
            // Arrange
            List<string> expectedTagsList = new List<string>() { "Hardware", "Hot", "Dead", "RipFlowers", "Jewels", "Bland", "AlienNoises", "Fridge", "MomsSpaghetti", "EminemCantFixThis", "FutureWaifu", "TeknologiIsTheFuture" };
            for (int i = 0; nrOfTags < expectedTagsList.Count; i++)
            {
                expectedTagsList.Remove(expectedTagsList.First());
            }

            User expectedUser = new User("Tester", "TT@DD.SS", "TestUser123", "TestPass");

            Category expectedCategory = new Category();

            var controller = new CreatePostController(_DB);

            bool success = true;


            // Act 

            try
            {
                controller.CreatePostModel(expectedUser, expectedPostTitle, expectedPostDescription, expectedCategory, expectedTagsList); // this method has to return the newly created object after its ID is set from the DB
            }
            catch (Exception)
            {
                success = false;
            }


            // Assert

            Assert.IsFalse(success);
        }

        #endregion
    }
}