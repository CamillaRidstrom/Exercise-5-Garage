using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage
{
    // Kommentar finns under switcharna

    public class Handler
    {
        private Garage<Vehicle> vehicleGarage;
        //public enum VehicleType
        //{
        //    Airplane,
        //    Motorcycle,
        //    Car,
        //    Bus,
        //    Boat
        //}
        private UI ui;
        //private Garaget garaget;
        //private Parking parking;

        public Handler(UI ui) //, Garaget garaget, Parking parking
        {
            this.ui = ui;
            //this.garaget = garaget;
            //this.parking = parking;
        }
        public void HandleGarageMenu()
        {
            while (true)
            {
                ui.DisplayGarageMenu();
                int garageMenuChoice = ui.GetUserChoice();

                switch (garageMenuChoice)
                {
                    case 1:
                        SetCapacity();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        GetOccupancy();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        //Garage.ListAllParkedVehicles();
                        ListAllParkedVehicles();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        CountVehicleTypes();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        SearchByLicensePlate();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        return;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            }
        }
        public void HandleParkingMenu() //
        {
            while (true)
            {
                ui.DisplayParkingMenu();
                int parkingMenuChoice = ui.GetUserChoice();

                switch (parkingMenuChoice)
                {
                    case 1:
                        UserAddedVehicle();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        RemoveParkedVehicle();
                        //Console.WriteLine("Remove vehicle executed. Your vehicle is now collected"); //Lägg till {parking.Type} sen
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        SearchByAttributes();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        return;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            }
        }
        internal void HandlePrePopulatedGarageMenu()
        {
            vehicleGarage = new Garage<Vehicle>(50);
            PopulateGarage();

            while (true)
            {
                ui.DisplayPopulatedGarageMenu();
                int garageMenuChoice = ui.GetUserChoice();
                

                switch (garageMenuChoice)
                {
                    case 1:
                        UserAddedVehicle();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        RemoveParkedVehicle();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        GetOccupancy();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        ListAllParkedVehicles();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        CountVehicleTypes();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        SearchByLicensePlate();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        SearchByAttributes();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        return;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            }
        }
        /*  KOMMENTAR:
         
            * Här nedan i Handler skulle jag nog behöva refaktorera - många metoder är det.. 

            * Ordningen uppifrån och ner så som de förekommer i switchen.
          
            HandlePrePopulatedGarageMenu kallar på samma metoder som HandleGarageMenu & HandleParkingMenu
            förutom SetCapacity. Den använder också en unik metod PopulateGarage();  

            * Hade metoderna först uppdelade i två klasser Parking och Garage ungefär som menyn.
            Men tyckte det blev snårigt att skicka in värden mellan dem (finns ju helt säkert effektivare sätt)
            och så behövde jag ju en basklass som heter Garage så ett tag döpte jag om den första "Garage" till "Garaget".
            Det blev rörigt. Så skippade de klasserna och började om med Garage-klassen. 
            (I Manager har jag kvar spår av de två klasserna utkommaterat). 
       
            * Tänker att det skulle vara bättre om fler metoder låg direkt som mer generiska metoder i Garage.
            Men har inte lyckats få till det. Den har just nu bara två public metoder där:
            
            public void AddVehicle(T vehicle) 
             och 
            public bool RemoveVehicleByLicencePlate(string lP)
            
            Eftersom jag har int Capacity och int Occupancy deklarerade i Garage-klassen. 
            Metode GetOccupancy() här i Handlern använder dom fast på instansen vehicleGarage. 
            (I Garage ligger fortfarande ett misslyckade försök att skriva ytterligare en metod kvar utkommaterat.)
            
            * Att refaktorera vad som egentligen hör bäst till Manager, UI och Handler behöver göras. 
            ..men just nu är jag bara glad att det funkar. 

        */

        public void SetCapacity() //Klar
        {
            if (vehicleGarage != null)
            {
                bool condition = true;
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWarning, a garage allready exists. If you set a new capacity, this will clear out all parked vehicles.");
                Console.ForegroundColor = originalColor;

                while (true)
                {
                    string userDecision = Util.ValidateInput("Would you like to proceed? Please enter Y or N: ", 1, 1, false, "letters");
                    if (userDecision.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    else if (userDecision.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again");
                    }
                }
            }
 
            Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
            Console.WriteLine("Please set a capacity for the garage.\n");
            int TheCapacity = Convert.ToInt32(Util.ValidateInput("Please enter number of parking slots: ", 1, 3, false, "digits"));
            vehicleGarage = new Garage<Vehicle>(TheCapacity);
            Console.WriteLine("Set capacity of garage executed");
        }
        public void GetOccupancy() //Klar
        {
            if (vehicleGarage == null)
            {
                Console.WriteLine("\nThere is currently no garage. Please set capacity to create one.");
            }
            else
            {
                Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
                Console.WriteLine($"Capacity of garage: {vehicleGarage.Capacity}.\n" +
                $"Number of vehicles currently parked: {vehicleGarage.Occupancy}.\n");
            }
        }
        public void UserAddedVehicle() //Klar - men numberOfWheels är utkommenterad
        {
            Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
            if (vehicleGarage == null)
            {
                Console.WriteLine("\nThere is currently no garage.\nPlease go to the Garage menu to set capacity and thereby create one.");
            }
            else
            {
                Console.WriteLine("Park a vehicle in our garage by first entering the vehicle's details.\n");

                Console.Write("Type (Airplane, Boat, Bus, Car, Motorcycle): ");
                if (Enum.TryParse(Console.ReadLine(), out Vehicle.VehicleType type))
                {
                    Console.WriteLine($"\nPlease enter the license plate of the {type} you would like to park.");
                    string licensePlateLetters = Util.ValidateInput("Please start with letters: ", 3, 3, false, "letters").ToUpper();
                    string licensePlateDigits = Util.ValidateInput("Thank you, and now the numbers: ", 3, 3, false, "digits");
                    string licencePlate = licensePlateLetters + licensePlateDigits;

                    string color = Util.ValidateInput("Color: ", 2, 30, false, "letters");

                    string manufacturer = Util.ValidateInput("Manufacturer: ", 1, 30);

                    string model = Util.ValidateInput("Model: ", 1, 30);

                    //Console.WriteLine("Number of wheels: ");
                    //int numberOfWheels = int.Parse(Util.ValidateInput("Number of wheels: ", 1, 2, false, "digits"));

                    vehicleGarage.AddVehicle(new Vehicle(type, licencePlate, color, manufacturer, model));//, numberOfWheels));

                    //garaget.TheOccupancy++;
                    //Console.WriteLine($"Add vehicle executed. Your {type} {licencePlate} is now parked.");
                }
                else
                {
                    Console.WriteLine("Invalid vehicle type. Please try again");
                }
            }
        }
        public void ListAllParkedVehicles() //Klar
        {
            Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
            Console.WriteLine($"List of all parked vehicles in the garage:\n");
            if (vehicleGarage == null || vehicleGarage.Occupancy == 0)
            {
                Console.WriteLine("\nThere is currently no parked vehicles.");
            }
            else
            {
                foreach (Vehicle vehicle in vehicleGarage)
                {
                    if (vehicle != null)
                    {
                        string description = vehicle.GetDescription();
                        Console.WriteLine(description);
                    }
                }
                Console.WriteLine("'List all parked vehicles' executed.");
            }
        }
        public void SearchByLicensePlate() //Klar
        {
            Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
            if (vehicleGarage == null || vehicleGarage.Occupancy == 0)
            {
                Console.WriteLine("\nThere is currently no parked vehicles to search.");
            }
            else
            {
                Console.WriteLine($"Please enter the license plate you would like to find.\n");
                string searchLetters = Util.ValidateInput("Please start with letters: ", 3, 3, false, "letters").ToUpper();
                //Console.WriteLine($"Thank you, and now the numbers: ");
                string searchDigits = Util.ValidateInput("Thank you, and now the numbers: ", 3, 3, false, "digits");
                string searchLicensePlate = searchLetters + searchDigits;

                foreach (Vehicle vehicle in vehicleGarage)
                {
                    if (vehicle.LicensePlate == searchLicensePlate)
                    {
                        Console.WriteLine($"\nVehicle found!");
                        string description2 = vehicle.GetDescription();
                        Console.WriteLine(description2);
                        Console.WriteLine("'Search by license plate' executed.");
                        return;
                    }
                }
                Console.WriteLine($"\nVehicle {searchLicensePlate} not found");
                Console.WriteLine("'Search by license plate' executed.");
            }
        }
        public void RemoveParkedVehicle() //Klar
        {
            Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
            if (vehicleGarage == null || vehicleGarage.Occupancy == 0)
            {
                Console.WriteLine("\nThere is currently no parked vehicles to collect");
            }
            else
            {
                Console.WriteLine($"Please enter the license plate of the vehicle you would like to collect.\n");
                string searchLetters = Util.ValidateInput("Please start with letters: ", 3, 3, false, "letters").ToUpper();
                //Console.WriteLine($"Thank you, and now the numbers: ");
                string searchDigits = Util.ValidateInput("Thank you, and now the numbers: ", 3, 3, false, "digits");
                string searchLicensePlate = searchLetters + searchDigits;

                foreach (Vehicle vehicle in vehicleGarage)
                {
                    if (vehicle.LicensePlate == searchLicensePlate)
                    {
                        Console.WriteLine($"\nVehicle found!");
                        string description2 = vehicle.GetDescription();
                        Console.WriteLine(description2);

                        vehicleGarage.RemoveVehicleByLicencePlate(searchLicensePlate);
                        Console.WriteLine($"\nVehicle removed from the garage!");
                        return; //Nått är fel här
                    }
                }
                Console.WriteLine($"\nVehicle {searchLicensePlate} not found");
            }
        }
        public void CountVehicleTypes() //Klar
        {
            if (vehicleGarage == null || vehicleGarage.Occupancy == 0)
            {
                Console.WriteLine("\nThere is currently no parked vehicles to count.");
            }
            else
            {
                Dictionary<string, int> vehicleTypeCount = new Dictionary<string, int>();
                foreach (Vehicle vehicle in vehicleGarage)
                {
                    string vehicleType = vehicle.Type.ToString();

                    if (!vehicleTypeCount.ContainsKey(vehicleType))
                    {
                        vehicleTypeCount[vehicleType] = 1;
                    }
                    else
                    {
                        vehicleTypeCount[vehicleType]++;
                    }
                    //return vehicleTypeCount;
                }
                Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
                Console.WriteLine("Number of different vehicles currently parked in this garage");
                foreach (var kvp in vehicleTypeCount)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
            Console.WriteLine("\n'Vehicle count type' executed.");
        }
        private void SearchByAttributes() // Klar (skulle kunna putsas till)
        {
            if (vehicleGarage == null || vehicleGarage.Occupancy == 0)
            {
                Console.WriteLine("\nThere is currently no parked vehicles to search among.");
            }
            else
            {
                Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
                Console.WriteLine("How many attributes do you wish to search with?");
                int numberOfAttributes = int.Parse(Util.ValidateInput("Please enter you choice - 1, 2 or 3: ", 1,1,false,"digits"));

                List<string> attributes = new List<string>();
                List<string> values = new List<string>();

                for(int i = 0; i < numberOfAttributes; i++) 
                {
                    Console.WriteLine($"\nEnter attribute {i + 1}");
                    attributes.Add(Util.ValidateInput("Type, Color, Manufacturer or Model: ",4,12,false,"letters"));

                    Console.WriteLine($"\nEnter the value you want to search for attribute {attributes[i]}");
                    values.Add(Util.ValidateInput("Please write here: ", 2, 30));
                }

                Console.WriteLine("\nVehicles matching the specified attributes:\n");

                foreach (Vehicle vehicle in vehicleGarage)
                {
                    bool match = false;

                    for (int i = 0; i < numberOfAttributes; i++)
                    {
                        string attribute = attributes[i];
                        string value = values[i];

                        switch (attribute.ToLower())
                        {
                            case "type":
                                match = vehicle.Type.ToString().Equals(value, StringComparison.OrdinalIgnoreCase);
                                break;
                            case "color":
                                match = vehicle.Color.Equals(value, StringComparison.OrdinalIgnoreCase);
                                break;
                            case "manufacturer":
                                match = vehicle.Manufacturer.Equals(value, StringComparison.OrdinalIgnoreCase);
                                break;
                            case "model":
                                match = vehicle.Model.Equals(value, StringComparison.OrdinalIgnoreCase);
                                break;
                            //case "numberofwheels":
                            //    match = vehicle.NumberOfWheels.Equals(value, StringComparison.OrdinalIgnoreCase);
                            //    break;
                            default:
                                Console.WriteLine($"Invalid attribute: {attribute}.\nIt needs to be Type, Color, Manufaturer or Model, please try again.");
                                return;
                        }

                        if (!match)
                        {
                            break;
                        }
                    }
                    if (match)
                    {
                        Console.WriteLine(vehicle.GetDescription());
                    }
                }
            }
        }
        private void PopulateGarage() //Klar
        {
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Car, "ABC123", "Blue", "Nissan", "Micra"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Car, "DEF456", "Yellow", "Nissan", "Juke"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Car, "REW765", "White", "Nissan", "Leaf"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Car, "LKJ323", "Purple", "Nissan", "Qashqai"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Car, "ADV123", "Black", "Nissan", "X-trail"));

            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Car, "BCA123", "Brown", "Ford", "T"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Bus, "FDE456", "White", "Ford", "E-Transit"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Car, "EWR765", "White", "Ford", "Bronco"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Car, "KJL323", "Blue", "Ford", "Explorer"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Car, "FOX123", "Orange", "Ford", "Mustang"));

            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Boat, "DEF564", "Dark honduras wood", "Löfholmens varv", "Viking III"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Boat, "EWR676", "White", "Nimbus", "Comuter 9"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Motorcycle, "WOW001", "Golden", "Puch", "Dakota"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Motorcycle, "RUT442", "Red", "Puch", "Florida"));
            vehicleGarage.AddVehicle(new Vehicle(Vehicle.VehicleType.Airplane, "URV778", "White-Red", "Cessna", "195"));
            Console.Clear();
        }
    }
}