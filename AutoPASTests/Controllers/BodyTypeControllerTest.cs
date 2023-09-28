using AutoPASDML;
using AutoPASBL.Interface;
using AutoPASAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

using Moq;
using Moq.Language.Flow;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoPASAL.Services;
using AutoPASAPITests.MockRepository;
using AutoPASAL;
using System.Web.Mvc;
using AutoPASAL.IRepository;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class BodyTypeControllerTests
    {
        private BodyTypeController _controller;
        private Mock<IBodyTypeService> _mockBodyTypeService;
        private Mock<ILogger<BodyTypeController>> _mockLogger;
        private BodyTypeMockRepo _mockBodyTypeRepo;
        private BodyTypeService _bodyTypeService;
        private Mock<IBodyTypeRepo> _IBodyTypeRepo;

        [SetUp]
        public void Setup()
        {
            _IBodyTypeRepo = new Mock<IBodyTypeRepo>();
            _bodyTypeService = new BodyTypeService(_IBodyTypeRepo.Object);
            _mockBodyTypeRepo=new BodyTypeMockRepo();
            _mockBodyTypeService = new Mock<IBodyTypeService>();
            _mockLogger = new Mock<ILogger<BodyTypeController>>();
            _controller = new BodyTypeController(_mockBodyTypeService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllBodyType_ReturnsData()
        {
            // Arrange
            var bodyTypes = new List<bodyType> { };
            _mockBodyTypeService.Setup(service => service.GetAllBodyType()).Returns(_bodyTypeService.GetAllBodyType);
            _IBodyTypeRepo.Setup(repo => repo.GetAllBodyType()).Returns(_mockBodyTypeRepo.ReturnsBodyType);

            // Act
            var result = await _controller.GetAllBodyType() as OkObjectResult;
            
            // Assert
            Assert.AreEqual(bodyTypes,result.Value);
        }

        [Test]
        public async Task GetAllBodyType_ReturnsNull()
        {
            // Arrange
            _mockBodyTypeService.Setup(service => service.GetAllBodyType()).Returns(_bodyTypeService.GetAllBodyType);
            _IBodyTypeRepo.Setup(service => service.GetAllBodyType()).Returns(_mockBodyTypeRepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllBodyType() as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }

        [Test]
        public async Task GetAllBodyType_WhenServiceThrowsException()
        {
            // Arrange
            _mockBodyTypeService.Setup(service => service.GetAllBodyType()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllBodyType() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllBodyType_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockBodyTypeService.Setup(service => service.GetAllBodyType()).Returns(_bodyTypeService.GetAllBodyType);
            _IBodyTypeRepo.Setup(service => service.GetAllBodyType()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllBodyType() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }



    }
}
