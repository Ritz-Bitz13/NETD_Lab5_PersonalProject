using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass_Week5
{
    class Program
    {
        static void Main(string[] args)
        {
            Table a = new Table("Grey", "Wood", 50,50,50);
            Table b = new Table();

            Console.WriteLine(a.Color);
            a.Color = "Red";
            Console.WriteLine(a.Color);

            Console.ReadLine();
        }
    }
}
