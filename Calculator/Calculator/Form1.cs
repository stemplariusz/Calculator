using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double wynik = 0;
        String dzialanie = "";
        bool operacja = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //cyfry
        {
            if ((textBox1.Text == "0")||(operacja))
                textBox1.Clear();

            operacja = false;
            Button bt = (Button)sender;
            if(bt.Text == ",")
            {
                if (!textBox1.Text.Contains(","))
                {
                    if (textBox1.Text == "")
                        textBox1.Text = "0";
                    textBox1.Text += bt.Text;
                }
            }
            else
                textBox1.Text += bt.Text;
        }

        private void button13_Click(object sender, EventArgs e) //działania
        {
            Button bt = (Button)sender;
            dzialanie = bt.Text;
            wynik = double.Parse(textBox1.Text);
            label1.Text = double.Parse(textBox1.Text) + " " + dzialanie;
            operacja = true;
        }

        private void button12_Click(object sender, EventArgs e) //równa się
        {
            label1.Text += " " + textBox1.Text;
            if (dzialanie == "+")
            {
                textBox1.Text = Convert.ToString(wynik + double.Parse(textBox1.Text));
            }
            if (dzialanie == "-")
            {
                textBox1.Text = Convert.ToString(wynik - double.Parse(textBox1.Text));
            }
            if (dzialanie == "/")
            {
                if (textBox1.Text == ",")
                    textBox1.Text = "0";
                if (double.Parse(textBox1.Text) == 0)
                    textBox1.Text = "Nie dziel przez zero";
                else
                {
                    textBox1.Text = Convert.ToString(wynik / double.Parse(textBox1.Text));
                }   
            }
            if (dzialanie == "*")
            {
                textBox1.Text = Convert.ToString(wynik * double.Parse(textBox1.Text));
            }

            //wynik = double.Parse(textBox1.Text);
            //label1.Text = "";
        }

        private void button16_Click(object sender, EventArgs e) //CE
        {
            textBox1.Text = "0";
            textBox1.Select();
        }

        private void button17_Click(object sender, EventArgs e) //C
        {
            textBox1.Text = "0";
            label1.Text = "";
            wynik = 0;
            textBox1.Select();
        }

        private void button18_Click(object sender, EventArgs e) //<-
        {
            if(textBox1.Text != "")
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }
    }
}
