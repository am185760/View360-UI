using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encode_Decode_Utilty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hex = "";
            string ascii = textBox1.Text;
            for (int i = 0; i < ascii.Length; i++)
            {
                char ch = ascii[i];
                int tmp = (int)ch;
                string part = tmp.ToString("X"); ;
                hex += part;
            }
            textBox2.Text = hex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String ascii = "";
            string hex = textBox1.Text;
            if (OnlyHexInString(hex))
            {
                for (int i = 0; i < hex.Length; i += 2)
                {
                    String part = hex.Substring(i, 2);
                    char ch = (char)Convert.ToInt32(part, 16); ;
                    ascii += ch;
                }
                textBox2.Text = ascii;
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }
        public bool OnlyHexInString(string test)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
