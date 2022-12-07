using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;


namespace SimpleObservableCollection
{
    public class Car
    {

        //data members;
        private int year;
        private string make;
        private int id;
        
        private string model;
        private string condition;
        
        //Year property Getter/Setter
        public int Year
        {

            get { return this.year; }
            set { this.year = value; }
        }
      //Make property getter/setter
        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        //ID property getting/setter
        public int ID
        {

            get { return this.id; }
            set { this.id = value; }
        }
        //constructor
        public Car(int year, string make, string condition, string model, int ID)
        {

            this.year = year;
            this.make = make;
            this.condition = condition;
            this.model = model;
            //notice that I am using a defined method to create the ID.
            this.ID = generateID();
        }
        //default constructor
        public Car()
        {


        }
        //generateID is a method that simply generates a random integer.
        public static int generateID()
        {

            //this is how you generate a random number in C#
           Random rand  = new Random();
            int randomNumber = rand.Next();

            return randomNumber; 
        }
        //Overriding ToString so that it returns the ID so that I can use it in my program.
        public override string ToString()
        {
            return this.ID.ToString();
        }
        
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public string Condition
        {

            get { return this.condition; }
            set { this.condition = value; }
        }
        
    }
}
