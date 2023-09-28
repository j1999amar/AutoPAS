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
using System.Net;
using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASAL;
using AutoPASAPITests.MockRepository;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class InsuredContactControllerTests
    {
        private InsuredContactController _controller;
        private Mock<IInsuredContactService> _mockInsuredContactService;
        private Mock<ILogger<InsuredContactController>> _mockLogger;
        private InsuredContactMockRepo _mockInsuredContactRepo;
        private InsuredContactService _InsuredContactService;
        private Mock<IInsuredContactRepo> _IInsuredContactRepo;

        [SetUp]
        public void Setup()
        {
            _IInsuredContactRepo = new Mock<IInsuredContactRepo>();
            _InsuredContactService = new InsuredContactService(_IInsuredContactRepo.Object);
            _mockInsuredContactRepo = new InsuredContactMockRepo();
            _mockInsuredContactService = new Mock<IInsuredContactService>();
            _mockLogger = new Mock<ILogger<InsuredContactController>>();
            _controller = new InsuredContactController(_mockInsuredContactService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetInsuredById_ReturnsData()
        {
            // Arrange
            var insured = new List<insured> { };
            Guid Id = new Guid();
            _mockInsuredContactService.Setup(service => service.GetInsuredById(Id)).Returns(_InsuredContactService.GetInsuredById);
            _IInsuredContactRepo.Setup(repo => repo.GetInsuredById(Id)).Returns(_mockInsuredContactRepo.ReturnsInsured);

            // Act
            var result = await _controller.GetInsuredById(Id) as OkObjectResult;

            // Assert
            Assert.AreEqual(insured, result.Value);
        }

        [Test]
        public async Task GetInsuredById_ReturnsNull()
        {
            // Arrange
            Guid Id = new Guid();
            _mockInsuredContactService.Setup(service => service.GetInsuredById(Id)).Returns(_InsuredContactService.GetInsuredById);
            _IInsuredContactRepo.Setup(service => service.GetInsuredById(Id)).Returns(_mockInsuredContactRepo.ReturnsInsuredNull);

            // Act
            var result = await _controller.GetInsuredById(Id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }

        [Test]
        public async Task GetInsuredById_WhenServiceThrowsException()
        {
            // Arrange
            Guid Id = new Guid();
            _mockInsuredContactService.Setup(service => service.GetInsuredById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetInsuredById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetInsuredById_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid Id = new Guid();
            _mockInsuredContactService.Setup(service => service.GetInsuredById(Id)).Returns(_InsuredContactService.GetInsuredById);
            _IInsuredContactRepo.Setup(service => service.GetInsuredById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetInsuredById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetContactById_ReturnsData()
        {
            // Arrange
            var contact = new List<contact> { };
            Guid Id = new Guid();
            _mockInsuredContactService.Setup(service => service.GetContactById(Id)).Returns(_InsuredContactService.GetContactById);
            _IInsuredContactRepo.Setup(repo => repo.GetContactById(Id)).Returns(_mockInsuredContactRepo.ReturnsContact);

            // Act
            var result = await _controller.GetContactById(Id) as OkObjectResult;

            // Assert
            Assert.AreEqual(contact, result.Value);
        }

        [Test]
        public async Task GetContactById_ReturnsNull()
        {
            // Arrange
            Guid Id = new Guid();
            _mockInsuredContactService.Setup(service => service.GetContactById(Id)).Returns(_InsuredContactService.GetContactById);
            _IInsuredContactRepo.Setup(service => service.GetContactById(Id)).Returns(_mockInsuredContactRepo.ReturnsContactNull);

            // Act
            var result = await _controller.GetContactById(Id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }

        [Test]
        public async Task GetContactById_WhenServiceThrowsException()
        {
            // Arrange
            Guid Id = new Guid();
            _mockInsuredContactService.Setup(service => service.GetContactById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetContactById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetContactById_WhenRepositoryThrowsException()
        {
            // Arrange
            Guid Id = new Guid();
            _mockInsuredContactService.Setup(service => service.GetContactById(Id)).Returns(_InsuredContactService.GetContactById);
            _IInsuredContactRepo.Setup(service => service.GetContactById(Id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetContactById(Id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}
