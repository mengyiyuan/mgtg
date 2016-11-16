using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy
{
    public  class RomanSymbol
    {
        private readonly Dictionary<char, int> symbolToValue = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

        private char _symbol;
        private int _value;

        public RomanSymbol(char s)
        {
            if (symbolToValue.Keys.Contains(s))
            {
                _symbol = s;
                _value = symbolToValue[s];
            }

            else
            {
                throw new ArgumentOutOfRangeException("symbol", "s", "The symbol is not recognized as a Roman Symbol");
            }
        }

        public int GetValue()
        {
            return _value;
        }
    }
}
