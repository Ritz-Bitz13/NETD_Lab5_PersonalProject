//This is just a typical Fraction class that I have been using as an example for years! 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Fraction
    {
        private double numerator;
        private double denominator;

        /// <summary>
        /// Initialize the fraction properties
        /// </summary>
        /// <param name="numerator">Upper number</param>
        /// <param name="denominator">Lower number</param>
        public Fraction(double numerator, double denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        /// <summary>
        /// Access to the numerator property
        /// </summary>
        public double Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        /// <summary>
        /// Access to the denominator property
        /// </summary>
        public double Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("0 denominator");
                }

                this.denominator = value;
            }
        }

        /// <summary>
        /// Return a string representation of a fraction
        /// </summary>
        /// <returns>Displayable attribute</returns>
        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }

        // Overloaded operator *
        // Multiplies two given fractions and returns the result
        // The method is static and therefore not associated with
        // any particular instance of Fraction

        public static Fraction operator *(Fraction x, Fraction y)
        {
            Fraction f = new Fraction(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
            return f;
        }

    }
}