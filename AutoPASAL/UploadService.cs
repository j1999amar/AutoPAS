using AutoPASAL.DTO_Model;
using AutoPASAL.Dynamic;
using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;
using Newtonsoft.Json;
using System.Text.Json;

namespace AutoPASAL
{
    public class UploadService : IUploadService
    {

        private readonly IMetaDataRepo _metaDataRepo;
        private readonly ICSVService _csvService;
        private readonly IJSONService _jsonService;
        private readonly IDynamicRateTableService _dynamicRateTableService;
        public UploadService(IDynamicRateTableService dynamicRateTableService, ICSVService csvService, IJSONService jsonService, IMetaDataRepo metaDataRepo)
        {
            _dynamicRateTableService = dynamicRateTableService;
            _csvService = csvService;
            _metaDataRepo = metaDataRepo;
            _jsonService = jsonService;
        }
        public async Task<object> AddRateTables(UploadFile file, string filename)
        {
            object obj = new();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = $"..\\..\\..\\..\\AutoPASDML";
            string directoryPath = Path.Combine(baseDirectory, relativePath);
            string searchPattern = $"{filename}.cs";
            string[] files = Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
            var csvHeaders = await _csvService.GetHeader(file);
            var headerRow = await _csvService.GetHeaderRow(file);

            if (files.Length > 0)
            {
                //await _tableDynamicController.Test();
                await _dynamicRateTableService.DynamicTableAlteration(csvHeaders,headerRow, filename);
                await _dynamicRateTableService.DynamicModelEditing(csvHeaders, filename);
                await _dynamicRateTableService.DynamicRepoEditing(csvHeaders, filename);
                await _dynamicRateTableService.DynamicMetadataTableEditing(csvHeaders, filename);
            }

            else
            {
                await _dynamicRateTableService.DynamicTableCreation(headerRow, filename);
                await _dynamicRateTableService.DynamicModelCreation(csvHeaders, filename);
                await _dynamicRateTableService.DynamicContextEditing(filename);
                await _dynamicRateTableService.DynamicIRepositoryCreation(filename);
                await _dynamicRateTableService.DynamicRepositoryCreation(csvHeaders, filename);
                await _dynamicRateTableService.DynamicIServiceCreation(filename);
                await _dynamicRateTableService.DynamicServiceCreation(filename);
                await _dynamicRateTableService.DynamicControllerCreation(filename);
                await _dynamicRateTableService.DynamicProgramFileEditing(filename);
                await _dynamicRateTableService.DynamicRatingServiceEditing(filename);
                await _dynamicRateTableService.DynamicMetadataTableAdd(csvHeaders, filename);
            }
            return obj;

        }
        public async Task<object> CreateTables(JsonElement filedata, string filename)
        {
            object obj = new();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = $"..\\..\\..\\..\\AutoPASDML";
            string directoryPath = Path.Combine(baseDirectory, relativePath);
            string searchPattern = $"{filename}.cs";
            string[] files = Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
            var dataheader = await _jsonService.JSONDivideField(filedata);
            var csvHeaders = JsonConvert.DeserializeObject < string[]>(dataheader.Header);
            var headerRow = await _jsonService.JSONDivideData(dataheader.Data);
            if (files.Length > 0)
            {
                //await _tableDynamicController.Test();
                await _dynamicRateTableService.DynamicTableAlteration(csvHeaders, headerRow, filename);
                await _dynamicRateTableService.DynamicModelEditing(csvHeaders, filename);
                await _dynamicRateTableService.DynamicRepoEditing(csvHeaders, filename);
                await _dynamicRateTableService.DynamicMetadataTableEditing(csvHeaders, filename);
            }

            else
            {
                await _dynamicRateTableService.DynamicTableCreation(headerRow, filename);
                await _dynamicRateTableService.DynamicModelCreation(csvHeaders, filename);
                await _dynamicRateTableService.DynamicContextEditing(filename);
                await _dynamicRateTableService.DynamicIRepositoryCreation(filename);
                await _dynamicRateTableService.DynamicRepositoryCreation(csvHeaders, filename);
                await _dynamicRateTableService.DynamicIServiceCreation(filename);
                await _dynamicRateTableService.DynamicServiceCreation(filename);
                await _dynamicRateTableService.DynamicControllerCreation(filename);
                await _dynamicRateTableService.DynamicProgramFileEditing(filename);
                await _dynamicRateTableService.DynamicRatingServiceEditing(filename);
                await _dynamicRateTableService.DynamicMetadataTableAdd(csvHeaders, filename);
            }
            return obj;

        }
        public Task<List<metadatatables>> GetTableList()
        {
            var meta = _metaDataRepo.GetTableList();
            return meta;
        }
        public Task<List<metadatatables>> GetTableListById(string id)
        {
            var meta = _metaDataRepo.GetTableListById(id);
            return meta;
        }
        public Task<metadatatables> UpdateTableListById(metadatatables obj,string id)
        {
            var meta = _metaDataRepo.UpdateTableListById(obj,id);
            return meta;
        }
    }
}
