using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAppForDemonstration.Models
{
    public class car
    {
        //declaring data memebers and getter/setter properties.
        public string make { get; set; }

        public string modelName { get; set; }

        public int year { get; set; }

        public int kilometers { get; set; }

        //no parameter constructor (required - explain why in the demo)
       public car()
        {


        }


        //full parameter constructor
        public car(string make, string modelName, int year, int kilometers)
        {

            this.make = make;
            this.modelName = modelName;
            this.year = year;
            this.kilometers = kilometers;
        }


        public double calcValue(int year, int kilometers)
        {
            //arbitrary formula that returns the value of a car.
            if (year > 2010)
            {

                return (kilometers / year) * 200000;


            }
            else
            {

                return (kilometers / year) * 100000;


            }


        }

        public override string ToString()
        {
            return "Hello, your registered vehicle Make: " + this.make + "Model: " + this.modelName + "Year: " + this.year + "Kilometers: " + this.kilometers + "\n Is appraised at: " + calcValue(year, kilometers);
        }


    }
}
