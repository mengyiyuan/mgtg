using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy
{
    public class RomanSymbolString
    {
        private string _s;
        private int _value;

        public RomanSymbolString(string s)
        {
            _s = s;
            _value = ConvertToValue(s);
        }

        private int ConvertToValue(string s)
        {
            int value = 0;

            if (isValidString(s))
            {
                char[] allSymbols = s.ToUpper().ToArray();

                for (int i = 0; i < allSymbols.Count() - 1; i++)
                {
                    char current = allSymbols[i];
                    int currentValue = new RomanSymbol(current).GetValue();
                    char next = allSymbols[i + 1];
                    int nextValue = new RomanSymbol(next).GetValue();

                    if (currentValue >= nextValue)
                    {
                        value += currentValue;
                    }

                    else
                    {
                        value -= currentValue;
                    }

                }

                value += new RomanSymbol(allSymbols.Last()).GetValue();
            }

            else
            {
                value = -1; // invalid string has negative value
            }

            return value;
        }

        private bool isValidString(string input)
        {
            int length = input.Length;

            bool validRepeat = checkRepeatPattern(input);
            bool validSubstract = checkSubstractPattern(input);
            bool validSubstract2 = checkSubstract2(input);

            if (validRepeat && validSubstract && validSubstract2)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private bool checkRepeatPattern(string s)
        {
            int length = s.Length;
            char[] repeatable = { 'I', 'X', 'C', 'M' };

            if (length < 4)
            {
                return true;
            }

            else
            {
                for (int i = 0; i <= length - 4; i++)
                {
                    string test = s.Substring(i, 4);

                    if (test.Contains("DD") || test.Contains("LL") || test.Contains("VV"))
                    {
                        return false;
                    }

                    else
                    {
                        // Check double occrence of I, X, C, M
                        foreach (char c in repeatable)
                        {
                            int occurrences = test.Count(x => x == c);

                            if (occurrences == 4)
                            {
                                return false;
                            }
                        }
                    }

                }

                return true;
            }

            // Only accept a string of length 4
            // if 'DD', 'LL', 'VV' exist, return false

            

            

        }

        private bool checkSubstractPattern(string s)
        {
            // Rules:
            // "I" can be subtracted from "V" and "X" only
            // "X" can be subtracted from "L" and "C" only. 
            // "C" can be subtracted from "D" and "M" only. 
            // "V", "L", and "D" can never be subtracted.

            char[] input = s.ToArray();
            char[] substractable = { 'I', 'X', 'C' };

            for (int i = 0; i < s.Length - 1; i++)
            {
                char current = input[i];
                RomanSymbol currentS = new RomanSymbol(current);
                char next = input[i + 1];
                RomanSymbol nextS = new RomanSymbol(next);

                
                if (substractable.Contains(current))
                {
                    // small values can only be substracted from values <= 10 times of itself
                    if (nextS.GetValue() > currentS.GetValue() * 10)
                    {
                        return false;
                    }
                }

                else
                {
                    // "V", "L", and "D" can never be subtracted.

                    if (currentS.GetValue() < nextS.GetValue())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool checkSubstract2(string s)
        {
            int length = s.Length;

            if (length <= 2)
            {
                return true;
            }

            else
            {
                // Check substring of length 3
                for (int i = 2; i < length; i++)
                {
                    RomanSymbol current = new RomanSymbol(s[i]);
                    RomanSymbol currentMinus1 = new RomanSymbol(s[i - 1]);
                    RomanSymbol currentMinus2 = new RomanSymbol(s[i - 2]);

                    if (current.GetValue() > currentMinus1.GetValue() && current.GetValue() > currentMinus2.GetValue())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        public int GetValue()
        {
            return _value;
        }
    }
}
