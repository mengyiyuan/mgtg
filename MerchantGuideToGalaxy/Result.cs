using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy
{
    public class Result
    {
        private InputFile _f;
        private string _q;
        private string _a;

        public Result(InputFile f, string q)
        {
            _f = f;
            _q = q;
            _a = GetAnswer(q);
        }

        private string GetAnswer(string q)
        {
            string qHeader = "";
            string answer = "";

            if (q.Contains("how much is "))
            {
                qHeader = "how much is";

                string galaticUnits = q.Substring(qHeader.Length, q.Length - qHeader.Length - 1).Trim();
                int result = _f.GetGalaxyUnitStringValue(galaticUnits);

                if (result < 0)
                {
                    answer = "I don't know what you are asking";
                }

                else
                {
                    answer = galaticUnits + " is " + result;
                }
                
            }

            else if (q.Contains("how many Credits is "))
            {
                qHeader = "how many Credits is ";

                string metal = _f.IdentifyMetal(q);

                int units = _f.GetGalaxyUnitStringValue(q.Substring("how many Credits is ".Length, (q.IndexOf(metal) - qHeader.Length)).Trim());

                double result = _f.GetGoodUnitCredit(metal) * units;

                if (result < 0)
                {
                    answer = "I don't know what you are asking";
                }

                else
                {
                    answer = q.Substring(qHeader.Length, q.Length - qHeader.Length - 1) + "is " + result + " Credits";
                }
                
            }

            else
            {
                answer = "I don't know what you are asking";
            }

            return answer;
        }

        public string GetResult()
        {
            return _a;
        }
    }
}
