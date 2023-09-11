using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2cls1
{
    /*
     * Design a CargoShip class that extends the Ship class. 
     * The CargoShip class should have the following members:
● A field for the cargo capacity in tonnage (an int )
● appropriate accessors and mutators
● A toString method that overrides the toString method in the base class.
    The CargoShip class’s toString method should display only the ship’s name and the 
    ship’s cargo capacity.

     */
    internal class CargoShip:Ship
    {
        private int _cargoCapacity;
        public void set_CargoCapacity(int capacity)
        {
            this._cargoCapacity = capacity;
        }
        public int get_CargoCapacity() {  
            return this._cargoCapacity; 
        }

        // the following method is going to override the ship class method
        public override void toString() // local or the CargoShip class toString() method
        //public void toString()
        {
            Console.WriteLine("The name of the Ship is "+ get_nameoftheShip() + "\t"
                + "The cargo capacity is "+ get_CargoCapacity());
        }
    }
}
