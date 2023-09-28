using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class ModelMockRepo
    {
        public async Task<List<model>> ReturnsModel()
        {
            List<model> model = new List<model> { };
            return model;
        }
        public async Task<List<model>> ReturnsNull()
        {
            return null;
        }
    }
}
