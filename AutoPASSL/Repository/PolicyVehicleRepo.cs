using AutoPASAL.IRepository;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class PolicyVehicleRepo:IPolicyVehicleRepo
    {
        private readonly APASDBContext _context;
        public PolicyVehicleRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<PolicyVehicle> Insertpolicyvehicle(PolicyVehicle objpolicyvehicle)
        {
            await _context.PolicyVehicle.AddAsync(objpolicyvehicle);
            await _context.SaveChangesAsync();
            return objpolicyvehicle;
        }
    }
}
