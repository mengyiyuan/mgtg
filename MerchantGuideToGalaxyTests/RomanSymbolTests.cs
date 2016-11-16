using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantGuideToGalaxy;

namespace MerchantGuideToGalaxyTests
{
    [TestClass]
    public class RomanSymbolTests
    {
        [TestMethod]
        public void RomanSymbol_ValidSymbol_ReturnNumericValue()
        {
            RomanSymbol rs = new RomanSymbol('X');
            int rs_value = rs.GetValue();

            int expected = 10;

            Assert.AreEqual(rs_value, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RomanSymbol_InvalidSymbol_ThrowOutOfRangeException()
        {
            RomanSymbol rs = new RomanSymbol('A');

            int actual = rs.GetValue();
        }
    }
}
