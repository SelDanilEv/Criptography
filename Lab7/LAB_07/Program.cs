using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var encode = new DESCryptoEncode();
            var decode = new DESCryptoDecode();

            string text = "";
            var secret = "SECRET12";

            do
            {
                Console.WriteLine("\nPrint 'exit' to exit\nPrint another text to encrypt and decrypt\nPress 'ENTER' to use default text");
                text = Console.ReadLine();
                Console.Clear();

                if (text.StartsWith(" ") || text.Length == 0)
                {
                    text = "SELITSKY DANIL EVGENIVICH";
                }

                Console.WriteLine($"Original text : {text}");

                var crypted = encode.Encode(text, secret);
                Console.WriteLine($"After encoding : {crypted}");

                var decoded = decode.Decode(crypted, secret);
                Console.WriteLine($"After decoding : {decoded}");
            }
            while (text != "exit");
        }
    }
}
