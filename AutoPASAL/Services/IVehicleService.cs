using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IVehicleService
    {
        Task<List<vehicle>> GetAllVehicles();
        Task<List<vehicle>?> GetVehicleById(Guid Id);
        Task<List<RTO>?> GetAllRTOState();
        Task<List<RTO>?> GetRTOCityByState(string state);
        Task<List<RTO>?> GetRTONameByCity(string city);
        Task<List<Brands>> GetBrandByVehicleType(int Id);
        Task<vehicle> AddVehicle(vehicle objVehicle);
        Task<vehicle> UpdateVehicleById(Guid Id, vehicle objVehicle);
    }
}
