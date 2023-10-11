using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage
{
    /*  KOMMENTAR:

        * Jag är väligt osäker på IEnumerable och har ng inte implementerat det på rätt sätt?
        Jag har inte lyckats med att använda enum på något vettigt sätt i Garage, dock används det i Vehicle.

    */


    public class Garage<T> : IEnumerable<T> where T: IEnumerable 
    {
        private T[] vehicles;
        private int capacity;
        private int occupancy;

        public Garage(int capacity = 0) //Obs osäker på = 0 här
        {
            this.capacity = capacity;
            vehicles = new T[capacity];
            occupancy = 0;
        }
        public int Capacity
        { 
            get { return capacity; } // nås via garage.Capacity
        }
        public int Occupancy
        { 
            get { return occupancy; } //nås via garage.Occupancy 
        }
        public void AddVehicle(T vehicle) //(Vehicle vehicle) 
        {
            if(occupancy < capacity)
            {
                vehicles[occupancy] = vehicle;
                occupancy++;
                Console.WriteLine($"Add vehicle executed. Your vehicle is now parked."); //Hade velat ha {Type} {LicencePlate} här isf vehicle
            }
            else
            {
                Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
                Console.WriteLine("We are sorry but the garage is currently full. No more space to park additional vehicles unfortunatley. \nPlease check with us at another time.\n");
            }
        }
        public bool RemoveVehicleByLicencePlate(string lP)
        {
            for (int i = 0; i < Occupancy; i++)
            {
                T vehicle = vehicles[i];
                if (vehicle is Vehicle && ((Vehicle)(object)vehicle).LicensePlate == lP) //licensePlate)
                {
                    for (int j = i; j < Occupancy - 1; j++)
                    {
                        vehicles[j] = vehicles[j + 1];
                    }

                    vehicles[Occupancy - 1] = default(T);
                    occupancy--;
                    return true;
                } 
            }
            return false;
        }
        //public void ListAllParkedVehicles()
        //{
        //    Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
        //    Console.WriteLine($"List of all parked vehicles in the garage:\n");
        //    if (Occupancy == 0)
        //    {
        //        Console.WriteLine("\nThere is currently no parked vehicles."); //Här funkar det
        //    }
        //    else
        //    {
        //        foreach (T vehicle in vehicles)
        //        {
        //            Console.WriteLine(vehicle.ToString()); //Här blir det fel
        //        }
        //    }
        //}
        public IEnumerator<T> GetEnumerator() 
        {
            for (int i=0; i < occupancy; i++) 
            {
                yield return vehicles[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
    }
}
