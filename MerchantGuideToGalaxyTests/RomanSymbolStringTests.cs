using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantGuideToGalaxy;

namespace MerchantGuideToGalaxyTests
{
    [TestClass]
    public class RomanSymbolStringTests
    {
        [TestMethod]
        public void CheckRepeatPattern_DLVRepeat_ReturnFalse()
        {
            RomanSymbolString rms = new RomanSymbolString("DLVVVDLVLLDDD");

            bool valid = rms.checkRepeatPattern();

            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void CheckRepeatPattern_NoDLVRepeatLengthLessThan4_ReturnTrue()
        {
            RomanSymbolString rms = new RomanSymbolString("XVM");

            bool valid = rms.checkRepeatPattern();

            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void CheckRepeatPattern_IXCMInvalidRepeatLengthMoreThan4_ReturnFalse()
        {
            RomanSymbolString rms = new RomanSymbolString("IIIXXXICCCCIIMMMM");

            bool valid = rms.checkRepeatPattern();

            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void CheckRepeatPattern_IXCMValidRepeatLengthMoreThan4_ReturnTrue()
        {
            RomanSymbolString rms = new RomanSymbolString("XXXIX");

            bool valid = rms.checkRepeatPattern();

            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void CheckSubstractPattern_IXCSubstractFromIncorrectSymbols_ReturnFalse()
        {
            RomanSymbolString rms = new RomanSymbolString("ILD");

            bool valid = rms.checkSubstractPattern();

            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void CheckSubstractPattern_VLDSubstracted_ReturnFalse()
        {
            RomanSymbolString rms = new RomanSymbolString("VXLCD");

            bool valid = rms.checkSubstractPattern();

            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void CheckSubstractPattern_ValidSubstration_ReturnTrue()
        {
            RomanSymbolString rms = new RomanSymbolString("IVIXXLXCCDCM");

            bool valid = rms.checkSubstractPattern();

            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void CheckSubstractSingleSymbol_LengthLessThan2_ReturnTrue()
        {
            RomanSymbolString rms = new RomanSymbolString("IV");

            bool valid = rms.checkSubstractPattern();

            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void CheckSubstractSingleSymbol_LengthMoreThan2SubstractMoreThan2Symbols_ReturnFalse()
        {
            RomanSymbolString rms = new RomanSymbolString("IVXLCDM");

            bool valid = rms.checkSubstractPattern();

            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void CheckSubstractSingleSymbol_LengthMoreThan2SubstractSingleSymbol_ReturnTrue()
        {
            RomanSymbolString rms = new RomanSymbolString("IMVC");

            bool valid = rms.checkSubstractSingleSymbol();

            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void GetValue_InvalidString_ReturnMinus1()
        {
            RomanSymbolString rms = new RomanSymbolString("IVXLCDM");

            int actual = rms.GetValue();

            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void GetValue_ValidString_ReturnConvertedValue()
        {
            RomanSymbolString rms = new RomanSymbolString("MCMIII");

            int actual = rms.GetValue();

            Assert.AreEqual(1903, actual);
        }
    }
}
