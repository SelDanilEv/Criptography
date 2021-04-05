using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result.Text = "";
            if ((number1.Text != null && number1.Text != "") && (number2.Text != null && number2.Text != ""))
            {
                for (int i = Convert.ToInt32(number1.Text); i > 0; i--)
                {
                    if (Convert.ToInt32(number1.Text) % i == 0)
                    {
                        if (Convert.ToInt32(number2.Text) % i == 0)
                        {
                            if(number3.Text != null && number3.Text != "")
                            {
                                if (Convert.ToInt32(number3.Text) % i == 0)
                                {
                                    result.Text = i.ToString();
                                    break;
                                }
                            }
                            else
                            {
                                result.Text = i.ToString();
                                break;
                            }
                        }
                    }
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            result.Text = "";
            int n = 0;
            List<int> Simple = new List<int>();
            List<int> Strick = new List<int>();
            List<int> Res = new List<int>();
            int num1 = 0, num2 = 0;

            if ((number1.Text != null && number1.Text != "") && (number2.Text != null && number2.Text != ""))
            {
                if (Convert.ToInt32(number1.Text) > Convert.ToInt32(number2.Text))
                {
                    num1 = Convert.ToInt32(number2.Text);
                    num2 = Convert.ToInt32(number1.Text);
                    n = (int)Math.Sqrt(num1);
                }
                else
                {
                    num1 = Convert.ToInt32(number1.Text);
                    num2 = Convert.ToInt32(number2.Text);
                    n = (int)Math.Sqrt(num2);
                }

                for (int i = 2; i <= n; i++)
                {
                    if (Strick.Contains(i)) continue;
                    Simple.Add(i);
                    for (int j = i + 1; j <= n; j++)
                        if (j % i == 0) Strick.Add(j);
                }

                for (int i = num1; i <= num2; i++)
                {
                    foreach (int num in Simple)
                        if (i % num == 0) Strick.Add(i);
                    if (Strick.Contains(i)) continue;
                    Res.Add(i);
                }

                int count = 0;

                if(num1<n)
                {
                    foreach (int i in Simple)
                        if (i >= num1)
                        {
                            result.Text += i.ToString() + ", ";
                            count++;
                        }
                }
                foreach (int i in Res)
                {
                    result.Text += i.ToString() + ", ";
                    count++;
                }

                result.Text += "Всего простых чисел в интервале: " + count;
            }    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result.Text = "";
            bool res = true;
            int num = Convert.ToInt32(number3.Text);

            if (num > 1)
            {
                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        res = false;
                        break;
                    }
                }
            }
            else res = false;

            if (res)
                result.Text += "Да";
            else result.Text += "Нет";
        }
    }
}
