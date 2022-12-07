using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace HandlingExeptions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //creating a list that can house objects of type Human.
        List<Human> humans = new List<Human>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //try statement
            try
            {
             

                humans.Add(new Human(txtName.Text, int.Parse(txtAge.Text)));
                
                

            }
            //catch statement
            catch(Exception ex)
            {
                MessageBox.Show("A format exception occured:" + ex.ToString());



            }
            //finally statement - optional
            finally
            {

                txtName.Text = string.Empty;
                txtAge.Text = string.Empty;
            }

            
            
        }

    
    }
}

/*
 * Exercise:
 * Think about what would happen if txtName.Text is empty or returns null.
 * Would an exception be caught or not?
 * Make it so that a txtName.Text cannot be empty.
 * Is that validation or exception handling?
 * 
 * 
 * */
