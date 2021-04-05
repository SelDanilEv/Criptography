using System;

namespace LAB_06
{
    class Program
    {
        static void Main()
        {
            var enigma = new Enigma();
            var encoded = enigma.Crypt("DANIL EVGENIVICH SELITSKY", 3, 1, 3);
            var decoded = enigma.Crypt(encoded, 3, 1, 3);
            
            Console.WriteLine($"Encoded:{encoded}\n" +
                              $"Decoded:{decoded}");
        }
    }
}
