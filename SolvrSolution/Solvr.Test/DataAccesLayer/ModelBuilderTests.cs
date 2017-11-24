using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccesLayer.ModelBuilds;
using SolvrLibrary;

namespace Solvr.Test.DataAccesLayer
{
    /// <summary>
    /// Summary description for ModelBuilderTests
    /// </summary>
    [TestClass]
    public class ModelBuilderTests
    {
        public ModelBuilderTests()
        {
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

        [TestMethod]
        [DataRow("hej", 5)]
        [DataRow("hej", 2)]
        [DataRow("hej", 3)]
        public void BuildCategoryTestPositive(string expectedName, int expectedId)
        {
            //Prepare
            ModelBuilder modelBuilder = new ModelBuilder();
            Category expectedCategory = new Category
            {
                Id = expectedId,
                Name = expectedName
            };
            
            //Act
            Category actualCategory = modelBuilder.BuildCategory(expectedId);
            string actualName = actualCategory.Name;
            int actualId = actualCategory.Id;

            //Assert
            string msg = "expected name was: " + expectedName +
                         ". Actual name is: " + actualName;
            Assert.AreEqual(expectedName, actualName, msg);

            msg = "expected id was: " + expectedId +
                  ". Actual id is: " + actualId;
            Assert.AreEqual(expectedId, actualId, msg);
        }


        [TestMethod]
        public void BuildCategoryTest()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
