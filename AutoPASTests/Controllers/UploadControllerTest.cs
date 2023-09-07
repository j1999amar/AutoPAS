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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class UploadControllerTests
    {
        private Mock<IUploadBL> _UploadBLMock;
        private Mock<ILogger<UploadController>> _loggerMock;
        private UploadController _UploadController;

        [SetUp]
        public void Setup()
        {
            _UploadBLMock = new Mock<IUploadBL>();
            _loggerMock = new Mock<ILogger<UploadController>>();
            _UploadController = new UploadController(_UploadBLMock.Object, _loggerMock.Object);
            
        }

        [Test]
        public async Task GetTableList_Returns_OkResult()
        {
            //Arrange
            var table = new List<metadatatables>();
            _UploadBLMock.Setup(x => x.GetTableList()).ReturnsAsync(table);

            //Act
            var result = await _UploadController.GetTableList();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(table, okResult.Value);
        }

        [Test]
        public async Task GetTableList_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _UploadBLMock.Setup(x => x.GetTableList()).Throws(new Exception());

            //Act
            var result = await _UploadController.GetTableList();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetTableListById_Returns_OkResult()
        {
            //Arrange
            var id = "";
            var table = new List<metadatatables>();
            _UploadBLMock.Setup(x => x.GetTableListById(id)).ReturnsAsync(table);

            //Act
            var result = await _UploadController.GetTableListById(id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(table, okResult.Value);
        }

        [Test]
        public async Task GetTableListById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            var id = "";
            _UploadBLMock.Setup(x => x.GetTableListById(id)).Throws(new Exception());

            //Act
            var result = await _UploadController.GetTableListById(id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task AddRateTables_Returns_OkResult_When_Files_Exist()
        {
            // Arrange
            var _formFiles = new FormFile(Stream.Null, 0, 1, "file.cs", "file.cs");
            var file = new UploadFile { files = _formFiles };
            string filename = "test";

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = $"..\\..\\..\\..\\AutoPASDML";
            string directoryPath = Path.Combine(baseDirectory, relativePath);
            string searchPattern = $"{filename}.cs";
            _UploadBLMock.Setup(x => x.DynamicTableAlteration(file, filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicModelEditing(file, filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicMetadataTableEditing(file, filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicModelCreation(file, filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicContextEditing(filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicInterfaceCreation(filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicBLCreation(filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicControllerCreation(filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicProgramFileEditing(filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicMetadataTableAdd(file, filename)).Returns(Task.CompletedTask);
            _UploadBLMock.Setup(x => x.DynamicTableCreation(file, filename)).Returns(Task.CompletedTask);

            // Act
            var result = await _UploadController.AddRateTables(file, filename);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var objectResult = (OkObjectResult)result;
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
        }

        [Test]
        public async Task AddRateTables_Returns_InternalServerError_When_Files_Not_Exist()
        {
            // Arrange
            var _formFiles = new FormFile(Stream.Null, 0, 0, "file.cs", "file.cs");
            var file = new UploadFile { files = _formFiles };
            string filename = "test";

            // Act
            var result = await _UploadController.AddRateTables(file, filename);

            // Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }

    }
}
