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
    public class PolicyCoverageControllerTests
    {
        private Mock<IPolicyCoverageBL> _policyCoverageBLMock;
        private Mock<ILogger<PolicyCoverageController>> _loggerMock;
        private PolicyCoverageController _policyCoverageController;

        [SetUp]
        public void Setup()
        {
            _policyCoverageBLMock = new Mock<IPolicyCoverageBL>();
            _loggerMock = new Mock<ILogger<PolicyCoverageController>>();
            _policyCoverageController = new PolicyCoverageController(_policyCoverageBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task AddPolicyCoverage_Returns_OkResult()
        {
            //Arrange
            var policycoverage = new policycoverage();
            List<int> coverageId = new List<int>();
            _policyCoverageBLMock.Setup(x => x.AddPolicyCoverage(coverageId)).ReturnsAsync(policycoverage);

            //Act
            var result = await _policyCoverageController.AddPolicyCoverage(coverageId);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policycoverage, okResult.Value);
        }

        [Test]
        public async Task AddPolicyCoverage_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var objpolicycoverage = new policycoverage();
            List<int> coverageId = new List<int>();
            _policyCoverageBLMock.Setup(x => x.AddPolicyCoverage(coverageId)).Throws(new Exception());

            //Act
            var result = await _policyCoverageController.AddPolicyCoverage(coverageId);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task EditPolicyCoverage_Returns_OkResult()
        {
            //Arrange
            var Id = Guid.NewGuid();
            var policycoverage = new policycoverage();
            List<int> coverageId = new List<int>();
            _policyCoverageBLMock.Setup(x => x.EditPolicyCoverage(Id,coverageId)).ReturnsAsync(policycoverage);

            //Act
            var result = await _policyCoverageController.EditPolicyCoverage(Id,coverageId);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policycoverage, okResult.Value);
        }

        [Test]
        public async Task EditPolicyCoverage_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var Id = Guid.NewGuid();
            List<int> coverageId = new List<int>();
            _policyCoverageBLMock.Setup(x => x.EditPolicyCoverage(Id,coverageId)).Throws(new Exception());

            //Act
            var result = await _policyCoverageController.EditPolicyCoverage(Id,coverageId);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetPolicyCoverageById_Returns_OkResult()
        {
            //Arrange
            var Id = Guid.NewGuid();
            var policycoverage = new List<policycoverage>();
            _policyCoverageBLMock.Setup(x => x.GetPolicyCoverageById(Id)).ReturnsAsync(policycoverage);

            //Act
            var result = await _policyCoverageController.GetPolicyCoverageById(Id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policycoverage, okResult.Value);
        }

        [Test]
        public async Task GetPolicyCoverageById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var Id = Guid.NewGuid();
            _policyCoverageBLMock.Setup(x => x.GetPolicyCoverageById(Id)).Throws(new Exception());

            //Act
            var result = await _policyCoverageController.GetPolicyCoverageById(Id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}