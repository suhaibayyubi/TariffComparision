using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparision.Factory
{
    class TariffFactory
    {
        public ITariff GetTariff(string name, List<CalculationModel> model)
        {
            var tariffModel = model.FirstOrDefault(i => i.TariffName.ToUpper() == name.ToUpper());
            ITariff returnVal = null;
            if(name.ToUpper() == "BASIC TARIFF")
            {                
                returnVal = new BasicElectricityTraffic(tariffModel);
            }
            else if(name.ToUpper() == "PACKAGED TARIFF")
            {
                returnVal = new PackagedTariff(tariffModel);
            }

            return returnVal;
        }
    }
}
