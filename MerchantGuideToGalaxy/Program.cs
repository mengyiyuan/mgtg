using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the path to the file: ");
            string filePath = Console.ReadLine();

            //string filePath = @"C:\Temp\File3.txt";

            string[] assessmentInput = System.IO.File.ReadAllLines(filePath);

            InputFile file = new InputFile(assessmentInput);

            List<string> listOfQuestions = file.GetQuestions();

            foreach (string q in listOfQuestions)
            {
                Result r = new Result(file, q);

                Console.WriteLine(r.GetResult());
            }

            //Console.WriteLine(file.GetGalaxyUnitStringValue("blahblah"));

            //string testS = "IM";

            //RomanSymbolString test = new RomanSymbolString(testS);

            //Console.WriteLine(test.GetValue());

            Console.ReadLine();
        }
    }
}
