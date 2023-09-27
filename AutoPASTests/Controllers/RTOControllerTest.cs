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

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class RTOControllerTests
    {
        private Mock<IRTOBL> _rtoBLMock;
        private Mock<ILogger<RTOController>> _loggerMock;
        private RTOController _rtoController;

        [SetUp]
        public void Setup()
        {
            _rtoBLMock = new Mock<IRTOBL>();
            _loggerMock = new Mock<ILogger<RTOController>>();
            _rtoController = new RTOController(_rtoBLMock.Object,_loggerMock.Object);
        }

        [Test]
        public async Task GetAllRTOState_Returns_OkResult()
        {
            //Arrange
            var rtoList = new List<RTO>();
            _rtoBLMock.Setup(x => x.GetAllRTOState()).ReturnsAsync(rtoList);

            //Act
            var result = await _rtoController.GetAllRTOState();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(rtoList, okResult.Value);
        }

        [Test]
        public async Task GetAllRTOState_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _rtoBLMock.Setup(x => x.GetAllRTOState()).Throws(new Exception());

            //Act
            var result = await _rtoController.GetAllRTOState();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        
        [Test]
        public async Task GetRTOCityByState_Returns_OkResult()
        {
            //Arrange
            var rtoList = new List<RTO>();
            var state = "SomeState";
            _rtoBLMock.Setup(x => x.GetRTOCityByState(state)).ReturnsAsync(rtoList);

            //Act
            var result = await _rtoController.GetRTOCityByState(state);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(rtoList, okResult.Value);
        }

        [Test]
        public async Task GetRTOCityByState_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var state = "SomeState";
            _rtoBLMock.Setup(x => x.GetRTOCityByState(state)).Throws(new Exception());

            //Act
            var result = await _rtoController.GetRTOCityByState(state);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetRTONameByCity_Returns_OkResult()
        {
            //Arrange
            var rtoList = new List<RTO>();
            var city = "SomeCity";
            _rtoBLMock.Setup(x => x.GetRTONameByCity(city)).ReturnsAsync(rtoList);

            //Act
            var result = await _rtoController.GetRTONameByCity(city);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(rtoList, okResult.Value);
        }

        [Test]
        public async Task GetRTONameByCity_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var city = "SomeCity";
            _rtoBLMock.Setup(x => x.GetRTONameByCity(city)).Throws(new Exception());

            //Act
            var result = await _rtoController.GetRTONameByCity(city);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetAllRTO_Returns_OkResult()
        {
            //Arrange
            var rtoList = new List<RTO>();
            var id = new Guid();
            _rtoBLMock.Setup(x => x.GetAllRTO(id)).ReturnsAsync(rtoList);

            //Act
            var result = await _rtoController.GetAllRTO(id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(rtoList, okResult.Value);
        }

        [Test]
        public async Task GetAllRTO_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var id = new Guid();
            _rtoBLMock.Setup(x => x.GetAllRTO(id)).Throws(new Exception());

            //Act
            var result = await _rtoController.GetAllRTO(id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        
        [Test]
        public async Task GetCity_Returns_OkResult()
        {
            //Arrange
            var rtoList = new List<RTO>();
            var id = new Guid();
            _rtoBLMock.Setup(x => x.GetCity(id)).ReturnsAsync(rtoList);

            //Act
            var result = await _rtoController.GetCity(id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(rtoList, okResult.Value);
        }
        [Test]
        public async Task GetCity_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var id = new Guid();
            _rtoBLMock.Setup(x => x.GetCity(id)).Throws(new Exception());

            //Act
            var result = await _rtoController.GetCity(id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
