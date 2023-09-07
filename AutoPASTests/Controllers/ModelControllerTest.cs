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
    public class ModelControllerTests
    {
        private Mock<IModelBL> _modelBLMock;
        private Mock<ILogger<ModelController>> _loggerMock;
        private ModelController _modelController;

        [SetUp]
        public void Setup()
        {
            _modelBLMock = new Mock<IModelBL>();
            _loggerMock = new Mock<ILogger<ModelController>>();
            _modelController = new ModelController(_modelBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetModelByBrand_Returns_OkResult()
        {
            //Arrange
            var modelList = new List<model>();
            var BrandId = 0;
            _modelBLMock.Setup(x => x.GetModelByBrand(BrandId)).ReturnsAsync(modelList);

            //Act
            var result = await _modelController.GetModelByBrand(BrandId);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(modelList, okResult.Value);
        }

        [Test]
        public async Task GetModelByBrand_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var BrandId = 0;
            _modelBLMock.Setup(x => x.GetModelByBrand(BrandId)).Throws(new Exception());

            //Act
            var result = await _modelController.GetModelByBrand(BrandId);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetAllModel_Returns_OkResult()
        {
            //Arrange
            var modelList = new List<model>();
            _modelBLMock.Setup(x => x.GetAllModel()).ReturnsAsync(modelList);

            //Act
            var result = await _modelController.GetAllModel();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(modelList, okResult.Value);
        }

        [Test]
        public async Task GetAllModel_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _modelBLMock.Setup(x => x.GetAllModel()).Throws(new Exception());

            //Act
            var result = await _modelController.GetAllModel();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
