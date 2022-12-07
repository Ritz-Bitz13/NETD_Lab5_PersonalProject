using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace SimpleObservableCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //This is an observable collection, a data structure similar to a list that will contain our car objects.
        public ObservableCollection<Car> cars = new ObservableCollection<Car>();

       //Public MainWindow and InitializeComponent(); are used to launch the MainWindow.
        public MainWindow()
        {

            InitializeComponent();
            //I am adding a new car
            cars.Add(new Car(2020, "Tesla", "New", "Model X", Car.generateID()));

           
           //data bind
            lstCars.ItemsSource = cars;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            cars.Add(new Car(int.Parse(txtYear.Text), txtMake.Text, txtCondition.Text, txtModel.Text, Car.generateID()));
            txtYear.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtMake.Text = string.Empty;
            txtCondition.Text = string.Empty;

        }

      

        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            

            for(int i=0; i < cars.Count; i++)
            {
                cars[i].ID = 123;
                CollectionViewSource.GetDefaultView(cars).Refresh();

            }

           





        }

        private void lstCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedID = lstCars.SelectedItem.ToString();
            int ID = int.Parse(selectedID);

            SecondWindow xyz = new SecondWindow(cars, ID,  sender);
            xyz.Show();

            

            
        }
    }
}


/*Add another data member to the Car class
 * Add to the cosntructor
 * add it to the list view
 * pass it to the second window
 * and make it so that you can alter it (from the second window)! 
 * 
 * 
 * 
 * 
*/