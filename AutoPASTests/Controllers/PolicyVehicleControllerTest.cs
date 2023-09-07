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
    public class PolicyVehicleControllerTests
    {
        private Mock<IpolicyvehicleBL> _policyvehicleBLMock;
        private Mock<ILogger<PolicyVehicleController>> _loggerMock;
        private PolicyVehicleController _policyVehicleController;

        [SetUp]
        public void Setup()
        {
            _policyvehicleBLMock = new Mock<IpolicyvehicleBL>();
            _loggerMock = new Mock<ILogger<PolicyVehicleController>>();
            _policyVehicleController = new PolicyVehicleController(_policyvehicleBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task insertpolicyvehicle_Returns_OkResult()
        {
            //Arrange
            var policyvehicle = new PolicyVehicle();
            var objPolicyVehicle = new PolicyVehicle();
            _policyvehicleBLMock.Setup(x => x.Insertpolicyvehicle(objPolicyVehicle)).ReturnsAsync(policyvehicle);

            //Act
            var result = await _policyVehicleController.insertpolicyvehicle(objPolicyVehicle);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(policyvehicle, okResult.Value);
        }

        [Test]
        public async Task insertpolicyvehicle_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var objPolicyVehicle = new PolicyVehicle();
            _policyvehicleBLMock.Setup(x => x.Insertpolicyvehicle(objPolicyVehicle)).Throws(new Exception());

            //Act
            var result = await _policyVehicleController.insertpolicyvehicle(objPolicyVehicle);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
