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

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class ModelControllerTests
    {
        private ModelController _controller;
        private Mock<IModelService> _mockModelService;
        private Mock<ILogger<ModelController>> _mockLogger;
        private ModelMockRepo _mockModelRepo;
        private ModelService _ModelService;
        private Mock<IModelRepo> _IModelRepo;

        [SetUp]
        public void Setup()
        {
            _IModelRepo = new Mock<IModelRepo>();
            _ModelService = new ModelService(_IModelRepo.Object);
            _mockModelRepo = new ModelMockRepo();
            _mockModelService = new Mock<IModelService>();
            _mockLogger = new Mock<ILogger<ModelController>>();
            _controller = new ModelController(_mockModelService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllModel_ReturnsData()
        {
            // Arrange
            var model = new List<model> { };
            _mockModelService.Setup(service => service.GetAllModel()).Returns(_ModelService.GetAllModel);
            _IModelRepo.Setup(repo => repo.GetAllModel()).Returns(_mockModelRepo.ReturnsModel);

            // Act
            var result = await _controller.GetAllModel() as OkObjectResult;

            // Assert
            Assert.AreEqual(model, result.Value);
        }

        [Test]
        public async Task GetAllModel_ReturnsNull()
        {
            // Arrange
            _mockModelService.Setup(service => service.GetAllModel()).Returns(_ModelService.GetAllModel);
            _IModelRepo.Setup(repo => repo.GetAllModel()).Returns(_mockModelRepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllModel() as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetAllModel_WhenServiceThrowsException()
        {
            // Arrange
            _mockModelService.Setup(service => service.GetAllModel()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllModel() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllModel_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockModelService.Setup(service => service.GetAllModel()).Returns(_ModelService.GetAllModel);
            _IModelRepo.Setup(repo => repo.GetAllModel()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllModel() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task GetModelByBrand_ReturnsData()
        {
            // Arrange
            var model = new List<model> { };
            int BrandId = 0;
            _mockModelService.Setup(service => service.GetModelByBrand(BrandId)).Returns(_ModelService.GetModelByBrand);
            _IModelRepo.Setup(repo => repo.GetModelByBrand(BrandId)).Returns(_mockModelRepo.ReturnsModel);

            // Act
            var result = await _controller.GetModelByBrand(BrandId) as OkObjectResult;

            // Assert
            Assert.AreEqual(model, result.Value);
        }

        [Test]
        public async Task GetModelByBrand_ReturnsNull()
        {
            // Arrange
            int BrandId = 0;
            _mockModelService.Setup(service => service.GetModelByBrand(BrandId)).Returns(_ModelService.GetModelByBrand);
            _IModelRepo.Setup(repo => repo.GetModelByBrand(BrandId)).Returns(_mockModelRepo.ReturnsNull);

            // Act
            var result = await _controller.GetModelByBrand(BrandId) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetModelByBrand_WhenServiceThrowsException()
        {
            // Arrange
            int BrandId = 0;
            _mockModelService.Setup(service => service.GetModelByBrand(BrandId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetModelByBrand(BrandId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetModelByBrand_WhenRepositoryThrowsException()
        {
            // Arrange
            int BrandId = 0;
            _mockModelService.Setup(service => service.GetModelByBrand(BrandId)).Returns(_ModelService.GetModelByBrand);
            _IModelRepo.Setup(repo => repo.GetModelByBrand(BrandId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetModelByBrand(BrandId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

    }
}
