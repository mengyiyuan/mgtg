using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy
{
    public class InputFile
    {
        private readonly string[] Metals = new string[]
        {
            "Silver",
            "Gold",
            "Iron"
        };

        private string[] _lines;

        private List<string> _questions = new List<string>();

        private Dictionary<string, double> _goodToUnitPrice = new Dictionary<string, double>();

        private Dictionary<string, char> _galaxyUnitToRomanSymbol = new Dictionary<string, char>();

        public InputFile(string[] lines)
        {
            _lines = lines;
            ProcessFile();            
        }

        private void ProcessFile()
        {
            foreach (string line in _lines)
            {
                // If there are only 3 components in the line
                // it is info about galaxy unit to roman symbol

                if (line.Split(' ').Count() == 3)
                {
                    string unit = line.Split(' ')[0];
                    char symbol = line.Split(' ')[2].ToCharArray()[0];

                    _galaxyUnitToRomanSymbol.Add(unit, symbol);
                }

                else
                {
                    if (line.Contains('?'))
                    {
                        _questions.Add(line);
                    }

                    else
                    {
                        ProcessInfo(line);
                    }
                }
            }
        }

        private void ProcessInfo(string line)
        {
            
            string good = IdentifyMetal(line);
            int price = 0;
            
            int indexOfMetalInLine = line.IndexOf(good);

            string galaxyUnitsString = line.Substring(0, indexOfMetalInLine).Trim();

            int units = GetGalaxyUnitStringValue(galaxyUnitsString);

            Int32.TryParse(Regex.Match(line, @"\d+").Value, out price);

            _goodToUnitPrice.Add(good, (double)price / units);
        }

        public string IdentifyMetal(string s)
        {
            foreach (string metal in Metals)
            {
                if (s.Contains(metal))
                {
                    return metal;
                }
            }

            return string.Empty;
        }

        public int GetGalaxyUnitStringValue(string s)
        {
            string[] units = s.Split(' ');

            string romanSymobolString = "";

            foreach (string unit in units)
            {
                if (GetGalaxyUnitRomanSymbol(unit) == '\0')
                {
                    return -1;
                }

                romanSymobolString += GetGalaxyUnitRomanSymbol(unit);
            }

            return new RomanSymbolString(romanSymobolString).GetValue();

        }

        private char GetGalaxyUnitRomanSymbol(string unit)
        {
            // If input char is not a valid unit

            if (_galaxyUnitToRomanSymbol.Keys.Contains(unit))
            {
                return _galaxyUnitToRomanSymbol[unit];
            }

            else
            {
                return '\0';
            }
            
        }

        public double GetGoodUnitCredit(string good)
        {
            return _goodToUnitPrice[good];
        }

        public List<string> GetQuestions()
        {
            return _questions;
        }
    }
}
