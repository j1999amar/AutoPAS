using AutoPASAL.IRepository;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public class MasterService : IMasterService
    {
        private readonly IMasterRepo _masterRepo;

        public MasterService(IMasterRepo masterRepo)
        {
            _masterRepo = masterRepo;
        }
        public async Task<List<Master>> GetAllMaster()
        {
            return await _masterRepo.GetAllMaster();
        }
    }
}
