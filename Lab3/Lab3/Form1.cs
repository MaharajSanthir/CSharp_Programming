using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            //Clear lbl_result
            lbl_result.Text = "";

            #region Initiate: UserInput to hold user entry, AgeEx for user entry validation
            //************************************************************************************
            string UserInput = tbx_age.Text;
            Regex AgeEx = new Regex(@"^\d+$");
            #endregion

            if (AgeEx.IsMatch(UserInput)) // Check user entry is number. IF yes proceed.
            {
                #region Calculate Birthyear: Subtract age value entered from current year. Display Birthyear. 
                //*******************************************************************************************
                int Birthyear = DateTime.Now.Year - Convert.ToInt32(UserInput);
                lbl_result.Text = string.Format("Your birth year is {0}.", Birthyear);
                #endregion

                #region If the user is born between now and December 31, the year should be minus one.
                //************************************************************************************
                // Birthyear will be the previous year except on December 31.
                if (DateTime.Now.ToString("m") != "31 December")
                    lbl_result.Text += string.Format("\n\nOR\n\n{0} (If you were born between {1} - 31 December)", Birthyear - 1, DateTime.Now.ToString("m"));
                else
                    lbl_result.Text += " \n\n :) Happy Birthday! :)";
                #endregion
            }
            else // Ask user to enter number only.
                lbl_result.Text = "\n Enter only numbers for age.";
        }

        #region Code to press Enter in textbox to press calculate button without mouse click
        //**************************************************************************
        private void tbx_age_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_calculate.PerformClick();
        }
        #endregion

    }
}
