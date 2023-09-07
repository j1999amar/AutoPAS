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
    public class VariantControllerTests
    {
        private Mock<IVariantBL> _variantBLMock;
        private Mock<ILogger<VariantController>> _loggerMock;
        private VariantController _variantController;

        [SetUp]
        public void Setup()
        {
            _variantBLMock = new Mock<IVariantBL>();
            _loggerMock = new Mock<ILogger<VariantController>>();
            _variantController = new VariantController(_variantBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAllVariant_Returns_OkResult()
        {
            //Arrange
            var variantList = new List<variant>();            
            _variantBLMock.Setup(x => x.GetAllVariant()).ReturnsAsync(variantList);

            //Act
            var result = await _variantController.GetAllVariant();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(variantList, okResult.Value);
        }

        [Test]
        public async Task GetAllVariant_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _variantBLMock.Setup(x => x.GetAllVariant()).Throws(new Exception());

            //Act
            var result = await _variantController.GetAllVariant();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetVariant_Returns_OkResult()
        {
            //Arrange
            var variantList = new List<variant>();
            var ModelId = 0;
            var FuelId = 0;
            var TransmissionId = 0;
            _variantBLMock.Setup(x => x.GetVariant(ModelId, FuelId, TransmissionId)).ReturnsAsync(variantList);

            //Act
            var result = await _variantController.GetVariant(ModelId, FuelId, TransmissionId);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(variantList, okResult.Value);
        }

        [Test]
        public async Task GetVariant_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var ModelId = 0;
            var FuelId = 0;
            var TransmissionId = 0;
            _variantBLMock.Setup(x => x.GetVariant(ModelId, FuelId, TransmissionId)).Throws(new Exception());

            //Act
            var result = await _variantController.GetVariant(ModelId, FuelId, TransmissionId);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
