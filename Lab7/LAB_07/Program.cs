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

            var crypted = encode.Encode("PRIMAKOV MAKSIM NIKOLAEVICH!!", "KEY12345");
            var uncrypted = decode.Decode(crypted, "KEY12345");

            Console.WriteLine(crypted);
            Console.WriteLine(uncrypted);
        }
    }
}
