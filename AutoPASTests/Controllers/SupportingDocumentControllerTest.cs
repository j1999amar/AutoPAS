using AutoPASBL.Interface;
using AutoPASAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;
using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASAL;
using AutoPASAPITests.MockRepository;
using AutoPASAPITests.MockBL;

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class SupportingDocumentControllerTests
    {
        private SupportingDocumentController _controller;
        private Mock<ISupportingDocumentService> _mockSupportingDocumentService;
        private Mock<ILogger<SupportingDocumentController>> _mockLogger;
        private SupportingDocumentMockRepo _mockSupportingDocumentRepo;
        private SupportingDocumentMockBL _mocksupportingDocumentMockBL;
        private SupportingDocumentService _SupportingDocumentService;
        private Mock<ISupportingDocumentRepo> _ISupportingDocumentRepo;
        private Mock<ISupportingDocumentBL> _ISupportingDocumentBL;

        [SetUp]
        public void Setup()
        {
            _ISupportingDocumentRepo = new Mock<ISupportingDocumentRepo>();
            _ISupportingDocumentBL = new Mock<ISupportingDocumentBL> ();
            _SupportingDocumentService = new SupportingDocumentService(_ISupportingDocumentRepo.Object,_ISupportingDocumentBL.Object);
            _mockSupportingDocumentRepo = new SupportingDocumentMockRepo();
            _mocksupportingDocumentMockBL = new  SupportingDocumentMockBL ();
            _mockSupportingDocumentService = new Mock<ISupportingDocumentService>();
            _mockLogger = new Mock<ILogger<SupportingDocumentController>>();
        }

        //[Test]
        //public async Task GetAllSupportingDocument_ReturnsData()
        //{
        //    // Arrange
        //    string Id="id";
        //    string filename= "filename";
        //    string docname = Id + "_" + filename;
        //    string fileName = Id + "_" + filename;
        //    string docloc = "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv";
        //    var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
        //    string doctype = "application/octet-stream";
        //    var SupportingDocuments = new FileStreamResult(fileStream, doctype)
        //    {
        //        FileDownloadName = filename
        //    };
        //    _mockSupportingDocumentService.Setup(service => service.GetDocumentById(Id,filename)).Returns(_SupportingDocumentService.GetDocumentById);
        //    _mockSupportingDocumentService.Setup(service => service.GetContentTypeForFile(Id, filename)).Returns(_SupportingDocumentService.GetContentTypeForFile);
        //    _ISupportingDocumentRepo.Setup(repo => repo.GetDocumentById(docname)).Returns(_mockSupportingDocumentRepo.ReturnsSupportingDocument);
        //    _ISupportingDocumentBL.Setup(bl => bl.GetDocument(docloc)).Returns(_mocksupportingDocumentMockBL.ReturnsFileStream);
        //    _ISupportingDocumentBL.Setup(bl => bl.GetContentTypeForFile(fileName)).Returns(_mocksupportingDocumentMockBL.ReturnsContentType);

        //    // Act
        //    var result = await _controller.GetDocumentById(Id, filename) as FileStreamResult;

        //    // Assert
        //    Assert.AreEqual(SupportingDocuments.FileDownloadName, result.FileDownloadName);
        //    Assert.AreEqual(SupportingDocuments.ContentType, result.ContentType);
        //}
        [Test]
        public async Task GetAllSupportingDocument_ReturnsNullFileStream()
        {
            // Arrange
            string Id = "id";
            string filename = "filename";
            string docname = Id + "_" + filename;
            string fileName = Id + "_" + filename;
            string docloc = "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv";
            var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
            string doctype = "application/octet-stream";
            var SupportingDocuments = new FileStreamResult(fileStream, doctype)
            {
                FileDownloadName = filename
            };
            _mockSupportingDocumentService.Setup(service => service.GetDocumentById(Id, filename)).Returns(_SupportingDocumentService.GetDocumentById);
            _mockSupportingDocumentService.Setup(service => service.GetContentTypeForFile(Id, filename)).Returns(_SupportingDocumentService.GetContentTypeForFile);
            _ISupportingDocumentRepo.Setup(repo => repo.GetDocumentById(docname)).Returns(_mockSupportingDocumentRepo.ReturnsSupportingDocument);
            _ISupportingDocumentBL.Setup(bl => bl.GetDocument(docloc)).Returns(_mocksupportingDocumentMockBL.ReturnsFileStreamNull);
            // Act
            var result = await _controller.GetDocumentById(Id, filename) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetAllSupportingDocument_ReturnsNullDoc()
        {
            // Arrange
            string Id = "id";
            string filename = "filename";
            string docname = Id + "_" + filename;
            string fileName = Id + "_" + filename;
            string docloc = "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv";
            var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
            string doctype = "application/octet-stream";
            var SupportingDocuments = new FileStreamResult(fileStream, doctype)
            {
                FileDownloadName = filename
            };
            _mockSupportingDocumentService.Setup(service => service.GetDocumentById(Id, filename)).Returns(_SupportingDocumentService.GetDocumentById);
            _mockSupportingDocumentService.Setup(service => service.GetContentTypeForFile(Id, filename)).Returns(_SupportingDocumentService.GetContentTypeForFile);
            _ISupportingDocumentRepo.Setup(repo => repo.GetDocumentById(docname)).Returns(_mockSupportingDocumentRepo.ReturnsNull);
            // Act
            var result = await _controller.GetDocumentById(Id, filename) as ObjectResult;

            // Assert
            Assert.AreEqual("Returns Null", result.Value);
        }
        [Test]
        public async Task GetDocumentById_WhenServiceThrowsException()
        {
            // Arrange
            string Id = "id";
            string filename = "filename";
            string docname = Id + "_" + filename;
            string fileName = Id + "_" + filename;
            string docloc = "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv";
            var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
            string doctype = "application/octet-stream";
            var SupportingDocuments = new FileStreamResult(fileStream, doctype)
            {
                FileDownloadName = filename
            };
            _mockSupportingDocumentService.Setup(service => service.GetDocumentById(Id, filename)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetDocumentById(Id, filename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetContentTypeForFile_WhenServiceThrowsException()
        {
            // Arrange
            string Id = "id";
            string filename = "filename";
            string docname = Id + "_" + filename;
            string fileName = Id + "_" + filename;
            string docloc = "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv";
            var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
            string doctype = "application/octet-stream";
            var SupportingDocuments = new FileStreamResult(fileStream, doctype)
            {
                FileDownloadName = filename
            };
            _mockSupportingDocumentService.Setup(service => service.GetDocumentById(Id, filename)).Returns(_SupportingDocumentService.GetDocumentById);
            _ISupportingDocumentRepo.Setup(repo => repo.GetDocumentById(docname)).Returns(_mockSupportingDocumentRepo.ReturnsSupportingDocument);
            _ISupportingDocumentBL.Setup(bl => bl.GetDocument(docloc)).Returns(_mocksupportingDocumentMockBL.ReturnsFileStream);
            _mockSupportingDocumentService.Setup(service => service.GetContentTypeForFile(Id, filename)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetDocumentById(Id, filename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetDocumentById_WhenRepositoryThrowsException()
        {
            // Arrange
            string Id = "id";
            string filename = "filename";
            string docname = Id + "_" + filename;
            string fileName = Id + "_" + filename;
            string docloc = "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv";
            var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
            string doctype = "application/octet-stream";
            var SupportingDocuments = new FileStreamResult(fileStream, doctype)
            {
                FileDownloadName = filename
            };
            _mockSupportingDocumentService.Setup(service => service.GetDocumentById(Id, filename)).Returns(_SupportingDocumentService.GetDocumentById);
            _mockSupportingDocumentService.Setup(service => service.GetContentTypeForFile(Id, filename)).Returns(_SupportingDocumentService.GetContentTypeForFile);
            _ISupportingDocumentRepo.Setup(repo => repo.GetDocumentById(docname)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetDocumentById(Id, filename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetDocument_WhenBLThrowsException()
        {
            // Arrange
            string Id = "id";
            string filename = "filename";
            string docname = Id + "_" + filename;
            string fileName = Id + "_" + filename;
            string docloc = "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv";
            var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
            string doctype = "application/octet-stream";
            var SupportingDocuments = new FileStreamResult(fileStream, doctype)
            {
                FileDownloadName = filename
            };
            _mockSupportingDocumentService.Setup(service => service.GetDocumentById(Id, filename)).Returns(_SupportingDocumentService.GetDocumentById);
            _mockSupportingDocumentService.Setup(service => service.GetContentTypeForFile(Id, filename)).Returns(_SupportingDocumentService.GetContentTypeForFile);
            _ISupportingDocumentRepo.Setup(repo => repo.GetDocumentById(docname)).Returns(_mockSupportingDocumentRepo.ReturnsSupportingDocument);
            _ISupportingDocumentBL.Setup(bl => bl.GetDocument(docloc)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetDocumentById(Id, filename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
        [Test]
        public async Task GetContentTypeForFile_WhenBLThrowsException()
        {
            // Arrange
            string Id = "id";
            string filename = "filename";
            string docname = Id + "_" + filename;
            string fileName = Id + "_" + filename;
            string docloc = "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv";
            var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
            string doctype = "application/octet-stream";
            var SupportingDocuments = new FileStreamResult(fileStream, doctype)
            {
                FileDownloadName = filename
            };
            _mockSupportingDocumentService.Setup(service => service.GetDocumentById(Id, filename)).Returns(_SupportingDocumentService.GetDocumentById);
            _mockSupportingDocumentService.Setup(service => service.GetContentTypeForFile(Id, filename)).Returns(_SupportingDocumentService.GetContentTypeForFile);
            _ISupportingDocumentRepo.Setup(repo => repo.GetDocumentById(docname)).Returns(_mockSupportingDocumentRepo.ReturnsSupportingDocument);
            _ISupportingDocumentBL.Setup(bl => bl.GetDocument(docloc)).Returns(_mocksupportingDocumentMockBL.ReturnsFileStream);
            _ISupportingDocumentBL.Setup(bl => bl.GetContentTypeForFile(fileName)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetDocumentById(Id, filename) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}
