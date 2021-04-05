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
            int choose = -1;
            Console.OutputEncoding = Encoding.UTF8;

            Regex patternUnicode = new Regex(@"\p{L}");
            Alphabets alphabet = new Alphabets();
            Console.WriteLine("Choose mod (1 -> 4lab, 3 -> 5lab, (2lab)default)");

            while (choose != 0)
            {
                int.TryParse(Console.ReadLine(), out choose);
                String resultText = "";
                Console.Clear();


                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Lab4");
                        String text;
                        double kirEntropy;
                        for (int i = 0; i < 3; i++)
                        {
                            resultText = "";
                            using (StreamReader sr = new StreamReader($"{i}.txt"))
                            {
                                text = (sr.ReadToEnd());
                                MatchCollection matches = patternUnicode.Matches(text);
                                foreach (Match match in matches)
                                    resultText += match;
                            }

                            kirEntropy = alphabet.EntropySennon(resultText, alphabet.Bel);
                            Console.WriteLine();
                            Console.WriteLine("Энтропия lab4 языка по Шеннону:" + kirEntropy);
                            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        }
                        break;
                    case 2:
                        break;
                    case 0:
                        break;
                    default:
                        //LT
                        Console.WriteLine("LT");
                        String textLT;
                        String resultTextLT;
                        using (StreamReader sr = new StreamReader("textLT.txt"))
                        {
                            text = (sr.ReadToEnd());
                            MatchCollection matches = patternUnicode.Matches(text);
                            foreach (Match match in matches)
                                resultText += match;
                        }

                        kirEntropy = alphabet.EntropySennon(resultText, alphabet.Litv);
                        Console.WriteLine();
                        Console.WriteLine("Энтропия литовского языка по Шеннону:" + kirEntropy);
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                        Console.WriteLine("BIN LT");
                        String textBinLt = alphabet.GetBytes(resultText);
                        Regex patternBin = new Regex(@"[0-1]");
                        String resultTextBinLT = "";
                        MatchCollection matchesBinLt = patternBin.Matches(textBinLt);
                        foreach (Match match in matchesBinLt)
                            resultTextBinLT += match;
                        double binLtEntopy = alphabet.EntropySennon(resultTextBinLT, alphabet.Binary);
                        Console.WriteLine("Энтропия bin Lt по Шеннону:" + binLtEntopy);
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                        //En
                        Console.WriteLine("MK");
                        String textMk;
                        String resultTextMk = "";
                        using (StreamReader sr = new StreamReader("textMK.txt"))
                        {
                            textMk = (sr.ReadToEnd());
                            MatchCollection matches = patternUnicode.Matches(textMk);
                            foreach (Match match in matches)
                                resultTextMk += match;
                        }

                        double enEntropy = alphabet.EntropySennon(resultTextMk, alphabet.Maken);
                        Console.WriteLine();
                        Console.WriteLine("Энтропия македонского языка по Шеннону:" + enEntropy);
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                        //BinEn
                        Console.WriteLine("Bin MK");
                        String textBinMk = alphabet.GetBytes(resultTextMk);
                        String resultTextBinMK = "";
                        MatchCollection matchesBinMk = patternBin.Matches(textBinMk);
                        foreach (Match match in matchesBinMk)
                            resultTextBinMK += match;
                        double binEnEntopy = alphabet.EntropySennon(resultTextBinMK, alphabet.Binary);
                        Console.WriteLine("Энтропия bin Mk по Шеннону:" + binEnEntopy);
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                        //В
                        string myFIOMK = "Селитски Данил Евгениевич";
                        string myFioLT = "Selitsky Danil Evgenievich";
                        String myFIOBinLt = alphabet.GetBytes(myFIOMK);
                        String myFIOBinMk = alphabet.GetBytes(myFioLT);
                        Console.WriteLine("Количество информации LT:" + alphabet.countInf(kirEntropy, myFIOMK.Length));
                        Console.WriteLine("Количество информации LT bin:" + alphabet.countInf(binLtEntopy, myFIOBinLt.Length));
                        byte[] bytesASCIIMyLt = Encoding.ASCII.GetBytes(myFIOMK);
                        string ASCIIMyLt = "";
                        foreach (var b in bytesASCIIMyLt)
                            ASCIIMyLt += b;
                        Console.WriteLine("Количество информации LT ASCII:" + alphabet.countInf(binLtEntopy, ASCIIMyLt.Length));


                        Console.WriteLine("Количество информации MK:" + alphabet.countInf(enEntropy, myFioLT.Length));
                        Console.WriteLine("Количество информации MK bin:" + alphabet.countInf(binEnEntopy, myFIOBinMk.Length));
                        byte[] bytesASCIIMyMk = Encoding.ASCII.GetBytes(myFioLT);
                        string ASCIIMyMk = "";
                        foreach (var b in bytesASCIIMyMk)
                            ASCIIMyMk += b;
                        Console.WriteLine("Количество информации MK ASCII:" + alphabet.countInf(binEnEntopy, ASCIIMyMk.Length));

                        //Г 
                        Console.WriteLine("LT Error 0,1: " + alphabet.countInformationWithMistake(binLtEntopy, ASCIIMyLt.Length, 0.9));
                        Console.WriteLine("LT Error 0,5: " + alphabet.countInformationWithMistake(binLtEntopy, ASCIIMyLt.Length, 0.5));
                        Console.WriteLine("LT Error 1: " + alphabet.countInformationWithMistake(binLtEntopy, ASCIIMyLt.Length, 1));
                        Console.WriteLine("MK Error 0,1: " + alphabet.countInformationWithMistake(binEnEntopy, ASCIIMyMk.Length, 0.9));
                        Console.WriteLine("MK Error 0,5: " + alphabet.countInformationWithMistake(binEnEntopy, ASCIIMyMk.Length, 0.5));
                        Console.WriteLine("MK Error 1: " + alphabet.countInformationWithMistake(binEnEntopy, ASCIIMyMk.Length, 1));
                        break;
                }
            Console.WriteLine("Choose mod (1 -> (2lab)default, 2 -> 4lab, 3 -> 5lab)");
            }
        }
    }
}
