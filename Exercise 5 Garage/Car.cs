using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage
{
    public class Car : Vehicle
    {
        private const int NumberOfWheels = 4;

        public string FuelType { get; set; } //Fueltype (Gasoline/Diesel)

        //Constructor
        public Car(VehicleType type, string licenceplate, string color, string manufacturer, string model, string fueltype) 
            : base(type, licenceplate, color, manufacturer, model)
        {
            FuelType = fueltype;
        }
        //Method/s
        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Fueltype:\t{FuelType}\nNumber of wheels:\t{NumberOfWheels}\n";
        }
    }
}
