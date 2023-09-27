using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL
{
    public class RTOService:IRTOService
    {
        private readonly IRTORepo _rtoRepo;
        public RTOService(IRTORepo rtoRepo)
        {
            _rtoRepo = rtoRepo;
        }

        public Task<List<RTO>?> GetAllRTOState()
        {
            var rto = _rtoRepo.GetAllRTOState();
            return rto;
        }
        public Task<List<RTO>?> GetRTOCityByState(string state)
        {
            var rto = _rtoRepo.GetRTOCityByState(state);
            return rto;
        }
        public Task<List<RTO>?> GetRTONameByCity(string city)
        {
            var rto = _rtoRepo.GetRTONameByCity(city);
            return rto;
        }
        public Task<List<RTO>?> GetAllRTO(Guid Id)
        {
            var rto = _rtoRepo.GetAllRTO(Id);
            return rto;
        }
        public Task<List<RTO>?> GetCity(Guid Id)
        {
            var city = _rtoRepo.GetCity(Id);
            return city;
        }

        public Task<RTO> AddRTO(RTO rto)
        {
            return _rtoRepo.AddRTO(rto);
        
        }

        public bool IsExists(int id)
        {
            return _rtoRepo.IsExists(id);         
        }

        public Task<RTO> EditRTO(RTO rto)
        {
            return _rtoRepo.EditRTO(rto);
        }

        public bool DeleteRTO(int id)
        {
            return _rtoRepo.DeleteRTO(id);
        }
    }
}
