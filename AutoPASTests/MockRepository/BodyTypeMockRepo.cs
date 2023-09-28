using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class BodyTypeMockRepo 
    {
        public async Task<List<bodyType>?> ReturnsBodyType()
        {
            var bodyTypes = new List<bodyType>{};
            return bodyTypes;
        }
        public async Task<List<bodyType>?> ReturnsNull()
        {
            return null;
        }
    }


}
