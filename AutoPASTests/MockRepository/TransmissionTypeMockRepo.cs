using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class TransmissionTypeMockRepo
    {
        public async Task<List<transmissiontype>> ReturnsTransmissionTypes()
        {
            List<transmissiontype> transmissiontype = new List<transmissiontype> { };
            return transmissiontype;
        }
        public async Task<List<transmissiontype>> ReturnsNull()
        {
            return null;
        }
    }
}
