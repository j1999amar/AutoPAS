using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IRTOService
    {
        Task<List<rto>?> GetAllRTOState();
        Task<List<rto>?> GetRTOCityByState(string state);
        Task<List<rto>?> GetRTONameByCity(string city);
        Task<List<rto>?> GetAllRTO(Guid Id);
        Task<List<rto>?> GetCity(Guid Id);
        Task<rto> AddRTO(rto rto);
        public bool IsExists(int id);
    }
}
