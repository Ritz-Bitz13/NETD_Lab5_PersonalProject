#region Comment Header
/*
 * Name:            Martin Barber
 * Student ID:      100368442
 * Date:            November 4th, 2022
 * File Name:       Lab3_MartinBarber
 * Description:     This Lab has you communicate back and forth with a database, when a use buys shares, it adjusts the tables / database information.
 */
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;
using TabControl = System.Windows.Controls.TabControl;
#endregion

#region Namespace & Initialize
namespace Lab3_MartinBarber
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

        List<share> sharesList = new List<share>();

 

        #endregion

        #region Create Buttom Click
        /// <summary>
        /// This will create a new buyer of shares as long as the validation checks out and there are enough shares.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {



            #region Validation
            int errorCounter = 0;
            int temp;
            try
            {
                /////////////////////////////////////////////////////////////////
                /////////////////   VALIDATE BUYER TEXT BOX   ///////////////////
                /////////////////////////////////////////////////////////////////
                if (txtBuyer.Text.Trim() == "" || txtBuyer.Text == String.Empty)
                {
                    MessageBox.Show("You need to enter the name of the Buyer", "Error - No Buyer Name");
                    errorCounter++;
                    txtBuyer.Clear();
                    txtBuyer.Focus();
                }

                if (txtBuyer.Text.Length > 1)
                {
                    // This validates to make sure there are no numbers in the textbox.
                    bool result = txtBuyer.Text.All(Char.IsLetter);
                    if (result)
                    {
                        // continue
                    }
                    else
                    {
                        // If there is no buyers name, show error
                        MessageBox.Show("Please enter a valid Name.", "Error - Buyer Name.");
                        errorCounter++;
                        txtBuyer.Clear();
                        txtBuyer.Focus();
                    }
                }

                //////////////////////////////////////////////////////////////////
                /////////////////   VALIDATE SHARES TEXT BOX   ///////////////////
                //////////////////////////////////////////////////////////////////
                if (txtShares.Text.Trim() == "" || txtShares.Text == String.Empty)
                {
                    MessageBox.Show("You need to enter the amount of shares you want to buy.", "Error - No shares amount entered.");
                    errorCounter++;
                    txtShares.Focus();
                }
                else if (txtShares.Text.Length > 0)
                {
                    // Check to make sure the shares has a number in it. 
                    bool check = int.TryParse(txtShares.Text, out temp);
                    if (check)
                    {
                        // Continue
                    }
                    else
                    {
                        // If there is anything but a number entered, show an error
                        MessageBox.Show("Error - You did not enter a number into the shares.",
                            "Error - Number of Shares.");
                        errorCounter++;
                        txtShares.Clear();
                        txtShares.Focus();
                    }
                }

                ///////////////////////////////////////////////////////
                /////////////////   VALIDATE DATE   ///////////////////
                ///////////////////////////////////////////////////////

                if (dpkDate.SelectedDate == null)
                {
                    // If the date was not selected, show an error
                    MessageBox.Show("Please select a Date the shares were purchased.", "Error - Date not selected.");
                    errorCounter++;
                }

                string share = "";

                ////////////////////////////////////////////////////////////
                /////////////////   RADIO BUTTON CHECK   ///////////////////
                ////////////////////////////////////////////////////////////
                if (rbtCommon.IsChecked == true)
                {
                    share = "common";
                }
                else
                {
                    share = "preferred";
                }
                #endregion

                #region Validation Clears, Enter information to Database
                /////////////////////////////////////////////////////////////////////
                /////////////////   AFTER VALIDATION CHECKS OUT   ///////////////////
                /////////////////////////////////////////////////////////////////////

                // If there are 0 errors in validation, go ahead with entering information into database.
                if (errorCounter == 0)
                {

                    // Make shares textbox and int so you can manipulate the number to add / subtract to tables.
                    int numShares = int.Parse(txtShares.Text);

                    // Create the connectstring
                    string connectString = Properties.Settings.Default.connect_string;
                    SqlConnection connect = new SqlConnection(connectString);
                    // Open the connection
                    connect.Open();
                    // Insert Query to set all the information to the table.
                    string insertQuery = "INSERT INTO Buyer (name, numshares, date, shareType) VALUES ('" + txtBuyer.Text + "', '" +
                                         txtShares.Text + "', '" + dpkDate.SelectedDate.ToString() + "', '" + share + "')";
                    // Run the command to implement the query.
                    SqlCommand command = new SqlCommand(insertQuery, connect);
                    command.ExecuteNonQuery();

                    // Find what shares we will be subtracting from common or preferred.

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////      COMMUNICATION ACTIVITY ADDED STUFF       /////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    string selectQuery = "";
                    if (share == "common")
                    {
                        selectQuery = "SELECT common FROM Shares";

                        // Set price, get the random day to make a random power
                        int day = (dpkDate.SelectedDate.Value.Date - new DateTime(1990, 1, 1)).Days;
                        Random rnd = new Random(day);
                        int power = rnd.Next(1, 5);
                        int price = 20; 
                        sharesList.Add(new CommonShare(txtBuyer.Text, numShares, dpkDate.SelectedDate.ToString(), share, price , power));
                        
                    }

                    else
                    {
                        selectQuery = "SELECT preferred FROM Shares"; 

                        int day = (dpkDate.SelectedDate.Value.Date - new DateTime(1990, 1, 1)).Days;
                        Random rnd = new Random(day);
                        int power = rnd.Next(6, 10);
                        int price = 40;
                        sharesList.Add(new PreferredShare(txtBuyer.Text, numShares, dpkDate.SelectedDate.ToString(), share, price, power));
                    }
                    DataGridView.Items.Add(sharesList);

                    // Implement the select statement to get the number of shares available in the proper table
                    SqlCommand secondCommand = new SqlCommand(selectQuery, connect);

                    // Subtract the shares being purchased from the main table.
                    int availableShares = Convert.ToInt32(secondCommand.ExecuteScalar());
                    availableShares = availableShares - numShares;
                    // If there are more shares trying to be purchsed than what is available. Fail.
                    if (availableShares < 0)
                    {
                        MessageBox.Show("Sorry we do not have that many shares available for purchase.",
                            "Error Shares Available.");
                    }
                    else
                    {
                        // If there is more than enough shares available. Update the table and set the new number of available shares.
                        string updateQuery = "";
                        if (share == "common")
                        {
                            // if the shares being purchased are common
                            updateQuery = "UPDATE Shares SET common = '" + availableShares + "' ";
                            SqlCommand thirdcommand = new SqlCommand(updateQuery, connect);
                            thirdcommand.ExecuteScalar();
                        }
                        else
                        {
                            // if the shares being purchased are preferred
                            updateQuery = "UPDATE Shares SET preferred = '" + availableShares + "' ";
                            SqlCommand thirdcommand = new SqlCommand(updateQuery, connect);
                            thirdcommand.ExecuteScalar();
                        }

                        // Show the shares were successfully bought, and clear all the textboxes
                        MessageBox.Show("Shares successfully purchased.", "Shares Purchased.");
                        txtBuyer.Text = String.Empty;
                        txtShares.Text = String.Empty;
                        dpkDate.SelectedDate = null;
                        txtBuyer.Focus();

                        connect.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
        #endregion
        #endregion

        #region Tab Control Selection Changed
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tab = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            switch (tab)
            {
                #region View Summary Selected
                case "View Summary":

                    try
                    {

                        // Get the amount of common shares purchased in total.
                        string connectString = Properties.Settings.Default.connect_string;
                        SqlConnection connect = new SqlConnection(connectString);
                        connect.Open();
                        string getCommonSharesSoldQuery = "SELECT SUM(numshares) FROM Buyer WHERE shareType = 'common'";
                        SqlCommand fourthCommand = new SqlCommand(getCommonSharesSoldQuery, connect);
                        int soldCommonShares = Convert.ToInt32(fourthCommand.ExecuteScalar());
                        txtCommonShares.Text = soldCommonShares.ToString();


                        // Get the amount of preferred shares purchased in total.
                        string getPrefSharesSoldQuery = "SELECT SUM(numshares) FROM Buyer WHERE shareType = 'preferred'";
                        SqlCommand fifthCommand = new SqlCommand(getPrefSharesSoldQuery, connect);
                        int soldPrefShares = Convert.ToInt32(fifthCommand.ExecuteScalar());
                        txtPreferredShares.Text = soldPrefShares.ToString();

                        // Get the revenue
                        int revenue = (soldCommonShares * 20) + (soldPrefShares * 40);
                        txtRevenue.Text = "$"+ revenue.ToString();

                        // Get how many common shares are remaining
                        string getRemainingCommonSharesQuery = "SELECT common FROM Shares";
                        SqlCommand sixthCommand = new SqlCommand(getRemainingCommonSharesQuery, connect);
                        int remainingCommon = Convert.ToInt32(sixthCommand.ExecuteScalar());
                        txtCommonAvailable.Text = remainingCommon.ToString();

                        // Get how many Preferred shares are remaining
                        string getRemainingPrefSharesQuery = "SELECT preferred FROM Shares";
                        SqlCommand seventhCommand = new SqlCommand(getRemainingPrefSharesQuery, connect);
                        int remainingPref = Convert.ToInt32(seventhCommand.ExecuteScalar());
                        txtPreferredAvailable.Text = remainingPref.ToString();

                        connect.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
                #endregion

                #region View Entries Selected
                case "View Entries":
                    // This will get all the data from the table Buyer and show it in a table.
                    FillData();

                    break;


                case "View Objects":

                    break;
            }
        }
        #endregion
        #endregion

        #region Fill DataTable
        private void FillData()
        {
            try
            {
                // Connect to database, open connection, get all information from Buyer table
                string connectString = Properties.Settings.Default.connect_string;
                SqlConnection connect = new SqlConnection(connectString);
                connect.Open();
                string selectAllQuery = "SELECT * FROM Buyer";
                SqlCommand selectAllCommand = new SqlCommand(selectAllQuery, connect);
                SqlDataAdapter dataAdapt = new SqlDataAdapter(selectAllCommand);
                DataTable table = new DataTable("Buyer");

                // fill information into table
                dataAdapt.Fill(table);

                // show the data in the table
                Output.ItemsSource = table.DefaultView;
            }
            catch (Exception e)
            {
                // If there is an error, show it in messagebox
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        private void FillObject()
        {
            
        }

     

        #endregion
    }
}
