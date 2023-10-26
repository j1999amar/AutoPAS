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
    public class RTOControllerTests
    {
        private RTOController _controller;
        private Mock<IRTOService> _mockRTOService;
        private Mock<ILogger<RTOController>> _mockLogger;
        private RTOMockRepo _mockRTORepo;
        private RTOService _RTOService;
        private Mock<IRTORepo> _IRTORepo;

        [SetUp]
        public void Setup()
        {
            _IRTORepo = new Mock<IRTORepo>();
            _RTOService = new RTOService(_IRTORepo.Object);
            _mockRTORepo = new RTOMockRepo();
            _mockRTOService = new Mock<IRTOService>();
            _mockLogger = new Mock<ILogger<RTOController>>();
            _controller = new RTOController(_mockRTOService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllRTO_ReturnsData()
        {
            // Arrange
            var rtos = new List<rto> { };
            Guid id = new Guid();
            _mockRTOService.Setup(service => service.GetAllRTO(id)).Returns(_RTOService.GetAllRTO);
            _IRTORepo.Setup(repo => repo.GetAllRTO(id)).Returns(_mockRTORepo.ReturnsRTO);

            // Act
            var result = await _controller.GetAllRTO(id) as OkObjectResult;

            // Assert
            Assert.AreEqual(rtos, result.Value);
        }

        [Test]
        public async Task GetAllRTO_ReturnsNull()
        {
            // Arrange
            Guid id = new Guid();
            _mockRTOService.Setup(service => service.GetAllRTO(id)).Returns(_RTOService.GetAllRTO);
            _IRTORepo.Setup(service => service.GetAllRTO(id)).Returns(_mockRTORepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllRTO(id) as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }

        [Test]
        public async Task GetAllRTO_WhenServiceThrowsException()
        {
            // Arrange
            Guid id = new Guid();
            _mockRTOService.Setup(service => service.GetAllRTO(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllRTO(id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllRTO_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid id = new Guid();
            _mockRTOService.Setup(service => service.GetAllRTO(id)).Returns(_RTOService.GetAllRTO);
            _IRTORepo.Setup(service => service.GetAllRTO(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllRTO(id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllRTOState_ReturnsData()
        {
            // Arrange
            var rtos = new List<rto> { };
            _mockRTOService.Setup(service => service.GetAllRTOState()).Returns(_RTOService.GetAllRTOState);
            _IRTORepo.Setup(repo => repo.GetAllRTOState()).Returns(_mockRTORepo.ReturnsRTO);

            // Act
            var result = await _controller.GetAllRTOState() as OkObjectResult;

            // Assert
            Assert.AreEqual(rtos, result.Value);
        }

        [Test]
        public async Task GetAllRTOState_ReturnsNull()
        {
            // Arrange
            _mockRTOService.Setup(service => service.GetAllRTOState()).Returns(_RTOService.GetAllRTOState);
            _IRTORepo.Setup(service => service.GetAllRTOState()).Returns(_mockRTORepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllRTOState() as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }

        [Test]
        public async Task GetAllRTOState_WhenServiceThrowsException()
        {
            // Arrange
            _mockRTOService.Setup(service => service.GetAllRTOState()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllRTOState() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllRTOState_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockRTOService.Setup(service => service.GetAllRTOState()).Returns(_RTOService.GetAllRTOState);
            _IRTORepo.Setup(service => service.GetAllRTOState()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllRTOState() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetRTOCityByState_ReturnsData()
        {
            // Arrange
            var rtos = new List<rto> { };
            string test = "";
            _mockRTOService.Setup(service => service.GetRTOCityByState(test)).Returns(_RTOService.GetRTOCityByState);
            _IRTORepo.Setup(repo => repo.GetRTOCityByState(test)).Returns(_mockRTORepo.ReturnsRTO);

            // Act
            var result = await _controller.GetRTOCityByState(test) as OkObjectResult;

            // Assert
            Assert.AreEqual(rtos, result.Value);
        }

        [Test]
        public async Task GetRTOCityByState_ReturnsNull()
        {
            // Arrange
            string test = "";
            _mockRTOService.Setup(service => service.GetRTOCityByState(test)).Returns(_RTOService.GetRTOCityByState);
            _IRTORepo.Setup(service => service.GetRTOCityByState(test)).Returns(_mockRTORepo.ReturnsNull);

            // Act
            var result = await _controller.GetRTOCityByState(test) as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }

        [Test]
        public async Task GetRTOCityByState_WhenServiceThrowsException()
        {
            // Arrange
            string test = "";
            _mockRTOService.Setup(service => service.GetRTOCityByState(test)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetRTOCityByState(test) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetRTOCityByState_WhenRepositoryThrowsException()
        {
            // Arrange
            string test = "";
            _mockRTOService.Setup(service => service.GetRTOCityByState(test)).Returns(_RTOService.GetAllRTO);
            _IRTORepo.Setup(service => service.GetRTOCityByState(test)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetRTOCityByState(test) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetRTONameByCity_ReturnsData()
        {
            // Arrange
            var rtos = new List<rto> { };
            string test = "";
            _mockRTOService.Setup(service => service.GetRTONameByCity(test)).Returns(_RTOService.GetRTONameByCity);
            _IRTORepo.Setup(repo => repo.GetRTONameByCity(test)).Returns(_mockRTORepo.ReturnsRTO);

            // Act
            var result = await _controller.GetRTONameByCity(test) as OkObjectResult;

            // Assert
            Assert.AreEqual(rtos, result.Value);
        }

        [Test]
        public async Task GetRTONameByCity_ReturnsNull()
        {
            // Arrange
            string test = "";
            _mockRTOService.Setup(service => service.GetRTONameByCity(test)).Returns(_RTOService.GetRTONameByCity);
            _IRTORepo.Setup(service => service.GetRTONameByCity(test)).Returns(_mockRTORepo.ReturnsNull);

            // Act
            var result = await _controller.GetRTONameByCity(test) as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }

        [Test]
        public async Task GetRTONameByCity_WhenServiceThrowsException()
        {
            // Arrange
            string test = "";
            _mockRTOService.Setup(service => service.GetRTONameByCity(test)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetRTONameByCity(test) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetRTONameByCity_WhenRepositoryThrowsException()
        {
            // Arrange
            string test = "";
            _mockRTOService.Setup(service => service.GetRTONameByCity(test)).Returns(_RTOService.GetAllRTO);
            _IRTORepo.Setup(service => service.GetRTONameByCity(test)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetRTONameByCity(test) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetCity_ReturnsData()
        {
            // Arrange
            var rtos = new List<rto> { };
            Guid id = new Guid();
            _mockRTOService.Setup(service => service.GetCity(id)).Returns(_RTOService.GetCity);
            _IRTORepo.Setup(repo => repo.GetCity(id)).Returns(_mockRTORepo.ReturnsRTO);

            // Act
            var result = await _controller.GetCity(id) as OkObjectResult;

            // Assert
            Assert.AreEqual(rtos, result.Value);
        }

        [Test]
        public async Task GetCity_ReturnsNull()
        {
            // Arrange
            Guid id = new Guid();
            _mockRTOService.Setup(service => service.GetCity(id)).Returns(_RTOService.GetCity);
            _IRTORepo.Setup(service => service.GetCity(id)).Returns(_mockRTORepo.ReturnsNull);

            // Act
            var result = await _controller.GetCity(id) as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }

        [Test]
        public async Task GetCity_WhenServiceThrowsException()
        {
            // Arrange
            Guid id = new Guid();
            _mockRTOService.Setup(service => service.GetCity(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetCity(id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetCity_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid id = new Guid();
            _mockRTOService.Setup(service => service.GetCity(id)).Returns(_RTOService.GetCity);
            _IRTORepo.Setup(service => service.GetCity(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetCity(id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task AddRTO_ReturnOkResponse_WhenRTOIdIsNotExsitsAndDataAdded()
        {
            //Arrange
            var rto = new rto();
            _mockRTOService.Setup(service=>service.IsExists(rto.RTOId)).Returns(false);

            //Act
            var result=await _controller.AddRTO(rto) as ObjectResult;

            //Assert
            Assert.AreEqual(200,result.StatusCode);
        }

        [Test]
        public async Task AddRTO_ReturnBadRequest_WhenRTOIdIsExsitsAndDataNotAdded()
        {
            //Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.IsExists(rto.RTOId)).Returns(true);

            //Act
            var result = await _controller.AddRTO(rto) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task AddRTO_WhenServiceThrowsException()
        {
            // Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.AddRTO(rto)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.AddRTO(rto) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task AddRTO_WhenRepositoryThrowsException()
        {
            // Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.AddRTO(rto)).Throws(new Exception());
            _IRTORepo.Setup(service => service.AddRTO(rto)).Throws(new Exception());

            // Act
            var result = await _controller.AddRTO(rto) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }


        [Test]
        public async Task EditRTO_ReturnOkResponse_WhenRTOIdIsExsitsAndDataUpdated()
        {
            //Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.IsExists(rto.RTOId)).Returns(true);

            //Act
            var result = await _controller.EditRTO(rto) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task EditRTO_ReturnBadRequest_WhenRTOIdIsNotExsitsAndDataNotUpdated()
        {
            //Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.IsExists(rto.RTOId)).Returns(false);

            //Act
            var result = await _controller.EditRTO(rto) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task EditRTO_WhenServiceThrowsException()
        {
            // Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.EditRTO(rto)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.EditRTO(rto) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task EditRTO_WhenRepositoryThrowsException()
        {
            // Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.EditRTO(rto)).Throws(new Exception());
            _IRTORepo.Setup(service => service.EditRTO(rto)).Throws(new Exception());

            // Act
            var result = await _controller.EditRTO(rto) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task DeleteRTO_ReturnOkResponse_WhenRTOIdIsExsitsAndDataDeleted()
        {
            //Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.IsExists(rto.RTOId)).Returns(true);

            //Act
            var result =  _controller.DeleteRTO(rto.RTOId) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task DeleteRTO_ReturnBadRequest_WhenRTOIdIsNotExsitsAndDataNotDeleted()
        {
            //Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.IsExists(rto.RTOId)).Returns(false);

            //Act
            var result =  _controller.DeleteRTO(rto.RTOId) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task DeleteRTO_WhenServiceThrowsException()
        {
            // Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.DeleteRTO(rto.RTOId)).Throws(new Exception());

            // Act
            var result =  _controller.DeleteRTO(rto.RTOId) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task DeleteRTO_WhenRepositoryThrowsException()
        {
            // Arrange
            var rto = new rto();
            _mockRTOService.Setup(service => service.DeleteRTO(rto.RTOId)).Throws(new Exception());
            _IRTORepo.Setup(service => service.DeleteRTO(rto.RTOId)).Throws(new Exception());

            // Act
            var result = _controller.DeleteRTO(rto.RTOId) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}
