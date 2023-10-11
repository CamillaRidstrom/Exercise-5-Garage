using Exercise_5_Garage;
using static Exercise_5_Garage.Vehicle;

namespace Excercise_5_Garage.Test
{
    [TestClass]
    public class GarageTest
    {
        [TestMethod]
        public void AddVehicle_WhenGarageIsNotFull_ShouldAddVehicle()
        {
            //-- Arrange
            /*12345*/ 
            int capacity = 5;
            /*1 Enum*/ //var garage = new Garage<IEnumerable<int>>(capacity);
            /*1*/ //int vehicleToAdd = 42;
            /*2 List*/ //var garage = new Garage<List <Car>>(capacity);
            /*2*/ //var CarToAdd = new Car("Car", "ABC123", "Black", "Nissan", "Yuke", "Petrol");
            /*3 Dictonary */ //var garage = new Garage<Dictionary<string, Vehicle>>(capacity);
            /*3*/ //var vehicleToAdd = new Vehicle("ABC123", "Car"); //, "Black", "Nissan", "Yuke");
            /*4 Array */ //var garage = new Garage<Car>(capacity);
            /*4*/ //var vehicleToAdd = new Vehicle("Car", "ABC123", "Black", "Nissan", "Yuke");
            /* 5 Vehicle */
            var garage = new Garage<Vehicle>(capacity);
            /*5*/ 
            var vehicleToAdd = new Vehicle(VehicleType.Car, "ABC123", "Black", "Nissan", "Yuke");

            //-- Act
            /*1*/ //garage.AddVehicle(vehicleToAdd); 
            /*2*/ //garage.AddVehicle(new List<Car> { CarToAdd });
            /*3*/ //garage.AddVehicle(new Dictionary<string, Vehicle> { { vehicleToAdd.LicensePlate, vehicleToAdd } });
            /*4*/ //garage.AddVehicle(new Vehicle[] { vehicleToAdd });

            /*5*/ 
            garage.AddVehicle(vehicleToAdd); 

            //-- Assert
            /*12345*/
            Assert.AreEqual(1, garage.Occupancy);

            /*1*/ //Assert.AreEqual(vehicleToAdd, garage[0]);
            /*2*/ //CollectionAssert.Contains(garage[0], carToAdd);
            /*3*/ //Assert.IsTrue(garage.ContainsKey(vehicleToAdd.LicensePlate));
            /*4*/ //Assert.AreEqual(vehicleToAdd, garage[0]);

            /*5*/ 
            Assert.IsTrue(garage.Contains(vehicleToAdd));

        }
        [TestMethod]
        public void AddVehicle_WhenGarageIsFull_ShouldDisplayInformationThatItCannotBeDone()
        {
            //--Arrange
            int capacity = 2;
            var garage = new Garage<Vehicle>(capacity);

            var vehicle1 = new Vehicle(VehicleType.Car, "ABC123", "Yellow", "Nissan", "Yuke");
            var vehicle2 = new Vehicle(VehicleType.Car, "DEF456", "Blue", "Nissan", "Micra");
            var vehicleToAdd = new Vehicle(VehicleType.Car, "GHI789", "White", "Nissan", "Leaf");

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                garage.AddVehicle(vehicle1);
                garage.AddVehicle(vehicle2);

                //--Act
                garage.AddVehicle(vehicleToAdd);

                //--Assert
                string consoleOutput = sw.ToString();
                Assert.IsTrue(consoleOutput.Contains("We are sorry but the garage is currently full. No more space to park additional vehicles unfortunatley. \nPlease check with us at another time.\n"));

            }
        }
    }
}