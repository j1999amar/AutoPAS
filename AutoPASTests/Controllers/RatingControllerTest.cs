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

namespace AutoPASAPI.Tests.Controllers
{
    [TestFixture]
    public class RatingControllerTests
    {
        private Mock<IRT_NCBFactorBL> _NCBFactorBLMock;
        private Mock<IRT_OwnDamageFactorBL> _OwnDamageFactorBLMock;
        private Mock<IRT_LegalLiabilityPremiumBL> _LegalLiabilityPremiumBLMock;
        private Mock<IRT_ThirdPartyCoverPremiumBL> _ThirdPartyCoverPremiumBLMock;
        private Mock<IRT_TheftFactorBL> _TheftFactorBLMock;
        private Mock<IRT_GSTFactorBL> _GSTFactorBLMock;
        private Mock<IRT_NCBBL> _NCBBLMock;
        private Mock<IRT_ODPBL> _ODPBLMock;
        private Mock<IRT_TPCBL> _TPCBLMock;
        private Mock<IRT_LLPBL> _LLPBLMock;
        private Mock<IRT_THEFTBL> _TheftBLMock;
        private Mock<IRT_GSTBL> _GstBLMock;
        private Mock<ILogger<RatingController>> _loggerMock;
        private RatingController _ratingController;

