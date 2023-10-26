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
    public class TransmissionTypeService:ITransmissionTypeService
    {
        private readonly ITransmissionTypeRepo _transmissionTypeRepo;
        public TransmissionTypeService(ITransmissionTypeRepo transmissionTypeRepo)
        {
            _transmissionTypeRepo = transmissionTypeRepo;
        }

        public Task<transmissiontype> AddTransmissionType(transmissiontype transmissiontype)
        {
            return _transmissionTypeRepo.AddTransmissionType(transmissiontype);
        }

        public bool DeleteTransmissionType(int id)
        {
            return _transmissionTypeRepo.DeleteTransmissionType(id);
        }

        public Task<transmissiontype> EditTransmissionType(transmissiontype transmissiontype)
        {
            return _transmissionTypeRepo.EditTransmissionType(transmissiontype);
        }

        public Task<List<transmissiontype>> GetAllTransmissionTypes()
        {
            var tran= _transmissionTypeRepo.GetAllTransmissionTypes();
            return tran;
        }
        public Task<List<transmissiontype>> GetTransmissionTypes(int ModelId, int FuelId)
        {
            var tran=_transmissionTypeRepo.GetTransmissionTypes(ModelId, FuelId);
            return tran;
        }

        public bool IsExists(int id)
        {
            return _transmissionTypeRepo.IsExists(id);
        }
    }
}
