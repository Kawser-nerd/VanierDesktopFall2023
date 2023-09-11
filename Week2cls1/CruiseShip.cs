using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2cls1
{
    /*
     * Design a CruiseShip class that extends the Ship class. The CruiseShip class should have
the following members:
● A field for the maximum number of passengers (an int )
● appropriate accessors and mutators
● A ToString method that overrides the ToString method in the base class. 
    The CruiseShip class’s toString method should display only the ship’s name and the maximum 
    number of passengers.
     */

    /*
     * In C# we use : (colon) to inherit or implement any class
     * If you want to inherit multiple class/es or interfaces, you need to seperate oneach class
     * or interface with comma ,
     */
    internal class CruiseShip : Ship // the way to do inheritance in C#
    {
        private int _noofPassengersMax;

        public void set_noofPassengersMax(int noofPassenger)
        {
            this._noofPassengersMax = noofPassenger;
        }
        public int get_noofPassengersMax()
        {
            return this._noofPassengersMax;
        }
        public override void toString()
        //public void toString()
        {
            Console.WriteLine("The name of the ship is " + get_nameoftheShip() + "\t" +
                "And the number of total passengers is: " + get_noofPassengersMax());
        }

        /*
         * this toString() method is the local method of CruiseShip class. Our target is to access
         * toString() method of the Ship class, which is parent class
         * 
         * to do that, we need to create an object/instance of the Ship Class
        
         */

        /*
        public void parent_Ship() { 
        Ship sh = new Ship();
        sh.toString(); // this is the parent class to String
         }*/
        
    }

}
