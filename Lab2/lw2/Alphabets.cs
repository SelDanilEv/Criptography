using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw2
{
    class Alphabets
    {
        char[] litv = { 'A', 'Ą', 'B', 'C', 'Č', 'D', 'E', 'Ę', 'Ė', 'F', 'G', 'H', 'I', 'Į', 'Y', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'Š', 'T', 'U', 'Ų', 'Ū', 'V', 'Z', 'Ž' };
        char[] maken = { 'А', 'Б', 'В', 'Г', 'Д', 'Ѓ', 'Е', 'Ж', 'З', 'Ѕ', 'И', 'Ј', 'К', 'Л', 'Љ', 'М', 'Н', 'Њ', 'О', 'П', 'Р', 'С', 'Т', 'Ќ', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Џ', 'Ш' };
        char[] bel = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'І', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ў', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };

        char[] binary = { '0', '1' };

        public char[] Litv { get => litv; }
        public char[] Maken { get => maken; }
        public char[] Bel { get => bel; }
        public char[] Binary { get => binary; }

        public double EntropySennon(String file, char[] alf)
        {
            double resEntropy = 0;
            int[] count = new int[alf.Length+1];
            double[] probability = new double[alf.Length];
            if (alf == litv || alf == maken || alf == binary || alf == bel)
            {
                Console.WriteLine("Количество вхождений символа");
                for (int i = 0; i < alf.Length; i++)
                {
                    count[i] = file.ToUpper().Where(el => el == alf[i]).Count();

                    if (count[i] != 0)
                    {
                        probability[i] = (double)count[i] / file.Length;
                        Console.WriteLine($"{alf[i]}: {count[i]}\t=> {100 * probability[i]}%");
                        resEntropy += probability[i] * Math.Log(probability[i], 2);
                    }
                }


                count[alf.Length] = 0;
                foreach (var num in count)
                {
                    count[alf.Length] += num;
                }
                Console.WriteLine(count[alf.Length]);
            }
            return -resEntropy;
        }


        public string GetBytes(String str)
        {
            String strB = "";
            for (int i = 0; i < str.Length; i++)
            {
                strB += Convert.ToString((int)str[i], 2) + " ";
            }
            return strB;
        }


        public double countInf(double entropy, int N)
        {
            return entropy * N;
        }

        public double countInformationWithMistake(double entropy, int N, double p)
        {
            double q = 1 - p;
            double result = -p * Math.Log(p) / Math.Log(2) - q * Math.Log(q) / Math.Log(2);
            return N * (entropy - result);
        }

    }
}
