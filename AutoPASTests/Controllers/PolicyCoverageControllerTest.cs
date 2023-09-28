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
    public class PolicyCoverageControllerTests
    {
        private PolicyCoverageController _controller;
        private Mock<IPolicyCoverageService> _mockPolicyCoverageService;
        private Mock<ILogger<PolicyCoverageController>> _mockLogger;
        private PolicyCoverageMockRepo _mockPolicyCoverageRepo;
        private PolicyCoverageService _PolicyCoverageService;
        private Mock<IPolicyCoverageRepo> _IPolicyCoverageRepo;

        [SetUp]
        public void Setup()
        {
            _IPolicyCoverageRepo = new Mock<IPolicyCoverageRepo>();
            _PolicyCoverageService = new PolicyCoverageService(_IPolicyCoverageRepo.Object);
            _mockPolicyCoverageRepo = new PolicyCoverageMockRepo();
            _mockPolicyCoverageService = new Mock<IPolicyCoverageService>();
            _mockLogger = new Mock<ILogger<PolicyCoverageController>>();
            _controller = new PolicyCoverageController(_mockPolicyCoverageService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetPolicyCoverageById_ReturnsData()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            var policyCoverages = new List<policycoverage> { };
            _mockPolicyCoverageService.Setup(service => service.GetPolicyCoverageById(Id)).Returns(_PolicyCoverageService.GetPolicyCoverageById);
            _IPolicyCoverageRepo.Setup(repo => repo.GetPolicyCoverageById(Id)).Returns(_mockPolicyCoverageRepo.ReturnsPolicyCoverage);

            // Act
            var result = await _controller.GetPolicyCoverageById(Id) as OkObjectResult;

            // Assert
            Assert.AreEqual(policyCoverages, result.Value);
        }

        [Test]
        public async Task GetPolicyCoverageById_ReturnsNull()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            _mockPolicyCoverageService.Setup(service => service.GetPolicyCoverageById(Id)).Returns(_PolicyCoverageService.GetPolicyCoverageById);
            _IPolicyCoverageRepo.Setup(service => service.GetPolicyCoverageById(Id)).Returns(_mockPolicyCoverageRepo.ReturnsPolicyCoverageNull);

            // Act
            var result = await _controller.GetPolicyCoverageById(Id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }

        [Test]
        public async Task GetPolicyCoverageById_WhenServiceThrowsException()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            _mockPolicyCoverageService.Setup(service => service.GetPolicyCoverageById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetPolicyCoverageById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetPolicyCoverageById_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            _mockPolicyCoverageService.Setup(service => service.GetPolicyCoverageById(Id)).Returns(_PolicyCoverageService.GetPolicyCoverageById);
            _IPolicyCoverageRepo.Setup(service => service.GetPolicyCoverageById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetPolicyCoverageById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
       

    }
}