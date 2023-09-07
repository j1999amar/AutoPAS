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
    public class PolicyVehicleService:IPolicyVehicleService
    {
        private readonly IPolicyVehicleRepo _policyVehicleRepo;
        public PolicyVehicleService(IPolicyVehicleRepo policyvehicleRepo)
        {
            _policyVehicleRepo = policyvehicleRepo;
        }
        public Task<PolicyVehicle> Insertpolicyvehicle(PolicyVehicle PolicyVehicle)
        {
            var pol = _policyVehicleRepo.Insertpolicyvehicle(PolicyVehicle);
            return pol;
        }
    }
}
