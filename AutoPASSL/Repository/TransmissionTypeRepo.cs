using AutoPASAL.IRepository;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class TransmissionTypeRepo: ITransmissionTypeRepo
    {
        private readonly APASDBContext _context;
        public TransmissionTypeRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task<List<transmissiontype>> GetTransmissionTypes(int ModelId, int FuelId)
        {
            List<transmissiontype> transmissiontype = new List<transmissiontype>();
            var id1 = _context.modelfueltype.Where(y => y.ModelId == ModelId && y.FuelTypeId == FuelId).Select(y => y.ModelFuelTypeId);
            var id2 = _context.modelfueltypevariant.Where(x => id1.Contains(x.ModelFuelTypeId)).Select(x => x.TransmissionTypeId);
            transmissiontype = await _context.transmissiontype.Where(z => id2.Contains(z.TransmissionTypeId)).ToListAsync();
            if (transmissiontype == null) return null;
            return transmissiontype;
        }
        public async Task<List<transmissiontype>> GetAllTransmissionTypes()
        {
            List<transmissiontype> transmissiontype = new List<transmissiontype>();

            transmissiontype = await _context.transmissiontype.ToListAsync();
            if (transmissiontype == null) return null;
            return transmissiontype;
        }

        public async Task<transmissiontype> AddTransmissionType(transmissiontype transmissiontype)
        {
            await _context.transmissiontype.AddAsync(transmissiontype);
            var transmissionTypeIsAdded = await _context.SaveChangesAsync();
            return transmissionTypeIsAdded>0?transmissiontype:null;
        }

        public bool IsExists(int id)
        {
            return _context.transmissiontype.Any(x=>x.TransmissionTypeId == id);
        }

        public async Task<transmissiontype> EditTransmissionType(transmissiontype transmissiontype)
        {
            _context.transmissiontype.Entry(transmissiontype).State = EntityState.Modified;
            var change = await _context.SaveChangesAsync();
            return change > 0 ? transmissiontype : null;
        }

        public bool DeleteTransmissionType(int id)
        {
            var transmissiontype = _context.transmissiontype.Find(id);
            _context.transmissiontype.Remove(transmissiontype);
            var change =  _context.SaveChanges();
            return change > 0 ? true : false;
        }
    }
}
