﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    [Keyless]
    public class insuredContact
    {
        public contact contact { get; set; }
        public insured insured { get; set; }
    }
}
