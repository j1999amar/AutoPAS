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
    public class BodyTypeControllerTests
    {
        private Mock<IBodyTypeBL> _bodyTypeBLMock;
        private Mock<ILogger<BodyTypeController>> _loggerMock;
        private BodyTypeController _bodyTypeController;

        [SetUp]
        public void Setup()
        {
            _bodyTypeBLMock = new Mock<IBodyTypeBL>();
            _loggerMock = new Mock<ILogger<BodyTypeController>>();
            _bodyTypeController = new BodyTypeController(_bodyTypeBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAllBodyType_Returns_OkResult()
        {
            //Arrange
            var bodyList = new List<bodyType>();
            _bodyTypeBLMock.Setup(x => x.GetAllBodyType()).ReturnsAsync(bodyList);

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
            _bodyTypeBLMock.Setup(x => x.GetAllBodyType()).Throws(new Exception());

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
            _bodyTypeBLMock.Setup(x => x.GetAllBodyType()).ReturnsAsync(bodyList);

            //Act
            var result = await _bodyTypeController.GetAllBodyType();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(bodyList, okResult.Value);
        }

    }
}
