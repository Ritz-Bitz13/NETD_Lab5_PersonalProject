using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Lab4_MartinBarber.Models;

namespace Lab4_MartinBarber.Models
{
    public class Textbook
    {
        public static List<Textbook> books = new List<Textbook>();

        public string title { get; set; }
        public int isbn { get; set; }
        public int version { get; set; }
        public double originalPrice { get; set; }
        public string condition { get; set; }
        public double appraisal { get; set; }
        

        // Default Constructor
        public Textbook()
        {

        }

        //Parameterized constructor
        public Textbook(string title, int isbn, int version, double originalPrice, string condition, double appraisal)
        {
            this.title = title;
            this.isbn = isbn;
            this.version = version;
            this.originalPrice = originalPrice;
            this.condition = condition;
            this.appraisal = appraisal;
        }

        public double calcAppraise(double price, string condition)
        {
            // If like new, divide by half
            if (condition == "Like New")
            {
                return (price * 0.5);
            }
            // If condition is good, 0.33 the price
            else if (condition == "Good")
            {
                return (price * 0.33);
            }
            // If condition is bad, 0.25 the price
            else
            {
                return (price * 0.25);
            }
        }

        public string toString()
        {
            return "testing";
        }
    }
}
