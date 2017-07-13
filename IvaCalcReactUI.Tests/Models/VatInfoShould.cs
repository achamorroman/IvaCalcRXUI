using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IvaCalcReactUI.Models;


namespace IvaCalcReactUI.Tests
{
    [TestFixture]
    public class VatInfoShould
    {
        [Test]
        public void Compute_amount_with__vat_not_included()
        {
            // Given
            const double vatRate = 21;
            const double amount = 100;

            // When
            var vatInfo = new VatInfo(vatRate, amount, vatIncluded: false);

            // Then
            const double vatBase = 100;
            const double vatAmount = 21;
            const double totalAmount = 121;

            Assert.AreEqual(vatBase, vatInfo.VatBase);
            Assert.AreEqual(vatAmount, vatInfo.VatAmount);
            Assert.AreEqual(totalAmount, vatInfo.TotalAmount);
        }

        [Test]
        public void Compute_amount_with__vat_included()
        {
            // Given
            const double vatRate = 21;
            const double amount = 100;

            // When
            var vatInfo = new VatInfo(vatRate, amount, vatIncluded: true);

            // Then
            const double vatBase = 82.64;
            const double vatAmount = 17.36;
            const double totalAmount = 100;

            Assert.AreEqual(vatBase, vatInfo.VatBase);
            Assert.AreEqual(vatAmount, vatInfo.VatAmount);
            Assert.AreEqual(totalAmount, vatInfo.TotalAmount);
        }
    }
}
