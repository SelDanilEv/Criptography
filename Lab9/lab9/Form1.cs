using System;
using System.Collections.Generic;
using Org.BouncyCastle.Math;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int N = 8;
        int[] privateKey, publicKey;
        int n, a;
        List<int> encrypt;

        public Form1()
        {
            InitializeComponent();
        }

        int[] SuperincreasingSequence(int n)
        {
            int[] result = new int[n];
            int sum = 0;
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = sum + random.Next(1,10);
                sum += result[i];
            }
            return result;
        }

        int[] NormalSequence(int[] ss, int a, int n)
        {
            int[] result = new int[ss.Length];
            for(int i = 0;i<result.Length; i++)
            {
                result[i] = (ss[i] * a) % n;
            }
            return result;
        }

        int gcdex(int a, int b, out int x, out int y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }
            int x1, y1;
            int d1 = gcdex(b, a % b, out x1, out y1);
            x = y1;
            y = x1 - (a / b) * y1;
            return d1;
        }

        int ReverseElement(int a, int N, ref int result)
        {
            int x, y, d;
            d = gcdex(a, N, out x, out y);
            if (d != 1)
            {
                return 1;
            }
            else
            {
                if (x < 0) x = x + N;
                result = x;
                return 0;
            }
        }

        List<int> Encryption(string str, int[] publicKey, out TimeSpan time)
        {
            DateTime t = DateTime.Now;
            var binaryStr = Encoding.GetEncoding(1251).GetBytes(str).Select(s => Convert.ToString(s, 2).PadLeft(N, '0'));
            var result = new List<int>(binaryStr.Count());

            foreach(var symbol in binaryStr)
            {
                int sum = 0;
                for(int i = 0; i < symbol.Length; i++)
                {
                    if (symbol[i] == '1')
                    {
                        sum += publicKey[i];
                    }
                }
                result.Add(sum);
            }
            time = DateTime.Now - t;
            return result;
        }

        string Decryption(List<int> str, int[] privateKey, int a, int n, out TimeSpan time)
        {
            DateTime t = DateTime.Now;
            var aInverse = 0;
            ReverseElement(a, n, ref aInverse);
            var binaryStr = new List<string>();
            var symbol = new StringBuilder();

            foreach (var num in str)
            {
                int weight = (num * aInverse) % n;
                symbol.Clear();

                foreach (var keyNum in privateKey.Reverse())
                {
                    if (keyNum <= weight)
                    {
                        symbol.Insert(0, '1');
                        weight = weight - keyNum;
                    }
                    else
                    {
                        symbol.Insert(0, '0');
                    }
                }
                binaryStr.Add(symbol.ToString());
            }
            time = DateTime.Now - t;
            return Encoding.GetEncoding(1251).GetString(binaryStr.Select(s => Convert.ToByte(s, 2)).ToArray()); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan t;
            int x, y;
            privateKey = SuperincreasingSequence(N);
            for(int i = 0; i < privateKey.Length; i++)
            {
                n += privateKey[i] + 1;
            }
            for(int i = 2; i < n; i++)
            {
                if(gcdex(i, n, out x, out y) == 1)
                {
                    a = i;
                    break;
                }
            }
            publicKey = NormalSequence(privateKey, a, n);
            encrypt = Encryption(textBox1.Text, publicKey, out t);
            textBox2.Text = string.Join(", ", encrypt);
            textBox3.Text = t.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeSpan t;
            textBox2.Text = Decryption(encrypt, privateKey, a, n, out t);
            textBox4.Text = t.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
