using AutoPASAL.IRepository;
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
    public class RTORepo:IRTORepo
    {
        private readonly APASDBContext _context;

        public RTORepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task<List<rto>?> GetAllRTOState()
        {
            var rtos = await _context.rto.GroupBy(x => x.State).Select(g => g.OrderBy(x => x.State).FirstOrDefault()).ToListAsync();
            if (rtos == null) return null;
            return rtos;
        }
        public async Task<List<rto>?> GetRTOCityByState(string state)
        {
            var rtos = await _context.rto.Where(x => x.State.ToLower() == state.ToLower()).GroupBy(x => x.City).Select(g => g.OrderBy(x => x.City).FirstOrDefault()).ToListAsync();
            if (rtos == null) return null;
            return rtos;
        }
        public async Task<List<rto>?> GetRTONameByCity(string city)
        {
            var rtos = await _context.rto.Where(x => x.City.ToLower() == city.ToLower()).ToListAsync();
            if (rtos == null) return null;
            return rtos;
        }
        public async Task<List<rto>?> GetAllRTO(Guid Id)
        {
            var vehicle = await _context.PolicyVehicle.FirstOrDefaultAsync(x => x.PolicyId == Id);
            var vehicleid = vehicle.VehicleId;
            var veh = await _context.vehicle.FirstOrDefaultAsync(x => x.VehicleId == vehicleid);
            var rtoid = veh.RTOId;
            var rtos = await _context.rto.Where(x => x.RTOId == rtoid).ToListAsync();
            return rtos;
        }
        public async Task<List<rto>?> GetCity(Guid Id)
        {
            var vehicle = await _context.PolicyVehicle.FirstOrDefaultAsync(x => x.PolicyId == Id);
            var vehicleid = vehicle.VehicleId;
            var veh = await _context.vehicle.FirstOrDefaultAsync(x => x.VehicleId == vehicleid);
            var rtoid = veh.RTOId;
            var rtos = await _context.rto.FirstOrDefaultAsync(x => x.RTOId == rtoid);
            var state = rtos.State;
            var city = await _context.rto.Where(x => x.State == state).ToListAsync();
            var cities = city.OrderBy(x => x.RTOId == rtoid ? 0 : 1).ToList();
            return cities;
        }

        public async Task<rto> AddRTO(rto rto)
        {
            await _context.rto.AddAsync(rto);
            var rtoIsAdded=await _context.SaveChangesAsync();
            return rtoIsAdded > 0 ? rto : null;        
        }

        public bool IsExists(int id)
        {
            return _context.rto.Any(x=>x.RTOId == id);
        }

        public async Task<rto> EditRTO(rto rto)
        {
            _context.rto.Entry(rto).State = EntityState.Modified;
            var change = await _context.SaveChangesAsync();
            return change > 0 ? rto : null;
        }

        public bool DeleteRTO(int id)
        {
            var rto = _context.rto.Find(id);
            _context.rto.Remove(rto);
            var change =  _context.SaveChanges();
            return change > 0 ? true : false;
        }
    }
}
