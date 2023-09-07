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
using System.Web.Razor.Parser.SyntaxTree;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class VehicleTypeControllerTests
    {
        private Mock<IVehicleTypeBL> _vehicleTypeBLMock;
        private Mock<ILogger<VehicleTypeController>> _loggerMock;
        private VehicleTypeController _vehicleTypeController;

        [SetUp]
        public void Setup()
        {
            _vehicleTypeBLMock = new Mock<IVehicleTypeBL>();
            _loggerMock = new Mock<ILogger<VehicleTypeController>>();
            _vehicleTypeController = new VehicleTypeController(_vehicleTypeBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAllVehicleType_Returns_OkResult()
        {
            //Arrange
            var vehicleTypeList = new List<vehicleType>();
            _vehicleTypeBLMock.Setup(x => x.GetAllVehicleType()).ReturnsAsync(vehicleTypeList);

            //Act
            var result = await _vehicleTypeController.GetAllVehicleType();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(vehicleTypeList, okResult.Value);
        }

        [Test]
        public async Task GetAllVehicleType_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var vehicleTypeList = new List<vehicleType>();
            _vehicleTypeBLMock.Setup(x => x.GetAllVehicleType()).Throws(new Exception());

            //Act
            var result = await _vehicleTypeController.GetAllVehicleType();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
