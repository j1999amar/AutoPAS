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

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class InsuredContactControllerTests
    {
        private Mock<IInsuredBL> _insuredBLMock;
        private Mock<IContactBL> _contactBLMock;
        private Mock<ILogger<InsuredContactController>> _loggerMock;
        private InsuredContactController _insuredContactController;

        [SetUp]
        public void Setup()
        {
            _insuredBLMock = new Mock<IInsuredBL>();
            _contactBLMock = new Mock<IContactBL>();
            _loggerMock = new Mock<ILogger<InsuredContactController>>();
            _insuredContactController = new InsuredContactController(_contactBLMock.Object,_insuredBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task AddInsuredContact_Returns_OkResult()
        {
            //Arrange
            var con = new contact();
            var objContact = new contact() { ContactId=new Guid()};
            _contactBLMock.Setup(y => y.AddContact(objContact)).ReturnsAsync(con);
            var ins = new insured();
            var objInsured = new insured();
            _insuredBLMock.Setup(x => x.AddInsured(objInsured)).ReturnsAsync(ins);
            var objInsuredContact = new insuredContact()
            {
                contact= objContact,
                insured= objInsured
            };

            //Act
            var result = await _insuredContactController.AddInsuredContact(objInsuredContact);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(objInsuredContact, okResult.Value);
        }

        [Test]
        public async Task AddInsuredContact_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var objContact = new contact();
            var objInsured = new insured();
            _contactBLMock.Setup(y => y.AddContact(objContact)).Throws(new Exception());
            var objInsuredContact = new insuredContact()
            {
                contact = objContact,
                insured = objInsured
            };
            //Act
            var result = await _insuredContactController.AddInsuredContact(objInsuredContact);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task EditInsuredContact_Returns_OkResult()
        {
            //Arrange
            Guid Id1 = Guid.NewGuid();
            var insured = new insured();
            var objInsured = new insured();
            _insuredBLMock.Setup(x => x.EditInsured(Id1,objInsured)).ReturnsAsync(insured);
            Guid Id2 = Guid.NewGuid();
            var cont = new contact();
            var objContact = new contact();
            _contactBLMock.Setup(y => y.EditContact(Id2,objContact)).ReturnsAsync(cont);
            var objInsuredContact = new insuredContact()
            {
                contact = objContact,
                insured = objInsured
            };

            //Act
            var result = await _insuredContactController.EditInsuredContact(Id2,objInsuredContact);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(200, objectResult.StatusCode);
        }

       

        [Test]
        public async Task EditInsuredContact_Exception_ReturnsStatusCode500()
        {
            // Arrange
            Guid Id1 = Guid.NewGuid();
            var Insr = new insured();
            var objInsured = new insured();
            var cont = new contact();
            _insuredBLMock.Setup(x => x.EditInsured(Id1, Insr)).Throws(new Exception());
            var objInsuredContact = new insuredContact();

            // Act
            var result = await _insuredContactController.EditInsuredContact(Id1,objInsuredContact);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetInsuredById_Returns_OkResult()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var Insured = new List<insured>();
            _insuredBLMock.Setup(x => x.GetInsuredById(Id)).ReturnsAsync(Insured);

            //Act
            var result = await _insuredContactController.GetInsuredById(Id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(Insured, okResult.Value);
        }

        [Test]
        public async Task GetInsuredById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            _insuredBLMock.Setup(x => x.GetInsuredById(Id)).Throws(new Exception());

            //Act
            var result = await _insuredContactController.GetInsuredById(Id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetContactById_Returns_OkResult()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var Contact = new List<contact>();
            _insuredBLMock.Setup(x => x.GetContactById(Id)).ReturnsAsync(Contact);

            //Act
            var result = await _insuredContactController.GetContactById(Id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(Contact, okResult.Value);
        }

        [Test]
        public async Task GetContactById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            _insuredBLMock.Setup(x => x.GetContactById(Id)).Throws(new Exception());

            //Act
            var result = await _insuredContactController.GetContactById(Id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
