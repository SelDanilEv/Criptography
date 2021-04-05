using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lw2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //RU
            Console.WriteLine("RU");
            String textRU = "";
            Regex patternRU = new Regex(@"[А-Яа-я]");
            Alphabets alphabet = new Alphabets();
            String resultTextRU = "";
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                textRU = (sr.ReadToEnd());
                MatchCollection matches = patternRU.Matches(textRU);
                foreach (Match match in matches)
                    resultTextRU += match;
                //text = text.Replace("—", "");
                //text = text.Replace("-", "");
                //text = text.Replace(":", "");
                //text = text.Replace("«", "");
                //text = text.Replace("»", "");
                //text = text.Replace("?", "");
                //text = text.Replace("!", "");
                //text = text.Replace(".", "");
                //text = text.Replace(",", "");
                //text = text.Replace("\r\n", "");
                //text = text.Replace(" ", "");
            }

            double kirEntropy = alphabet.EntropySennon(resultTextRU, alphabet.Cyrillic);
            Console.WriteLine();
            Console.WriteLine("Энтропия русского языка по Шеннону:" + kirEntropy);
            Console.WriteLine("____________________________________");

            //BinRu
            Console.WriteLine("BIN RU");
            String textBinRu = alphabet.GetBytes(resultTextRU);
            Regex patternBin = new Regex(@"[0-1]");
            String resultTextBinRU = "";
            MatchCollection matchesBinRu = patternBin.Matches(textBinRu);
            foreach (Match match in matchesBinRu)
                resultTextBinRU += match;
            double binRuEntopy = alphabet.EntropySennon(resultTextBinRU, alphabet.Binary);
            Console.WriteLine("Энтропия bin Ru по Шеннону:" + binRuEntopy);
            Console.WriteLine("____________________________________");

            //En
            Console.WriteLine("EN");
            String textEn = "";
            Regex patternEn = new Regex(@"[A-Za-z]");
            String resultTextEn = "";
            using (StreamReader sr = new StreamReader("textEN.txt"))
            {
                textEn = (sr.ReadToEnd());
                MatchCollection matches = patternEn.Matches(textEn);
                foreach (Match match in matches)
                    resultTextEn += match;
            }

            double enEntropy = alphabet.EntropySennon(resultTextEn, alphabet.Latin);
            Console.WriteLine();
            Console.WriteLine("Энтропия английского языка по Шеннону:" + enEntropy);
            Console.WriteLine("____________________________________");

            //BinEn
            Console.WriteLine("Bin EN");
            String textBinEn = alphabet.GetBytes(resultTextEn);
            String resultTextBinEN = "";
            MatchCollection matchesBinEn = patternBin.Matches(textBinEn);
            foreach (Match match in matchesBinEn)
                resultTextBinEN += match;
            double binEnEntopy = alphabet.EntropySennon(resultTextBinEN, alphabet.Binary);
            Console.WriteLine("Энтропия bin En по Шеннону:" + binEnEntopy);
            Console.WriteLine("____________________________________");

            //В
            string myFIO = "Кравцова Диана Вячеславовна";
            string myFioEn = "Kravtsova Diana Vyacheslavovna";
            String myFIOBinRu = alphabet.GetBytes(myFIO);
            String myFIOBinEn = alphabet.GetBytes(myFioEn);
            Console.WriteLine("Количество информации RU:" + alphabet.countInf(kirEntropy, myFIO.Length));
            Console.WriteLine("Количество информации RU bin:" + alphabet.countInf(binRuEntopy, myFIOBinRu.Length));
            byte[] bytesASCIIMyRu = Encoding.ASCII.GetBytes(myFIO);
            string ASCIIMyRu = "";
            foreach (var b in bytesASCIIMyRu)
                ASCIIMyRu += b;
            Console.WriteLine("Количество информации RU ASCII:" + alphabet.countInf(binRuEntopy, ASCIIMyRu.Length));
         
            
            Console.WriteLine("Количество информации EN:" + alphabet.countInf(enEntropy, myFioEn.Length));
            Console.WriteLine("Количество информации EN bin:" + alphabet.countInf(binEnEntopy, myFIOBinEn.Length));
            byte[] bytesASCIIMyEn = Encoding.ASCII.GetBytes(myFioEn);
            string ASCIIMyEn = "";
            foreach (var b in bytesASCIIMyEn)
                ASCIIMyEn += b;
            Console.WriteLine("Количество информации EN ASCII:" + alphabet.countInf(binEnEntopy, ASCIIMyEn.Length));

            //Г 
            Console.WriteLine("RU Error 0,1: " + alphabet.countInformationWithMistake(binRuEntopy, ASCIIMyRu.Length, 0.9));
            Console.WriteLine("RU Error 0,5: " + alphabet.countInformationWithMistake(binRuEntopy, ASCIIMyRu.Length, 0.5));
            Console.WriteLine("RU Error 1: " + alphabet.countInformationWithMistake(binRuEntopy, ASCIIMyRu.Length, 1));
            Console.WriteLine("EN Error 0,1: " + alphabet.countInformationWithMistake(binEnEntopy, ASCIIMyEn.Length, 0.9));
            Console.WriteLine("EN Error 0,5: " + alphabet.countInformationWithMistake(binEnEntopy, ASCIIMyEn.Length, 0.5));
            Console.WriteLine("EN Error 1: " + alphabet.countInformationWithMistake(binEnEntopy, ASCIIMyEn.Length, 1));

            Console.ReadKey();


        }
    }
}
