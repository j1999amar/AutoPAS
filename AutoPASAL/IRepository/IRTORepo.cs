using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IRTORepo
    {
        Task<List<RTO>?> GetAllRTOState();
        Task<List<RTO>?> GetRTOCityByState(string state);
        Task<List<RTO>?> GetRTONameByCity(string city);
        Task<List<RTO>?> GetAllRTO(Guid Id);
        Task<List<RTO>?> GetCity(Guid Id);
        Task<RTO> AddRTO(RTO rto);
        Task<RTO> EditRTO(RTO rto);
        public bool DeleteRTO(int id);
        public bool IsExists(int id);
    }
}
