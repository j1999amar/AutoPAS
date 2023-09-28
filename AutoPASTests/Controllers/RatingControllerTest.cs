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
using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASAL;
using AutoPASAPITests.MockRepository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class RatingControllerTests
    {
        private RatingController _controller;
        private Mock<IRatingService> _mockRatingService;
        private Mock<ILogger<RatingController>> _mockLogger;
        private RT_THEFTMockRepo _mockRT_THEFTRepo;
        private RT_GSTMockRepo _mockRT_GSTRepo;
        private RT_NCBMockRepo _mockRT_NCBRepo;
        private RT_TPCMockRepo _mockRT_TPCRepo;
        private RT_ODPMockRepo _mockRT_ODPRepo;
        private RT_LLPMockRepo _mockRT_LLPRepo;
        private RatingService _RatingService;
        private Mock<IRT_GSTRepo> _IRT_GSTRepo;
        private Mock<IRT_NCBRepo> _IRT_NCBRepo;
        private Mock<IRT_LLPRepo> _IRT_LLPRepo;
        private Mock<IRT_TPCRepo> _IRT_TPCRepo;
        private Mock<IRT_THEFTRepo> _IRT_THEFTRepo;
        private Mock<IRT_ODPRepo> _IRT_ODPRepo;

        [SetUp]
        public void Setup()
        {
            _IRT_GSTRepo = new Mock<IRT_GSTRepo>();
            _IRT_NCBRepo = new Mock<IRT_NCBRepo>();
            _IRT_ODPRepo = new Mock<IRT_ODPRepo>();
            _IRT_THEFTRepo = new Mock<IRT_THEFTRepo>();
            _IRT_LLPRepo = new Mock<IRT_LLPRepo>();
            _IRT_TPCRepo = new Mock<IRT_TPCRepo>();
            _mockRT_THEFTRepo = new RT_THEFTMockRepo();
            _mockRT_THEFTRepo = new RT_THEFTMockRepo(); 
            _mockRT_GSTRepo = new RT_GSTMockRepo();
            _mockRT_NCBRepo = new RT_NCBMockRepo();
            _mockRT_TPCRepo = new RT_TPCMockRepo();
            _mockRT_ODPRepo= new RT_ODPMockRepo();
            _mockRT_LLPRepo = new RT_LLPMockRepo();
            _mockRatingService = new Mock<IRatingService>();
            _mockLogger = new Mock<ILogger<RatingController>>();
        }

        [Test]
        public async Task GetTableByName_ReturnsRT_GST()
        {
            // Arrange
            var data = new List<RT_GST> { };
            string tablename = "RT_GST";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_GSTRepo.Setup(repo => repo.GetRT_GST()).Returns(_mockRT_GSTRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByName(tablename) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByName_ReturnsRT_GSTNull()
        {
            // Arrange
            string tablename = "RT_GST";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_GSTRepo.Setup(repo => repo.GetRT_GST()).Returns(_mockRT_GSTRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByName_WhenRT_GSTRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_GST";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_GSTRepo.Setup(repo => repo.GetRT_GST()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByName_ReturnsRT_NCB()
        {
            // Arrange
            var data = new List<RT_NCB> { };
            string tablename = "RT_NCB";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_NCBRepo.Setup(repo => repo.GetRT_NCB()).Returns(_mockRT_NCBRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByName(tablename) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByName_ReturnsRT_NCBNull()
        {
            // Arrange
            string tablename = "RT_NCB";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_NCBRepo.Setup(repo => repo.GetRT_NCB()).Returns(_mockRT_NCBRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByName_WhenRT_NCBRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_NCB";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_NCBRepo.Setup(repo => repo.GetRT_NCB()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByName_ReturnsRT_LLP()
        {
            // Arrange
            var data = new List<RT_LLP> { };
            string tablename = "RT_LLP";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_LLPRepo.Setup(repo => repo.GetRT_LLP()).Returns(_mockRT_LLPRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByName(tablename) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByName_ReturnsRT_LLPNull()
        {
            // Arrange
            string tablename = "RT_LLP";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_LLPRepo.Setup(repo => repo.GetRT_LLP()).Returns(_mockRT_LLPRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByName_WhenRT_LLPRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_LLP";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_LLPRepo.Setup(repo => repo.GetRT_LLP()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByName_ReturnsRT_ODP()
        {
            // Arrange
            var data = new List<RT_ODP> { };
            string tablename = "RT_ODP";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_ODPRepo.Setup(repo => repo.GetRT_ODP()).Returns(_mockRT_ODPRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByName(tablename) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByName_ReturnsRT_ODPNull()
        {
            // Arrange
            string tablename = "RT_ODP";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_ODPRepo.Setup(repo => repo.GetRT_ODP()).Returns(_mockRT_ODPRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByName_WhenRT_ODPRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_ODP";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_ODPRepo.Setup(repo => repo.GetRT_ODP()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByName_ReturnsRT_TPC()
        {
            // Arrange
            var data = new List<RT_TPC> { };
            string tablename = "RT_TPC";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_TPCRepo.Setup(repo => repo.GetRT_TPC()).Returns(_mockRT_TPCRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByName(tablename) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByName_ReturnsRT_TPCNull()
        {
            // Arrange
            string tablename = "RT_TPC";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_TPCRepo.Setup(repo => repo.GetRT_TPC()).Returns(_mockRT_TPCRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByName_WhenRT_TPCRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_TPC";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_TPCRepo.Setup(repo => repo.GetRT_TPC()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByName_ReturnsRT_THEFT()
        {
            // Arrange
            var data = new List<RT_THEFT> { };
            string tablename = "RT_THEFT";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_THEFTRepo.Setup(repo => repo.GetRT_THEFT()).Returns(_mockRT_THEFTRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByName(tablename) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByName_ReturnsRT_THEFTNull()
        {
            // Arrange
            string tablename = "RT_THEFT";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_THEFTRepo.Setup(repo => repo.GetRT_THEFT()).Returns(_mockRT_THEFTRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByName_WhenRT_THEFTRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_THEFT";
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).Returns(_RatingService.GetTableByName);
            _IRT_THEFTRepo.Setup(repo => repo.GetRT_THEFT()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_GST()
        {
            // Arrange
            var data = new List<RT_GST> { };
            string tablename = "RT_GST";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_GSTRepo.Setup(repo => repo.GetRT_GSTById(id)).Returns(_mockRT_GSTRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_GSTNull()
        {
            // Arrange
            string tablename = "RT_GST";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_GSTRepo.Setup(repo => repo.GetRT_GSTById(id)).Returns(_mockRT_GSTRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByNameAndId_WhenRT_GSTRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_GST";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_GSTRepo.Setup(repo => repo.GetRT_GSTById(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_NCB()
        {
            // Arrange
            var data = new List<RT_NCB> { };
            string tablename = "RT_NCB";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_NCBRepo.Setup(repo => repo.GetRT_NCBById(id)).Returns(_mockRT_NCBRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_NCBNull()
        {
            // Arrange
            string tablename = "RT_NCB";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_NCBRepo.Setup(repo => repo.GetRT_NCBById(id)).Returns(_mockRT_NCBRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByNameAndId_WhenRT_NCBRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_NCB";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_NCBRepo.Setup(repo => repo.GetRT_NCBById(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_LLP()
        {
            // Arrange
            var data = new List<RT_LLP> { };
            string tablename = "RT_LLP";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_LLPRepo.Setup(repo => repo.GetRT_LLPById(id)).Returns(_mockRT_LLPRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_LLPNull()
        {
            // Arrange
            string tablename = "RT_LLP";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_LLPRepo.Setup(repo => repo.GetRT_LLPById(id)).Returns(_mockRT_LLPRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByNameAndId_WhenRT_LLPRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_LLP";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_LLPRepo.Setup(repo => repo.GetRT_LLPById(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_ODP()
        {
            // Arrange
            var data = new List<RT_ODP> { };
            string tablename = "RT_ODP";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_ODPRepo.Setup(repo => repo.GetRT_ODPById(id)).Returns(_mockRT_ODPRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_ODPNull()
        {
            // Arrange
            string tablename = "RT_ODP";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_ODPRepo.Setup(repo => repo.GetRT_ODPById(id)).Returns(_mockRT_ODPRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByNameAndId_WhenRT_ODPRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_ODP";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_ODPRepo.Setup(repo => repo.GetRT_ODPById(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_TPC()
        {
            // Arrange
            var data = new List<RT_TPC> { };
            string tablename = "RT_TPC";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_TPCRepo.Setup(repo => repo.GetRT_TPCById(id)).Returns(_mockRT_TPCRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_TPCNull()
        {
            // Arrange
            string tablename = "RT_TPC";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_TPCRepo.Setup(repo => repo.GetRT_TPCById(id)).Returns(_mockRT_TPCRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByNameAndId_WhenRT_TPCRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_TPC";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_TPCRepo.Setup(repo => repo.GetRT_TPCById(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_THEFT()
        {
            // Arrange
            var data = new List<RT_THEFT> { };
            string tablename = "RT_THEFT";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_THEFTRepo.Setup(repo => repo.GetRT_THEFTById(id)).Returns(_mockRT_THEFTRepo.ReturnsData);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as OkObjectResult;

            // Assert
            Assert.AreEqual(data, result.Value);
        }

        [Test]
        public async Task GetTableByNameAndId_ReturnsRT_THEFTNull()
        {
            // Arrange
            string tablename = "RT_THEFT";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_THEFTRepo.Setup(repo => repo.GetRT_THEFTById(id)).Returns(_mockRT_THEFTRepo.ReturnsNull);

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetTableByNameAndId_WhenRT_THEFTRepositoryThrowsException()
        {
            // Arrange
            string tablename = "RT_THEFT";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByNameAndId(tablename,id)).Returns(_RatingService.GetTableByNameAndId);
            _IRT_THEFTRepo.Setup(repo => repo.GetRT_THEFTById(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByNameAndId(tablename,id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByName_WhenServiceThrowsException()
        {
            // Arrange
            string tablename = "TABLE";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetTableByNameAndId_WhenServiceThrowsException()
        {
            // Arrange
            string tablename = "TABLE";
            int id = 0;
            _mockRatingService.Setup(service => service.GetTableByName(tablename)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTableByName(tablename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

    }
}
