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
    public class PolicyControllerTests
    {
        private PolicyController _controller;
        private Mock<IPolicyService> _mockPolicyService;
        private Mock<ILogger<PolicyController>> _mockLogger;
        private PolicyMockRepo _mockPolicyRepo;
        private PolicyService _PolicyService;
        private Mock<IPolicyRepo> _IPolicyRepo;

        [SetUp]
        public void Setup()
        {
            _IPolicyRepo = new Mock<IPolicyRepo>();
            _PolicyService = new PolicyService(_IPolicyRepo.Object);
            _mockPolicyRepo = new PolicyMockRepo();
            _mockPolicyService = new Mock<IPolicyService>();
            _mockLogger = new Mock<ILogger<PolicyController>>();
            _controller = new PolicyController(_mockPolicyService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllPolicy_ReturnsData()
        {
            // Arrange
            var policy = new List<policy> { };
            _mockPolicyService.Setup(service => service.GetAllPolicies()).Returns(_PolicyService.GetAllPolicies);
            _IPolicyRepo.Setup(repo => repo.GetAllPolicies()).Returns(_mockPolicyRepo.ReturnsPolicy);

            // Act
            var result = await _controller.GetAllPolicies() as OkObjectResult;

            // Assert
            Assert.AreEqual(policy, result.Value);
        }

        [Test]
        public async Task GetAllPolicy_ReturnsNull()
        {
            // Arrange
            _mockPolicyService.Setup(service => service.GetAllPolicies()).Returns(_PolicyService.GetAllPolicies);
            _IPolicyRepo.Setup(service => service.GetAllPolicies()).Returns(_mockPolicyRepo.ReturnsNullPolicy);

            // Act
            var result = await _controller.GetAllPolicies() as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }

        [Test]
        public async Task GetAllPolicy_WhenServiceThrowsException()
        {
            // Arrange
            _mockPolicyService.Setup(service => service.GetAllPolicies()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllPolicies() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetAllPolicy_WhenRepositoryThrowsException()
        {
            // Arrange
            _mockPolicyService.Setup(service => service.GetAllPolicies()).Returns(_PolicyService.GetAllPolicies);
            _IPolicyRepo.Setup(service => service.GetAllPolicies()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllPolicies() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetPoliciesInRange_ReturnsData()
        {
            // Arrange
            var policy = new List<policy> { };
            int startIndex = 0;
            int count = 5;
            _mockPolicyService.Setup(service => service.GetPoliciesInRange(startIndex,count)).Returns(_PolicyService.GetPoliciesInRange);
            _IPolicyRepo.Setup(repo => repo.GetPoliciesInRange(startIndex, count)).Returns(_mockPolicyRepo.ReturnsPolicy);

            // Act
            var result = await _controller.GetPoliciesInRange(startIndex, count) as OkObjectResult;

            // Assert
            Assert.AreEqual(policy, result.Value);
        }

        [Test]
        public async Task GetPoliciesInRange_ReturnsNull()
        {
            // Arrange
            int startIndex = 0;
            int count = 5;
            _mockPolicyService.Setup(service => service.GetPoliciesInRange(startIndex, count)).Returns(_PolicyService.GetPoliciesInRange);
            _IPolicyRepo.Setup(service => service.GetPoliciesInRange(startIndex, count)).Returns(_mockPolicyRepo.ReturnsNullPolicy);

            // Act
            var result = await _controller.GetPoliciesInRange(startIndex, count) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }

        [Test]
        public async Task GetPoliciesInRange_WhenServiceThrowsException()
        {
            // Arrange
            int startIndex = 0;
            int count = 5;
            _mockPolicyService.Setup(service => service.GetPoliciesInRange(startIndex, count)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetPoliciesInRange(startIndex, count) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetPoliciesInRange_WhenRepositoryThrowsException()
        {
            // Arrange
            int startIndex = 0;
            int count = 5;
            _mockPolicyService.Setup(service => service.GetPoliciesInRange(startIndex, count)).Returns(_PolicyService.GetPoliciesInRange);
            _IPolicyRepo.Setup(service => service.GetPoliciesInRange(startIndex, count)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetPoliciesInRange(startIndex, count) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetPolicyById_ReturnsData()
        {
            // Arrange
            var policy = new List<policy> { };
            Guid Id = Guid.NewGuid();
            _mockPolicyService.Setup(service => service.GetPolicyById(Id)).Returns(_PolicyService.GetPolicyById);
            _IPolicyRepo.Setup(repo => repo.GetPolicyById(Id)).Returns(_mockPolicyRepo.ReturnsPolicy);

            // Act
            var result = await _controller.GetPolicyById(Id) as OkObjectResult;

            // Assert
            Assert.AreEqual(policy, result.Value);
        }

        [Test]
        public async Task GetPolicyById_ReturnsNull()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            _mockPolicyService.Setup(service => service.GetPolicyById(Id)).Returns(_PolicyService.GetPolicyById);
            _IPolicyRepo.Setup(service => service.GetPolicyById(Id)).Returns(_mockPolicyRepo.ReturnsNullPolicy);

            // Act
            var result = await _controller.GetPolicyById(Id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }

        [Test]
        public async Task GetPolicyById_WhenServiceThrowsException()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            _mockPolicyService.Setup(service => service.GetPolicyById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetPolicyById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetPolicyById_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            _mockPolicyService.Setup(service => service.GetPolicyById(Id)).Returns(_PolicyService.GetPolicyById);
            _IPolicyRepo.Setup(service => service.GetPolicyById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetPolicyById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
    

      
      
        [Test]
        public async Task GetPolicyCount_ReturnsData()
        {
            // Arrange
            int count = 1;
            _mockPolicyService.Setup(service => service.GetPolicyCount()).Returns(_PolicyService.GetPolicyCount);
            _IPolicyRepo.Setup(repo => repo.GetPolicyCount()).Returns(_mockPolicyRepo.ReturnsONE);

            // Act
            var result = await _controller.GetPolicyCount() as OkObjectResult;

            // Assert
            Assert.AreEqual(count, result.Value);
        }

        [Test]
        public async Task GetPolicyCount_ReturnsNull()
        {
            // Arrange
            string policynumber = "";
            _mockPolicyService.Setup(service => service.GetPolicyCount()).Returns(_PolicyService.GetPolicyCount);
            _IPolicyRepo.Setup(service => service.GetPolicyCount()).Returns(_mockPolicyRepo.ReturnsZERO);

            // Act
            var result = await _controller.GetPolicyCount() as ObjectResult;

            // Assert
            Assert.AreEqual("No Policy", result.Value);
        }

        [Test]
        public async Task GetPolicyCount_WhenServiceThrowsException()
        {
            // Arrange
            string policynumber = "";
            _mockPolicyService.Setup(service => service.GetPolicyCount()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetPolicyCount() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetPolicyCount_WhenRepositoryThrowsException()
        {
            // Arrange
            string policynumber = "";
            _mockPolicyService.Setup(service => service.GetPolicyCount()).Returns(_PolicyService.GetPolicyCount);
            _IPolicyRepo.Setup(service => service.GetPolicyCount()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetPolicyCount() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetNCBById_ReturnsData()
        {
            // Arrange
            int ncb = 1;
            Guid Id = Guid.NewGuid();
            _mockPolicyService.Setup(service => service.GetNCBById(Id)).Returns(_PolicyService.GetNCBById);
            _IPolicyRepo.Setup(repo => repo.GetNCBById(Id)).Returns(_mockPolicyRepo.ReturnsONE);

            // Act
            var result = await _controller.GetNCBById(Id) as OkObjectResult;

            // Assert
            Assert.AreEqual(ncb, result.Value);
        }

        [Test]
        public async Task GetNCBById_ReturnsNull()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            _mockPolicyService.Setup(service => service.GetNCBById(Id)).Returns(_PolicyService.GetNCBById);
            _IPolicyRepo.Setup(service => service.GetNCBById(Id)).Returns(_mockPolicyRepo.ReturnsTWO);

            // Act
            var result = await _controller.GetNCBById(Id) as ObjectResult;

            // Assert
            Assert.AreEqual("No NCB", result.Value);
        }

        [Test]
        public async Task GetNCBById_WhenServiceThrowsException()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            _mockPolicyService.Setup(service => service.GetNCBById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetNCBById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetNCBById_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            _mockPolicyService.Setup(service => service.GetNCBById(Id)).Returns(_PolicyService.GetNCBById);
            _IPolicyRepo.Setup(service => service.GetNCBById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetNCBById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}