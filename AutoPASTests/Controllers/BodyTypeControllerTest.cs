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
        private Mock<ILogger<BodyTypeController>> _mockLogger;
        private BodyTypeController _controller;

        private Mock<IBodyTypeService> _mockBodyTypeService;
        private Mock<IBodyTypeRepo> _IBodyTypeRepo;

        private BodyTypeMockRepo _mockBodyTypeRepo;
        private BodyTypeService _bodyTypeService;

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
            Assert.AreEqual(null, result.Value);
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
        
        
        [Test]
        public async Task AddBodyType_ReturnsBadRequest_WhenIdIsExists()
        {
            //Arrange
            var bodyType = new bodyType();
            _mockBodyTypeService.Setup(service=>service.IsExists(bodyType.BodyTypeId)).Returns(true);

            //Act
            var result = await _controller.AddBodyType(bodyType) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);

        }
        [Test]
        public async Task AddBodyType_ReturnsOkResponse_WhenIdIsNotExistsAndAddRecord()
        {
            //Arrange
            var bodyType = new bodyType();
            _mockBodyTypeService.Setup(service => service.IsExists(bodyType.BodyTypeId)).Returns(false);

            //Act
            var result = await _controller.AddBodyType(bodyType) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public async Task AddBodyType_WhenServiceThrowsException()
        {
            // Arrange
            var bodyType=new bodyType();
            _mockBodyTypeService.Setup(service => service.AddBodyType(bodyType)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.AddBodyType(bodyType) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task AddBodyType_WhenRepositoryThrowsException()
        {
            // Arrange
            var bodyType = new bodyType();
            _IBodyTypeRepo.Setup(service => service.AddBodyType(bodyType)).ThrowsAsync(new Exception());
            _mockBodyTypeService.Setup(service => service.AddBodyType(bodyType)).ThrowsAsync(new Exception());
            // Act
            var result = await _controller.AddBodyType(bodyType) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }


        [Test]
        public async Task EditBodyType_ReturnsBadRequest_WhenIdIsNotExists()
        {
            //Arrange
            var bodyType = new bodyType();
            _mockBodyTypeService.Setup(service => service.IsExists(bodyType.BodyTypeId)).Returns(false);

            //Act
            var result = await _controller.EditBodyType(bodyType) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);

        }
        [Test]
        public async Task EditBodyType_ReturnsOkRequest_WhenIdIsExists()
        {
            //Arrange
            var bodyType = new bodyType();
            _mockBodyTypeService.Setup(service => service.IsExists(bodyType.BodyTypeId)).Returns(true);

            //Act
            var result = await _controller.EditBodyType(bodyType) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public async Task EditBodyType_WhenServiceThrowsException()
        {
            // Arrange
            var bodyType = new bodyType();
            _mockBodyTypeService.Setup(service => service.AddBodyType(bodyType)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.EditBodyType(bodyType) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task EditBodyType_WhenRepositoryThrowsException()
        {
            // Arrange
            var bodyType = new bodyType();
            _IBodyTypeRepo.Setup(service => service.EditBodyType(bodyType)).ThrowsAsync(new Exception());
            _mockBodyTypeService.Setup(service => service.EditBodyType(bodyType)).ThrowsAsync(new Exception());
            // Act
            var result = await _controller.EditBodyType(bodyType) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }


        [Test]
        public async Task DeleteBodyType_ReturnsBadRequest_WhenIdIsNotExists()
        {
            //Arrange
            var bodyType = new bodyType();
            _mockBodyTypeService.Setup(service => service.IsExists(bodyType.BodyTypeId)).Returns(false);

            //Act
            var result = await _controller.DeleteBodyType(bodyType.BodyTypeId) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);

        }
        [Test]
        public async Task DeleteBodyType_ReturnsOkRequest_WhenIdIsExistsAndDataDeleted()
        {
            //Arrange
            var bodyType = new bodyType();
            _mockBodyTypeService.Setup(service => service.IsExists(bodyType.BodyTypeId)).Returns(true);

            //Act
            var result = await _controller.DeleteBodyType(bodyType.BodyTypeId) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public async Task DeleteBodyType_WhenServiceThrowsException()
        {
            // Arrange
            var bodyType = new bodyType();
            _mockBodyTypeService.Setup(service => service.DeleteBodyType(bodyType.BodyTypeId)).Throws(new Exception());

            // Act
            var result = await _controller.DeleteBodyType(bodyType.BodyTypeId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task DeleteBodyType_WhenRepositoryThrowsException()
        {
            // Arrange
            var bodyType = new bodyType();
            _IBodyTypeRepo.Setup(service => service.DeleteBodyType(bodyType.BodyTypeId)).Throws(new Exception());
            _mockBodyTypeService.Setup(service => service.DeleteBodyType(bodyType.BodyTypeId)).Throws(new Exception());
            // Act
            var result = await _controller.DeleteBodyType(bodyType.BodyTypeId) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }




    }
}
