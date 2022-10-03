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

namespace AdderTestApp
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






         private void NumberChanged(object sender, TextChangedEventArgs e)
         {
             double firstNumber;
             double secondNumber;
             double answer;
             //You can use the out keyword as a parameter modifier, which lets you pass an argument to a method by reference rather than by value.
             //How do I know? Microsoft Documentation! https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out
             if (double.TryParse(txtFirstNumber.Text, out firstNumber) &&
                  txtSecondNumber != null &&
                 double.TryParse(txtSecondNumber.Text, out secondNumber) &&
                 lblOutput != null)
             {
                 answer = firstNumber + secondNumber;
                 lblOutput.Content = answer.ToString();

             }
             // If the numbers don't parse, check if they are loaded
             // If they're loaded, blank the output field
             else if (lblOutput != null)
             {
                 lblOutput.Content = "";
             }

         }
        
    }
}
