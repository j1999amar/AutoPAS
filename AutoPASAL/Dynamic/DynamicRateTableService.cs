using AutoPASAL.DTO_Model;
using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoPASAL.Dynamic
{
    public interface IDynamicRateTableService 
    {
        Task DynamicModelCreation(string[] csvHeaders, string filename);
        Task DynamicContextEditing(string filename);
        Task DynamicRepositoryCreation(string[] csvHeaders, string filename);
        Task DynamicIRepositoryCreation(string filename);
        Task DynamicIServiceCreation(string filename);
        Task DynamicServiceCreation(string filename);
        Task DynamicControllerCreation(string filename);
        Task DynamicRatingServiceEditing(string filename);
        Task DynamicProgramFileEditing(string filename);
        Task DynamicModelEditing(string[] csvHeaders, string filename);
        Task DynamicRepoEditing(string[] csvHeaders, string filename);
        Task DynamicMetadataTableEditing(string[] csvHeaders, string filename);
        Task DynamicMetadataTableAdd(string[] csvHeaders, string filename);
        Task DynamicTableCreation(HeaderRow headerRow, string filename);
        Task DynamicTableAlteration(string[] csvHeaders, HeaderRow headerRow, string filename);


    }
    public class DynamicRateTableService:IDynamicRateTableService
    {

        private readonly IMetaDataRepo _metaDataRepo;
        private readonly ICSVService _csvService;
        public DynamicRateTableService(IMetaDataRepo metaDataRepo, ICSVService csvService)
        {
            _metaDataRepo = metaDataRepo;
            _csvService = csvService;
        }
        public async Task DynamicModelCreation(string[] csvHeaders, string filename)
        {
            // Create the Model.cs file dynamically
            var modelcode = new StringBuilder();

            modelcode.AppendLine("using System.ComponentModel.DataAnnotations;");
            modelcode.AppendLine();
            modelcode.AppendLine($"namespace AutoPASDML");
            modelcode.AppendLine("{");
            modelcode.AppendLine($"    public class {filename}");
            modelcode.AppendLine("    {");

            if (csvHeaders != null)
            {
                foreach (var header in csvHeaders)
                {
                    modelcode.AppendLine($"        public string {header} {{ get; set; }}");
                }
            }
            modelcode.AppendLine("      //property");
            modelcode.AppendLine("    }");
            modelcode.AppendLine("}");
            string relativePath = $"..\\..\\..\\..\\AutoPASDML\\{filename}.cs";
            string filePath = GetFilePath(relativePath);
            fileSave(filePath, modelcode);
            return;
        }
        public async Task DynamicContextEditing(string filename)
        {

            string relativePath = "..\\..\\..\\..\\AutoPASSL\\APASDBContext.cs";
            string filePath = GetFilePath(relativePath);
            string fileContent = GetContent(filePath);
            StringBuilder sb = new StringBuilder(fileContent);
            string insertionPoint = "//DbSet";
            int insertionIndex = sb.ToString().IndexOf(insertionPoint);
            sb.Insert(insertionIndex, $"public DbSet<{filename}> {filename} {{ get; set; }}\r\n        ");
            System.IO.File.WriteAllText(filePath, sb.ToString());
            return;
        }
        public async Task DynamicRepositoryCreation(string[] csvHeaders,string filename)
        {
            var repositorycode = new StringBuilder();
            repositorycode.AppendLine("using AutoPASAL.IRepository;");
            repositorycode.AppendLine("using AutoPASDML;");
            repositorycode.AppendLine("using Microsoft.EntityFrameworkCore;");
            repositorycode.AppendLine();
            repositorycode.AppendLine("namespace AutoPASSL.Repository");
            repositorycode.AppendLine("{");
            repositorycode.AppendLine($"        public class {filename}Repo : I{filename}Repo");
            repositorycode.AppendLine("        {");
            repositorycode.AppendLine("            private readonly APASDBContext _context;");
            repositorycode.AppendLine($"            public {filename}Repo(APASDBContext context)");
            repositorycode.AppendLine("            {");
            repositorycode.AppendLine("                _context = context;");
            repositorycode.AppendLine("            }");
            repositorycode.AppendLine($"            public async Task<List<{filename}>> Get{filename}()");
            repositorycode.AppendLine("            {");
            repositorycode.AppendLine($"                var obj = await _context.{filename}.ToListAsync();");
            repositorycode.AppendLine("                return obj;");
            repositorycode.AppendLine("            }");
            repositorycode.AppendLine($"            public async Task<List<{filename}>> Get{filename}ById(int id)");
            repositorycode.AppendLine("            {");
            repositorycode.AppendLine($"                var obj = await _context.{filename}.Where(x => x.id == id.ToString()).ToListAsync();");
            repositorycode.AppendLine("                return obj;");
            repositorycode.AppendLine("            }");
            repositorycode.AppendLine($"            public async Task<{filename}> Update{filename}ById({filename} obj)");
            repositorycode.AppendLine("            {");
            repositorycode.AppendLine($"                var  {filename} = await _context.{filename}.FirstOrDefaultAsync(x => x.id == obj.id);");
            repositorycode.AppendLine($"                if ({filename}  != null)");
            repositorycode.AppendLine("                {"); if (csvHeaders != null)
            {
                foreach (var header in csvHeaders)
                {
                    if (header != "id" || header != "Id" || header != "ID" || header != "iD")
                    {
                        repositorycode.AppendLine($"                   {filename}.{header} = obj.{header};");
                    }
                }

            }
            repositorycode.AppendLine("                    //property");
            repositorycode.AppendLine("                    await _context.SaveChangesAsync();");
            repositorycode.AppendLine("                }");
            repositorycode.AppendLine($"                return {filename}  ;");
            repositorycode.AppendLine("            }");
            repositorycode.AppendLine($"            public async Task<{filename}> Add{filename}Entry({filename} obj)");
            repositorycode.AppendLine("            {");
            repositorycode.AppendLine($"                await _context.{filename}.AddAsync(obj);");
            repositorycode.AppendLine($"                await _context.SaveChangesAsync();");
            repositorycode.AppendLine($"                return obj;");
            repositorycode.AppendLine("            }");
            repositorycode.AppendLine($"            public async Task<{filename}> Delete{filename}Entry(int id)");
            repositorycode.AppendLine("            {");
            repositorycode.AppendLine($"                var {filename}= await _context.{filename}.FirstOrDefaultAsync(x => x.id == id.ToString());");
            repositorycode.AppendLine($"                if ({filename} != null)");
            repositorycode.AppendLine("                {");
            repositorycode.AppendLine($"                    _context.{filename}.Remove({filename});");
            repositorycode.AppendLine($"                    await _context.SaveChangesAsync();");
            repositorycode.AppendLine("                }");
            repositorycode.AppendLine($"               return {filename};");
            repositorycode.AppendLine("            }");
            repositorycode.AppendLine("        }");
            repositorycode.AppendLine("}");
            string relativePath = $"..\\..\\..\\..\\AutoPASSL\\Repository\\{filename}Repo.cs";
            string filePath = GetFilePath(relativePath);
            fileSave(filePath, repositorycode);
            return;
        }
        public async Task DynamicIRepositoryCreation(string filename)
        {
            var irepositorycode = new StringBuilder();
            irepositorycode.AppendLine("using AutoPASDML;");
            irepositorycode.AppendLine("namespace AutoPASAL.IRepository");
            irepositorycode.AppendLine();
            irepositorycode.AppendLine("{");
            irepositorycode.AppendLine($"    public interface I{filename}Repo");
            irepositorycode.AppendLine("    {");
            irepositorycode.AppendLine($"        Task<List<{filename}>> Get{filename}();");
            irepositorycode.AppendLine($"        Task<List<{filename}>> Get{filename}ById(int id);");
            irepositorycode.AppendLine($"        Task<{filename}> Update{filename}ById({filename} obj);");
            irepositorycode.AppendLine($"        Task<{filename}> Add{filename}Entry({filename} obj);");
            irepositorycode.AppendLine($"        Task <{filename}> Delete{filename}Entry(int id);");
            irepositorycode.AppendLine("    }");
            irepositorycode.AppendLine("}");
            string relativePath = $"..\\..\\..\\..\\AutoPASAL\\IRepository\\I{filename}Repo.cs";
            string filePath = GetFilePath(relativePath);
            fileSave(filePath, irepositorycode);
            return;
        }
        public async Task DynamicIServiceCreation(string filename)
        {
            var iservicecode = new StringBuilder();
            iservicecode.AppendLine("using AutoPASDML;");
            iservicecode.AppendLine();
            iservicecode.AppendLine("namespace AutoPASAL.Services");
            iservicecode.AppendLine("{");
            iservicecode.AppendLine($"    public interface I{filename}Service");
            iservicecode.AppendLine("    {");
            iservicecode.AppendLine($"        Task<List<{filename}>> Get{filename}();");
            iservicecode.AppendLine($"        Task<List<{filename}>> Get{filename}ById(int id);");
            iservicecode.AppendLine($"        Task<{filename}> Update{filename}ById({filename} obj);");
            iservicecode.AppendLine($"        Task<{filename}> Add{filename}Entry({filename} obj);");
            iservicecode.AppendLine($"        Task <{filename}> Delete{filename}Entry(int id);");
            iservicecode.AppendLine("    }");
            iservicecode.AppendLine("}");
            string relativePath = $"..\\..\\..\\..\\AutoPASAL\\Services\\I{filename}Service.cs";
            string filePath = GetFilePath(relativePath);
            fileSave(filePath, iservicecode);
            return;
        }
        public async Task DynamicServiceCreation(string filename)
        {
            var servicecode = new StringBuilder();
            servicecode.AppendLine("using AutoPASAL.IRepository;");
            servicecode.AppendLine("using AutoPASAL.Services;");
            servicecode.AppendLine("using AutoPASDML;");
            servicecode.AppendLine();
            servicecode.AppendLine("namespace AutoPASAL");
            servicecode.AppendLine("{");
            servicecode.AppendLine($"    public class {filename}Service : I{filename}Service");
            servicecode.AppendLine("    {");
            servicecode.AppendLine($"        private readonly I{filename}Repo _{filename}Repo;");
            servicecode.AppendLine($"        public {filename}Service(I{filename}Repo {filename}Repo)");
            servicecode.AppendLine("        {");
            servicecode.AppendLine($"        _{filename}Repo = {filename}Repo;");
            servicecode.AppendLine("        }");
            servicecode.AppendLine($"        public Task<List<{filename}>> Get{filename}()");
            servicecode.AppendLine("        {");
            servicecode.AppendLine($"        var {filename} = _{filename}Repo.Get{filename}();");
            servicecode.AppendLine($"        return {filename};");
            servicecode.AppendLine("        }");
            servicecode.AppendLine($"        public Task<List<{filename}>> Get{filename}ById(int id)");
            servicecode.AppendLine("        {");
            servicecode.AppendLine($"        var {filename} = _{filename}Repo.Get{filename}ById(id);");
            servicecode.AppendLine($"        return {filename};");
            servicecode.AppendLine("        }");
            servicecode.AppendLine($"        public Task<{filename}> Update{filename}ById({filename} obj)");
            servicecode.AppendLine("        {");
            servicecode.AppendLine($"           var {filename} = _{filename}Repo.Update{filename}ById(obj);");
            servicecode.AppendLine($"           return {filename};");
            servicecode.AppendLine("        }");
            servicecode.AppendLine($"        public Task<{filename}> Add{filename}Entry({filename} obj)");
            servicecode.AppendLine("        {");
            servicecode.AppendLine($"            var {filename} = _{filename}Repo.Add{filename}Entry(obj);");
            servicecode.AppendLine($"            return {filename};");
            servicecode.AppendLine("        }");
            servicecode.AppendLine($"        public Task <{filename}> Delete{filename}Entry(int id)");
            servicecode.AppendLine("        {");
            servicecode.AppendLine($"            var {filename} = _{filename}Repo.Delete{filename}Entry(id);");
            servicecode.AppendLine($"            return {filename};");
            servicecode.AppendLine("        }");
            servicecode.AppendLine("    }");
            servicecode.AppendLine("}");
            string relativePath = $"..\\..\\..\\..\\AutoPASAL\\{filename}Service.cs";
            string filePath = GetFilePath(relativePath);
            fileSave(filePath, servicecode);
            return;

        }
        public async Task DynamicControllerCreation(string filename)
        {
            var controllercode = new StringBuilder();
            controllercode.AppendLine("using Microsoft.AspNetCore.Mvc;");
            controllercode.AppendLine("using AutoPASAL.Services;");
            controllercode.AppendLine("using AutoPASDML;");
            controllercode.AppendLine();
            controllercode.AppendLine("namespace AutoPASAPI.Controllers");
            controllercode.AppendLine("{");
            controllercode.AppendLine("     [Route(\"autopasapi /[controller]\")]");
            controllercode.AppendLine();
            controllercode.AppendLine("     [ApiController]");
            controllercode.AppendLine();
            controllercode.AppendLine($"    public class {filename}Controller : ControllerBase");
            controllercode.AppendLine("     { ");
            controllercode.AppendLine($"        private readonly ILogger<{filename}Controller> _logger;");
            controllercode.AppendLine($"        private readonly I{filename}Service _{filename}Service;");
            controllercode.AppendLine();
            controllercode.AppendLine($"        public {filename}Controller(ILogger<{filename}Controller> logger,I{filename}Service {filename}Service)");
            controllercode.AppendLine("         { ");
            controllercode.AppendLine("             _logger = logger;");
            controllercode.AppendLine($"             _{filename}Service={filename}Service; ");
            controllercode.AppendLine("         }");
            controllercode.AppendLine($"        [HttpGet(\"Get{filename}\")]");
            controllercode.AppendLine();
            controllercode.AppendLine($"        public async Task<IActionResult> Get{filename}()");
            controllercode.AppendLine("         {");
            controllercode.AppendLine("             try");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"                return Ok(await _{filename}Service.Get{filename}());");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("             catch (Exception ex)");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"             _logger.LogInformation(\"Error in function Get{filename}\");");
            controllercode.AppendLine();
            controllercode.AppendLine("             return StatusCode(500, ex);");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("         }");
            controllercode.AppendLine($"        [HttpGet(\"Get{filename}ById/{{id}}\")]");
            controllercode.AppendLine();
            controllercode.AppendLine($"        public async Task<IActionResult> Get{filename}ById(int id)");
            controllercode.AppendLine("         {");
            controllercode.AppendLine("             try");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"                return Ok(await _{filename}Service.Get{filename}ById(id));");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("             catch (Exception ex)");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"             _logger.LogInformation(\"Error in function Get{filename}ById\");");
            controllercode.AppendLine();
            controllercode.AppendLine("             return StatusCode(500, ex);");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("         }");
            controllercode.AppendLine($"        [HttpPut(\"Update{filename}ById\")]");
            controllercode.AppendLine();
            controllercode.AppendLine($"        public async Task<IActionResult> Update{filename}ById([FromBody] {filename} obj)");
            controllercode.AppendLine("         {");
            controllercode.AppendLine("             try");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"                return Ok(await _{filename}Service.Update{filename}ById(obj));");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("             catch (Exception ex)");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"             _logger.LogInformation(\"Error in function Update{filename}ById\");");
            controllercode.AppendLine();
            controllercode.AppendLine("             return StatusCode(500, ex);");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("         }");
            controllercode.AppendLine($"         [HttpPost(\"Add{filename}Entry\")]");
            controllercode.AppendLine($"         public async Task<IActionResult> Add{filename}Entry([FromBody] {filename} obj)");
            controllercode.AppendLine("         {");
            controllercode.AppendLine("             try");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"                 return Ok(await _{filename}Service.Add{filename}Entry(obj));");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("             catch (Exception ex)");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"             _logger.LogInformation(\"Error in function Add{filename}Entry\");");
            controllercode.AppendLine("             return StatusCode(500, ex);");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("         }");
            controllercode.AppendLine($"         [HttpDelete(\"Delete{filename}Entry /{{id}}\")]");
            controllercode.AppendLine($"         public async Task<IActionResult> Delete{filename}Entry(int id)");
            controllercode.AppendLine("         {");
            controllercode.AppendLine("             try");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"                 return Ok(await _{filename}Service.Delete{filename}Entry(id));");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("             catch (Exception ex)");
            controllercode.AppendLine("             {");
            controllercode.AppendLine($"                 _logger.LogInformation(\"Error in function Delete{filename}Entry\");");
            controllercode.AppendLine("                 return StatusCode(500, ex);");
            controllercode.AppendLine("             }");
            controllercode.AppendLine("         }");
            controllercode.AppendLine("     }");
            controllercode.AppendLine("}");
            string relativePath = $"..\\..\\..\\..\\AutoPASAPI\\Controllers\\{filename}Controller.cs";
            string filePath = GetFilePath(relativePath);
            fileSave(filePath, controllercode);
            return;
        }
        public async Task DynamicRatingServiceEditing(string filename)
        {
            string relativePath = "..\\..\\..\\..\\AutoPASAL\\RatingService.cs";
            string filePath = GetFilePath(relativePath);
            string fileContent = GetContent(filePath);
            StringBuilder sb = new StringBuilder(fileContent);
            string insertionPoint1 = "//insert1";
            int insertionIndex1 = sb.ToString().IndexOf(insertionPoint1);
            sb.Insert(insertionIndex1, $"private readonly I{filename}Repo _{filename}Repo;\r\n        ");
            string insertionPoint2 = "/*insert2*/";
            int insertionIndex2 = sb.ToString().IndexOf(insertionPoint2);
            sb.Insert(insertionIndex2, $", I{filename}Repo {filename}Repo");
            string insertionPoint3 = "//insert3";
            int insertionIndex3 = sb.ToString().IndexOf(insertionPoint3);
            sb.Insert(insertionIndex3, $"_{filename}Repo = {filename}Repo;\r\n            ");
            string insertionPoint4 = "//insert4";
            int insertionIndex4 = sb.ToString().IndexOf(insertionPoint4);
            sb.Insert(insertionIndex4, $"else if (tablename == \"{filename}\")\r\n            {{\r\n                obj = await _{filename}Repo.Get{filename}();\r\n            }}\r\n            ");
            string insertionPoint5 = "//insert5";
            int insertionIndex5 = sb.ToString().IndexOf(insertionPoint5);
            sb.Insert(insertionIndex5, $"else if (tablename == \"{filename}\")\r\n            {{\r\n                obj = await _{filename}Repo.Get{filename}ById(id);\r\n            }}\r\n            ");
            string insertionPoint6 = "//insert6";
            int insertionIndex6 = sb.ToString().IndexOf(insertionPoint6);
            sb.Insert(insertionIndex6, $"else if (tablename == \"{filename}\")\r\n            {{\r\n                obj = await _{filename}Repo.Update{filename}ById(JsonSerializer.Deserialize<{filename}>(body.GetRawText()));\r\n            }}\r\n            ");
            string insertionPoint7 = "//insert7";
            int insertionIndex7 = sb.ToString().IndexOf(insertionPoint7);
            sb.Insert(insertionIndex7, $"else if (tablename == \"{filename}\")\r\n            {{\r\n                obj = await _{filename}Repo.Add{filename}Entry(JsonSerializer.Deserialize<{filename}>(body.GetRawText()));\r\n            }}\r\n            ");
            string insertionPoint8 = "//insert8";
            int insertionIndex8 = sb.ToString().IndexOf(insertionPoint8);
            sb.Insert(insertionIndex8, $"else if (tablename == \"{filename}\")\r\n            {{\r\n                obj = await _{filename}Repo.Delete{filename}Entry(id);\r\n            }}\r\n            ");
            System.IO.File.WriteAllText(filePath, sb.ToString());
            return;

        }
        public async Task DynamicProgramFileEditing(string filename)
        {

            string relativePath = "..\\..\\..\\..\\AutoPASAPI\\Program.cs";
            string filePath = GetFilePath(relativePath);
            string fileContent = GetContent(filePath);
            StringBuilder sb = new StringBuilder(fileContent);
            string insertionPoint = "//insert";
            int insertionIndex = sb.ToString().IndexOf(insertionPoint);
            sb.Insert(insertionIndex, $"\r\n\r\n        container.Register<I{filename}Service, {filename}Service>();\r\n        builder.Services.AddScoped<I{filename}Service, {filename}Service>();\r\n\r\n        container.Register<I{filename}Repo, {filename}Repo>();\r\n        builder.Services.AddScoped<I{filename}Repo, {filename}Repo>();");
            System.IO.File.WriteAllText(filePath, sb.ToString());
            return;
        }
        public async Task DynamicModelEditing(string[] csvHeaders, string filename)
        {
            string relativePath = $"..\\..\\..\\..\\AutoPASDML";
            string directoryPath = GetFilePath(relativePath);
            string searchPattern = $"{filename}.cs";
            string[] files = Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
            string fileContents = File.ReadAllText(files[0]);
            string pattern = @"\s+(\S+)\s+{\s+get;\s+set;\s+}";
            List<string> extractedStrings = new List<string>();
            MatchCollection matches = Regex.Matches(fileContents, pattern);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    string extractedString = match.Groups[1].Value.Trim();
                    extractedStrings.Add(extractedString);
                }
            }

            // Compare csvHeaders and extractedStrings
            var missingHeaders = csvHeaders.Except(extractedStrings).ToList();
            var extraHeaders = extractedStrings.Except(csvHeaders).ToList();

            // Add missing headers to file content//property
            StringBuilder sb = new StringBuilder(fileContents);
            foreach (var missingHeader in missingHeaders)
            {
                    int insertIndex = fileContents.IndexOf("//property");
                    sb.Insert(insertIndex, $"public string {missingHeader} {{ get; set; }}\r\n      ");
            }
                // Remove extra headers from file content
            foreach (var extraHeader in extraHeaders)
            {
                string patternToRemove = $@"public\s+string\s+{extraHeader}\s+{{\s+get;\s+set;\s+}}";
                Regex regex = new Regex(patternToRemove);
                sb = new StringBuilder(regex.Replace(sb.ToString(), ""));
            }

            // Write modified file content back to the file
            System.IO.File.WriteAllText(files[0], sb.ToString());
            return;
        }
        public async Task DynamicRepoEditing(string[] csvHeaders,string filename)
        {
            string relativePath = $"..\\..\\..\\..\\AutoPASSL\\Repository";
            string directoryPath = GetFilePath(relativePath);
            string searchPattern = $"{filename}Repo.cs";
            string[] files = Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
            string fileContents = File.ReadAllText(files[0]);
            string pattern = $@"{filename}.(\S+)\s+=\s+obj.(\S+)";
            List<string> extractedStrings = new List<string>();
            MatchCollection matches = Regex.Matches(fileContents, pattern);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    string extractedProperty = match.Groups[1].Value;
                    extractedStrings.Add(extractedProperty);
                }
            }
            var missingHeaders = csvHeaders.Except(extractedStrings).ToList();
            var extraHeaders = extractedStrings.Except(csvHeaders).ToList();
            StringBuilder sb = new StringBuilder(fileContents);
            foreach (var missingHeader in missingHeaders)
            {
                int insertIndex = fileContents.IndexOf("//property");
                sb.Insert(insertIndex, $"{filename}.{missingHeader} = obj.{missingHeader};\r\n                   ");
            }

            // Remove extra headers from file content
            foreach (var extraHeader in extraHeaders)
            {
                string patternToRemove = $"{filename}.{extraHeader} = obj.{extraHeader};";
                Regex regex = new Regex(patternToRemove);
                sb = new StringBuilder(regex.Replace(sb.ToString(), ""));
            }

            // Write modified file content back to the file
            System.IO.File.WriteAllText(files[0], sb.ToString());
            return;
        }
        public async Task DynamicMetadataTableEditing(string[] csvHeaders, string filename)
        {
            var fields = new StringBuilder();
            foreach (string header in csvHeaders)
            {
                fields.AppendLine($"{header},");
            }
            fields.Length -= 3;
            string field = fields.ToString();
            string pattern = ",\r\n";
            string outputText = Regex.Replace(field, pattern, ",");
            await _metaDataRepo.DynamicMetadataTableEditing(filename, outputText);
            return;
        }
        public async Task DynamicMetadataTableAdd(string[] csvHeaders, string filename)
        {
            var fields = new StringBuilder();
            foreach (string header in csvHeaders)
            {
                fields.AppendLine($"{header},");
            }
            fields.Length -= 3;
            string field = fields.ToString();
            string pattern = ",\r\n";
            string outputText = Regex.Replace(field, pattern, ",");
            metadatatables meta = new metadatatables();
            meta.Id = filename;
            meta.Fields = outputText;
            meta.Title = filename;
            meta.Description = filename;
            await _metaDataRepo.DynamicMetadataTableAdd(meta);
            return;
        }
        public async Task DynamicTableCreation(HeaderRow headerRow, string filename)
        {
            await _metaDataRepo.DynamicTableCreation(headerRow, filename);
            return;
        }

        public async Task DynamicTableAlteration(string[] csvHeaders, HeaderRow headerRow, string filename)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = $"..\\..\\..\\..\\AutoPASDML";
            string directoryPath = Path.Combine(baseDirectory, relativePath);
            string searchPattern = $"{filename}.cs";
            string[] files = Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
            string fileContents = System.IO.File.ReadAllText(files[0]);
            string pattern = @"\s+(\S+)\s+{\s+get;\s+set;\s+}";



            List<string> extractedStrings = new List<string>();
            MatchCollection matches = Regex.Matches(fileContents, pattern);


            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    string extractedString = match.Groups[1].Value.Trim();
                    extractedStrings.Add(extractedString);
                }
            }

            // Compare csvHeaders and extractedStrings
            var extraHeaders = extractedStrings.Except(csvHeaders).ToList();

            await _metaDataRepo.DynamicTableAlteration(csvHeaders, extraHeaders, headerRow, filename);
            return;
        }


        private string GetContent(string FilePath)
        {
            string fileContent = System.IO.File.ReadAllText(FilePath);
            return fileContent;
        }
        
        private async Task fileSave(string FilePath , StringBuilder code)
        {
            await using var saveFile = new StreamWriter(FilePath);
            await saveFile.WriteAsync(code.ToString());
            return ;
        }
        private string GetFilePath(string relativePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, relativePath);
            return filePath;
        }
    }
}
