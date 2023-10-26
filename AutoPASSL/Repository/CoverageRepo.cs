using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using AutoPASAL.IRepository;
using AutoPASAL.DTO_Model;
using AutoPASAL;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AutoPASSL.Repository
{
    public class CoverageRepo:ICoverageRepo
    {
        private readonly APASDBContext _context;

        public CoverageRepo(APASDBContext context)
        {
            _context = context;
        }


       
        public async Task<RT_ODP> GetODPRepo()
        {
            var RT_OD = await _context.rt_odp.FirstOrDefaultAsync(); 
            return RT_OD;
        }
        public async Task<RT_NCB> GetNCBRepo()
        {
            var RT_NCB = await _context.rt_ncb.FirstOrDefaultAsync();
            return RT_NCB;
        }
        public async Task<RT_TPC> GetTPCRepo()
        {
            var RT_TPC = await _context.rt_tpc.FirstOrDefaultAsync();
            return RT_TPC;
        }
        public async Task<RT_THEFT> GetTHEFTRepo()
        {
            var RT_THEFT = await _context.rt_theft.FirstOrDefaultAsync();
            return RT_THEFT;
        }
        public async Task<RT_GST> GetGSTRepo()
        {
            var RT_GST = await _context.rt_gst.FirstOrDefaultAsync();
            return RT_GST;
        }
       
        public async Task<List<coverages>> GetAllCoverages()
        {
            var coverages = await _context.coverages.ToListAsync();

            return coverages;
        }
        public async Task<PolicyVehicleDto> GetPolicyVehicleDetails(Guid PolicyId)
        {
            var policyVehicle = await (from p in _context.policy.AsQueryable()
                                       join pv in _context.PolicyVehicle.AsQueryable() on p.PolicyId equals pv.PolicyId
                                       join v in _context.vehicle.AsQueryable() on pv.VehicleId equals v.VehicleId
                                       where p.PolicyId == PolicyId
                                       select new PolicyVehicleDto
                                        {
                                            PolicyId = p.PolicyId,
                                            EligibleForNCB = p.EligibleForNCB,
                                            VehicleId = v.VehicleId,
                                            IDV = v.IDV,
                                            YearOfManufacture = v.YearOfManufacture,
                                            ExShowroomPrice = v.ExShowroomPrice
                                        }).FirstOrDefaultAsync();

            return policyVehicle;
        }

        public async Task<IEnumerable<PolicyCoverageDto>> GetPolicyCoverage(Guid policyId)
        {
            var policyCoverage = await (from pc in _context.policycoverage.AsQueryable()
                                        join c in _context.coverages.AsQueryable() on pc.CoverageId equals c.CoverageId
                                        where pc.PolicyId == policyId && pc.Limit == 1
                                        select new PolicyCoverageDto
                                        {
                                            PolicyId = pc.PolicyId,
                                            PolicyCoverageId = pc.PolicyCoverageId,
                                            CoverageCode = c.CovCd
                                        }).ToListAsync();
            return policyCoverage;
        }
        public async Task<PremiumFactors> GetPremiumFactors()
        {
            var rt_od = await GetODPRepo();
            var rt_ncb = await GetNCBRepo();
            var rt_tpc = await GetTPCRepo();
            var rt_theft = await GetTHEFTRepo();
            var rt_gst = await GetGSTRepo();
            return new PremiumFactors
            {
                RT_OD_Factor = rt_od.factor,
                RT_NCB_Factor = rt_ncb.factor,
                RT_TPC_Factor = rt_tpc.factor,
                RT_THEFT_Factor = rt_theft.factor,
                GST_Factor = rt_gst.factor,
            };
        }

        public async Task<coverages> AddCoverages(coverages coverages)
        {
            await _context.coverages.AddAsync(coverages);
            var coveragesIsAdded=await _context.SaveChangesAsync();
            return coveragesIsAdded > 0 ? coverages : null;
        }

        public bool IsExists(int id)
        {
            return _context.coverages.Any(x=>x.CoverageId == id);
        }

        public async Task<coverages> EditCoverage(coverages coverages)
        {
            _context.coverages.Entry(coverages).State = EntityState.Modified;
            var change = await _context.SaveChangesAsync();
            return change > 0 ? coverages : null;
        }

        public bool DeleteCoverage(int id)
        {
            var coverages = _context.coverages.Find(id);
            _context.coverages.Remove(coverages);
            var change =  _context.SaveChanges();
            return change > 0 ? true : false;
        }
    }
}
