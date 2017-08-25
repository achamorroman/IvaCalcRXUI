using System.Collections.Generic;
using IvaCalcReactUI.Models;

namespace IvaCalcReactUI.Services.VAT
{
    public interface IVatService
    {
        List<VatInfo> ComputeVat(double amount);
    }
}