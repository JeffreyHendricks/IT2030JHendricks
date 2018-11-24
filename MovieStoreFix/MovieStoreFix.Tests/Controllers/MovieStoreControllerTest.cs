using System;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieStoreFix.Controllers;
using MovieStoreFix.Models;
using System.Linq;
using Moq;
using System.Collections.Generic;

namespace MovieStoreFix.Tests.Controllers
{
    [TestClass]
    public class MovieStoreControllerTest
    {
        [TestMethod]
        public void MovieStoreFix_Index_Test()
        {
            //Arrange
            MoviesController controller = new MoviesController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStoreFix_ListOfMovies()
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
        public void MovieStoreFix_IndexRedirect_Success()
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
        public void MovieStoreFix_IndexRedirect_BadRequest()
        {
            //Arrange
            MoviesController controller = new MoviesController();

            //Act
            var result = controller.IndexRedirect(0) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStoreFix_ListFromDb_Success()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();


            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m =>m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            ViewResult result = controller.ListFromDb() as ViewResult;
            List<Movie> resultModel = result.Model as List<Movie>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Your Name", resultModel[0].Title);
            Assert.AreEqual("Ghost In Shell", resultModel[1].Title);
        }

        [TestMethod]
        public void MovieStoreFix_Details_Success()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();


            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            ViewResult result = controller.Details(1) as ViewResult;
            

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStoreFix_Details_No_Id()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();


            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            //Id is null so not happy path
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;


            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStoreFix_Details_MovieNull()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            Movie movie = null;
            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            HttpStatusCodeResult result = controller.Details(1) as HttpStatusCodeResult;


            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStoreFix_Create_Test()
        {
            //Arrange
            MoviesController controller = new MoviesController();

            //Act
            ViewResult result = controller.Create() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStoreFix_Edit_Success()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();


            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            ViewResult result = controller.Details(1) as ViewResult;


            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStoreFix_Edit_No_Id()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();


            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            //Id is null so not happy path
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;


            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStoreFix_Edit_MovieNull()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            Movie movie = null;
            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            HttpStatusCodeResult result = controller.Details(1) as HttpStatusCodeResult;


            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStoreFix_Delete_Success()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();


            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            ViewResult result = controller.Details(1) as ViewResult;


            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStoreFix_Delete_No_Id()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();


            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            //Id is null so not happy path
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;


            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStoreFix_Delete_MovieNull()
        {

            //Goal is to list our own list<Movies>
            //Step 1
            var list = new List<Movie>
            {
                new Movie {MovieId=1, Title="Your Name"},
                new Movie {MovieId=2, Title="Ghost In Shell"}
            }.AsQueryable();

            //Controller needs a mock Object
            //Step 2
            Mock<MovieStoreFixDBContext> mockContext = new Mock<MovieStoreFixDBContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            Movie movie = null;
            //Step 3 connect dbSet and List
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            //Step 4 connect dbSet to context
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Step 5 sent the mock context to the controller

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            HttpStatusCodeResult result = controller.Details(1) as HttpStatusCodeResult;


            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
        }

    }
}
