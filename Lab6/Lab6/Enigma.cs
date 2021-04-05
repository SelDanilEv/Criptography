﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_06
{
    public class Enigma
    {
        private static readonly string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string _rotor1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
        private static readonly string _rotor8 = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
        private static readonly string _betaRotor = "LEYJVCNIXWPBQMDRTAKZGFUHOS";
        private static readonly string[] _reflectorBDunn = { "AE", "BN", "CK", "DQ", "FU", "GY", "HW", "IJ", "LO", "MP", "RX", "SZ", "TV" };

        public string Crypt(string text, int posR, int posM, int posL)
        {
            var rotorR = new Rotor(_rotor1, posR);
            var rotorM = new Rotor(_rotor8, posM);
            var rotorL = new Rotor(_betaRotor, posL);
            var result = new StringBuilder(text.Length);
            char symbol;

            foreach (var ch in text)
            {
                if (rotorR.MoveRotor(posR))
                {
                    if (rotorM.MoveRotor(posM))
                    {
                        rotorL.MoveRotor(posL);
                    }
                }

                Console.Write(ch);

                if (ch == ' ')
                {
                    Console.Write("(space like X)");
                    symbol = rotorR[_alphabet.IndexOf('X')];
                }
                else
                {
                    symbol = rotorR[_alphabet.IndexOf(ch)];
                }
                LogToConsole(symbol);
                symbol = rotorM[_alphabet.IndexOf(symbol)];
                LogToConsole(symbol);
                symbol = rotorL[_alphabet.IndexOf(symbol)];
                LogToConsole(symbol);
                symbol = _reflectorBDunn.First(x => x.Contains(symbol)).First(x => !x.Equals(symbol));
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
            Console.Write(" => " + symbol);
        }
    }
}
