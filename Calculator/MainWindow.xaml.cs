/* Author Alaadin Addas 
 * A simple calculator applicaion to test out the 
 * grid layout and the stack panel! With some mistakes just for fun, for you to fix. 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    /* I kind of just left this here in the first class and did not explain it 
     * (I did not want you to drop the class right away).
     * Note public 'partial' class.
     * This keyword is used to split the functionality of methods, 
     * interfaces, or structure into multiple files. 
     * MainWindow: Window means we are inheriting from 
     * the Window class which gives us some features. 
     * To read more about it:
     * https://docs.microsoft.com/en-us/dotnet/api/system.windows.window?view=netcore-3.1
     *By the way public partial class MainWindow: Window is 
     *generated automatically.
     */
    public partial class MainWindow : Window
    {
       //public MainWindow initiates the window and launches it essentially.
        public MainWindow()
        {
            InitializeComponent();
        }
        //now we start with our custom code. if the button one is clicked
        //display one in the text box. We do this for all ten numeric buttons.
        private void one_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 1;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 2;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 3;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 4;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 5;
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 6;

        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 7;
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 8;
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 9;
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text += 0;
        }
        //if any of the operation buttons are clicked display 
        //them in the text box as well. We do this for every single
        //operation button (+, -, *, /, ^2, ^).
        private void add_Click(object sender, RoutedEventArgs e)
        {
            string plus = "+";
            displayBox.Text +=  plus;
        }

        private void subtract_Click(object sender, RoutedEventArgs e)
        {
            string minus = "-";
            displayBox.Text += minus;
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            string multiply = "*";
            displayBox.Text += multiply;

        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            string divide = "/";
            displayBox.Text += divide;
        }

        private void square_Click(object sender, RoutedEventArgs e)
        {
            string square = "^2";
            displayBox.Text += square;
        }

        private void exponent_Click(object sender, RoutedEventArgs e)
        {
            string exponent = "^";
            displayBox.Text += exponent;
        }
        //What should we do when the fraction is clicked?

        private void fraction_click(object sender, RoutedEventArgs e)
        {

            Fraction firstFraction = new Fraction(1,2);

            displayBox.Text = firstFraction.ToString();


        }
        //If the equals button is clicked, now we actually need to
        //do some work.
        private void equals_Click(object sender, RoutedEventArgs e)
        {

            //string operation is used to store the operation.
            //remember the text box contains one large string.
            //we need to extract the left hand side number the operation
            //and the right hand side number. To be clear don't say 
            //left hand side number and right hand side number. They
            //are called operands I am just being really specific to make
            //sure everyone understands me.
            string operation;
            //leftNumber is the first operand.
            double leftNumber;
            //right number is the second operand.
            double rightNumber;
            //We also need to store the location of the operator within
            //the string. I will explain why shortly.
            int operatorLocation = 0;
            //But first, I want to check if the text box has anything in it.
            if (displayBox.Text != null)
            {
                //If the + sign is contained in the string of text that is
                //in the display box.
                if (displayBox.Text.Contains("+"))
                {
                    //Then note that operatorLocation (so we can extract the
                    //operands and the operator later).
                    operatorLocation = displayBox.Text.IndexOf("+");
                } else if (displayBox.Text.Contains("-"))
                {
                    operatorLocation = displayBox.Text.IndexOf("-");
                    
                } else if (displayBox.Text.Contains("*"))
                {
                    operatorLocation = displayBox.Text.IndexOf("*");

                } else if (displayBox.Text.Contains("/"))
                {
                    operatorLocation = displayBox.Text.IndexOf("/");

                } else if (displayBox.Text.Contains("^2"))
                {
                    operatorLocation = displayBox.Text.IndexOf("^2");

                } else if (displayBox.Text.Contains("^"))
                {

                    operatorLocation = displayBox.Text.IndexOf("^");
                }
                //If there is no operation, then tell the user! 
                else
                {


                    displayBox.Clear();
                    displayBox.Text = "You must enter an operator!";

                }
                //Here is where things get a little dicey.
                //We need a string variable to hold the operation we want
                //to perform. So we use the .Substring property of the textbox,
                //and input the location of the operation which we found earlier.
                //The operation is of length 1, that is why we input:
                //.Substring(1, operatorLocation);
                operation = displayBox.Text.Substring(1, operatorLocation);
              
                //The left hand side operand is going to start at position zero
                //until the operator location.

                
                leftNumber = Convert.ToDouble(displayBox.Text.Substring(0, operatorLocation));
                //The right hand side operand is going to start after the operatorLocation
                //hence operatorLocation+1, and will end as follows
        


                rightNumber = Convert.ToDouble(displayBox.Text.Substring(operatorLocation + 1, displayBox.Text.Length - operatorLocation - 1));
                
                
                if (operation == "+")
                {

                    displayBox.Text += "=" + (leftNumber + rightNumber);
                }
                else if (operation == "-")
                {

                    displayBox.Text += "=" + (leftNumber - rightNumber);
                }
                else if (operation == "*")
                {

                    displayBox.Text += "=" + (leftNumber * rightNumber);
                }
                else if (operation == "/")
                {
                    if (rightNumber != 0)
                    {

                        displayBox.Text += "=" + (leftNumber / rightNumber);
                    }
                    else
                    {
                        displayBox.Clear();
                        displayBox.Text = "Denominator cannot be zero!";
                    }
                }
                else if (operation == "^2")
                {

                    displayBox.Text += "=" + (leftNumber * leftNumber);
                }
                else if (operation == "^")
                {

                    displayBox.Text += "=" + (Math.Pow(leftNumber, rightNumber));
                } 
                else
                {

                    displayBox.Clear();
                    displayBox.Text = "Something went horribly wrong";
                }

            }
            else
            {
                //If the text box has nothing in it, tell the user! 
                displayBox.Clear();
                displayBox.Text = "You must enter something!";
            }






            
        }

        private void displayBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            displayBox.Clear();
        }
    }
}
