using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Language.Flow;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoPASDML;
using Microsoft.Extensions.Logging;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class CoverageControllerTests
    {
        private Mock<ICoveragesBL> _coveragesBLMock;
        private Mock<ILogger<CoveragesController>> _loggerMock;
        private CoveragesController _coveragesController;

        [SetUp]
        public void Setup()
        {
            _coveragesBLMock = new Mock<ICoveragesBL>();
            _loggerMock = new Mock<ILogger<CoveragesController>>();
            _coveragesController = new CoveragesController(_coveragesBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAllCoverages_Returns_OkResult()
        {
            //Arrange
            var coveragesList = new List<coverages>();
            _coveragesBLMock.Setup(x => x.GetAllCoverages()).ReturnsAsync(coveragesList);

            //Act
            var result = await _coveragesController.GetAllCoverages();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(coveragesList, okResult.Value);
        }

        [Test]
        public async Task GetAllCoverages_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _coveragesBLMock.Setup(x => x.GetAllCoverages()).Throws(new Exception());

            //Act
            var result = await _coveragesController.GetAllCoverages();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task CalculatePremium_Returns_OkResult()
        {
            // Arrange
            var premium = new PremiumRating();
            _coveragesBLMock.Setup(x => x.CalculatePremium()).ReturnsAsync(premium);

            // Act
            var result = await _coveragesController.CalculatePremium();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(premium, okResult.Value);
        }

        [Test]
        public async Task CalculatePremium_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            // Arrange
            _coveragesBLMock.Setup(x => x.CalculatePremium()).Throws(new Exception());

            // Act
            var actionResult = await _coveragesController.CalculatePremium();
            var objectResult = actionResult as ObjectResult;

            // Assert
            Assert.IsNotNull(objectResult);
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
