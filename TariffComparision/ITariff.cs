using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparision
{
    public interface ITariff
    {
        /// <summary>
        /// Calculate the tariff with repect to the consumption.
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns> Total tariff calculated.</returns>
        decimal CalulateTariff(int consumption);
    }
}
