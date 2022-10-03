using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass_Week5
{
    class Table
    {
        private string color;
        private string material;
        private double height;
        private double width;
        private double length;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public Table()
        { }

        public Table(string color, double height, double width, double length)
        {
            this.color = color;
            this.height = height;
            this.width = width;
            this.length = length;
        }

        public Table(string color, string material, double height, double width, double length)
        {
            this.color = color;
            this.material = material;
            this.height = height;
            this.width = width;
            this.length = length;
        }

        // acces smodifier, return type, method name, parameters
        public bool Charging(bool pluggedIn)
        {
            if (pluggedIn == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
