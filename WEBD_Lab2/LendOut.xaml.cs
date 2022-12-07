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
using System.Data.SqlClient;

namespace WEBD_Lab2
{
    /// <summary>
    /// Interaction logic for LendOut.xaml
    /// </summary>
    public partial class LendOut : UserControl
    {
        public LendOut()
        {
            InitializeComponent();
        }

        public int Random()
        {
            Random rand = new Random();
            int number = rand.Next();
            return number;
        }

        private void AddToDatabase(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectString = Properties.Settings.Default.connect_string;

                // Create a new connection to the database
                SqlConnection connect = new SqlConnection(connectString);
                //Open the connection
                connect.Open();
                // Going to get the randon ID number for the primary Key item
                int ID = Random();
                // Insert the Query
                string Query = "INSERT INTO Items (ID, Name, Employee_ID, Equipment, PhoneNumber) VALUES('" + ID + "', '" + txtName.Text + "', '" +
                    txtEmployee.Text + "', '" + txtDescription.Text + "', '" + txtPhone.Text + "')";
                // Pass the command into the Query / connection
                SqlCommand command = new SqlCommand(Query, connect);
                // Execute the query
                command.ExecuteNonQuery();
                // Close the connection
                connect.Close();
                // Show the query was added successfully.
                MessageBox.Show("New Item was added to the database.");
                // Emply the textboxes
                txtName.Clear();
                txtEmployee.Clear();
                txtDescription.Clear();
                txtPhone.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
