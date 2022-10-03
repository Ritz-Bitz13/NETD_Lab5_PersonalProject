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
using System.Windows.Navigation;
using System.Windows.Shapes;
#endregion

#region NameSpace & Initialize
namespace ICE01_TikTacToe
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

        #region Global Variable and Bool - if clicked
        //counter to track how many X's and O's are on the board.
        int gameCounter = 1;
        // bools to check if the textbox was clicked already or not.
        bool clicked1 = false;
        bool clicked2 = false;
        bool clicked3 = false;
        bool clicked4 = false;
        bool clicked5 = false;
        bool clicked6 = false;
        bool clicked7 = false;
        bool clicked8 = false;
        bool clicked9 = false;
        #endregion

        #region Textbox Top Left
        private void UserSelection1(object sender, MouseButtonEventArgs e)
        {
            // Top Left Text box
            if (clicked1 == false)
            {
                // If user typed something in it before. Clear it.
                txtGrid00.Clear();
                // If the counter is odd, make the text box as an 'X', if its even, mark it as a 'O'.
                if (gameCounter % 2 == 0)
                    txtGrid00.Text = "O";
                else
                {
                    txtGrid00.Text = "X";
                }
                txtGrid00.IsReadOnly = true; // change to readonly so the user cant type more into the textboxes.
                clicked1 = true; // Change the bool so the user cant click this box again to add more to counter.
                gameCounter++;
                ClearAll();
            }
        }
        #endregion

        #region Textbox Top Center
        private void UserSelection2(object sender, MouseButtonEventArgs e)
        {
            if (clicked2 == false)
            {
                // If user typed something in it before. Clear it.
                txtGrid01.Clear();
                // If the counter is odd, make the text box as an 'X', if its even, mark it as a 'O'.
                if (gameCounter % 2 == 0)
                    txtGrid01.Text = "O";
                else
                {
                    txtGrid01.Text = "X";
                }
                gameCounter++;
                txtGrid01.IsReadOnly = true; // change to readonly so the user cant type more into the textboxes.
                clicked2 = true; // Change the bool so the user cant click this box again to add more to counter.
                ClearAll();
            }
        }
        #endregion

        #region Textbox Top Right
        private void UserSelection3(object sender, MouseButtonEventArgs e)
        {
            if (clicked3 == false)
            {
                // If user typed something in it before. Clear it.
                txtGrid02.Clear();
                // If the counter is odd, make the text box as an 'X', if its even, mark it as a 'O'.
                if (gameCounter % 2 == 0)
                    txtGrid02.Text = "O";
                else
                {
                    txtGrid02.Text = "X";
                }
                gameCounter++;
                txtGrid02.IsReadOnly = true; // change to readonly so the user cant type more into the textboxes.
                clicked3 = true; // Change the bool so the user cant click this box again to add more to counter.
                ClearAll();
            }
        }
        #endregion

        #region Textbox Center Left
        private void UserSelection4(object sender, MouseButtonEventArgs e)
        {
            if (clicked4 == false)
            {
                // If user typed something in it before. Clear it.
                txtGrid10.Clear();
                // If the counter is odd, make the text box as an 'X', if its even, mark it as a 'O'.
                if (gameCounter % 2 == 0)
                    txtGrid10.Text = "O";
                else
                {
                    txtGrid10.Text = "X";
                }
                gameCounter++;
                txtGrid10.IsReadOnly = true; // change to readonly so the user cant type more into the textboxes.
                clicked4 = true; // Change the bool so the user cant click this box again to add more to counter.
                ClearAll();
            }
        }
        #endregion

        #region Textbox Center Center
        private void UserSelection5(object sender, MouseButtonEventArgs e)
        {
            if (clicked5 == false)
            {
                // If user typed something in it before. Clear it.
                txtGrid11.Clear();
                // If the counter is odd, make the text box as an 'X', if its even, mark it as a 'O'.
                if (gameCounter % 2 == 0)
                    txtGrid11.Text = "O";
                else
                {
                    txtGrid11.Text = "X";
                }
                gameCounter++;
                txtGrid11.IsReadOnly = true; // change to readonly so the user cant type more into the textboxes.
                clicked5 = true; // Change the bool so the user cant click this box again to add more to counter.
                ClearAll();
            }
        }
        #endregion

        #region Textbox Center Right
        private void UserSelection6(object sender, MouseButtonEventArgs e)
        {
            if (clicked6 == false)
            {
                // If user typed something in it before. Clear it.
                txtGrid12.Clear();
                // If the counter is odd, make the text box as an 'X', if its even, mark it as a 'O'.
                if (gameCounter % 2 == 0)
                    txtGrid12.Text = "O";
                else
                {
                    txtGrid12.Text = "X";
                }
                gameCounter++;
                txtGrid12.IsReadOnly = true; // change to readonly so the user cant type more into the textboxes.
                clicked6 = true; // Change the bool so the user cant click this box again to add more to counter.
                ClearAll();
            }
        }
        #endregion

        #region Textbox Bottom Left
        private void UserSelection7(object sender, MouseButtonEventArgs e)
        {
            if (clicked7 == false)
            {
                // If user typed something in it before. Clear it.
                txtGrid20.Clear();
                // If the counter is odd, make the text box as an 'X', if its even, mark it as a 'O'.
                if (gameCounter % 2 == 0)
                    txtGrid20.Text = "O";
                else
                {
                    txtGrid20.Text = "X";
                }
                gameCounter++;
                txtGrid20.IsReadOnly = true; // change to readonly so the user cant type more into the textboxes.
                clicked7 = true; // Change the bool so the user cant click this box again to add more to counter.
                ClearAll();
            }
        }
        #endregion

        #region Textbox Bottom Center
        private void UserSelection8(object sender, MouseButtonEventArgs e)
        {
            if (clicked8 == false)
            {
                // If user typed something in it before. Clear it.
                txtGrid21.Clear();
                // If the counter is odd, make the text box as an 'X', if its even, mark it as a 'O'.
                if (gameCounter % 2 == 0)
                    txtGrid21.Text = "O";
                else
                {
                    txtGrid21.Text = "X";
                }
                gameCounter++;
                txtGrid21.IsReadOnly = true; // change to readonly so the user cant type more into the textboxes.
                clicked8 = true; // Change the bool so the user cant click this box again to add more to counter.
                ClearAll();
            }
        }
        #endregion

        #region Textbox Bottom Right
        private void UserSelection9(object sender, MouseButtonEventArgs e)
        {
            if (clicked9 == false)
            {
                // If user typed something in it before. Clear it.
                txtGrid22.Clear();
                // If the counter is odd, make the text box as an 'X', if its even, mark it as a 'O'.
                if (gameCounter % 2 == 0)
                    txtGrid22.Text = "O";
                else
                {
                    txtGrid22.Text = "X";
                }
                gameCounter++;
                txtGrid22.IsReadOnly = true; // change to readonly so the user cant type more into the textboxes.
                clicked9 = true; // Change the bool so the user cant click this box again to add more to counter.
                ClearAll();
            }
        }
        #endregion

        #region Clear All Custom Method
        private void ClearAll()
        {
            // Clear all the boxes, turn read only back off and turn textboxes as clickable.
            if (gameCounter == 10)
            {
                txtGrid00.Clear();
                txtGrid00.IsReadOnly = false;
                clicked1 = false;
                txtGrid01.Clear();
                txtGrid01.IsReadOnly = false;
                clicked2 = false;
                txtGrid02.Clear();
                txtGrid02.IsReadOnly = false;
                clicked3 = false;
                txtGrid10.Clear();
                txtGrid10.IsReadOnly = false;
                clicked4 = false;
                txtGrid11.Clear();
                txtGrid11.IsReadOnly = false;
                clicked5 = false;
                txtGrid12.Clear();
                txtGrid12.IsReadOnly = false;
                clicked6 = false;
                txtGrid20.Clear();
                txtGrid20.IsReadOnly = false;
                clicked7 = false;
                txtGrid21.Clear();
                txtGrid21.IsReadOnly = false;
                clicked8 = false;
                txtGrid22.Clear();
                txtGrid22.IsReadOnly = false;
                clicked9 = false;

                gameCounter = 1;
            }

        }
        #endregion

    }
}