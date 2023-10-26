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
    public class VehicleControllerTests
    {
        private VehicleController _controller;
        private Mock<IVehicleService> _mockVehicleService;
        private Mock<ILogger<VehicleController>> _mockLogger;
        private VehicleMockRepo _mockVehicleRepo;
        private VehicleService _VehicleService;
        private Mock<IVehicleRepo> _IVehicleRepo;

        [SetUp]
        public void Setup()
        {
            _IVehicleRepo = new Mock<IVehicleRepo>();
            _VehicleService = new VehicleService(_IVehicleRepo.Object);
            _mockVehicleRepo = new VehicleMockRepo();
            _mockVehicleService = new Mock<IVehicleService>();
            _mockLogger = new Mock<ILogger<VehicleController>>();
            _controller = new VehicleController(_mockVehicleService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllVehicle_ReturnsData()
        {
            // Arrange
            var Vehicles = new List<vehicle> { };
            _mockVehicleService.Setup(service => service.GetAllVehicles()).Returns(_VehicleService.GetAllVehicles);
            _IVehicleRepo.Setup(repo => repo.GetAllVehicles()).Returns(_mockVehicleRepo.ReturnsVehicle);

            // Act
            var result = await _controller.GetAllVehicles() as OkObjectResult;

            // Assert
            Assert.AreEqual(Vehicles, result.Value);
        }

        [Test]
        public async Task GetAllVehicle_ReturnsNull()
        {
            // Arrange
            _mockVehicleService.Setup(service => service.GetAllVehicles()).Returns(_VehicleService.GetAllVehicles);
            _IVehicleRepo.Setup(service => service.GetAllVehicles()).Returns(_mockVehicleRepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllVehicles() as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }

        [Test]
        public async Task GetAllVehicle_WhenServiceThrowsException()
        {
            // Arrange
            _mockVehicleService.Setup(service => service.GetAllVehicles()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllVehicles() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllVehicle_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockVehicleService.Setup(service => service.GetAllVehicles()).Returns(_VehicleService.GetAllVehicles);
            _IVehicleRepo.Setup(service => service.GetAllVehicles()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllVehicles() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetVehicleById_ReturnsData()
        {
            // Arrange
            var Vehicles = new List<vehicle> { };
            Guid Id = new Guid();
            _mockVehicleService.Setup(service => service.GetVehicleById(Id)).Returns(_VehicleService.GetVehicleById);
            _IVehicleRepo.Setup(repo => repo.GetVehicleById(Id)).Returns(_mockVehicleRepo.ReturnsVehicle);

            // Act
            var result = await _controller.GetVehicleById(Id) as OkObjectResult;

            // Assert
            Assert.AreEqual(Vehicles, result.Value);
        }

        [Test]
        public async Task GetVehicleById_ReturnsNull()
        {
            // Arrange
            Guid Id = new Guid();
            _mockVehicleService.Setup(service => service.GetVehicleById(Id)).Returns(_VehicleService.GetVehicleById);
            _IVehicleRepo.Setup(service => service.GetVehicleById(Id)).Returns(_mockVehicleRepo.ReturnsNull);

            // Act
            var result = await _controller.GetVehicleById(Id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }

        [Test]
        public async Task GetVehicleById_WhenServiceThrowsException()
        {
            // Arrange
            Guid Id = new Guid();
            _mockVehicleService.Setup(service => service.GetVehicleById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetVehicleById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetVehicleById_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid Id = new Guid();
            _mockVehicleService.Setup(service => service.GetVehicleById(Id)).Returns(_VehicleService.GetVehicleById);
            _IVehicleRepo.Setup(service => service.GetVehicleById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetVehicleById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
    }
    
}
