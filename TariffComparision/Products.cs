using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparision
{
    public class TariffAnnualCost
    {
        public string TariffName { get; set; }
        public decimal AnnualCost { get; set; }
    }

    public class CalculationModel
    {
        public string TariffName { get; set; }
        public decimal BaseCostPerMonth { get; set; }
        public decimal ConsumptionCostPerkWh { get; set; }  
        
        public decimal MinimumCostPerYear { get; set; }

        public int MaxkWhLimitperYear { get; set; }
    }

    public class InputParam
    {
        public string TariffName { get; set; }

        public int Consumption { get; set; }
    }
        
        
}
