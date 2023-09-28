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
using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASAL;
using AutoPASAPITests.MockRepository;
using AutoPASSL.Repository;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class FuelTypeControllerTests
    {
        private FuelTypeController _controller;
        private Mock<IFuelTypeService> _mockFuelTypeService;
        private Mock<ILogger<FuelTypeController>> _mockLogger;
        private FuelTypeMockRepo _mockFuelTypeRepo;
        private FuelTypeService _FuelTypeService;
        private Mock<IFuelTypeRepo> _IFuelTypeRepo;

        [SetUp]
        public void Setup()
        {
            _IFuelTypeRepo = new Mock<IFuelTypeRepo>();
            _FuelTypeService = new FuelTypeService(_IFuelTypeRepo.Object);
            _mockFuelTypeRepo = new FuelTypeMockRepo();
            _mockFuelTypeService = new Mock<IFuelTypeService>();
            _mockLogger = new Mock<ILogger<FuelTypeController>>();
            _controller = new FuelTypeController(_mockFuelTypeService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllFuelType_ReturnsData()
        {
            // Arrange
            var fuelType = new List<fueltype> { };
            _mockFuelTypeService.Setup(service => service.GetAllFuelTypes()).Returns(_FuelTypeService.GetAllFuelTypes);
            _IFuelTypeRepo.Setup(repo => repo.GetAllFuelTypes()).Returns(_mockFuelTypeRepo.ReturnsFuelTypes);

            // Act
            var result = await _controller.GetAllFuelTypes() as OkObjectResult;

            // Assert
            Assert.AreEqual(fuelType, result.Value);
        }

        [Test]
        public async Task GetAllFuelType_ReturnsNull()
        {
            // Arrange
            _mockFuelTypeService.Setup(service => service.GetAllFuelTypes()).Returns(_FuelTypeService.GetAllFuelTypes);
            _IFuelTypeRepo.Setup(repo => repo.GetAllFuelTypes()).Returns(_mockFuelTypeRepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllFuelTypes() as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetAllFuelType_WhenServiceThrowsException()
        {
            // Arrange
            _mockFuelTypeService.Setup(service => service.GetAllFuelTypes()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllFuelTypes() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllFuelType_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockFuelTypeService.Setup(service => service.GetAllFuelTypes()).Returns(_FuelTypeService.GetAllFuelTypes);
            _IFuelTypeRepo.Setup(repo => repo.GetAllFuelTypes()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllFuelTypes() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task GetFuelTypes_ReturnsData()
        {
            // Arrange
            var fuelType = new List<fueltype> { };
            int ModelId = 0;
            _mockFuelTypeService.Setup(service => service.GetFuelTypes(ModelId)).Returns(_FuelTypeService.GetFuelTypes);
            _IFuelTypeRepo.Setup(repo => repo.GetFuelTypes(ModelId)).Returns(_mockFuelTypeRepo.ReturnsFuelTypes);

            // Act
            var result = await _controller.GetFuelTypes(ModelId) as OkObjectResult;

            // Assert
            Assert.AreEqual(fuelType, result.Value);
        }

        [Test]
        public async Task GetFuelTypes_ReturnsNull()
        {
            // Arrange
            int ModelId = 0;
            _mockFuelTypeService.Setup(service => service.GetFuelTypes(ModelId)).Returns(_FuelTypeService.GetFuelTypes);
            _IFuelTypeRepo.Setup(repo => repo.GetFuelTypes(ModelId)).Returns(_mockFuelTypeRepo.ReturnsNull);

            // Act
            var result = await _controller.GetFuelTypes(ModelId) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetFuelTypes_WhenServiceThrowsException()
        {
            // Arrange
            int ModelId = 0;
            _mockFuelTypeService.Setup(service => service.GetFuelTypes(ModelId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetFuelTypes(ModelId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetFuelTypes_WhenRepositoryThrowsException()
        {
            // Arrange
            int ModelId = 0;
            _mockFuelTypeService.Setup(service => service.GetFuelTypes(ModelId)).Returns(_FuelTypeService.GetFuelTypes);
            _IFuelTypeRepo.Setup(repo => repo.GetFuelTypes(ModelId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetFuelTypes(ModelId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}
