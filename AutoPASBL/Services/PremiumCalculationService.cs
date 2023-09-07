using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASBL.Services
{
    public class PremiumCalculationService
    {

        public decimal IDV { get; set; }
        public decimal RT_ODP_Factor { get; set; }
        public decimal RT_ODP_Value { get; set; }
        public decimal RT_NCB_Factor { get; set; }
        public decimal RT_NCB_Value { get; set; }
        public decimal RT_TPC_Factor { get; set; }
        public decimal RT_TPC_Value { get; set; }
        public decimal RT_THEFT_Factor { get; set; }
        public decimal RT_THEFT_Value { get; set; }
        public decimal RT_GST_Factor { get; set; }
        public decimal RT_GST_Value { get; set; }
        public decimal TotalODPremium { get; set; }
        public decimal TotalNetPremium { get; set; }
        public decimal TotalPremium { get; set; }

        public void CalculateODPremium(int isNCB)
        {

            RT_ODP_Value = IDV * RT_ODP_Factor;
            if (isNCB == 1)
            {
                RT_NCB_Value = RT_ODP_Value * RT_NCB_Factor;
            }

            TotalODPremium = RT_ODP_Value - RT_NCB_Value;
        }
        public void CalculateTPCPremium()
        {
            RT_TPC_Value = IDV * RT_TPC_Factor;
        }
        public void CalculateTHEFTPremium()
        {
            RT_THEFT_Value = IDV * RT_THEFT_Factor;
        }

        public void CalculateTotalPremium()
        {
            TotalNetPremium = TotalODPremium + RT_TPC_Value + RT_THEFT_Value;
            RT_GST_Value = TotalNetPremium * RT_GST_Factor;
            TotalPremium = TotalNetPremium + RT_GST_Value;
        }
    }
}
