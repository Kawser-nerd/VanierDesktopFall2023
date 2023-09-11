using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2cls1
{
    /*
     * ● A field for the name of the ship (a string)
        ● A field for the year that the ship was built (a string)
    ● A constructor and appropriate accessors and mutators
● A ToString method that displays the ship’s name and the year it was built
     *
     */
    internal class Ship
    {
        private string _nameofShip; // this is regular variable declaration

        /*
         * in C# we can use default get and set method to any variable we declared/created
         * for that, we don't need to create separate accessors and mutators, but then every time
         * you need to keep your variable public.
         */

        public string buildYearofShip { set; get; }
        /* 
         * the way I showed in line 26 has already enabled accesors and mutators with it. Its the 
         * short-end way to define a variable in C#, which enabled the set method for the variable
         * as well as get method.
         * 
         * we don't need another set of set or get method for this short had variable
         */

        // crtl + K, ctrl + D to autoformat the code, maintaining the indentation properly

        //Constructor: The 
        public Ship()
        {

        }

        // we need to create accessors for each of the private variable
        public void set_nameoftheShip(string nameofShip)
        {
            this._nameofShip = nameofShip;
            // this keyword always refers to the variables and methods in the same same class
            // not outside the class
        }

        public string get_nameoftheShip()
        {
            return this._nameofShip;
        }

        //override

        // if there is a probability that the following method is going to be overrided at 
        // any place of the program, we need to declare the method as virtual
        public virtual void toString()
        //public void toString()
        {
            
            Console.WriteLine("The name of the Ship is " + get_nameoftheShip() +
                "\t The built year was " + buildYearofShip);
        }
    }
}
