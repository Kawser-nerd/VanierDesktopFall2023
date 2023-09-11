using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2cls1 // namespace is same as package name in Java
{
    internal class Program
    {
        /*
         * This class is the main class, with main method in it
         * 
         * we are going to keep this class for demonstration purpose
         * 
         * Demonstrate the classes in a program that has a Ship array. 
         * Assign various Ship, CruiseShip , and CargoShip objects to the array elements. 
         * The program should then step through the array, calling each object’s toString 
         * method
         * 
         * Add two CruiseShip and two CargoShip for the practice purpose
         * 
         */


        static void Main(string[] args)
        {
            /*
             * Here we are creating ship array with Class type Ship. And, because it is array
             * we need to define the number of variables/instances/memories from the time
             * of declaration
             */
            Ship[] ships = new Ship[4];

            // now we need to assign the objects/values for each memory space of the Ship class
            ships[0] = new CruiseShip();
            ships[1] = new CruiseShip();
            ships[2] = new CargoShip();
            ships[3] = new CargoShip();
            /* Example of Polymorphism*/

            // to coninuously access the list of array variables, we need a loop to perform that

            for (int i = 0; i < 1; i++)
            {
                if (i < 2)
                {
                    CruiseShip ship = new CruiseShip();
                    Console.WriteLine("Enter the Name of the Cruise Ship");
                    ship.set_nameoftheShip(Console.ReadLine());// parent methods

                    Console.WriteLine("Enter the built year of the Cruise Ship");
                    ship.buildYearofShip = Console.ReadLine(); // parent members

                    Console.WriteLine("Enter the Maximum number of Passengers");
                    // Super class doen't have any knowledge of their child class
                    // here we are trying to access the set_noofPassengersMax() which
                    // is the member of Child class. WE create the object with Ship class
                    // which is the base class. So, with base class object/instance, we 
                    // can not access the child class memebers

                    /*
                     * Two methods for Console Reading
                     * read(): read everything, (a paragraph/ )
                     * readLine(): reads full line
                     */

                    // Console.ReadLine returns the value in String format.. We need to 
                    // Convert it to Integer to set the value for the method
                    ship.set_noofPassengersMax(int.Parse(Console.ReadLine())); // local member
                    ships[i] = ship;

                }
                else
                {
                    CargoShip ship = new CargoShip();

                    Console.WriteLine("Enter the Name of the Cargo Ship");
                    ship.set_nameoftheShip(Console.ReadLine());
                    Console.WriteLine("Enter the Built year of the Ship");
                    ship.buildYearofShip = Console.ReadLine();

                    Console.WriteLine("Enter the Capacity of the Ship");
                    ship.set_CargoCapacity(int.Parse(Console.ReadLine()));
                    ships[i] = ship;

                }
            }

            // Print all the information

            for (int i = 0; i < 1; i++)
            {
                
                ships[i].toString(); // this one is pointing to our base class toString method
                // not the child class toString methods at all

                // we want use CargoShip class toString()
                
            }

            Console.ReadKey();// this will hault the console until we press any key from the Keyboard
        }
    }
}

