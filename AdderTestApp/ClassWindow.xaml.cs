using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdderTestApp
{
    /// <summary>
    /// Interaction logic for ClassWindow.xaml
    /// </summary>
    public partial class ClassWindow : Window
    {
        public ClassWindow()
        {
            InitializeComponent();
        }

        int gameCounter = 1;

        private void UserSelection1(object sender, MouseButtonEventArgs e)
        {
            txtGrid00.Clear();
            if (gameCounter % 2 == 0)
                txtGrid00.Text = "O";
            else
            {
                txtGrid00.Text = "X";
            }

            gameCounter++;
            ClearAll();
        }

        private void UserSelection2(object sender, MouseButtonEventArgs e)
        {
            txtGrid01.Clear();
            if (gameCounter % 2 == 0)
                txtGrid01.Text = "O";
            else
            {
                txtGrid01.Text = "X";
            }

            gameCounter++;
            ClearAll();
        }

        private void UserSelection3(object sender, MouseButtonEventArgs e)
        {
            txtGrid02.Clear();
            if (gameCounter % 2 == 0)
                txtGrid02.Text = "O";
            else
            {
                txtGrid02.Text = "X";
            }

            gameCounter++;
            ClearAll();
        }

        private void UserSelection4(object sender, MouseButtonEventArgs e)
        {
            txtGrid10.Clear();
            if (gameCounter % 2 == 0)
                txtGrid10.Text = "O";
            else
            {
                txtGrid10.Text = "X";
            }

            gameCounter++;
            ClearAll();
        }

        private void UserSelection5(object sender, MouseButtonEventArgs e)
        {
            txtGrid11.Clear();
            if (gameCounter % 2 == 0)
                txtGrid11.Text = "O";
            else
            {
                txtGrid11.Text = "X";
            }

            gameCounter++;
            ClearAll();
        }

        private void UserSelection6(object sender, MouseButtonEventArgs e)
        {
            txtGrid12.Clear();
            if (gameCounter % 2 == 0)
                txtGrid12.Text = "O";
            else
            {
                txtGrid12.Text = "X";
            }

            gameCounter++;
            ClearAll();
        }

        private void UserSelection7(object sender, MouseButtonEventArgs e)
        {
            txtGrid20.Clear();
            if (gameCounter % 2 == 0)
                txtGrid20.Text = "O";
            else
            {
                txtGrid20.Text = "X";
            }

            gameCounter++;
            ClearAll();
        }

        private void UserSelection8(object sender, MouseButtonEventArgs e)
        {
            txtGrid21.Clear();
            if (gameCounter % 2 == 0)
                txtGrid21.Text = "O";
            else
            {
                txtGrid21.Text = "X";
            }

            gameCounter++;
            ClearAll();
        }

        private void UserSelection9(object sender, MouseButtonEventArgs e)
        {
            txtGrid22.Clear();
            if (gameCounter % 2 == 0)
                txtGrid22.Text = "O";
            else
            {
                txtGrid22.Text = "X";
            }

            gameCounter++;
            ClearAll();
        }


        private void ClearAll()
        {
            if (gameCounter == 10)
            {
                txtGrid00.Clear();
                txtGrid00.IsReadOnly = false;
                txtGrid01.Clear();
                txtGrid01.IsReadOnly = false;
                txtGrid02.Clear();
                txtGrid02.IsReadOnly = false;
                txtGrid10.Clear();
                txtGrid10.IsReadOnly = false;
                txtGrid11.Clear();
                txtGrid11.IsReadOnly = false;
                txtGrid12.Clear();
                txtGrid12.IsReadOnly = false;
                txtGrid20.Clear();
                txtGrid20.IsReadOnly = false;
                txtGrid21.Clear();
                txtGrid21.IsReadOnly = false;
                txtGrid22.Clear();
                txtGrid22.IsReadOnly = false;

                gameCounter = 1;
            }
            
        }

    }
}
