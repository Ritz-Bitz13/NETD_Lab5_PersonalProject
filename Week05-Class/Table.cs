using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05_Class
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
            get { return color;}
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
    }
}
