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
    public class CoverageControllerTests
    {
        private CoveragesController _controller;
        private Mock<ICoverageService> _mockCoverageService;
        private Mock<ILogger<CoveragesController>> _mockLogger;
        private CoverageMockRepo _mockCoverageRepo;
        private CoverageService _CoverageService;
        private Mock<ICoverageRepo> _ICoverageRepo;

        [SetUp]
        public void Setup()
        {
            _ICoverageRepo = new Mock<ICoverageRepo>();
            _CoverageService = new CoverageService(_ICoverageRepo.Object);
            _mockCoverageRepo = new CoverageMockRepo();
            _mockCoverageService = new Mock<ICoverageService>();
            _mockLogger = new Mock<ILogger<CoveragesController>>();
            _controller = new CoveragesController(_mockCoverageService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllCoverage_ReturnsData()
        {
            // Arrange
            var coverages = new List<coverages> { };
            _mockCoverageService.Setup(service => service.GetAllCoverages()).Returns(_CoverageService.GetAllCoverages);
            _ICoverageRepo.Setup(repo => repo.GetAllCoverages()).Returns(_mockCoverageRepo.ReturnsCoverage);

            // Act
            var result = await _controller.GetAllCoverages() as OkObjectResult;

            // Assert
            Assert.AreEqual(coverages, result.Value);
        }

        [Test]
        public async Task GetAllCoverage_ReturnsNull()
        {
            // Arrange
            _mockCoverageService.Setup(service => service.GetAllCoverages()).Returns(_CoverageService.GetAllCoverages);
            _ICoverageRepo.Setup(service => service.GetAllCoverages()).Returns(_mockCoverageRepo.ReturnsNull);

            // Act
            var result = await _controller.GetAllCoverages() as ObjectResult;

            // Assert
            Assert.AreEqual(null, result.Value);
        }

        [Test]
        public async Task GetAllCoverage_WhenServiceThrowsException()
        {
            // Arrange
            _mockCoverageService.Setup(service => service.GetAllCoverages()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllCoverages() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllCoverage_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockCoverageService.Setup(service => service.GetAllCoverages()).Returns(_CoverageService.GetAllCoverages);
            _ICoverageRepo.Setup(service => service.GetAllCoverages()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllCoverages() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task AddCoverage_ReturnOkResponseWhenCoverageIdIsNotExistsAndIsAdded()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service=>service.IsExists(coverage.CoverageId)).Returns(false);

            //Act
            var result= await _controller.AddCoverage(coverage) as ObjectResult;

            //
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task AddCoverage_ReturnBadRequestWhenCoverageIdIsExistsAndIsNotAdded()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.IsExists(coverage.CoverageId)).Returns(true);

            //Act
            var result = await _controller.AddCoverage(coverage) as ObjectResult;

            //
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task AddCoverage_WhenServiceThorwsException()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.AddCoverages(coverage)).Throws(new Exception());

            //Act
            var result = await _controller.AddCoverage(coverage) as ObjectResult;

            //
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task AddCoverage_WhenRepositoryThorwsException()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.AddCoverages(coverage)).Throws(new Exception());
            _ICoverageRepo.Setup(service => service.AddCoverages(coverage)).ThrowsAsync(new Exception());




            //Act
            var result = await _controller.AddCoverage(coverage) as ObjectResult;

            //
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task EditCoverage_ReturnOkResponseWhenCoverageIdIsExistsAndIsUpdated()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.IsExists(coverage.CoverageId)).Returns(true);

            //Act
            var result = await _controller.EditCoverage(coverage) as ObjectResult;

            //
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task EditCoverage_ReturnBadRequestWhenCoverageIdIsNotExistsAndIsNotUpdated()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.IsExists(coverage.CoverageId)).Returns(false);

            //Act
            var result = await _controller.EditCoverage(coverage) as ObjectResult;

            //
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task EditCoverage_WhenServiceThorwsException()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.EditCoverage(coverage)).Throws(new Exception());

            //Act
            var result = await _controller.EditCoverage(coverage) as ObjectResult;

            //
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task EditCoverage_WhenRepositoryThorwsException()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.EditCoverage(coverage)).Throws(new Exception());
            _ICoverageRepo.Setup(service => service.EditCoverage(coverage)).ThrowsAsync(new Exception());

            //Act
            var result = await _controller.EditCoverage(coverage) as ObjectResult;

            //
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public async Task DeleteCoverage_ReturnOkResponse_WhenCoverageIdIsExsistsAndDataDeleted()
        {
            //Arrange
            var coverage = new coverages();
            _mockCoverageService.Setup(service=>service.IsExists(coverage.CoverageId)).Returns(true);

            //Act
            var result= _controller.DeleteCoverage(coverage.CoverageId) as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public async Task DeleteCoverage_ReturnOkResponse_WhenCoverageIdIsNotExsistsAndDataIsNotDeleted()
        {
            //Arrange
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.IsExists(coverage.CoverageId)).Returns(false);

            //Act
            var result = _controller.DeleteCoverage(coverage.CoverageId) as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task DeleteCoverage_WhenServiceThorwsException()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.DeleteCoverage(coverage.CoverageId)).Throws(new Exception());

            //Act
            var result =  _controller.DeleteCoverage(coverage.CoverageId) as ObjectResult;

            //
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task DeleteCoverage_WhenRepositoryThorwsException()
        {
            //Arrange 
            var coverage = new coverages();
            _mockCoverageService.Setup(service => service.DeleteCoverage(coverage.CoverageId)).Throws(new Exception());
            _ICoverageRepo.Setup(service => service.DeleteCoverage(coverage.CoverageId)).Throws(new Exception());

            //Act
            var result = await _controller.EditCoverage(coverage) as ObjectResult;

            //
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}
