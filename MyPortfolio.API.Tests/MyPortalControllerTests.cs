using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.API.Controllers;
using MyPortfolio.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.API.Tests
{
    [TestClass]
    public class MyPortalControllerTests
    {
        private MyPortfolioDbContext _context;
        private MyPortalController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyPortfolioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new MyPortfolioDbContext(options);

            // Seed data
            _context.MyPortals.AddRange(new List<MyPortal>
            {
                new MyPortal { ID = 1, Username = "abc", Password = "123" },
            });

            _context.SaveChanges();

            _controller = new MyPortalController(_context);
        }

        [TestMethod]
        public async Task GetMyPortals_ShouldReturnAllPortals()
        {
            // Act
            var result = await _controller.GetMyPortals();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var portals = (result.Result as OkObjectResult).Value as List<MyPortal>;
            Assert.AreEqual(2, portals.Count);
        }

        [TestMethod]
        public async Task GetMyPortal_ShouldReturnPortalById()
        {
            // Act
            var result = await _controller.GetMyPortal(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var portal = (result.Result as OkObjectResult).Value as MyPortal;
            Assert.AreEqual(1, portal.ID);
        }

        [TestMethod]
        public async Task GetMyPortal_ShouldReturnNotFound()
        {
            // Act
            var result = await _controller.GetMyPortal(99);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostMyPortal_ShouldAddPortal()
        {
            // Arrange
            var newPortal = new MyPortal { ID = 3, Username = "abc", Password = "123" };

            // Act
            var result = await _controller.PostMyPortal(newPortal);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            Assert.AreEqual(3, _context.MyPortals.Count());
        }

        [TestMethod]
        public async Task PutMyPortal_ShouldUpdatePortal()
        {
            // Arrange
            var portalToUpdate = _context.MyPortals.First();
            portalToUpdate.Username = "def";

            // Act
            var result = await _controller.PutMyPortal(portalToUpdate.ID, portalToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
            var updatedPortal = _context.MyPortals.First(p => p.ID == portalToUpdate.ID);
            Assert.AreEqual("Updated Portal", updatedPortal.Username);
        }

        [TestMethod]
        public async Task PutMyPortal_ShouldReturnBadRequest()
        {
            // Arrange
            var portalToUpdate = new MyPortal { ID = 99, Username = "Invalid" };

            // Act
            var result = await _controller.PutMyPortal(1, portalToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteMyPortal_ShouldRemovePortal()
        {
            // Act
            var result = await _controller.DeleteMyPortal(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
            Assert.AreEqual(1, _context.MyPortals.Count());
        }

        [TestMethod]
        public async Task DeleteMyPortal_ShouldReturnNotFound()
        {
            // Act
            var result = await _controller.DeleteMyPortal(99);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
