#region Comment Header
/*
    * Group Members: Martin Barber
    * Student ID's:	100368442
    * Class: NETD 3202 - 04
    * Date: Started Sept 28th, Finished October 1st.
    * File Name: Lab_1(Edit Page)
    * GitHub: https://github.com/Ritz-Bitz13/NETD3202-Work/tree/master/Lab1_CODE_IT_INC
*/
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endregion

#region NameSpace
namespace Lab1_CODE_IT_INC
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Window
    {
        public EditPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Validations and get/sets to cross pages
        bool validation2 = true;
        bool validation3 = true;
        bool validation4 = true;
        bool validation5 = true;

        public string project { get; set; }
        public double budget { get; set; }
        public double spent { get; set; }
        public double hours { get; set; }
        public string status { get; set; }
        #endregion

        #region When window open load information
        private void Window_Loading(object sender, EventArgs e)
        {
            string combo;

            this.txtEditProject.Text = project;
            this.txtEditBudget.Text = budget.ToString();
            this.txtEditSpent.Text = spent.ToString();
            this.txtEditHours.Text = hours.ToString();
            // combo box needs seperate variable to show information
            combo = status;
            this.cboEditStatus.Text = combo;
        }
        #endregion

        #region Alter Button
        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            string temp;
            temp = txtEditProject.Text;
            Program SelectProject = Program.Find(temp);


            //Project name is read only because the name wont change, its the information you want to change.
            SelectProject.ProjectName = this.txtEditProject.Text;


            // Check Budget Textbox
            if (CheckDouble(txtEditBudget.Text))
            {
                // If budget is entered properly and passed validation, save info to class list
                validation2 = true;
            }
            else
            {
                // If budget has string characters in the textbox, fail and alert user
                MessageBox.Show("Error - Budget is not a proper number. Please try again",
                    "Error - Project Budget");
                validation2 = false;
                txtEditBudget.Clear();
                txtEditBudget.Focus();
            }

            // Check the spent textbox
            if (CheckDouble(txtEditSpent.Text))
            {

                // If entered correctly
                validation3 = true;
            }
            else
            {
                // If Spent textbox has string characters, fail validation and notify user.
                MessageBox.Show("Error - Your input for 'spent' is not a proper number. Please try again.",
                    "Error - Project Spent");
                validation3 = false;
                txtEditSpent.Clear();
                txtEditSpent.Focus();
            }

            // Check Hours textbox
            if (CheckDouble(txtEditHours.Text))
            {
                // If hours is entered correctly, save information.
                validation4 = true;
            }
            else
            {
                // If hours txtbox has string characters show fail.
                MessageBox.Show("Error - Your hours are not a number. Please try again.",
                    "Error - Project Hours");
                validation4 = false;
                txtEditHours.Clear();
                txtEditHours.Focus();
            }

            // If combo box has nothing selected, fail and show it is blank
            if (cboEditStatus.Text.Length == 0)
            {
                validation5 = false;
                MessageBox.Show("Error - Status is blank, Please select one of the Status.", "Error Status");
            }
            else
            {
                // If combo box is selected save info
                validation5 = true;
            }

            if (validation2 && validation3 && validation4 && validation5)
            {
                SelectProject.TheBudget = Convert.ToDouble(txtEditBudget.Text.Trim());
                SelectProject.AmountSpent = Convert.ToDouble(txtEditSpent.Text.Trim());
                SelectProject.HoursRemaining = Convert.ToDouble(txtEditHours.Text.Trim());
                SelectProject.ProjectStatus = cboEditStatus.Text.Trim();
                this.Close();
                MessageBox.Show("Information Updated", "Updated Information");
            }
        }
        #endregion

        #region Exit Button
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Closes the page
            this.Close();
        }
        #endregion

        #region Validation CheckDouble
        public bool CheckDouble(string value)
        {
            // Variables for the validation
            bool isDouble = true;
            double tempNum;
            // Test if you can turn the input into a double
            if (double.TryParse(value, out tempNum))
            {
                // Once confirmed number works, is it above 0?
                if (tempNum > 0.0)
                {
                    // If its above zero, show its true and return the double
                    isDouble = true;
                    return isDouble;
                }
                else
                {
                    // If number is negative show false
                    isDouble = false;
                    return isDouble;
                }
            }
            else
            {
                // If there is string characters, show false.
                isDouble = false;
                return isDouble;
            }
        }
#endregion
    }
}
