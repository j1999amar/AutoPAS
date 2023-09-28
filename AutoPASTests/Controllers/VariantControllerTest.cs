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
    public class VariantControllerTests
    {
        private VariantController _controller;
        private Mock<IVariantService> _mockVariantService;
        private Mock<ILogger<VariantController>> _mockLogger;
        private VariantMockRepo _mockVariantRepo;
        private VariantService _VariantService;
        private Mock<IVariantRepo> _IVariantRepo;

        [SetUp]
        public void Setup()
        {
            _IVariantRepo = new Mock<IVariantRepo>();
            _VariantService = new VariantService(_IVariantRepo.Object);
            _mockVariantRepo = new VariantMockRepo();
            _mockVariantService = new Mock<IVariantService>();
            _mockLogger = new Mock<ILogger<VariantController>>();
            _controller = new VariantController(_mockVariantService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllVariant_ReturnsData()
        {
            // Arrange
            var variant = new List<variant> { };
            _mockVariantService.Setup(service => service.GetAllVariant()).Returns(_VariantService.GetAllVariant);
            _IVariantRepo.Setup(repo => repo.GetAllVariant()).Returns(_mockVariantRepo.ReturnsVariants);

            // Act
            var result = await _controller.GetAllVariant() as OkObjectResult;

            // Assert
            Assert.AreEqual(variant, result.Value);
        }

        [Test]
        public async Task GetAllVariant_ReturnsNull()
        {
            // Arrange
            _mockVariantService.Setup(service => service.GetAllVariant()).Returns(_VariantService.GetAllVariant);
            _IVariantRepo.Setup(repo => repo.GetAllVariant()).Returns(_mockVariantRepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllVariant() as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }
        [Test]
        public async Task GetAllVariant_WhenServiceThrowsException()
        {
            // Arrange
            _mockVariantService.Setup(service => service.GetAllVariant()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllVariant() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllVariant_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockVariantService.Setup(service => service.GetAllVariant()).Returns(_VariantService.GetAllVariant);
            _IVariantRepo.Setup(repo => repo.GetAllVariant()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllVariant() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task GetVariant_ReturnsData()
        {
            // Arrange
            var variant = new List<variant> { };
            int ModelId = 0;
            int FuelId = 0;
            int TransmissionId = 0;
            _mockVariantService.Setup(service => service.GetVariant(ModelId, FuelId,TransmissionId)).Returns(_VariantService.GetVariant);
            _IVariantRepo.Setup(repo => repo.GetVariant(ModelId, FuelId, TransmissionId)).Returns(_mockVariantRepo.ReturnsVariants);

            // Act
            var result = await _controller.GetVariant(ModelId, FuelId, TransmissionId) as OkObjectResult;

            // Assert
            Assert.AreEqual(variant, result.Value);
        }

        [Test]
        public async Task GetVariant_ReturnsNull()
        {
            // Arrange
            int ModelId = 0;
            int FuelId = 0;
            int TransmissionId = 0;
            _mockVariantService.Setup(service => service.GetVariant(ModelId, FuelId, TransmissionId)).Returns(_VariantService.GetVariant);
            _IVariantRepo.Setup(repo => repo.GetVariant(ModelId, FuelId, TransmissionId)).Returns(_mockVariantRepo.ReturnsNull);

            // Act
            var result = await _controller.GetVariant(ModelId, FuelId, TransmissionId) as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }
        [Test]
        public async Task GetVariant_WhenServiceThrowsException()
        {
            // Arrange
            int ModelId = 0;
            int FuelId = 0;
            int TransmissionId = 0;
            _mockVariantService.Setup(service => service.GetVariant(ModelId, FuelId, TransmissionId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetVariant(ModelId, FuelId, TransmissionId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetVariant_WhenRepositoryThrowsException()
        {
            // Arrange
            int ModelId = 0;
            int FuelId = 0;
            int TransmissionId =0; 
            _mockVariantService.Setup(service => service.GetVariant(ModelId, FuelId, TransmissionId)).Returns(_VariantService.GetVariant);
            _IVariantRepo.Setup(repo => repo.GetVariant(ModelId, FuelId, TransmissionId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetVariant(ModelId, FuelId, TransmissionId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

    }
}
