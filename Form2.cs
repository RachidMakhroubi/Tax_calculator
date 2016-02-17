using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpP1
{
    public partial class Form2 : Form
    {
        public Form2(string name, string adjustedGross, string amountOfTax, string amountOfHeldW2, string penalty, string federalTax,string 
            refund)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = adjustedGross;
            textBox3.Text = amountOfTax;
            textBox4.Text = amountOfHeldW2;
            textBox5.Text = penalty;
            textBox6.Text = federalTax;
            textBox7.Text = refund;
        }
    }
}
