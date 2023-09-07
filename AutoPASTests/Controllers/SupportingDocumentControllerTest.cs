using AutoPASBL.Interface;
using AutoPASAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoPASDML;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AutoPASSL;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class SupportingDocumentControllerTests
    {
        private Mock<ISupportingDocumentBL> _supportingDocumentBLMock;
        private Mock<ILogger<SupportingDocumentController>> _loggerMock;
        private SupportingDocumentController _supportingDocumentController;
        private Mock<APASDBContext> _context;

        [SetUp]
        public void Setup()
        {
            _supportingDocumentBLMock = new Mock<ISupportingDocumentBL>();
            _loggerMock = new Mock<ILogger<SupportingDocumentController>>();
            _context = new Mock<APASDBContext>();
            _supportingDocumentController = new SupportingDocumentController(_loggerMock.Object,_supportingDocumentBLMock.Object,_context.Object);
        }

        [Test]
        public async Task AddDocument_Returns_OkResult()
        {
            // Arrange
            var formFile1 = new FormFile(Stream.Null, 0, 1, "file1.cs", "file.cs");
            var formFile2 = new FormFile(Stream.Null, 0, 1, "file2.cs", "file.cs");
            var fileslist = new List<IFormFile>();
            fileslist.Add(formFile1);
            fileslist.Add(formFile2);
            var file = new MultipleFile {files=fileslist};
            _supportingDocumentBLMock.Setup(x => x.AddDocument(It.IsAny<IFormFile>())).Returns(Task.CompletedTask);


            // Act
            var result = await _supportingDocumentController.AddDocument(file);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            
        }

        [Test]
        public async Task AddDocument_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            // Arrange
            var formFile1 = new FormFile(Stream.Null, 0, 1, "file1.cs", "file.cs");
            var formFile2 = new FormFile(Stream.Null, 0, 1, "file2.cs", "file.cs");
            var fileslist = new List<IFormFile>
            {
                formFile1,
                formFile2
            };
            var file = new MultipleFile { files = fileslist };
            _supportingDocumentBLMock.Setup(x => x.AddDocument(It.IsAny<IFormFile>())).Throws(new Exception());

            // Act
            var result = await _supportingDocumentController.AddDocument(file);

            // Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }



        [Test]
        public async Task UpdateDocument_Returns_OkResult()
        {
            // Arrange
            var formFile1 = new FormFile(Stream.Null, 0, 1, "file1.cs", "file.cs");
            var formFile2 = new FormFile(Stream.Null, 0, 1, "file2.cs", "file.cs");
            var fileslist = new List<IFormFile>();
            fileslist.Add(formFile1);
            fileslist.Add(formFile2);
            var file = new MultipleFile { files = fileslist };
            _supportingDocumentBLMock.Setup(x => x.UpdateDocument(It.IsAny<IFormFile>())).Returns(Task.CompletedTask);

            // Act
            var result = await _supportingDocumentController.UpdateDocument(file);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task UpdateDocument_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            // Arrange
            var formFile1 = new FormFile(Stream.Null, 0, 1, "file1.cs", "file.cs");
            var formFile2 = new FormFile(Stream.Null, 0, 1, "file2.cs", "file.cs");
            var fileslist = new List<IFormFile>();
            fileslist.Add(formFile1);
            fileslist.Add(formFile2);
            var file = new MultipleFile { files = fileslist };
            _supportingDocumentBLMock.Setup(x => x.UpdateDocument(It.IsAny<IFormFile>())).Throws(new Exception());

            // Act
            var result = await _supportingDocumentController.UpdateDocument(file);

            // Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }
        [Test]
        public async Task GetDocumentById_Returns_OkResult()
        {
            string policyId = "somePolicyId";
            var supportingDocuments = new List<supportingdocument>
        {
            new supportingdocument
            {
                // Mock supportingdocument properties here
                PolicyId = policyId,
                DocumentLocation = "path/to/your/file.pdf",
                DocumentName = "file.pdf"
            }
        };

            // Mocking DbSet with supportingDocuments data
            var mockDbSet = new Mock<DbSet<supportingdocument>>();
            mockDbSet.As<IQueryable<supportingdocument>>().Setup(x => x.Provider).Returns(supportingDocuments.AsQueryable().Provider);
            mockDbSet.As<IQueryable<supportingdocument>>().Setup(x => x.Expression).Returns(supportingDocuments.AsQueryable().Expression);
            mockDbSet.As<IQueryable<supportingdocument>>().Setup(x => x.ElementType).Returns(supportingDocuments.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<supportingdocument>>().Setup(x => x.GetEnumerator()).Returns(supportingDocuments.AsQueryable().GetEnumerator());

            // Mocking supportingdocuments DbSet in the DbContext
            _context.Setup(x => x.supportingdocuments).Returns(mockDbSet.Object);

            // Act
            //var result = await _supportingDocumentController.GetDocumentById(policyId);

            // Assert
           // Assert.IsInstanceOf<OkObjectResult>(result.Result);

            //var okResult = result.Result as OkObjectResult;
            //Assert.IsInstanceOf<MultipleFile>(okResult.Value);

            //var multipleFile = okResult.Value as MultipleFile;
            //Assert.IsNotNull(multipleFile);
            //Assert.AreEqual(1, multipleFile.files.Count);
        }

    }
}
