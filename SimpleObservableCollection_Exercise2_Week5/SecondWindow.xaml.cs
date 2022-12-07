using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleObservableCollection
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public ObservableCollection<Car> cars;
        public int ID;
        public object sender;
        //constructor called for SecondWindow (makes second window and launches it).
        public SecondWindow(ObservableCollection<Car> cars, int ID, object sender)
        {
            this.cars = cars;
            this.ID = ID;
            this.sender = sender;
            InitializeComponent();
        }
        //if the alter button is clicked.
        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
             
            for(int i=0; i<cars.Count; i++)
            {
                //if we find the car ID, alter it from the textboxes.
                if(cars[i].ID == ID)
                {
                    cars[i].Year = int.Parse(txtYear.Text);
                    cars[i].Make = txtModel.Text;
                    cars[i].Condition = txtCondition.Text;
                    cars[i].Make = txtMake.Text;
                    CollectionViewSource.GetDefaultView(cars).Refresh();

                }
            }
            
        }
    }
}
