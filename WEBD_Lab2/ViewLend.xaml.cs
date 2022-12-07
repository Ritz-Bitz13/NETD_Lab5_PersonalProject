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
using System.Data;
using System.Data.SqlClient;

namespace WEBD_Lab2
{
    /// <summary>
    /// Interaction logic for ViewLend.xaml
    /// </summary>
    public partial class ViewLend : UserControl
    {
        public ViewLend()
        {
            InitializeComponent();
            FillData(); // This will fun the Fill Data method and create the table for the user to view.
        }

        private void FillData()
        {
            try
            {
                // Add the datasource for easy access
                string connectstring = Properties.Settings.Default.connect_string;
                // Create a new connection
                SqlConnection connect = new SqlConnection(connectstring);
                // Open the connection
                connect.Open();
                // type of the query I want to run
                string selectAllQuery = "SELECT * FROM Items";
                // Pass command to SQL Command
                SqlCommand command = new SqlCommand(selectAllQuery, connect);

                // Retreive data from the source and get it to populate in a grid.
                SqlDataAdapter DataAdapt = new SqlDataAdapter(command);
                // Link it to items table
                DataTable table = new DataTable("Items");
                // Fill the datatable with information

                // Fill data 
                DataAdapt.Fill(table);

                // Bind the data to the table
                ItemsGrid.ItemsSource = table.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
