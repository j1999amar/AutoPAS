using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IVehicleRepo
    {
        Task<List<vehicle>> GetAllVehicles();
        Task<List<vehicle>?> GetVehicleById(Guid Id);
        Task<List<rto>?> GetAllRTOState();
        Task<List<rto>?> GetRTOCityByState(string state);
        Task<List<rto>?> GetRTONameByCity(string city);
        Task<List<Brands>> GetBrandByVehicleType(int Id);
        Task<vehicle> AddVehicle(vehicle objVehicle);
        Task<vehicle> UpdateVehicleById(Guid Id, vehicle objVehicle);


        //Customer Portal:
        Task<object> GetVehicleDetailsByPolicyNumber(int policyNumber);
    }
}
