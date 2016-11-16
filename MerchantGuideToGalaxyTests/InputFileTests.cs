using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantGuideToGalaxy;

namespace MerchantGuideToGalaxyTests
{
    [TestClass]
    public class InputFileTests
    {
        string[] input =
        {
            "glob is I",
            "prok is V",
            "pish is X",
            "tegj is L",
            "glob glob Silver is 34 Credits"
        };

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetGalaxyUnitStringValue_InvalidUnit_ThrowException()
        {
            InputFile f = new InputFile(input);

            f.GetGalaxyUnitStringValue("glob prok blah");
        }

        [TestMethod]
        public void GetGalaxyUnitStringValue_ValidUnitString_ReturnValue()
        {
            InputFile f = new InputFile(input);

            int actual = f.GetGalaxyUnitStringValue("glob prok");

            Assert.AreEqual(4, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExtractMetalFromLine_InvalidMetal_ThrowException()
        {
            InputFile f = new InputFile(input);

            f.ExtractMetalFromLine("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
        }

        [TestMethod]
        public void ExtractMetalFromLine_ValidMetal_ReturnMetal()
        {
            InputFile f = new InputFile(input);

            string actual = f.ExtractMetalFromLine("how many Credits is glob prok Silver ?");

            Assert.AreEqual("Silver", actual);
        }

        [TestMethod]
        public void GetGoodUnitCredit_ValidMetal_ReturnUnitPrice()
        {
            InputFile f = new InputFile(input);

            double actual = f.GetGoodUnitCredit("Silver");

            Assert.AreEqual(17, actual, 0.001);
        }
    }
}
