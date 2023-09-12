using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IMasterService
    {
        Task<List<Master>> GetAllMaster();
    }
}
