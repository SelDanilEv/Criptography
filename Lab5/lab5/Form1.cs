using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        string source = "./file.txt";
        string ecrypte1 = "./file2.txt";
        string ecrypte2 = "./file3.txt";

        string secretKey1 = "Danil";
        string secretKey2 = "Selitsky";

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        #region file
        private void WriteFile(string path, string text)
        {
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }
        }
        private string ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path,Encoding.GetEncoding(1251)))
            {
                return sr.ReadToEnd();
            }
        }
        #endregion

        #region Route
        private string RoutePermutationEncoding(string text)
        {
            string result = "";
            int n = 24, m = 32;
            char[,] table = new char[n, m];

            while (text.Length % (m * n) != 0)
            {
                text += "#";
            }

            var separatedText = Split(text, m * n);

            foreach (var txt in separatedText)
            {
                int i = 0, j = 0;

                foreach (char ch in txt)
                {
                    table[i, j] = ch;
                    j++;
                    if (j == m)
                    {
                        i++;
                        j = 0;
                    }
                    if (i == n)
                    {
                        break;
                    }
                }

                var locres = "";
                for (int k = 0; k < m; k++)
                {
                    for (int l = 0; l < n; l++)
                    {
                        result += table[l, k];
                    }
                }
                result += locres;
            }
            return result;
        }

        private string RoutePermutationDecoding(string path)
        {
            string text = ReadFromFile(path);
            string result = "";
            int n = 24, m = 32;
            char[,] table = new char[n, m];

            var separatedText = Split(text, m * n);

            foreach (var txt in separatedText)
            {
                int count = 0;
                for (int k = 0; k < m; k++)
                {
                    for (int l = 0; l < n; l++)
                    {
                        table[l, k] = txt[count];
                        count++;
                    }
                }

                var locres = "";
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        result += table[i, j];
                    }
                }

                result += locres;
            }

            return result.Replace('#', '\0');
        }
        #endregion

        #region Multiple

        private void SwapCharacters(ref string str, int poschar1, int poschar2)
        {
            var aStringBuilder = new StringBuilder(str);
            char ch1 = str[poschar1];
            char ch2 = str[poschar2];
            aStringBuilder.Remove(poschar1, 1);
            aStringBuilder.Insert(poschar1, ch2);
            aStringBuilder.Remove(poschar2, 1);
            aStringBuilder.Insert(poschar2, ch1);
            str = aStringBuilder.ToString();
        }


        private void SwapColumn(ref string str, int column1, int column2, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                SwapCharacters(ref str, i * m + column1, i * m + column2);
            }
        }

        private void SwapRow(ref string str, int row1, int row2, int n, int m)
        {
            for (int i = 0; i < m; i++)
            {
                SwapCharacters(ref str, row1 * m + i, row2 * m + i);
            }
        }

        private string MultiplePermutationEncoding(string text)
        {
            string result = "";
            int n = secretKey1.Length, m = secretKey2.Length;


            while (text.Length % (m * n) != 0)
            {
                text += "#";
            }

            var key1sorted = secretKey1.ToCharArray().OrderBy(x => x.ToString());
            var key2sorted = secretKey2.ToCharArray().OrderBy(x => x.ToString());

            var separatedText = Split(text, m * n);

            foreach (var substring in separatedText)
            {
                var localResult = substring;

                int temp = 0;
                char lastch = '`';
                var locseckey1 = secretKey1;
                foreach (var ch in key1sorted)
                {
                    if (lastch != ch)
                    {
                        SwapRow(ref localResult, locseckey1.IndexOf(ch), temp, n, m);
                        SwapCharacters(ref locseckey1, locseckey1.IndexOf(ch), temp++);
                    }
                    else
                    {
                        SwapRow(ref localResult, locseckey1.LastIndexOf(ch), temp, n, m);
                        SwapCharacters(ref locseckey1, locseckey1.LastIndexOf(ch), temp++);
                    }
                    lastch = ch;
                }

                temp = 0;
                lastch = '`';
                var locseckey2 = secretKey2;
                foreach (var ch in key2sorted)
                {
                    if (lastch != ch)
                    {
                        SwapColumn(ref localResult, locseckey2.IndexOf(ch), temp, n, m);
                        SwapCharacters(ref locseckey2, locseckey2.IndexOf(ch), temp++);
                    }
                    else
                    {
                        SwapColumn(ref localResult, locseckey2.LastIndexOf(ch), temp, n, m);
                        SwapCharacters(ref locseckey2, locseckey2.LastIndexOf(ch), temp++);
                    }
                    lastch = ch;
                }

                result += localResult;
            }

            return result;
        }
        private string MultiplePermutationDecoding(string path)
        {
            string text = ReadFromFile(path);
            string result = "";
            int n = secretKey1.Length, m = secretKey2.Length;


            while (text.Length % (m * n) != 0)
            {
                text += "#";
            }

            var key1sorted = secretKey1.ToCharArray().OrderBy(x => x.ToString());
            var key2sorted = secretKey2.ToCharArray().OrderBy(x => x.ToString());

            var separatedText = Split(text, m * n);

            foreach (var substring in separatedText)
            {
                var localResult = substring;

                int temp = 0;
                char lastch = '`';
                var locseckey1 = String.Concat(key1sorted.Where(c => key1sorted.Contains(c)));
                foreach (var ch in secretKey1)
                {
                    if (lastch != ch)
                    {
                        SwapRow(ref localResult, locseckey1.IndexOf(ch), temp, n, m);
                        SwapCharacters(ref locseckey1, locseckey1.IndexOf(ch), temp++);
                    }
                    else
                    {
                        SwapRow(ref localResult, locseckey1.LastIndexOf(ch), temp, n, m);
                        SwapCharacters(ref locseckey1, locseckey1.LastIndexOf(ch), temp++);
                    }
                    lastch = ch;
                }

                temp = 0;
                lastch = '`';
                var locseckey2 = String.Concat(key2sorted.Where(c => key2sorted.Contains(c)));
                foreach (var ch in secretKey2)
                {
                    if (lastch != ch)
                    {
                        SwapColumn(ref localResult, locseckey2.IndexOf(ch), temp, n, m);
                        SwapCharacters(ref locseckey2, locseckey2.IndexOf(ch), temp++);
                    }
                    else
                    {
                        SwapColumn(ref localResult, locseckey2.LastIndexOf(ch), temp, n, m);
                        SwapCharacters(ref locseckey2, locseckey2.LastIndexOf(ch), temp++);
                    }
                    lastch = ch;
                }

                result += localResult;
            }

            return result.Replace('#', '\0'); ;
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //получить исходный текст
        {
            textBox1.Text = ReadFromFile(source);
        }

        private void button2_Click(object sender, EventArgs e) //получить текст, зашифрованный маршрутной перестановкой
        {
            textBox1.Text = ReadFromFile(ecrypte1);
        }

        private void button3_Click(object sender, EventArgs e) //получить текст, зашифрованный множественной перестановкой
        {
            textBox2.Text = ReadFromFile(ecrypte2);
        }

        private void button4_Click(object sender, EventArgs e) //зашифровать маршрутной перестановкой
        {
            var res = RoutePermutationEncoding(textBox1.Text);
            textBox2.Text = res;
            WriteFile(ecrypte1, res);
        }

        private void button5_Click(object sender, EventArgs e) //зашифровать множественной перестановкой
        {
            var res = MultiplePermutationEncoding(textBox1.Text);
            textBox2.Text = res;
            WriteFile(ecrypte2, res);
        }

        private void button6_Click(object sender, EventArgs e) //расшифровать маршрутной перестановкой
        {
            textBox2.Text = RoutePermutationDecoding(ecrypte1);
        }

        private void button7_Click(object sender, EventArgs e) //расшифроватьмножественной перестановкой
        {
            textBox2.Text = MultiplePermutationDecoding(ecrypte2);
        }

        private void button8_Click(object sender, EventArgs e) //очистить поля
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }


    }
}
