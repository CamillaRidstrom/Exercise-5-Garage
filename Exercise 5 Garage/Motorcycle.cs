using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise_5_Garage
{
    public class Motorcycle : Vehicle
    {
        private const int NumberOfWheels = 2;
        public string CylinderVolume { get; set; } //Eller en bool Sidovagn

        //Constructor
        public Motorcycle (VehicleType type, string licenceplate, string color, string manufacturer, string model, string cylindervolume) 
            : base(type, licenceplate, color, manufacturer, model)
        {
            CylinderVolume = cylindervolume;
        }
        //Method/s
        public override string GetDescription() 
        {
            return $"{base.GetDescription()}, CylinderVolume:\t{CylinderVolume}\nNumber of wheels:\t{NumberOfWheels}\n";
        }
    }
        
}
