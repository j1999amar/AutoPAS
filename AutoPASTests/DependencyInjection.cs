using AutoPASAPI.Controllers;
using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySqlConnector;
using NUnit;
using NUnit.Framework;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Configuration;
using System.Web.Mvc;
using AutoPASSL;


namespace AutoPASTests
{
    public class DependencyInjection
    {
        public Container Setup()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var container = new SimpleInjector.Container();

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

            container.Register<APASDBContext>();
            builder.Services.AddScoped<APASDBContext>();

            container.Register<IPolicyBL, PolicyBL>();
            builder.Services.AddScoped<IPolicyBL, PolicyBL>();

            container.Register<IInsuredContactBL, InsuredContactBL>();
            builder.Services.AddScoped<IInsuredContactBL, InsuredContactBL>();

            container.Register<IContactBL, ContactBL>();
            builder.Services.AddScoped<IContactBL, ContactBL>();

            container.Register<IInsuredBL, InsuredBL>();
            builder.Services.AddScoped<IInsuredBL, InsuredBL>();

            container.Register<IRTOBL, RTOBL>();
            builder.Services.AddScoped<IRTOBL, RTOBL>();

            container.Register<IVehicleBL, VehicleBL>();
            builder.Services.AddScoped<IVehicleBL, VehicleBL>();

            container.Register<IVehicleTypeBL, VehicleTypeBL>();
            builder.Services.AddScoped<IVehicleTypeBL, VehicleTypeBL>();

            container.Register<IVariantBL, VariantBL>();
            builder.Services.AddScoped<IVariantBL, VariantBL>();

            container.Register<IBodyTypeBL, BodyTypeBL>();
            builder.Services.AddScoped<IBodyTypeBL, BodyTypeBL>();

            container.Register<IModelBL, ModelBL>();
            builder.Services.AddScoped<IModelBL, ModelBL>();

            container.Register<ICoveragesBL, CoveragesBL>();
            builder.Services.AddScoped<ICoveragesBL, CoveragesBL>();

            container.Register<IPolicyCoverageBL, PolicyCoverageBL>();
            builder.Services.AddScoped<IPolicyCoverageBL, PolicyCoverageBL>();

            container.Register<ITransmissionTypeBL, TransmissionTypeBL>();
            builder.Services.AddScoped<ITransmissionTypeBL, TransmissionTypeBL>();

            container.Register<IFuelTypeBL, FuelTypeBL>();
            builder.Services.AddScoped<IFuelTypeBL, FuelTypeBL>();


            return container;
        }
    }
}