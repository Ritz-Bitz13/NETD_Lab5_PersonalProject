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

namespace WEBD_CarDatabase
{
    /// <summary>
    /// Interaction logic for AddCar.xaml
    /// </summary>
    public partial class AddCar : UserControl
    {
        public AddCar()
        {
            InitializeComponent();
        }

        public int random()
        {
            Random rand = new Random();
            int number = rand.Next();
            return number;
        }


        private void addCarToDatabase(object sender, RoutedEventArgs e)
        {

            try
            {
                //We added the data source to our settings in order to achieve this.
                string connectString = Properties.Settings.Default.connect_string;
                //creating a new connection.
                SqlConnection cn = new SqlConnection(connectString);
                //opening the connection
                cn.Open();
                //generating a random number to serve as our ID
                int ID = random();
                //Inserting query, this is a simple example but it is BAD! Lookup parametrized queries to avoid SQL injection: https://blog.codinghorror.com/give-me-parameterized-sql-or-give-me-death/
                string insertQuery = "INSERT INTO cars (ID, carMake, carModel, CarYear, CarDesc) VALUES('" + ID + "', '" + CarMake.Text + "', '" + CarModel.Text + "', '" + CarYear.Text + "', '" + CarDesc.Text + "')";
                //creating a new command and passing it the query + the connection.
                SqlCommand command = new SqlCommand(insertQuery, cn);
                //executing the query. 
                command.ExecuteNonQuery();
                //closing the connection (good practice).
                cn.Close();
                //Show a pop up message box if the record was added successfully.
                MessageBox.Show("Car Successfully Added to inventory.");
                //Empty everything if the record was added successfully.
                CarMake.Text = string.Empty;
                CarModel.Text = string.Empty;
                CarYear.Text = string.Empty;
                CarDesc.Text = string.Empty;







            }
            //catching any sort of exceptions that might occur.
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }




        }
    }
}

//This applicaiton could use some data validation of course.

  

/*
 * Exercise:
 * 1- Alter the table and add a new column named kilometers driven.
 * 2-Add a textbox in AddCar.xaml so that the user can enter the current mileage of the car.
 * 3-Alter the insertion query so that the current kilometers driven is also added to the database.
 * 
*/
    }
}
