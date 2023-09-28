using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using SimpleInjector;
using System.Web.Mvc;
using log4net.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore;
using AutoPASSL;
using AutoPASAL.Services;
using AutoPASAL;
using Microsoft.Extensions.DependencyInjection;
using AutoPASAL.IRepository;
using AutoPASSL.Repository;
using AutoPASAL.Dynamic;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession();

        //Inject DBContext
        builder.Services.AddDbContext<APASDBContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString("APASConnectionString"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
        }
        );

        builder.Services.AddCors((setup) =>
        {
            setup.AddPolicy("default", (options) =>
            {
                options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            });
        });

        // Dependency Injection  
        // 1. Create a new Simple Injector container
        var container = new SimpleInjector.Container();

        // 2. Configure (register) the container 
        container.Register<IBodyTypeService, BodyTypeService>();
        builder.Services.AddScoped<IBodyTypeService, BodyTypeService>();

        container.Register<IBrandsService, BrandsService>();
        builder.Services.AddScoped<IBrandsService, BrandsService>();

        container.Register<ICoverageService, CoverageService>();
        builder.Services.AddScoped<ICoverageService, CoverageService>();

        container.Register<IFuelTypeService, FuelTypeService>();
        builder.Services.AddScoped<IFuelTypeService, FuelTypeService>();

        container.Register<IInsuredContactService, InsuredContactService>();
        builder.Services.AddScoped<IInsuredContactService, InsuredContactService>();

        container.Register<IModelService, ModelService>();
        builder.Services.AddScoped<IModelService, ModelService>();

        container.Register<IPolicyCoverageService, PolicyCoverageService>();
        builder.Services.AddScoped<IPolicyCoverageService, PolicyCoverageService>();

        container.Register<IPolicyInsuredService, PolicyInsuredService>();
        builder.Services.AddScoped<IPolicyInsuredService, PolicyInsuredService>();
        
        container.Register<IPolicyService, PolicyService>();
        builder.Services.AddScoped<IPolicyService, PolicyService>();

        container.Register<IPolicyVehicleService, PolicyVehicleService>();
        builder.Services.AddScoped<IPolicyVehicleService, PolicyVehicleService>();
          
        container.Register<IRT_GSTService, RT_GSTService>();
        builder.Services.AddScoped<IRT_GSTService, RT_GSTService>();

        container.Register<IRT_LLPService, RT_LLPService>();
        builder.Services.AddScoped<IRT_LLPService, RT_LLPService>();

        container.Register<IRT_NCBService, RT_NCBService>();
        builder.Services.AddScoped<IRT_NCBService, RT_NCBService>();

        container.Register<IRT_ODPService, RT_ODPService>();
        builder.Services.AddScoped<IRT_ODPService, RT_ODPService>();

        container.Register<IRT_THEFTService, RT_THEFTService>();
        builder.Services.AddScoped<IRT_THEFTService, RT_THEFTService>();

        container.Register<IRT_TPCService, RT_TPCService>();
        builder.Services.AddScoped<IRT_TPCService, RT_TPCService>();

        container.Register<IRTOService, RTOService>();
        builder.Services.AddScoped<IRTOService, RTOService>();

        container.Register<ISupportingDocumentService, SupportingDocumentService>();
        builder.Services.AddScoped<ISupportingDocumentService, SupportingDocumentService>();

        container.Register<ITransmissionTypeService, TransmissionTypeService>();
        builder.Services.AddScoped<ITransmissionTypeService, TransmissionTypeService>();

        container.Register<IUploadService, UploadService>();
        builder.Services.AddScoped<IUploadService, UploadService>();

        container.Register<IVariantService, VariantService>();
        builder.Services.AddScoped<IVariantService, VariantService>();

        container.Register<IVehicleService, VehicleService>();
        builder.Services.AddScoped<IVehicleService, VehicleService>();

        container.Register<IVehicleTypeService, VehicleTypeService>();
        builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();

        container.Register<IDynamicRateTableService, DynamicRateTableService>();
        builder.Services.AddScoped<IDynamicRateTableService, DynamicRateTableService>();

        container.Register<IRatingService, RatingService>();
        builder.Services.AddScoped<IRatingService, RatingService>();//insert

        container.Register<IBodyTypeRepo, BodyTypeRepo>();
        builder.Services.AddScoped<IBodyTypeRepo, BodyTypeRepo>();

        container.Register<IBrandsRepo, BrandsRepo>();
        builder.Services.AddScoped<IBrandsRepo, BrandsRepo>();

        container.Register<ICoverageRepo, CoverageRepo>();
        builder.Services.AddScoped<ICoverageRepo, CoverageRepo>();

        container.Register<IFuelTypeRepo, FuelTypeRepo>();
        builder.Services.AddScoped<IFuelTypeRepo, FuelTypeRepo>();

        container.Register<IInsuredContactRepo, InsuredContactRepo>();
        builder.Services.AddScoped<IInsuredContactRepo, InsuredContactRepo>();

        container.Register<IMetaDataRepo, MetaDataRepo>();
        builder.Services.AddScoped<IMetaDataRepo, MetaDataRepo>();

        container.Register<IModelRepo, ModelRepo>();
        builder.Services.AddScoped<IModelRepo, ModelRepo>();

        container.Register<IPolicyCoverageRepo, PolicyCoverageRepo>();
        builder.Services.AddScoped<IPolicyCoverageRepo, PolicyCoverageRepo>();

        container.Register<IPolicyInsuredRepo, PolicyInsuredRepo>();
        builder.Services.AddScoped<IPolicyInsuredRepo, PolicyInsuredRepo>();

        container.Register<IPolicyRepo, PolicyRepo>();
        builder.Services.AddScoped<IPolicyRepo, PolicyRepo>();

        container.Register<IPolicyVehicleRepo, PolicyVehicleRepo>();
        builder.Services.AddScoped<IPolicyVehicleRepo, PolicyVehicleRepo>();

        container.Register<IRT_GSTRepo, RT_GSTRepo>();
        builder.Services.AddScoped<IRT_GSTRepo, RT_GSTRepo>();

        container.Register<IRT_LLPRepo, RT_LLPRepo>();
        builder.Services.AddScoped<IRT_LLPRepo, RT_LLPRepo>();

        container.Register<IRT_NCBRepo, RT_NCBRepo>();
        builder.Services.AddScoped<IRT_NCBRepo, RT_NCBRepo>();

        container.Register<IRT_ODPRepo, RT_ODPRepo>();
        builder.Services.AddScoped<IRT_ODPRepo, RT_ODPRepo>();

        container.Register<IRT_THEFTRepo, RT_THEFTRepo>();
        builder.Services.AddScoped<IRT_THEFTRepo, RT_THEFTRepo>();

        container.Register<IRT_TPCRepo, RT_TPCRepo>();
        builder.Services.AddScoped<IRT_TPCRepo, RT_TPCRepo>();

        container.Register<IRTORepo, RTORepo>();
        builder.Services.AddScoped<IRTORepo, RTORepo>();

        container.Register<ISupportingDocumentRepo, SupportingDocumentRepo>();
        builder.Services.AddScoped<ISupportingDocumentRepo, SupportingDocumentRepo>();

        container.Register<ITransmissionTypeRepo, TransmissionTypeRepo>();
        builder.Services.AddScoped<ITransmissionTypeRepo, TransmissionTypeRepo>();

        container.Register<IVariantRepo, VariantRepo>();
        builder.Services.AddScoped<IVariantRepo, VariantRepo>();

        container.Register<IVehicleRepo, VehicleRepo>();
        builder.Services.AddScoped<IVehicleRepo, VehicleRepo>();

        container.Register<IVehicleTypeRepo, VehicleTypeRepo>();
        builder.Services.AddScoped<IVehicleTypeRepo, VehicleTypeRepo>();

        builder.Services.AddScoped<ICSVService, CSVService>();

        builder.Services.AddScoped<IJSONService, JSONService>();

        builder.Services.AddScoped<DynamicRateTableService>();


        container.Register<ISupportingDocumentBL, SupportingDocumentBL>();
        builder.Services.AddScoped<ISupportingDocumentBL, SupportingDocumentBL>();

        container.Register<IMasterService, MasterService>();
        builder.Services.AddScoped<IMasterService, MasterService>();

        container.Register<IMasterRepo, MasterRepo>();
        builder.Services.AddScoped<IMasterRepo, MasterRepo>();




        //INSERT

        var app = builder.Build();

        var loggerFactory = app.Services.GetService<ILoggerFactory>();
        loggerFactory.AddLog4Net();
        XmlConfigurator.Configure(new FileInfo("log4net.config"));


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseSession();
        app.UseCors("default");
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}


