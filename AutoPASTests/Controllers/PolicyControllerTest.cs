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
    public class PolicyControllerTests
    {
        private Mock<IPolicyBL> _policyBLMock;
        private Mock<ILogger<PolicyController>> _loggerMock;
        private PolicyController _policyController;

        [SetUp]
        public void Setup()
        {
            _policyBLMock = new Mock<IPolicyBL>();
            _loggerMock = new Mock<ILogger<PolicyController>>();
            _policyController = new PolicyController(_policyBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAllPolicies_Returns_OkResult()
        {
            //Arrange
            var policyList = new List<policy>();
            _policyBLMock.Setup(x => x.GetAllPolicies()).ReturnsAsync(policyList);

            //Act
            var result = await _policyController.GetAllPolicies();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policyList, okResult.Value);
        }

        [Test]
        public async Task GetAllPolicies_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _policyBLMock.Setup(x => x.GetAllPolicies()).Throws(new Exception());

            //Act
            var result = await _policyController.GetAllPolicies();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetPoliciesInRange_Returns_OkResult()
        {
            //Arrange
            var startIndex= 0;
            var count= 0;
            var policyList = new List<policy>();
            _policyBLMock.Setup(x => x.GetPoliciesInRange(startIndex,count)).ReturnsAsync(policyList);

            //Act
            var result = await _policyController.GetPoliciesInRange(startIndex,count);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policyList, okResult.Value);
        }

        [Test]
        public async Task GetPoliciesInRange_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var startIndex = 0;
            var count = 0;
            _policyBLMock.Setup(x => x.GetPoliciesInRange(startIndex, count)).Throws(new Exception());

            //Act
            var result = await _policyController.GetPoliciesInRange(startIndex, count);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetPolicyCount_Returns_OkResult()
        {
            //Arrange
            var count = 0;
            _policyBLMock.Setup(x => x.GetPolicyCount()).ReturnsAsync(count);

            //Act
            var result = await _policyController.GetPolicyCount();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(count, okResult.Value);
        }

        [Test]
        public async Task GetPolicyCount_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _policyBLMock.Setup(x => x.GetPolicyCount()).Throws(new Exception());

            //Act
            var result = await _policyController.GetPolicyCount();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetPolicyById_Returns_OkResult()
        {
            //Arrange
            var policyList = new List<policy>();
            Guid Id = Guid.NewGuid();
            _policyBLMock.Setup(x => x.GetPolicyById(Id)).ReturnsAsync(policyList);

            //Act
            var result = await _policyController.GetPolicyById(Id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policyList, okResult.Value);
        }

        [Test]
        public async Task GetPolicyById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            _policyBLMock.Setup(x => x.GetPolicyById(Id)).Throws(new Exception());

            //Act
            var result = await _policyController.GetPolicyById(Id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task AddPolicy_Returns_OkResult()
        {
            //Arrange
            var policy = new policy();
            var objPolicy = new policy();
            _policyBLMock.Setup(x => x.AddPolicy(objPolicy)).ReturnsAsync(policy);

            //Act
            var result = await _policyController.AddPolicy(objPolicy);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policy, okResult.Value);
        }

        [Test]
        public async Task AddPolicy_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var objPolicy = new policy();
            _policyBLMock.Setup(x => x.AddPolicy(objPolicy)).Throws(new Exception());

            //Act
            var result = await _policyController.AddPolicy(objPolicy);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task UpdatePolicyNCB_Returns_OkResult()
        {
            //Arrange
            var policy = new policy();
            int Ncb = 0;
            _policyBLMock.Setup(x => x.UpdatePolicyNCB(Ncb)).ReturnsAsync(policy);

            //Act
            var result = await _policyController.UpdatePolicyNCB(Ncb);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policy, okResult.Value);
        }

        [Test]
        public async Task UpdatePolicyNCB_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            int Ncb = 0;
            _policyBLMock.Setup(x => x.UpdatePolicyNCB(Ncb)).Throws(new Exception());

            //Act
            var result = await _policyController.UpdatePolicyNCB(Ncb);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task UpdatePolicyById_Returns_OkResult()
        {
            //Arrange
            var policy = new policy();
            Guid Id = Guid.NewGuid();
            var objPolicy = new policy();
            _policyBLMock.Setup(x => x.UpdatePolicyById(Id, objPolicy)).ReturnsAsync(policy);

            //Act
            var result = await _policyController.UpdatePolicyById(Id, objPolicy);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policy, okResult.Value);
        }

        [Test]
        public async Task UpdatePolicyById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var objPolicy = new policy();
            _policyBLMock.Setup(x => x.UpdatePolicyById(Id,objPolicy)).Throws(new Exception());

            //Act
            var result = await _policyController.UpdatePolicyById(Id, objPolicy);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetNCBById_Returns_OkResult()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var NCB = 0;
            _policyBLMock.Setup(x => x.GetNCBById(Id)).ReturnsAsync(NCB);

            //Act
            var result = await _policyController.GetNCBById(Id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(NCB, okResult.Value);
        }

        [Test]
        public async Task GetNCBById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            _policyBLMock.Setup(x => x.GetNCBById(Id)).Throws(new Exception());

            //Act
            var result = await _policyController.GetNCBById(Id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
    }
}