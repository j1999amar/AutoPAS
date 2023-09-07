using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface ITransmissionTypeService
    {
        Task<List<transmissiontype>> GetAllTransmissionTypes();
        Task<List<transmissiontype>> GetTransmissionTypes(int ModelId, int FuelId);
    }
}
