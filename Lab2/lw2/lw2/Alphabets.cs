using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw2
{
    class Alphabets
    {
        char[] cyrillic = {'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч',
                           'Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я'};
        char[] latin = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        char[] binary = { '0', '1' };

        public char[] Cyrillic { get => cyrillic; set => cyrillic = value; }
        public char[] Latin { get => latin; set => latin = value; }
        public char[] Binary { get => binary; set => binary = value; }

        public double EntropySennon(String file, char[] alf) {
            double resEntropy = 0;
            int[] count = new int[alf.Length];
            double[] probability = new double[alf.Length];
            if (alf == cyrillic || alf == latin || alf == binary){
                Console.WriteLine("Количество вхождений символа");
                for (int i = 0; i < alf.Length; i++)
                {
                    count[i] = file.ToUpper().Where(el => el == alf[i]).Count();   
                    
                    if (count[i] != 0)
                        Console.WriteLine(alf[i] + "--" + count[i]);
                }

                Console.WriteLine();
                Console.WriteLine("Вероятность вхождения символа");
                double sumProbability = 0;
                for (int i = 0; i < alf.Length; i++)    
                {
                    if (count[i] != 0)
                    {
                        probability[i] = (double)count[i] / file.Length;
                        Console.WriteLine(alf[i] + "--" + probability[i]);
                        sumProbability += probability[i];
                        resEntropy += probability[i] * Math.Log(probability[i], 2);
                    }
                }
                Console.WriteLine("Сумма вероятностей:" + sumProbability);
                

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
            return entropy * (double)N;
        }

        public double countInformationWithMistake(double entropy, int N, double p)
        {
            double q = 1 - p;
            double result = 0;
            result = -p * Math.Log(p) / Math.Log(2) - q * Math.Log(q) / Math.Log(2);
            return N * (entropy - result);
        }

    }
}
