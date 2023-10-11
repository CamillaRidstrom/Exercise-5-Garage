using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Xml.Linq;

namespace Exercise_5_Garage
{
    public class UI
    {
        public void DisplayMainMenu()
        {
            string[] menuOptions = { "Garage menu - create and inspect", "Parking menu - park and collect", "Established garage - allready populated","Exit" };
            Util.CreateMenu(menuOptions, "MAIN MENU");
            Console.WriteLine();

        }
        public int GetUserChoice()
        {
            return Convert.ToInt32(Util.ValidateInput("Please enter your choice: ", 1, 1, false, "digits"));
        }
        public void DisplayGarageMenu()
        {
            string[] menuOptions = { " Set capacity", " Get occupancy", " List all vehicles", " Count the parked vehicles types", " Search for vehicle by license plate", " Back to the main menu", " Exit" };
            Util.CreateMenu(menuOptions, "GARAGE MENU");
            Console.WriteLine();
        }
        public void DisplayParkingMenu()
        {
            string[] menuOptions = { " Park vehicle", " Collect vehicle", " Search among parked vehicles by attribute", " Back to the main menu", " Exit" };
            Util.CreateMenu(menuOptions, "PARKING MENU");
            Console.WriteLine();
        }

        internal void DisplayPopulatedGarageMenu()
        {
            string[] menuOptions = { " Park vehicle", " Collect vehicle", " Get occupancy", " List all vehicles", " Count the parked vehicles types", " Search for vehicle by license plate", " Search among parked vehicles by attribute"," Back to the main menu", " Exit" };
            Util.CreateMenu(menuOptions, "ESTABLISHED GARAGE's MENU");
            Console.WriteLine();
        }
    }
}
