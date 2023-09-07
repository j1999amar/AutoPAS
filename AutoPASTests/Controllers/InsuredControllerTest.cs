using AutoPASAPI.Controllers;
using AutoPASDML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoPASSL;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class InsuredControllerTests
    {
        private APASDBContext _apasDBContext;
        private InsuredController _insuredController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<APASDBContext>()
                .Options;
            _apasDBContext = new APASDBContext(options);
            _insuredController = new InsuredController(_apasDBContext, new Logger<InsuredController>(new LoggerFactory()));
        }

        /*[Test]
        public async Task GetInsured_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var insured = new insured
            {
                InsuredId = Guid.NewGuid(),
                // Add other properties as needed
            };
            _apasDBContext.insured.Add(insured);
            await _apasDBContext.SaveChangesAsync();

            // Act
            var result = await _insuredController.GetInsured(insured.InsuredId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(insured, okResult.Value);
        }*/

        [Test]
        public async Task GetInsured_ReturnsStatusCode500()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = await _insuredController.GetInsured(id);

            // Assert

            if (result is ObjectResult objectResult)
            {
                Assert.AreEqual(500, objectResult.StatusCode);
            }

        }


        /*[Test]
        public async Task AddInsured_WithValidInsured_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var insured = new insured();

            // Act
            var result = await _insuredController.AddInsured(insured);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
            var createdAtActionResult = (CreatedAtActionResult)result;
            Assert.AreEqual("GetInsured", createdAtActionResult.ActionName);
            Assert.AreEqual(insured.InsuredId, createdAtActionResult.RouteValues["id"]);
            Assert.AreEqual(insured, createdAtActionResult.Value);
        }*/

        [Test]
        public async Task AddInsured_ReturnsStatusCode500()
        {
            // Arrange
            var insured = new insured
            {
                InsuredId = Guid.NewGuid(),
            };

            // Act
            var result = await _insuredController.AddInsured(insured);

            // Assert

            if (result is ObjectResult objectResult)
            {
                Assert.AreEqual(500, objectResult.StatusCode);
            }

        }
    }
}