        [SetUp]
        public void Setup()
        {
            _NCBFactorBLMock = new Mock<IRT_NCBFactorBL>();
            _OwnDamageFactorBLMock = new Mock<IRT_OwnDamageFactorBL>();
            _LegalLiabilityPremiumBLMock = new Mock<IRT_LegalLiabilityPremiumBL>();
            _ThirdPartyCoverPremiumBLMock = new Mock<IRT_ThirdPartyCoverPremiumBL>();
            _TheftFactorBLMock = new Mock<IRT_TheftFactorBL>();
            _GSTFactorBLMock = new Mock<IRT_GSTFactorBL>();
            _NCBBLMock = new Mock<IRT_NCBBL>();
            _ODPBLMock = new Mock<IRT_ODPBL>();
            _TPCBLMock= new Mock<IRT_TPCBL> ();
            _LLPBLMock= new Mock<IRT_LLPBL> ();
            _TheftBLMock = new Mock<IRT_THEFTBL>();
            _GstBLMock = new Mock<IRT_GSTBL>();
            _loggerMock = new Mock<ILogger<RatingController>>();
            _ratingController = new RatingController(_NCBFactorBLMock.Object,_OwnDamageFactorBLMock.Object,_LegalLiabilityPremiumBLMock.Object,_ThirdPartyCoverPremiumBLMock.Object,_TheftFactorBLMock.Object,_GSTFactorBLMock.Object, _NCBBLMock.Object, _ODPBLMock.Object, _TPCBLMock.Object, _LLPBLMock.Object, _TheftBLMock.Object, _GstBLMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetNCBFactors_Returns_OkResult()
        {
            //Arrange
            var NCBList = new List<RT_NCB>();
            _NCBBLMock.Setup(x => x.GetRT_NCB()).ReturnsAsync(NCBList);

            //Act
            var result = await _ratingController.GetNCBFactors();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(NCBList, okResult.Value);
        }

        [Test]
        public async Task GetNCBFactors_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _NCBBLMock.Setup(x => x.GetRT_NCB()).Throws(new Exception());

            //Act
            var result = await _ratingController.GetNCBFactors();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetRateTableById_Returns_OkResult()
        {
            //Arrange
            int Id = 1;
            var NCBList = new List<RT_NCB>();
            _NCBBLMock.Setup(x => x.GetRT_NCBById(Id)).ReturnsAsync(NCBList);

            //Act
            var result = await _ratingController.GetRateTableById(Id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(NCBList, okResult.Value);
        }

        [Test]
        public async Task GetRateTableById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            int Id = 1;
            _NCBBLMock.Setup(x => x.GetRT_NCBById(Id)).Throws(new Exception());

            //Act
            var result = await _ratingController.GetRateTableById(Id);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task UpdateNCBById_Returns_OkResult()
        {
            //Arrange
            var NCBL = new RT_NCB();
            int id = 1;
            decimal factor = new decimal();
            _NCBBLMock.Setup(x => x.UpdateRT_NCBById(id, factor)).ReturnsAsync(NCBL);

            //Act
            var result = await _ratingController.UpdateNCBById(id, factor);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(NCBL, okResult.Value);
        }

        [Test]
        public async Task UpdateNCBById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            int id = 1;
            decimal factor = new decimal();
            _NCBBLMock.Setup(x => x.UpdateRT_NCBById(id, factor)).Throws(new Exception());

            //Act
            var result = await _ratingController.UpdateNCBById(id, factor);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetODFactors_Returns_OkResult()
        {
            //Arrange
            var ODList = new List<RT_ODP>();
            _ODPBLMock.Setup(x => x.GetRT_ODP()).ReturnsAsync(ODList);

            //Act
            var result = await _ratingController.GetODFactors();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(ODList, okResult.Value);
        }

        [Test]
        public async Task GetODFactors_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _ODPBLMock.Setup(x => x.GetRT_ODP()).Throws(new Exception());

            //Act
            var result = await _ratingController.GetODFactors();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task UpdateODPById_Returns_OkResult()
        {
            //Arrange
            var NCBL = new RT_ODP();
            int id = 1;
            decimal factor = new decimal();
            _ODPBLMock.Setup(x => x.UpdateRT_ODPById(id, factor)).ReturnsAsync(NCBL);

            //Act
            var result = await _ratingController.UpdateODPById(id, factor);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(NCBL, okResult.Value);
        }

        [Test]
        public async Task UpdateODPById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            int id = 1;
            decimal factor = new decimal();
            _ODPBLMock.Setup(x => x.UpdateRT_ODPById(id, factor)).Throws(new Exception());

            //Act
            var result = await _ratingController.UpdateODPById(id, factor);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task GetLLPFactors_Returns_OkResult()
        {
            //Arrange
            var LLPList = new List<RT_LLP>();
            _LLPBLMock.Setup(x => x.GetRT_LLP()).ReturnsAsync(LLPList);

            //Act
            var result = await _ratingController.GetLLPFactors();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(LLPList, okResult.Value);
        }

        [Test]
        public async Task GetLLPFactors_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _LLPBLMock.Setup(x => x.GetRT_LLP()).Throws(new Exception());

            //Act
            var result = await _ratingController.GetLLPFactors();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task UpdateLLPById_Returns_OkResult()
        {
            //Arrange
            var LLPL = new RT_LLP();
            int id = 1;
            decimal factor = new decimal();
            _LLPBLMock.Setup(x => x.UpdateRT_LLPById(id, factor)).ReturnsAsync(LLPL);

            //Act
            var result = await _ratingController.UpdateLLPById(id, factor);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(LLPL, okResult.Value);
        }

        [Test]
        public async Task UpdateLLPById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            int id = 1;
            decimal factor = new decimal();
            _LLPBLMock.Setup(x => x.UpdateRT_LLPById(id, factor)).Throws(new Exception());

            //Act
            var result = await _ratingController.UpdateLLPById(id, factor);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetTPCPFactors_Returns_OkResult()
        {
            //Arrange
            var TPCPList = new List<RT_TPC>();
            _TPCBLMock.Setup(x => x.GetRT_TPC()).ReturnsAsync(TPCPList);

            //Act
            var result = await _ratingController.GetTPCPFactors();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(TPCPList, okResult.Value);
        }


        [Test]
        public async Task GetTPCPFactors_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _TPCBLMock.Setup(x => x.GetRT_TPC()).Throws(new Exception());

            //Act
            var result = await _ratingController.GetTPCPFactors();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
        [Test]
        public async Task UpdateTPCById_Returns_OkResult()
        {
            //Arrange
            var NCBL = new RT_TPC();
            int id = 1;
            decimal factor = new decimal();
            _TPCBLMock.Setup(x => x.UpdateRT_TPCById(id, factor)).ReturnsAsync(NCBL);

            //Act
            var result = await _ratingController.UpdateTPCById(id, factor);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(NCBL, okResult.Value);
        }

        [Test]
        public async Task UpdateTPCById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            int id = 1;
            decimal factor = new decimal();
            _TPCBLMock.Setup(x => x.UpdateRT_TPCById(id, factor)).Throws(new Exception());

            //Act
            var result = await _ratingController.UpdateTPCById(id, factor);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetTheftFactors_Returns_OkResult()
        {
            //Arrange
            var TheftList = new List<RT_THEFT>();
            _TheftBLMock.Setup(x => x.GetRT_THEFT()).ReturnsAsync(TheftList);

            //Act
            var result = await _ratingController.GetTheftFactors();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(TheftList, okResult.Value);
        }

        [Test]
        public async Task GetTheftFactors_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _TheftBLMock.Setup(x => x.GetRT_THEFT()).Throws(new Exception());

            //Act
            var result = await _ratingController.GetTheftFactors();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task UpdateTheftById_Returns_OkResult()
        {
            //Arrange
            var THEFTL = new RT_THEFT();
            int id = 1;
            decimal factor = new decimal();
            _TheftBLMock.Setup(x => x.UpdateRT_THEFTById(id, factor)).ReturnsAsync(THEFTL);

            //Act
            var result = await _ratingController.UpdateTheftById(id, factor);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(THEFTL, okResult.Value);
        }

        [Test]
        public async Task UpdateTheftById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            int id = 1;
            decimal factor = new decimal();
            _TheftBLMock.Setup(x => x.UpdateRT_THEFTById(id, factor)).Throws(new Exception());

            //Act
            var result = await _ratingController.UpdateTheftById(id, factor);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task GetGSTFactors_Returns_OkResult()
        {
            //Arrange
            var GSTList = new List<RT_GST>();
            _GstBLMock.Setup(x => x.GetRT_GST()).ReturnsAsync(GSTList);

            //Act
            var result = await _ratingController.GetGSTFactors();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(GSTList, okResult.Value);
        }

        [Test]
        public async Task GetGSTFactors_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            _GstBLMock.Setup(x => x.GetRT_GST()).Throws(new Exception());

            //Act
            var result = await _ratingController.GetGSTFactors();

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

        [Test]
        public async Task UpdateGstById_Returns_OkResult()
        {
            //Arrange
            var GSTL = new RT_GST();
            int id = 1;
            decimal factor = new decimal();
            _GstBLMock.Setup(x => x.UpdateRT_GSTById(id, factor)).ReturnsAsync(GSTL);

            //Act
            var result = await _ratingController.UpdateGstById(id, factor);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(GSTL, okResult.Value);
        }

        [Test]
        public async Task UpdateGstById_Returns_InternalServerErrorResult_When_Exception_Is_Thrown()
        {
            //Arrange
            int id = 1;
            decimal factor = new decimal();
            _GstBLMock.Setup(x => x.UpdateRT_GSTById(id, factor)).Throws(new Exception());

            //Act
            var result = await _ratingController.UpdateGstById(id, factor);

            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
        }

    }
}
