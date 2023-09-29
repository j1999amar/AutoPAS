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
using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASAL;
using AutoPASAPITests.MockRepository;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class VehicleTypeControllerTests
    {
        private VehicleTypeController _controller;
        private Mock<IVehicleTypeService> _mockVehicleTypeService;
        private Mock<ILogger<VehicleTypeController>> _mockLogger;
        private VehicleTypeMockRepo _mockVehicleTypeRepo;
        private VehicleTypeService _VehicleTypeService;
        private Mock<IVehicleTypeRepo> _IVehicleTypeRepo;

        [SetUp]
        public void Setup()
        {
            _IVehicleTypeRepo = new Mock<IVehicleTypeRepo>();
            _VehicleTypeService = new VehicleTypeService(_IVehicleTypeRepo.Object);
            _mockVehicleTypeRepo = new VehicleTypeMockRepo();
            _mockVehicleTypeService = new Mock<IVehicleTypeService>();
            _mockLogger = new Mock<ILogger<VehicleTypeController>>();
            _controller = new VehicleTypeController(_mockVehicleTypeService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllVehicleType_ReturnsData()
        {
            // Arrange
            var vehicleTypes = new List<vehicleType> { };
            _mockVehicleTypeService.Setup(service => service.GetAllVehicleType()).Returns(_VehicleTypeService.GetAllVehicleType);
            _IVehicleTypeRepo.Setup(repo => repo.GetAllVehicleType()).Returns(_mockVehicleTypeRepo.ReturnsVehicleType);

            // Act
            var result = await _controller.GetAllVehicleType() as OkObjectResult;

            // Assert
            Assert.AreEqual(vehicleTypes, result.Value);
        }

        [Test]
        public async Task GetAllVehicleType_ReturnsNull()
        {
            // Arrange
            _mockVehicleTypeService.Setup(service => service.GetAllVehicleType()).Returns(_VehicleTypeService.GetAllVehicleType);
            _IVehicleTypeRepo.Setup(service => service.GetAllVehicleType()).Returns(_mockVehicleTypeRepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllVehicleType() as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }

        [Test]
        public async Task GetAllVehicleType_WhenServiceThrowsException()
        {
            // Arrange
            _mockVehicleTypeService.Setup(service => service.GetAllVehicleType()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllVehicleType() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllVehicleType_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockVehicleTypeService.Setup(service => service.GetAllVehicleType()).Returns(_VehicleTypeService.GetAllVehicleType);
            _IVehicleTypeRepo.Setup(service => service.GetAllVehicleType()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllVehicleType() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task AddVehicleType_WhenVehicleTypeIdIsNotExsitsAndDataIsAdded()
        {
            //Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(false);

            //Act 
            var result = await _controller.AddVehicleType(vehicleType) as ObjectResult;

            Assert.AreEqual(200,result.StatusCode);
        }

        [Test]
        public async Task AddVehicleType_WhenVehicleTypeIdIsExsitsAndDataIsNotAdded()
        {
            //Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(true);

            //Act 
            var result = await _controller.AddVehicleType(vehicleType) as ObjectResult;

            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task AddVehicleType_WhenServiceThrowsException()
        {
            // Arrange
            var vehicleType = new vehicleType();

            _mockVehicleTypeService.Setup(service => service.AddVehicleType(vehicleType)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.AddVehicleType(vehicleType) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task AddVehicleType_WhenRepositoryThrowsException()
        {
            // Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.AddVehicleType(vehicleType)).Returns(_VehicleTypeService.AddVehicleType);
            _IVehicleTypeRepo.Setup(service => service.AddVehicleType(vehicleType)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.AddVehicleType(vehicleType) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task EditVehicleType_WhenVehicleTypeIdIsExsitsAndDataIsUpdated()
        {
            //Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(true);

            //Act 
            var result = await _controller.EditVehicleType(vehicleType) as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task EditVehicleType_WhenVehicleTypeIdIsNotExsitsAndDataIsNotUpdated()
        {
            //Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(false);

            //Act 
            var result = await _controller.EditVehicleType(vehicleType) as ObjectResult;

            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
       
        public async Task EditVehicleType_WhenServiceThrowsException()
        {
            // Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(true);
            _mockVehicleTypeService.Setup(service => service.EditVehicleType(vehicleType)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.EditVehicleType(vehicleType) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task EditVehicleType_WhenRepositoryThrowsException()
        {
            // Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(true);
            _mockVehicleTypeService.Setup(service => service.EditVehicleType(vehicleType)).Returns(_VehicleTypeService.EditVehicleType);
            _IVehicleTypeRepo.Setup(service => service.EditVehicleType(vehicleType)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.EditVehicleType(vehicleType) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }


        [Test]
        public async Task DeleteVehicleType_WhenVehicleTypeIdIsExsitsAndDataIsDeleted()
        {
            //Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(true);

            //Act 
            var result =  _controller.DeleteVehicleType(vehicleType.VehicleTypeId) as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task DeleteVehicleType_WhenVehicleTypeIdIsNotExsitsAndDataIsNotDeleted()
        {
            //Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(false);

            //Act 
            var result =  _controller.DeleteVehicleType(vehicleType.VehicleTypeId) as ObjectResult;

            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task DeleteVehicleType_WhenServiceThrowsException()
        {
            // Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(true);
            _mockVehicleTypeService.Setup(service => service.DeleteVehicleType(vehicleType.VehicleTypeId)).Throws(new Exception());

            // Act
            var result =  _controller.DeleteVehicleType(vehicleType.VehicleTypeId) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task DeleteVehicleType_WhenRepositoryThrowsException()
        {
            // Arrange
            var vehicleType = new vehicleType();
            _mockVehicleTypeService.Setup(service => service.IsExists(vehicleType.VehicleTypeId)).Returns(true);
            _mockVehicleTypeService.Setup(service => service.DeleteVehicleType(vehicleType.VehicleTypeId)).Returns(_VehicleTypeService.DeleteVehicleType);
            _IVehicleTypeRepo.Setup(service => service.DeleteVehicleType(vehicleType.VehicleTypeId)).Throws(new Exception());

            // Act
            var result =  _controller.DeleteVehicleType(vehicleType.VehicleTypeId) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}
