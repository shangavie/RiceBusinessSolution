using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiceBusinessSolution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txt4kg.Enabled = true;
            txt2Kg.Enabled = true;
            txt1Kg.Enabled = true;

            txt4kg.Text = "";
            txt2Kg.Text = "";
            txt1Kg.Text = "";

            double weight = Convert.ToDouble(txtWeight.Text);

            if(weight >= 0.5)
            {
                if(weight-Math.Truncate(weight) == 0.5 || weight - Math.Truncate(weight) == 0)
                {
                    int weight4bags = (int)(weight / 4);

                    if (weight4bags >= 1)
                    {
                        txt4kg.Text = weight4bags.ToString();
                    }

                    int weight2bags = (int)(weight % 4.0) / 2;
                    if (weight2bags >= 1)
                    {
                        txt2Kg.Text = weight2bags.ToString();
                    }

                    double weight1bags = (weight - weight4bags * 4) - weight2bags * 2;

                    if (weight1bags == 0.5 || weight1bags == 1)
                    {
                        txt1Kg.Text = "1";
                    }
                    else if (weight1bags == 1.5)
                    {
                        txt1Kg.Text = "2";
                    }
                }
                else
                {
                    MessageBox.Show("The order is rejected");
                }
                txt4kg.Enabled = false;
                txt2Kg.Enabled = false;
                txt1Kg.Enabled = false;                
            }

        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            if(e.KeyChar == 46)
            {
                if((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
