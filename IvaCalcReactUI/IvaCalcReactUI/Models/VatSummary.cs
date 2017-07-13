using System;
using System.Collections.Generic;

namespace IvaCalcReactUI.Models
{
    public class VatSummary
    {
        private double _amount;
        private int _units;
        private List<VatInfo> _vatInfos = new List<VatInfo>();
        private Dictionary<double, double> _vatRates = new Dictionary<double, double>();

        public VatSummary(double amount, int units)
        {
            _amount = amount;
            _units = units;

            ComputeVatInfo(_amount * _units);
        }

        private void ComputeVatInfo(double totalAmount)
        {
            InflateRatesDictionary(totalAmount);
            PopulateVatInfos(_vatRates);
        }

        public double Amount
        {
            get { return _amount; }
            set
            {
                if (_amount == value) return;
                _amount = value;
                OnVatInfoChanged();
            }
        }

        public int Units
        {
            get { return _units; }
            set
            {
                if (_units == value) return;
                _units = value;
                OnVatInfoChanged();
            }
        }

        public IEnumerable<VatInfo> VatInfos
        {
            get { return _vatInfos; }
        }

        public event EventHandler VatInfoChanged;

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

        private void InflateRatesDictionary(double amount)
        {
            if (_vatRates.Count > 0) _vatRates.Clear();

            _vatRates.Add((double)VatRates.General, amount);
            _vatRates.Add((double)VatRates.Reduced, amount);
            _vatRates.Add((double)VatRates.Superreduced, amount);
        }

        private void OnVatInfoChanged()
        {
            ComputeVatInfo(_amount * _units);
            VatInfoChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}