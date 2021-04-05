using System;

namespace LAB_06
{
    class Program
    {
        static void Main()
        {
            Enigma enigma = new Enigma();
            string encoded = enigma.Crypt("PRIMAKOV", 2, 0, 0);
            Console.WriteLine(encoded);
            Console.WriteLine(enigma.Crypt(encoded, 2, 0, 0));
        }
    }
}
