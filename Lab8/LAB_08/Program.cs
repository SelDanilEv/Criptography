namespace LAB_08
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            LinearCongruentialGenerator.Seed = 324212;
            for (int i = 0; i < 5; i++)
            {
                Console.Write(Convert.ToString(LinearCongruentialGenerator.Rand(), 2));
            }

            Console.WriteLine();

            var key = new byte[] { 13, 19, 90, 92, 240 };
            string encoded,text = "Secret text";

            Console.WriteLine($"    Before encryption: {text}");
            Console.WriteLine($"    After encryption: {encoded = RC4Crypt.Crypt(text, key)}");
            Console.WriteLine($"    After decryption: {RC4Crypt.Crypt(encoded, key)}");
        }
    }
}
