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
using AutoPASSL.Repository;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class BrandsControllerTests
    {
        private BrandsController _controller;
        private Mock<IBrandsService> _mockBrandsService;
        private Mock<ILogger<BrandsController>> _mockLogger;
        private BrandsMockRepo _mockBrandsRepo;
        private BrandsService _brandsService;
        private Mock<IBrandsRepo> _IBrandsRepo;

        [SetUp]
        public void Setup()
        {
            _IBrandsRepo = new Mock<IBrandsRepo>();
            _brandsService = new BrandsService(_IBrandsRepo.Object);
            _mockBrandsRepo = new BrandsMockRepo();
            _mockBrandsService = new Mock<IBrandsService>();
            _mockLogger = new Mock<ILogger<BrandsController>>();
            _controller = new BrandsController(_mockBrandsService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllBrand_ReturnsData()
        {
            // Arrange
            var brands = new List<Brands> { };
            _mockBrandsService.Setup(service => service.GetAllBrand()).Returns(_brandsService.GetAllBrand);
            _IBrandsRepo.Setup(repo => repo.GetAllBrand()).Returns(_mockBrandsRepo.ReturnsBrand);

            // Act
            var result = await _controller.GetAllBrand() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(brands, result.Value);
        }
        [Test]
        public async Task GetAllBrand_ReturnsNull()
        {
            // Arrange
            var brands = new List<Brands> { };
            _mockBrandsService.Setup(service => service.GetAllBrand()).Returns(_brandsService.GetAllBrand);
            _IBrandsRepo.Setup(repo => repo.GetAllBrand()).Returns(_mockBrandsRepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllBrand() as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }
        [Test]
        public async Task GetAllBrand_WhenServiceThrowsException()
        {
            // Arrange
            _mockBrandsService.Setup(service => service.GetAllBrand()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllBrand() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllBrand_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockBrandsService.Setup(service => service.GetAllBrand()).Returns(_brandsService.GetAllBrand);
            _IBrandsRepo.Setup(repo => repo.GetAllBrand()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllBrand() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetBrandByVehicleType_ReturnsData()
        {
            // Arrange
            var brands = new List<Brands> { };
            int VehicleType = 0;
            _mockBrandsService.Setup(service => service.GetBrandByVehicleType(VehicleType)).Returns(_brandsService.GetBrandByVehicleType);
            _IBrandsRepo.Setup(repo => repo.GetBrandByVehicleType(VehicleType)).Returns(_mockBrandsRepo.ReturnsBrand);

            // Act
            var result = await _controller.GetBrandByVehicleType(VehicleType) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(brands, result.Value);
        }
        [Test]
        public async Task GetBrandByVehicleType_ReturnsNull()
        {
            // Arrange
            var brands = new List<Brands> { };
            int VehicleType = 0;
            _mockBrandsService.Setup(service => service.GetBrandByVehicleType(VehicleType)).Returns(_brandsService.GetBrandByVehicleType);
            _IBrandsRepo.Setup(repo => repo.GetBrandByVehicleType(VehicleType)).Returns(_mockBrandsRepo.ReturnsNull);

            // Act
            var result = await _controller.GetBrandByVehicleType(VehicleType) as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }
        [Test]
        public async Task GetBrandByVehicleType_WhenServiceThrowsException()
        {
            // Arrange
            int VehicleType = 0;
            _mockBrandsService.Setup(service => service.GetBrandByVehicleType(VehicleType)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetBrandByVehicleType(VehicleType) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }        
        [Test]
        public async Task GetBrandByVehicleType_WhenRepositoryThrowsException()
        {
            // Arrange
            int VehicleType = 0;
            _mockBrandsService.Setup(service => service.GetBrandByVehicleType(VehicleType)).Returns(_brandsService.GetBrandByVehicleType);
            _IBrandsRepo.Setup(repo => repo.GetBrandByVehicleType(VehicleType)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetBrandByVehicleType(VehicleType) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task AddBrand_ReturnOkResponse_WhenBrandIdIsNotExsitsAndDataAdded()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(false);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            //Act
            var result = await _controller.AddBrands(brand) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public async Task AddBrand_ReturnBadRequest_WhenBrandIdIsExisitsAndDataIsNotAdded()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(true);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            //Act
            var result = await _controller.AddBrands(brand) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);

        }
        [Test]
        public async Task AddBrand_ReturnOkResponse_WhenVehicleTypeIsNotExists()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(false);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            //Act
            var result = await _controller.AddBrands(brand) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public async Task AddBrand_ReturnBadRequest_WhenVehicleTypeIsNotExists()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(false);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(false);

            //Act
            var result = await _controller.AddBrands(brand) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);

        }
        [Test]
        public async Task AddBrand_WhenServiceThrowsException()
        {
            // Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.AddBrands(brand)).ThrowsAsync(new Exception());
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(false);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            // Act
            var result = await _controller.AddBrands(brand) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task AddBrand_WhenRepositoryThrowsException()
        {
            // Arrange
            var brand=new Brands();
            _mockBrandsService.Setup(service => service.AddBrands(brand)).ThrowsAsync(new Exception());
            _IBrandsRepo.Setup(repo => repo.AddBrands(brand)).ThrowsAsync(new Exception());
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(false);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            // Act
            var result = await _controller.AddBrands(brand) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }




        [Test]
        public async Task Edit_ReturnOkResponse_WhenBrandIdIsExsitsAndDataUpdated()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(true);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            //Act
            var result = await _controller.EditBrands(brand) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public async Task EditBrand_ReturnBadRequest_WhenBrandIdIsNotExisitsAndDataIsNotUpdated()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(false);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            //Act
            var result = await _controller.EditBrands(brand) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);

        }
        [Test]
        public async Task EditBrand_ReturnOkResponse_WhenVehicleTypeIsExistsAndDataIsUpdated()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(true);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            //Act
            var result = await _controller.EditBrands(brand) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public async Task EditBrand_ReturnBadRequest_WhenVehicleTypeIsNotExists()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(true);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(false);

            //Act
            var result = await _controller.EditBrands(brand) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);

        }
        [Test]
        public async Task EditBrand_WhenServiceThrowsException()
        {
            // Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.EditBrands(brand)).ThrowsAsync(new Exception());
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(true);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            // Act
            var result = await _controller.EditBrands(brand) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task EditBrand_WhenRepositoryThrowsException()
        {
            // Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.EditBrands(brand)).ThrowsAsync(new Exception());
            _IBrandsRepo.Setup(repo => repo.EditBrands(brand)).ThrowsAsync(new Exception());
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(true);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            // Act
            var result = await _controller.EditBrands(brand) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task DeleteBrand_OkResponse_WhenBrandIsDeleted()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(true);

            //Act
            var result=_controller.DeleteBrands(brand.BrandId) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }
        [Test]
        public async Task DeleteBrand_BadRequest_WhenBrandIsNotDeleted()
        {
            //Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(false);

            //Act
            var result = _controller.DeleteBrands(brand.BrandId) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);

        }
        [Test]
        public async Task DeleteBrand_WhenServiceThrowsException()
        {
            // Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.EditBrands(brand)).ThrowsAsync(new Exception());
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(true);
            _mockBrandsService.Setup(service => service.vehicleTypeIdIsExists(brand.VehicleTypeId)).Returns(true);

            // Act
            var result = await _controller.EditBrands(brand) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task DeleteBrand_WhenRepositoryThrowsException()
        {
            // Arrange
            var brand = new Brands();
            _mockBrandsService.Setup(service => service.EditBrands(brand)).ThrowsAsync(new Exception());
            _IBrandsRepo.Setup(repo => repo.EditBrands(brand)).ThrowsAsync(new Exception());
            _mockBrandsService.Setup(service => service.IsExists(brand.BrandId)).Returns(true);

            // Act
            var result = await _controller.EditBrands(brand) as ObjectResult;

            // Assert
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}
