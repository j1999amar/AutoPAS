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
    public class PolicyInsuredControllerTests
    {
        private Mock<IpolicyinsuredBL> _policyinsuredBLMock;
        private Mock<ILogger<PolicyInsuredController>> _loggerMock;
        private PolicyInsuredController _policyInsuredController;

        [SetUp]
        public void Setup()
        {
            _policyinsuredBLMock = new Mock<IpolicyinsuredBL>();
            _loggerMock = new Mock<ILogger<PolicyInsuredController>>();
            _policyInsuredController = new PolicyInsuredController(_policyinsuredBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task insertpolicyinsured_Returns_OkResult()
        {
            //Arrange
            var policyinsured = new PolicyInsured();
            var objPolicyInsured = new  PolicyInsured();
            _policyinsuredBLMock.Setup(x => x.Insertpolicyinsured(objPolicyInsured)).ReturnsAsync(policyinsured);

            //Act
            var result = await _policyInsuredController.insertpolicyinsured(objPolicyInsured);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policyinsured, okResult.Value);
        }

        [Test]
        public async Task insertpolicyinsured_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var objPolicyInsured = new PolicyInsured();
            _policyinsuredBLMock.Setup(x => x.Insertpolicyinsured(objPolicyInsured)).Throws(new Exception());

            //Act
            var result = await _policyInsuredController.insertpolicyinsured(objPolicyInsured);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
