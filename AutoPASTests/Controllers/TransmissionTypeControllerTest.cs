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
using AutoPASSL.Repository;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class TransmissionTypeControllerTests
    {
        private TransmissionTypeController _controller;
        private Mock<ITransmissionTypeService> _mockTransmissionTypeService;
        private Mock<ILogger<TransmissionTypeController>> _mockLogger;
        private TransmissionTypeMockRepo _mockTransmissionTypeRepo;
        private TransmissionTypeService _TransmissionTypeService;
        private Mock<ITransmissionTypeRepo> _ITransmissionTypeRepo;

        [SetUp]
        public void Setup()
        {
            _ITransmissionTypeRepo = new Mock<ITransmissionTypeRepo>();
            _TransmissionTypeService = new TransmissionTypeService(_ITransmissionTypeRepo.Object);
            _mockTransmissionTypeRepo = new TransmissionTypeMockRepo();
            _mockTransmissionTypeService = new Mock<ITransmissionTypeService>();
            _mockLogger = new Mock<ILogger<TransmissionTypeController>>();
            _controller = new TransmissionTypeController(_mockTransmissionTypeService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllTransmissionType_ReturnsData()
        {
            // Arrange
            var TransmissionType = new List<transmissiontype> { };
            _mockTransmissionTypeService.Setup(service => service.GetAllTransmissionTypes()).Returns(_TransmissionTypeService.GetAllTransmissionTypes);
            _ITransmissionTypeRepo.Setup(repo => repo.GetAllTransmissionTypes()).Returns(_mockTransmissionTypeRepo.ReturnsTransmissionTypes);

            // Act
            var result = await _controller.GetAllTransmissionTypes() as OkObjectResult;

            // Assert
            Assert.AreEqual(TransmissionType, result.Value);
        }

        [Test]
        public async Task GetAllTransmissionType_ReturnsNull()
        {
            // Arrange
            _mockTransmissionTypeService.Setup(service => service.GetAllTransmissionTypes()).Returns(_TransmissionTypeService.GetAllTransmissionTypes);
            _ITransmissionTypeRepo.Setup(repo => repo.GetAllTransmissionTypes()).Returns(_mockTransmissionTypeRepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllTransmissionTypes() as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetAllTransmissionType_WhenServiceThrowsException()
        {
            // Arrange
            _mockTransmissionTypeService.Setup(service => service.GetAllTransmissionTypes()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllTransmissionTypes() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllTransmissionType_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockTransmissionTypeService.Setup(service => service.GetAllTransmissionTypes()).Returns(_TransmissionTypeService.GetAllTransmissionTypes);
            _ITransmissionTypeRepo.Setup(repo => repo.GetAllTransmissionTypes()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllTransmissionTypes() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task GetTransmissionTypeByBrand_ReturnsData()
        {
            // Arrange
            var TransmissionType = new List<transmissiontype> { };
            int ModelId = 0;
            int FuelId = 0;
            _mockTransmissionTypeService.Setup(service => service.GetTransmissionTypes(ModelId, FuelId)).Returns(_TransmissionTypeService.GetTransmissionTypes);
            _ITransmissionTypeRepo.Setup(repo => repo.GetTransmissionTypes(ModelId, FuelId)).Returns(_mockTransmissionTypeRepo.ReturnsTransmissionTypes);

            // Act
            var result = await _controller.GetTransmissionTypes(ModelId, FuelId) as OkObjectResult;

            // Assert
            Assert.AreEqual(TransmissionType, result.Value);
        }

        [Test]
        public async Task GetTransmissionTypeByBrand_ReturnsNull()
        {
            // Arrange
            int ModelId = 0;
            int FuelId = 0;
            _mockTransmissionTypeService.Setup(service => service.GetTransmissionTypes(ModelId, FuelId)).Returns(_TransmissionTypeService.GetTransmissionTypes);
            _ITransmissionTypeRepo.Setup(repo => repo.GetTransmissionTypes(ModelId, FuelId)).Returns(_mockTransmissionTypeRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTransmissionTypes(ModelId, FuelId) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTransmissionTypeByBrand_WhenServiceThrowsException()
        {
            // Arrange
            int ModelId = 0;
            int FuelId = 0;
            _mockTransmissionTypeService.Setup(service => service.GetTransmissionTypes(ModelId, FuelId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTransmissionTypes(ModelId, FuelId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTransmissionTypeByBrand_WhenRepositoryThrowsException()
        {
            // Arrange
            int ModelId = 0;
            int FuelId = 0;
            _mockTransmissionTypeService.Setup(service => service.GetTransmissionTypes(ModelId, FuelId)).Returns(_TransmissionTypeService.GetTransmissionTypes);
            _ITransmissionTypeRepo.Setup(repo => repo.GetTransmissionTypes(ModelId, FuelId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTransmissionTypes(ModelId, FuelId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

    }
}
