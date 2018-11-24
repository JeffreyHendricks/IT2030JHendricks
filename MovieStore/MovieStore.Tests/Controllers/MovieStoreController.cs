using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieStore.Controllers;
using MovieStore.Models;
using Moq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MovieStore.Tests.Controllers
{
    [TestClass]
    public class MovieStoreController
    {
        [TestMethod]
        public void MovieStore_Index_TestView()
        {
            //Arrange
            MoviesController controller = new MoviesController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void MovieStore_ListOfMovies()
        {
            //Arrange
            MoviesController controller = new MoviesController();

            //Act
            var result = controller.ListOfMovies();

            //Assert
            Assert.AreEqual("Terminator1", result[0].Title);
            Assert.AreEqual("Terminator2", result[1].Title);
            Assert.AreEqual("Terminator3", result[2].Title);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_Success()
        {
            //Arrange
            MoviesController controller = new MoviesController();

            //Act
            var result = controller.IndexRedirect(1) as RedirectToRouteResult;

            //Assert
            Assert.AreEqual("Create", result.RouteValues["action"]);
            Assert.AreEqual("HomeController", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_BadRequest()
        {
            //Arange
            MoviesController controller = new MoviesController();

            //Act
            var result = controller.IndexRedirect(0) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }


       [TestMethod]
        public void MovieStore_ListFromDB_Success()
        {
            // Goal is to use our own list(movies) instead of calling from the database

            //Step1
           var list = new List<Movie>
           {
               new Movie() {MovieId=1, Title="Ghost In Shell"},
               new Movie() {MovieId=2, Title="Your Name"}
              
           }.AsQueryable();

            //Step2
            Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step3 Connect
            mockSet.As<IQueryable<Movie>>.Setup((m => m.GetEnumerator())).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>.Setup((m => m.Provider)).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>.Setup((m => m.ElementType)).Returns(list.ElementType);
            mockSet.As<IQueryable<Movie>>.Setup((m => m.Expression)).Returns(list.Expression);

            //Step4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step5 send the mock context to the controller
            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);


            //Act
            ViewResult result = controller.ListFromDB() as ViewResult;
            List<Movie> resultModel = result.Model as List<Movie>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Ghost In Shell",resultModel[0].Title);
            Assert.AreEqual("Your Name", resultModel[1].Title);
        }

        [TestMethod]
        public void MovieStore_ListFromDB()
        {
            // Goal is to use our own list(movies) instead of calling from the database

            //Step1
            var list = new List<Movie>
           {
               new Movie() {MovieId=1, Title="Ghost In Shell"},
               new Movie() {MovieId=2, Title="Your Name"}

           }.AsQueryable();

            //Step2
            Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
            
            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);


            //Act
            ViewResult result = controller.ListFromDB() as ViewResult;
           

            //Assert
            Assert.IsNotNull(result);
            
        }
    }
}
