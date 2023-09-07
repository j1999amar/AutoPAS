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
    public class VehicleControllerTests
    {
        private Mock<IVehicleBL> _vehicleBLMock;
        private Mock<ILogger<VehicleController>> _loggerMock;
        private VehicleController _vehicleController;

        [SetUp]
        public void Setup()
        {
            _vehicleBLMock = new Mock<IVehicleBL>();
            _loggerMock = new Mock<ILogger<VehicleController>>();
            _vehicleController = new VehicleController(_vehicleBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAllVehicles_Returns_OkResult()
        {
            //Arrange
            var vehicle = new List<vehicle>();
            _vehicleBLMock.Setup(x => x.GetAllVehicles()).ReturnsAsync(vehicle);

            //Act
            var result = await _vehicleController.GetAllVehicles();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(vehicle, okResult.Value);
        }

        [Test]
        public async Task GetAllVehicles_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _vehicleBLMock.Setup(x => x.GetAllVehicles()).Throws(new Exception());

            //Act
            var result = await _vehicleController.GetAllVehicles();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetVehicleById_Returns_OkResult()
        {
            //Arrange
            var vehicle = new List<vehicle>();
            Guid Id = Guid.NewGuid();
            _vehicleBLMock.Setup(x => x.GetVehicleById(Id)).ReturnsAsync(vehicle);

            //Act
            var result = await _vehicleController.GetVehicleById(Id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(vehicle, okResult.Value);
        }

        [Test]
        public async Task GetVehicleById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            _vehicleBLMock.Setup(x => x.GetVehicleById(Id)).Throws(new Exception());

            //Act
            var result = await _vehicleController.GetVehicleById(Id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task AddVehicle_Returns_OkResult()
        {
            //Arrange
            var vehicle = new vehicle();
            var objVehicle = new vehicle();
            _vehicleBLMock.Setup(x => x.AddVehicle(objVehicle)).ReturnsAsync(vehicle);

            //Act
            var result = await _vehicleController.AddVehicle(objVehicle);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(vehicle, okResult.Value);
        }

        [Test]
        public async Task AddVehicle_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var objVehicle = new vehicle();
            _vehicleBLMock.Setup(x => x.AddVehicle(objVehicle)).Throws(new Exception());

            //Act
            var result = await _vehicleController.AddVehicle(objVehicle);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetBrandByVehicleType_Returns_OkResult()
        {
            //Arrange
            var brandList = new List<Brands>();
            var VehicleType = 0;
            _vehicleBLMock.Setup(x => x.GetBrandByVehicleType(VehicleType)).ReturnsAsync(brandList);

            //Act
            var result = await _vehicleController.GetBrandByVehicleType(VehicleType);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(brandList, okResult.Value);
        }

        [Test]
        public async Task GetBrandByVehicleType_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var VehicleType = 0;
            _vehicleBLMock.Setup(x => x.GetBrandByVehicleType(VehicleType)).Throws(new Exception());

            //Act
            var result = await _vehicleController.GetBrandByVehicleType(VehicleType);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task UpdateVehicleById_Returns_OkResult()
        {
            //Arrange
            var vehicle = new vehicle();
            Guid Id = Guid.NewGuid();
            var objVehicle = new vehicle();
            _vehicleBLMock.Setup(x => x.UpdateVehicleById(Id, objVehicle)).ReturnsAsync(vehicle);

            //Act
            var result = await _vehicleController.UpdateVehicleById(Id, objVehicle);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(vehicle, okResult.Value);
        }

        [Test]
        public async Task UpdateVehicleById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var objVehicle = new vehicle();
            _vehicleBLMock.Setup(x => x.UpdateVehicleById(Id, objVehicle)).Throws(new Exception());

            //Act
            var result = await _vehicleController.UpdateVehicleById(Id, objVehicle);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
    }
    
}
