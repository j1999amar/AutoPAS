using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;

namespace AutoPASAL.IRepository
{
    public interface IBodyTypeRepo
    {
        Task<List<bodyType>?> GetAllBodyType();
    }
}
