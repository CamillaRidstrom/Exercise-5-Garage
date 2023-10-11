using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage
{
    public class Manager
    {
        private UI ui;
        private Handler handler;
        //private Garaget garaget;
        //private Parking parking;
        public Manager()
        {
            ui = new UI();
            handler = new Handler(ui);
            //garaget = new Garaget(parking);
            //parking = new Parking(garaget);

        }
        public void Start()
        {
            Console.WriteLine("Welcome to Camillas Garage Manager");


            while (true)
            {
                ui.DisplayMainMenu();
                int mainMenuChoice = ui.GetUserChoice();

                switch (mainMenuChoice)
                {
                    case 1:
                        Console.Clear();
                        handler.HandleGarageMenu();
                        break;
                    case 2:
                        Console.Clear();
                        handler.HandleParkingMenu();
                        break;
                    case 3:
                        Console.Clear();
                        handler.HandlePrePopulatedGarageMenu();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            }
        }
    }
}
