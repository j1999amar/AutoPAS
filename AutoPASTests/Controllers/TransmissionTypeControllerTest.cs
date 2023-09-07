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

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class TransmissionTypeControllerTests
    {
        private Mock<ITransmissionTypeBL> _transmissionTypeBLMock;
        private Mock<ILogger<TransmissionTypeController>> _loggerMock;
        private TransmissionTypeController _transmissionTypeController;

        [SetUp]
        public void Setup()
        {
            _transmissionTypeBLMock = new Mock<ITransmissionTypeBL>();
            _loggerMock = new Mock<ILogger<TransmissionTypeController>>();
            _transmissionTypeController = new TransmissionTypeController(_transmissionTypeBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetTransmissionTypes_Returns_OkResult()
        {
            //Arrange
            var transmissionList = new List<transmissiontype>();
            var ModelId = 0;
            var FuelId = 0;
            _transmissionTypeBLMock.Setup(x => x.GetTransmissionTypes(ModelId, FuelId)).ReturnsAsync(transmissionList);

            //Act
            var result = await _transmissionTypeController.GetTransmissionTypes(ModelId, FuelId);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(transmissionList, okResult.Value);
        }

        [Test]
        public async Task GetTransmissionTypes_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var ModelId = 0;
            var FuelId = 0;
            _transmissionTypeBLMock.Setup(x => x.GetTransmissionTypes(ModelId, FuelId)).Throws(new Exception());

            //Act
            var result = await _transmissionTypeController.GetTransmissionTypes(ModelId, FuelId);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetAllTransmissionTypes_Returns_OkResult()
        {
            //Arrange
            var transmissionList = new List<transmissiontype>();
            _transmissionTypeBLMock.Setup(x => x.GetAllTransmissionTypes()).ReturnsAsync(transmissionList);

            //Act
            var result = await _transmissionTypeController.GetAllTransmissionTypes();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(transmissionList, okResult.Value);
        }

        [Test]
        public async Task GetAllTransmissionTypes_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _transmissionTypeBLMock.Setup(x => x.GetAllTransmissionTypes()).Throws(new Exception());

            //Act
            var result = await _transmissionTypeController.GetAllTransmissionTypes();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
