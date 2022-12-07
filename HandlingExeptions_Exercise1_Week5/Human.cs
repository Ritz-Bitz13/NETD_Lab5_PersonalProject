using System;
using System.Collections.Generic;
using System.Text;

namespace HandlingExeptions
{
    class Human
    {
        //data members.
        private string name;
        private int age;


        //Name getter and setter property
        public string Name
        {

            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {

            get { return this.age; }
            set { this.age = value; }
        }

        //contstructor
        public Human(string name, int age)
        {

            this.name = name;
            this.age = age;
        }



    }
}
