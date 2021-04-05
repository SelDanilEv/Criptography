using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_06
{
    public class Enigma
    {
        private static readonly string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string _gammaRotor = "FSOKANUERHMBTIYCWLQPZXVGJD";
        private static readonly string _rotor3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
        private static readonly string _betaRotor = "LEYJVCNIXWPBQMDRTAKZGFUHOS";
        private static readonly string[] _reflectorC = { "AF", "BV", "CP", "DJ", "EI", "GO", "HY", "KR", "LZ", "MX", "NW", "TQ", "SU" };

        public string Crypt(string text, int posR, int posM, int posL)
        {
            var rotorR = new Rotor(_betaRotor, posR);
            var rotorM = new Rotor(_rotor3, posM);
            var rotorL = new Rotor(_gammaRotor, posL);
            StringBuilder result = new StringBuilder(text.Length);

            foreach (var ch in text)
            {
                if (rotorR.MoveRotor(posR))
                {
                    if (rotorM.MoveRotor(posM))
                    {
                        rotorL.MoveRotor(posL);
                    }
                }

                Console.WriteLine(ch);

                char symbol = rotorR[_alphabet.IndexOf(ch)];
                LogToConsole(symbol);
                symbol = rotorM[_alphabet.IndexOf(symbol)];
                LogToConsole(symbol);
                symbol = rotorL[_alphabet.IndexOf(symbol)];
                LogToConsole(symbol);
                symbol = _reflectorC.First(x => x.Contains(symbol)).First(x => !x.Equals(symbol));
                LogToConsole(symbol);
                symbol = _alphabet[rotorL.IndexOf(symbol)];
                LogToConsole(symbol);
                symbol = _alphabet[rotorM.IndexOf(symbol)];
                LogToConsole(symbol);
                symbol = _alphabet[rotorR.IndexOf(symbol)];
                LogToConsole(symbol);
                Console.WriteLine();
                result.Append(symbol);
            }

            return result.ToString();
        }

        public void LogToConsole(char symbol)
        {
            Console.Write(" -> " + symbol);
        }
    }
}
