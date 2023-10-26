using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class InsuredContactMockRepo
    {
        public async Task<List<insured>?> ReturnsInsured()
        {
            var ins = new List<insured> { };
            return ins;
        }
        public async Task<List<contact>?> ReturnsContact()
        {
            var con = new List<contact> { };
            return con;
        }
        public async Task<object> ReturnsInsuredContactByPolicyNumber()
        {
            var con = new contact { };
            var ins = new insured { };
            return ins;
        }
        public async Task<List<insured>?> ReturnsInsuredNull()
        {
            return null;
        }
        public async Task<List<contact>?> ReturnsContactNull()
        {
            return null;
        }
        public async Task<object> ReturnsInsuredContactByPolicyNumberNull()
        {
            return null;
        }
    }
}
