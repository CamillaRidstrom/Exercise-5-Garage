using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage
{
    /*  KOMMENTAR:

        * Har hårdkodat hur användaren lägger in egenskaperna för vehicles 
          därför har jag fått problem att be de lägga in subklasspecifika egenskaper.

        * Har bara skapat subklasserna Car och Motorcycle eftersom de egentligen inte används
          som programmet ser ut nu, istället ligger VehicleTypes som en enumlista.
          Trodde att jag skulle lyckas få ihop det på egen hand, borde ha frågat om hjälp istället. 

    */

    public class Vehicle : IEnumerable<string> //Ev. byta ut till IEnumerable<KeyValuePair<string, object>>
    {
        public enum VehicleType
        {
            Airplane,
            Boat,
            Bus,
            Car,
            Motorcycle 
        }
        // Field/s
        //public int NumberOfWheels = 0;

        //Properties
        public VehicleType Type { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        //public int NumberOfWheels { get; set; }
        //public string X { get; set; }

        //Constructor
        public Vehicle(VehicleType type, string licenseplate, string color, string manufacturer, string model) //, int numberOfWheels)
        {
            Type = type;
            LicensePlate = licenseplate;
            Color = color;
            Manufacturer = manufacturer;
            Model = model;
            //NumberOfWheels = numberOfWheels; //Ej med i GetDescription nedanför
        }
        //Method/s
        public virtual string GetDescription() //Ev. override
        {
            return $"License plate:\t{LicensePlate}\nType:\t\t{Type}\nManufacturer:\t{Manufacturer}\nModel:\t\t{Model}\nColor:\t\t{Color}\n\n";
        }
        public IEnumerator<string> GetEnumerator()
        {
            yield return LicensePlate;
            yield return Color;
            yield return Manufacturer;
            yield return Model;
            //yield return NumberOfWheels; //int ej string
        }
        //public IEnumerator<int> GetEnumeratorInt()
        //{
        //    yield return NumberOfWheels; // Lägger denna som en unik constant för olika fordonstyper som alltid är samma
        //}
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
