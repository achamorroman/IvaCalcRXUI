using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IvaCalcReactUI.Models;

namespace IvaCalcReactUI.Services.VAT
{
    public class VatService : IVatService
    {
        private List<VatInfo> _vatInfos = new List<VatInfo>();
        private Dictionary<double, double> _vatRates = new Dictionary<double, double>();

        public VatService() { }

        public List<VatInfo> ComputeVat(double amount, int units)
        {
            var totalAmount = amount * units;

            InflateRatesDictionary(totalAmount);
            PopulateVatInfos(_vatRates);

            return _vatInfos;
        }

        private void InflateRatesDictionary(double amount)
        {
            if (_vatRates.Count > 0) _vatRates.Clear();

            _vatRates.Add((double)VatRates.General, amount);
            _vatRates.Add((double)VatRates.Reduced, amount);
            _vatRates.Add((double)VatRates.Superreduced, amount);
        }

        private void PopulateVatInfos(Dictionary<double, double> vatRates)
        {
            if (_vatInfos.Count > 0) _vatInfos.Clear();

            foreach (var vatRate in vatRates)
            {
                var vatNotIncludedInfo = new VatInfo(vatRate.Key, vatRate.Value, false);
                _vatInfos.Add(vatNotIncludedInfo);

                var vatIncludedInfo = new VatInfo(vatRate.Key, vatRate.Value, true);
                _vatInfos.Add(vatIncludedInfo);
            }
        }

    }
}
