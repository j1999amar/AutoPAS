using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface ITransmissionTypeRepo
    {
        Task<List<transmissiontype>> GetAllTransmissionTypes();
        Task<List<transmissiontype>> GetTransmissionTypes(int ModelId, int FuelId);
        Task<transmissiontype> AddTransmissionType(transmissiontype transmissiontype);
        public bool IsExists(int id);
    }
}
