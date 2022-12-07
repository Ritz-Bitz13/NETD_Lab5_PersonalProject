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

namespace WEBD_Lab2
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

        private void ListViewItemChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = e.Source as ListView;

            if (listView != null)
            {
                DisplayPanel.Children.Clear();

                if (listView.SelectedItem.Equals(lviLendOut))
                {
                    Control controlAddLend = new LendOut();

                    this.DisplayPanel.Children.Add(controlAddLend);
                }

                if (listView.SelectedItem.Equals(lviViewLendOut))
                {
                    Control controlView = new ViewLend();
                    this.DisplayPanel.Children.Add(controlView);
                }
            }
        }
    }
}
