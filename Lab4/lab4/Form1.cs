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

namespace lab4
{
    public partial class Form1 : Form
    {

        string file = "./file.txt";
        string file2 = "./file2.txt";
        string file3 = "./file3.txt";
        int keyCaesar = 2;
        string keyWordCaesar = "інфарматыка";
        string keyWord = "Даніл";
        char[,] table = new char[8, 4];
        string alpha = alfabet.ToLower();
        char[] newAlpha = new char[32];

        const string alfabet = "АБВГДЕЁЖЗІЙКЛМНОПРСТУЎФХЦЧШЫЬЭЮЯ";

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
            using (StreamReader sr = new StreamReader(path, encoding: Encoding.GetEncoding(1251)))
            {
                return sr.ReadToEnd();
            }
        }

        private void CreateNewAlpha(string keyWord, int key)
        {
            bool findSame = false;
            key--;
            int beg = 0, current = key;
            // добавить ключевое слово в новый алфавит
            for (int i = key; i < keyWord.Length + key; i++)
            {
                for (int j = key; j < keyWord.Length + key; j++)
                {
                    if (keyWord[i - key] == newAlpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)// если повторений нету, то буква добавляется в новый алфавит
                {
                    newAlpha[current] = keyWord[i - key];
                    current++;
                }
                findSame = false;
            }

            // добавить буквы после ключевого слова
            for (int i = 0; i < alpha.Length; i++)
            {
                for (int j = 0; j < newAlpha.Length; j++)
                {
                    if (alpha[i] == newAlpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)
                {
                    newAlpha[current] = alpha[i];
                    current++;
                }
                findSame = false;
                if (current == newAlpha.Length)
                {
                    beg = i;
                    break;
                }
            }

            // добавить буквы после ключевого слова
            current = 0;
            for (int i = beg; i < alpha.Length; i++)
            {
                for (int j = 0; j < newAlpha.Length; j++)
                {
                    if (alpha[i] == newAlpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)
                {
                    newAlpha[current] = alpha[i];
                    current++;
                }
                findSame = false;
            }
        }

        private string СaesarsСipherEncryption(string path)
        {
            string text = ReadFromFile(path).ToLower();
            string res = "";
            foreach (char ch in text)
            {
                for (int i = 0; i < alpha.Length; i++)
                {
                    if (ch == alpha[i])
                    {
                        res += newAlpha[i];
                        break;
                    }
                    else if (alpha.IndexOf(ch) < 0)
                    {
                        res += ch;
                        break;
                    }
                }
            }
            return res;
        }

        private string СaesarsСipherDecription(string path)
        {
            string text = ReadFromFile(path);
            string res = "";
            foreach (char ch in text)
            {
                for (int i = 0; i < newAlpha.Length; i++)
                {
                    if (ch == newAlpha[i])
                    {
                        res += alpha[i];
                        break;
                    }
                    else if (alpha.IndexOf(ch) < 0)
                    {
                        res += ch;
                        break;
                    }
                }
            }
            return res;
        }

        private string TrisemusTableEncryption(string text)
        {
            text = text.ToLower();

            string result = "";
            keyWord = keyWord.ToLower();

            for (var i = 0; i < keyWord.Length; i++)
            {
                table[i / 4, i % 4] = keyWord[i];
            }

            char[] Alphabet = alfabet.ToLower().Except(keyWord).ToArray();

            for (var i = 0; i < Alphabet.Length; i++)
            {
                int position = i + keyWord.Length;
                table[position / 4, position % 4] = Alphabet[i];
            }

            for (var k = 0; k < text.Length; k++)
            {
                char symbol = text[k];
                // Пытаемся найти символ в таблице
                for (var i = 0; i < 8; i++)
                {
                    for (var j = 0; j < 4; j++)
                    {
                        if (symbol == table[i, j])
                        {
                            symbol = table[(i + 1) % 8, j]; // Смещаемся циклически на следующую строку таблицы и запоминаем новый символ
                            i = 8; // Завершаем цикл по строкам
                            break; // Завершаем цикл по колонкам
                        }
                    }
                }
                result += symbol;
            }
            return result;
        }

        private string TrisemusTableDecryption(string text)
        {
            text = text.ToLower();
            keyWord = keyWord.ToLower();

            string result = "";
            for (var i = 0; i < keyWord.Length; i++)
            {
                table[i / 4, i % 4] = keyWord[i];
            }

            char[] Alphabet = alfabet.ToLower().Except(keyWord).ToArray();

            for (var i = 0; i < Alphabet.Length; i++)
            {
                int position = i + keyWord.Length;
                table[position / 4, position % 4] = Alphabet[i];
            }

            for (var k = 0; k < text.Length; k++)
            {
                char symbol = text[k];
                // Пытаемся найти символ в таблице
                for (var i = 0; i < 8; i++)
                {
                    for (var j = 0; j < 4; j++)
                    {
                        if (symbol == table[i, j])
                        {
                            symbol = table[(i + 7) % 8, j]; // Смещаемся циклически на следующую строку таблицы и запоминаем новый символ
                            i = 8; // Завершаем цикл по строкам
                            break; // Завершаем цикл по колонкам
                        }
                    }
                }
                result += symbol;
            }
            return result;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += ReadFromFile(file);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            CreateNewAlpha(keyWordCaesar, keyCaesar);
            textBox2.Text += СaesarsСipherEncryption(file);
            WriteFile(file2, СaesarsСipherEncryption(file));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text += СaesarsСipherDecription(file2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += ReadFromFile(file2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text += TrisemusTableEncryption(ReadFromFile(file));
            WriteFile(file3, TrisemusTableEncryption(ReadFromFile(file)));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text += TrisemusTableDecryption(ReadFromFile(file3));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += ReadFromFile(file3);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}