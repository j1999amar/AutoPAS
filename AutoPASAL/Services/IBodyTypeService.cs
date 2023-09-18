using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;

namespace AutoPASAL.Services
{
    public interface IBodyTypeService
    {
        Task<List<bodyType>?> GetAllBodyType();
        Task<bodyType> AddBodyType(bodyType bodyType);
        public  bool IsExists(int id);


    }
}
