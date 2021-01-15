using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparision
{
    public class BasicElectricityTraffic : ITariff
    {
        private CalculationModel model;
     
        public BasicElectricityTraffic(CalculationModel model)
        {
            this.model = model;
        }
        public decimal CalulateTariff(int consumption)
        {                     
            return (model.BaseCostPerMonth * 12) + consumption * model.ConsumptionCostPerkWh;
        }
    }
}
