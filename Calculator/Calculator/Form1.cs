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
            try
            {
                wynik = double.Parse(textBox1.Text);
                label1.Text = double.Parse(textBox1.Text) + " " + dzialanie;
                operacja = true;
            }
            catch
            {
                textBox1.Text = "0";
            }
        }

        private void button12_Click(object sender, EventArgs e) //równa się
        {
            if (label1.Text.Contains("+") || label1.Text.Contains("-") || label1.Text.Contains("*") || label1.Text.Contains("/"))
            {
                string[] split = label1.Text.Split('+','-','*','/');
                if (split[1] == "" || split[1] == "" || split[1] == "" || split[1] == "")
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
                            {
                                textBox1.Text = "Nie dziel przez zero";
                                #region Wyłączanie przycisków
                                button1.Enabled = false;
                                button2.Enabled = false;
                                button3.Enabled = false;
                                button4.Enabled = false;
                                button5.Enabled = false;
                                button6.Enabled = false;
                                button7.Enabled = false;
                                button8.Enabled = false;
                                button9.Enabled = false;
                                button10.Enabled = false;
                                button11.Enabled = false;
                                button12.Enabled = false;
                                button13.Enabled = false;
                                button14.Enabled = false;
                                button15.Enabled = false;
                                button18.Enabled = false;
                                button19.Enabled = false;
                                #endregion
                            }
                            else
                            {
                                textBox1.Text = Convert.ToString(wynik / double.Parse(textBox1.Text));
                            }
                        }
                    if (dzialanie == "*")
                        {
                            textBox1.Text = Convert.ToString(wynik * double.Parse(textBox1.Text));
                        }
                    
                    if (textBox1.Text.Contains("E") || textBox1.Text.Contains("e") || textBox1.Text.Contains("-"))
                    {
                        #region Wyłączanie przycisków
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button8.Enabled = false;
                        button9.Enabled = false;
                        button10.Enabled = false;
                        button11.Enabled = false;
                        button12.Enabled = false;
                        button13.Enabled = false;
                        button14.Enabled = false;
                        button15.Enabled = false;
                        button18.Enabled = false;
                        button19.Enabled = false;
                        #endregion
                    }
                }
                else
                {
                    label1.Text = textBox1.Text;
                    textBox1.Select();
                }
            }
            else
            {
                label1.Text = textBox1.Text;
                textBox1.Select();
            }

        }

        private void button16_Click(object sender, EventArgs e) //CE
        {
            textBox1.Text = "0";
            dzialanie = "";
            textBox1.Select();
            #region Włączanie przycisków
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            #endregion
        }

        private void button17_Click(object sender, EventArgs e) //C
        {
            textBox1.Text = "0";
            label1.Text = "";
            dzialanie = "";
            wynik = 0;
            textBox1.Select();
            #region Włączanie przycisków
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            #endregion
        }

        private void button18_Click(object sender, EventArgs e) //<-
        {
            if(textBox1.Text != "")
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }
    }
}
