﻿using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IPolicyInsuredRepo
    {
        Task<PolicyInsured> Insertpolicyinsured(PolicyInsured PolicyInsured);
    }
}
