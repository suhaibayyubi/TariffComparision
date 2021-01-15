using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffComparision.Factory;

namespace TariffComparision
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestData : Hardcoded Values fro Input Parameters that are passed by user.
            List<InputParam> input = new List<InputParam>{
                new InputParam {TariffName = "Basic Tariff", Consumption = 3500},
                new InputParam {TariffName ="Packaged Tariff", Consumption = 3500},
                new InputParam {TariffName = "Basic Tariff", Consumption = 4500},
                new InputParam {TariffName ="Packaged Tariff", Consumption = 4500},
                new InputParam {TariffName = "Basic Tariff", Consumption = 6000},
                new InputParam {TariffName ="Packaged Tariff", Consumption = 6000}
            };

            // Model : Model created as per the calculation values, in real time these values will be retieved from Database or configuration.
            List<CalculationModel> calculationModel = new List<CalculationModel>()
            {
                new CalculationModel { TariffName="Basic Tariff", BaseCostPerMonth= 5, ConsumptionCostPerkWh = .22M},
                new CalculationModel {TariffName = "Packaged Tariff", MaxkWhLimitperYear = 4000, MinimumCostPerYear = 800, ConsumptionCostPerkWh = .30M}
            };

            // Logical function
            var lstAnnualCost = GetAnnualCost(input, calculationModel);                       

        }

        /// <summary>
        /// Function created to retireve the annual cost as per the tariffs.
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="models"></param>
        /// <returns>Return the list of Annual cost with Tariff in descending order.</returns>
        public static List<TariffAnnualCost> GetAnnualCost(List<InputParam> inputs, List<CalculationModel> models)
        {
            List<TariffAnnualCost> lstAnnualCost = new List<TariffAnnualCost>();
            
            //Using factory patterns, so that in future new tariff plan can be added.
            TariffFactory factory = new TariffFactory();

            foreach( var input in inputs)
            {
                var tariffCost = new TariffAnnualCost();
                ITariff tariff = factory.GetTariff(input.TariffName, models);
                
                tariffCost.TariffName = input.TariffName;
                tariffCost.AnnualCost = tariff.CalulateTariff(input.Consumption);
                
                lstAnnualCost.Add(tariffCost);
            }
            // using Lamda expression to retrieve the list in descending order of Annual cost.
            return lstAnnualCost
                    .OrderByDescending(i => i.AnnualCost)
                    .ToList();
        }
    }
}
