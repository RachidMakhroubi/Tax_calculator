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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //******************************
            try
            {
                // get the name
               string name = Convert.ToString(textBox1.Text);
          
                // get the address
                string address = Convert.ToString(textBox2.Text);

                // get the city
               
                string city = Convert.ToString(textBox3.Text);

                // get the state
                string state = Convert.ToString(comboBox1.Text);
               
                // get the zip code
                string zipCode = Convert.ToString(textBox5.Text);

                // get the social security 
                string ssn = Convert.ToString(textBox4.Text);
                /////////////////////////////////////////////////////////
                // get the number of excemption
               decimal exemp= Convert.ToDecimal(textBox6.Text);
            
                // get the gross earning
                decimal gross = Convert.ToDecimal(textBox7.Text);

                // get the federal tax wtihheld
                decimal federalTax = Convert.ToDecimal(textBox8.Text);

                // get the capital Gains/losses
                decimal capital = Convert.ToDecimal(textBox9.Text);

                // get the real estate tax
                decimal realEstate = Convert.ToDecimal(textBox10.Text);

                // get the excise tax
                decimal exciseTax = Convert.ToDecimal(textBox11.Text);

                // get the gross earning
                decimal medicalExpence = Convert.ToDecimal(textBox12.Text);

                decimal adjustedGross = 
                    (gross - (1000 * exemp)) - ((realEstate + exciseTax) * 0.25m) - (medicalExpence * 0.08m) + (capital * 0.15m);

                decimal tax= 0.0m;
                decimal penalty = 0.0m;
                decimal taxOwed = 0.0m;

                if (adjustedGross < 0 && adjustedGross > 999.99m)

                    tax = adjustedGross * 0.10m;
               
                else if (adjustedGross >= 1000.00m && adjustedGross <9999.99m )
                    tax = adjustedGross  * 0.15m;

                 else if (adjustedGross >= 10000.00m && adjustedGross <19999.99m )
                    tax = adjustedGross  * 0.20m;

                 else if (adjustedGross >= 20000.00m && adjustedGross <29999.99m )
                    tax = adjustedGross  * 0.25m;

                 else if (adjustedGross <= 30000.00m)
                   
                    
                    tax = adjustedGross  * 0.28m;
                
                // calculate the penalty

                if( tax > (federalTax * 0.9m) )
                    penalty = (tax - federalTax) * 0.10m;
                
                taxOwed = tax + penalty;

                /*if(taxOwed > 0)
                    decimal owed = taxOwed;
                else
                    decimal refund = taxOwed;


               /* if (rdoFutureValue.Checked) // future value
                {
                    decimal monthlyInvestment =
                        Convert.ToDecimal(
                            txtMonthlyInvestment.Text);
                    decimal futureValue =
                        Calculations.CalculateFutureValue(
                            monthlyInvestment,
                            monthlyInterestRate,
                            months);
                    txtFutureValue.Text =
                        String.Format("{0:c}", futureValue);
                }
                else // monthly investment
                {
                    decimal futureValue =
                        Convert.ToDecimal(txtFutureValue.Text);
                    decimal monthlyInvestment =
                        Calculations.CalculateMonthlyInvestment(
                            futureValue,
                            monthlyInterestRate,
                            months);
                    txtMonthlyInvestment.Text =
                        String.Format("{0:c}", monthlyInvestment);
                }*/
                // pass the info to the constructor
               
                Form2 form = new Form2(textBox1.Text, adjustedGross.ToString(), tax.ToString(), textBox8.Text, penalty.ToString(), 
                    taxOwed.ToString(), taxOwed.ToString());
         
                form.Show();
            }
            catch (OverflowException)
            {
                MessageBox.Show("OverflowException. Try using smaller numbers.", "Entry Error");
            }
            catch (FormatException)
            {
                MessageBox.Show("All the info are required.", "Entry Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ": " + ex.Message, "Unknown Exception");
            }




            //*************
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            result =  MessageBox.Show("Are you sure?", "Exiting", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
            else    
          
                this.textBox1.Focus();

        }
    }
}
