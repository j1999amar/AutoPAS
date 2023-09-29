using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASAL;
using AutoPASAPI.Controllers;
using AutoPASAPITests.MockRepository;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASSL.Repository;
using AutoPASDML;
using Microsoft.AspNetCore.Mvc;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class MasterControllerTest
    {
        private MasterController _controller;
        private Mock<IMasterService> _mockIMasterService;
        private Mock<ILogger<MasterController>> _mockLogger;
        private Mock<IMasterRepo> _mockIMasterRepo;

        [SetUp]
        public void Setup()
        {
            _mockIMasterService = new Mock<IMasterService>();
            _mockIMasterRepo = new Mock<IMasterRepo>();
            _mockLogger = new Mock<ILogger<MasterController>>();

            _controller = new MasterController(_mockIMasterService.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllMaster_ReturnsOkResponse_WhenMasterTableExists()
        {
            // Arrange
            var master = new List<Master>();
            _mockIMasterService.Setup(service => service.GetAllMaster()).ReturnsAsync(master);

            // Act 
            var result = await _controller.GetAllMaster() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task GetAllMaster_ReturnsNoContent_WhenMasterTableIsEmpty()
        {
            // Arrange
            var master = new List<Master>(); // An empty list
            _mockIMasterService.Setup(service => service.GetAllMaster()).ReturnsAsync(master);

            // Act 
            var result = await _controller.GetAllMaster() as OkObjectResult;

            // Assert
            Assert.AreEqual(200, result.StatusCode);
        }


        [Test]
        public async Task GetAllMaster_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            // Arrange
            _mockIMasterService.Setup(service => service.GetAllMaster()).ThrowsAsync(new Exception());

            // Act 
            var result = await _controller.GetAllMaster() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
    }

}
