#region Comment Header
/*
    * Group Members: Martin Barber
    * Student ID's:	100368442
    * Class: NETD 3202 - 04
    * Date: Started Sept 28th, Finished October 1st.
    * File Name: Lab_1(Main Window Code)
    * GitHub: https://github.com/Ritz-Bitz13/NETD3202-Work/tree/master/Lab1_CODE_IT_INC
*/
#endregion

#region using statements
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
using System.Windows.Navigation;
using System.Windows.Shapes;
#endregion

#region Namespace
namespace Lab1_CODE_IT_INC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Variables
        private List<String> Status = new List<String>();
        string FileName;
        // Variables for messagebox to display information
        string displayProject;
        double displaybudget;
        double displaySpent;
        double displayHours;
        string displayStatus;

        // Validation to make sure everything is true before you enter it to the list.
        bool validation1 = true;
        bool validation2 = true;
        bool validation3 = true;
        bool validation4 = true;
        bool validation5 = true;
        #endregion

#region Create Project Button / Validation
        /// <summary>
        /// Once the user clicks the create button, as long as all the items in the textboxes are true, it will add it to the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Program proj = new Program();
            

            //Check project name string length
            if (txtProjectName.Text.Length >= 3)
            {
                // If name of project is 3 or more characters, save project name.
                validation1 = true;
                proj.ProjectName = this.txtProjectName.Text.Trim();
            }
            else
            {
                // If the Project name is too short, fail and alert the user.
                MessageBox.Show("Error - Project name too short, Please enter at least 3 characters.",
                    "Error - Project name");
                txtProjectName.Clear();
                txtProjectName.Focus();
                validation1 = false;
            }

            // Check Budget Textbox
            if (CheckDouble(txtBudget.Text))
            {
                // If budget is entered properly and passed validation, save info to class list
                validation2 = true;
                proj.TheBudget = Convert.ToDouble(txtBudget.Text.Trim());
            }
            else
            {
                // If budget has string characters in the textbox, fail and alert user
                MessageBox.Show("Error - Budget is not a proper number. Please try again",
                    "Error - Project Budget");
                txtBudget.Clear();
                txtBudget.Focus();
                validation2 = false;
            }

            // Check the spent textbox
            if (CheckDouble(txtSpent.Text))
            {
                // If entered correctly
                validation3 = true;
                proj.AmountSpent = Convert.ToDouble(txtSpent.Text.Trim());
            }
            else
            {
                // If Spent textbox has string characters, fail validation and notify user.
                MessageBox.Show("Error - Your input for 'spent' is not a proper number. Please try again." ,
                    "Error - Project Spent");
                txtSpent.Clear();
                txtSpent.Focus();
                validation3 = false;
            }

            // Check Hours textbox
            if (CheckDouble(txtHoursRemaining.Text))
            {
                // If hours is entered correctly, save information.
                validation4 = true;
                proj.HoursRemaining = Convert.ToDouble(txtHoursRemaining.Text.Trim());
            }
            else
            {
                // If hours txtbox has string characters show fail.
                MessageBox.Show("Error - Your hours are not a number. Please try again.",
                    "Error - Project Hours");
                txtHoursRemaining.Clear();
                txtHoursRemaining.Focus();
                validation4 = false;
                
            }

            // If combo box has nothing selected, fail and show it is blank
            if (cboStatus.Text.Length == 0)
            {
                validation5 = false;
                MessageBox.Show("Error - Status is blank, Please select one of the Status.", "Error Status");
            }
            else
            {
                // If combo box is selected save info
                validation5 = true;
                proj.ProjectStatus = cboStatus.Text.Trim();
            }

            // If all the validations pass without a false, then add the Project to the list
            if (validation1 && validation2 && validation3 && validation4 && validation5)
            {
                Program.Projects.Add(proj);
                // Clears old filename to make new filename
                FileName = "";
                FileName = proj.ProjectName;


                Status.Add(proj.ToString());
                lbxProjects.Items.Add(FileName);
                SetDefaults();
            }
            
        }
#endregion


#region Custom Functions

        /// <summary>
        /// This will set the defaults for all the Textboxes
        /// </summary>
        private void SetDefaults()
        {
            // Clear all textboxes to be ready for the next project.
            txtProjectName.Clear();
            txtBudget.Clear();
            txtSpent.Clear();
            txtHoursRemaining.Clear();
            cboStatus.Text = "";
            txtProjectName.Focus();
        }

        /// <summary>
        /// Once the user as selected and item from the list, you will be able to edit it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SelectedAnItem(object sender, EventArgs e)
        {
            if (lbxProjects.SelectedItem == null)
            {
                MessageBox.Show("Error, nothing has been selected, Please select a Project.",
                    "Error, Project Selection.");
            }
            else
            {
                string temp;
                temp = lbxProjects.SelectedItem.ToString();
                Populate(temp);
            }
            // If item is double clicked on the listbox, retrieve information and display it.

        }

        /// <summary>
        /// Populate the information for the textbox or edit button
        /// </summary>
        /// <param name="name"></param>
        private void Populate(string name)
        {
            // Looks to see if the project name exists.
            Program SelectProject = Program.Find(name);

            //THIS IS FOR THE MESSAGEBOX IF YOU DOUBLE CLICK THE FILE IN LISTBOX
            displayProject = SelectProject.ProjectName;
            displaybudget = SelectProject.TheBudget;
            displaySpent = SelectProject.AmountSpent;
            displayHours = SelectProject.HoursRemaining;
            displayStatus = SelectProject.ProjectStatus;

            // This is the messagebox that is receiving the information to display in the message box.
            MessageBox.Show(("Project Name: " + displayProject + "\nBudget: $" + String.Format("{0:n}", displaybudget) + "\nSpent: $" +
                             String.Format("{0:n}", displaySpent) + "\nHours Remaining: " + displayHours + "\nStatus: " + displayStatus), "Project Information");

        }

        /// <summary>
        /// This function checks if the number entered is a double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        #region Edit Button
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbxProjects.SelectedItem == null)
            {
                // If nothing is selected, Show an error
                MessageBox.Show("Error, Please select a project to edit.", "Error");
            }
            else
            {
                {
                    string temp;
                    temp = lbxProjects.SelectedItem.ToString();

                    // Finds the Poroject name to load information
                    Program SelectProject = Program.Find(temp);

                    // Loads the Data from the list, to go to edit page
                    EditPage window = new EditPage();
                    window.project = SelectProject.ProjectName;
                    window.budget = SelectProject.TheBudget;
                    window.spent = SelectProject.AmountSpent;
                    window.hours = SelectProject.HoursRemaining;
                    window.status = SelectProject.ProjectStatus;
                    window.ShowDialog();
                }
            }
        }
#endregion
    }
}
