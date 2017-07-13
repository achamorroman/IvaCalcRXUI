using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvaCalcReactUI.Models
{
    public class VatInfo
    {

        public VatInfo(double vatRate, double amount, bool vatIncluded)
        {
            VatRate = vatRate;
            Amount = amount;
            VatIncluded = vatIncluded;
            ComputeVat();
        }

        private void ComputeVat()
        {
            if (VatIncluded)
            {
                VatBase = Math.Round(Amount / (1 + (VatRate / 100)), 2);
                VatAmount = Amount - VatBase;
            }
            else
            {
                VatBase = Amount;
                VatAmount = Math.Round(VatBase * (VatRate / 100), 2);
            }
            TotalAmount = Math.Round(VatBase + VatAmount, 2);
        }

        public double Amount { get; private set; }
        public double VatRate { get; private set; }
        public bool VatIncluded { get; private set; }
        public string VatIncludedForHumans { get { return VatIncluded ? "Si" : "No"; } }
        public double VatBase { get; private set; }
        public double VatAmount { get; private set; }
        public double TotalAmount { get; private set; }
    }
}
