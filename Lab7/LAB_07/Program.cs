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

            string text = "";

            text = Console.ReadLine();

            if (text.StartsWith(" ") || text.Length == 0)
            {
                text = "SELITSKY DANIL EVGENIVICH";
            }

            var encode = new DESCryptoEncode();
            var decode = new DESCryptoDecode();

            Console.WriteLine($"Original text : {text}");

            var crypted = encode.Encode(text, "SECRET");
            Console.WriteLine($"After encoding : {crypted}");

            var uncrypted = decode.Decode(crypted, "SECRET");
            Console.WriteLine($"After decoding : {uncrypted}");
        }
    }
}
