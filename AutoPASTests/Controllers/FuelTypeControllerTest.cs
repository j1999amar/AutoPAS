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
    public class FuelTypeControllerTests
    {
        private Mock<IFuelTypeBL> _fuelTypeBLMock;
        private Mock<ILogger<FuelTypeController>> _loggerMock;
        private FuelTypeController _fuelTypeController;

        [SetUp]
        public void Setup()
        {
            _fuelTypeBLMock = new Mock<IFuelTypeBL>();
            _loggerMock = new Mock<ILogger<FuelTypeController>>();
            _fuelTypeController = new FuelTypeController(_fuelTypeBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetFuelTypes_Returns_OkResult()
        {
            //Arrange
            var fuelList = new List<fueltype>();
            var ModelId = 1;
            _fuelTypeBLMock.Setup(x => x.GetFuelTypes(ModelId)).ReturnsAsync(fuelList);

            //Act
            var result = await _fuelTypeController.GetFuelTypes(ModelId);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(fuelList, okResult.Value);
        }

        [Test]
        public async Task GetFuelTypes_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var ModelId = 0;
            _fuelTypeBLMock.Setup(x => x.GetFuelTypes(ModelId)).Throws(new Exception());

            //Act
            var result = await _fuelTypeController.GetFuelTypes(ModelId);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetAllFuelTypes_Returns_OkResult()
        {
            //Arrange
            var fuelList = new List<fueltype>();
            _fuelTypeBLMock.Setup(x => x.GetAllFuelTypes()).ReturnsAsync(fuelList);

            //Act
            var result = await _fuelTypeController.GetAllFuelTypes();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(fuelList, okResult.Value);
        }

        [Test]
        public async Task GetAllFuelTypes_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var ModelId = 0;
            _fuelTypeBLMock.Setup(x => x.GetAllFuelTypes()).Throws(new Exception());

            //Act
            var result = await _fuelTypeController.GetAllFuelTypes();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
