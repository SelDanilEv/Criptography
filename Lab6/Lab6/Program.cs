using System;
using System.Text;

namespace LAB_06
{
    class Program
    {
        static void Main()
        {
            var enigma = new Enigma();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('A');
            while (stringBuilder.Length < 1000000)
            {
                stringBuilder.Append(stringBuilder.ToString());
            }


            var encoded = enigma.Crypt(stringBuilder.ToString(), 3, 1, 3);

            var decoded = enigma.Crypt(encoded, 3, 1, 3);

            //Console.WriteLine($"Encoded:{encoded}\n" +
            //                  $"Is a? {encoded.Contains('A')}" +
            //                  $"Decoded:{decoded}");
            Console.WriteLine($"Is a? {encoded.Contains('A')}");
        }
    }
}
