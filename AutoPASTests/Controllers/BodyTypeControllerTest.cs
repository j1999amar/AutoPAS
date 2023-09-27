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
using AutoPASAL.Services;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class BodyTypeControllerTests
    {
        private Mock<IBodyTypeService> _bodyTypeMock;
        private Mock<ILogger<BodyTypeController>> _loggerMock;
        private BodyTypeController _bodyTypeController;

        [SetUp]
        public void Setup()
        {
            _bodyTypeMock = new Mock<IBodyTypeService>();
            _loggerMock = new Mock<ILogger<BodyTypeController>>();
            _bodyTypeController = new BodyTypeController(_bodyTypeMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAllBodyType_Returns_OkResult()
        {
            //Arrange
            var bodyList = new List<bodyType>();
            _bodyTypeMock.Setup(x => x.GetAllBodyType()).ReturnsAsync(bodyList);

            //Act
            var result = await _bodyTypeController.GetAllBodyType();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(bodyList, okResult.Value);
        }

        [Test]
        public async Task GetAllBodyType_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _bodyTypeMock.Setup(x => x.GetAllBodyType()).Throws(new Exception());

            //Act
            var result = await _bodyTypeController.GetAllBodyType();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetAllBodyType_Returns_null()
        {
            //Arrange
            var bodyList = new List<bodyType>(){null};
            _bodyTypeMock.Setup(x => x.GetAllBodyType()).ReturnsAsync(bodyList);

            //Act
            var result = await _bodyTypeController.GetAllBodyType();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(bodyList, okResult.Value);
        }

        [Test]
        public async Task jkn()
        {
            //Arrange
            var bodyList = new List<bodyType>() { null };
            _bodyTypeMock.Setup(x => x.GetAllBodyType()).ReturnsAsync(bodyList);

            //Act
            var result = await _bodyTypeController.GetAllBodyType();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(bodyList, okResult.Value);
        }


    }
}
