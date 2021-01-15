using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparision
{
    class PackagedTariff : ITariff
    {
        private CalculationModel model;

        public PackagedTariff(CalculationModel model)
        {
            this.model = model;
        }
        public decimal CalulateTariff(int consumption)
        {           
            //Calculation
            if(consumption <= model.MaxkWhLimitperYear)
            {
                return model.MinimumCostPerYear;
            }
            return model.MinimumCostPerYear + (consumption - model.MaxkWhLimitperYear) * model.ConsumptionCostPerkWh;
        }
    }
}
