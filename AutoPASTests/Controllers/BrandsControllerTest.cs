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
    public class BrandsControllerTests
    {
        private Mock<IBrandsBL> _brandsBLMock;
        private Mock<ILogger<BrandsController>> _loggerMock;
        private BrandsController _brandsController;

        [SetUp]
        public void Setup()
        {
            _brandsBLMock = new Mock<IBrandsBL>();
            _loggerMock = new Mock<ILogger<BrandsController>>();
            _brandsController = new BrandsController(_brandsBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetBrandByVehicleType_Returns_OkResult()
        {
            //Arrange
            var brandsList = new List<Brands>();
            var vehicleType = 0;
            _brandsBLMock.Setup(x => x.GetBrandByVehicleType(vehicleType)).ReturnsAsync(brandsList);

            //Act
            var result = await _brandsController.GetBrandByVehicleType(vehicleType);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(brandsList, okResult.Value);
        }

        [Test]
        public async Task GetFuelTypes_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var vehicleType = 0;
            _brandsBLMock.Setup(x => x.GetBrandByVehicleType(vehicleType)).Throws(new Exception());

            //Act
            var result = await _brandsController.GetBrandByVehicleType(vehicleType);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetAllBrand_Returns_OkResult()
        {
            //Arrange
            var brandsList = new List<Brands>();
            _brandsBLMock.Setup(x => x.GetAllBrand()).ReturnsAsync(brandsList);

            //Act
            var result = await _brandsController.GetAllBrand();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(brandsList, okResult.Value);
        }

        [Test]
        public async Task GetAllBrand_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _brandsBLMock.Setup(x => x.GetAllBrand()).Throws(new Exception());

            //Act
            var result = await _brandsController.GetAllBrand();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
