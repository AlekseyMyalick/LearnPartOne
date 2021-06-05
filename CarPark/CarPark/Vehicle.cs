using System;
using System.Xml.Serialization;

namespace CarPark
{
    [XmlInclude(typeof(PassengerCar))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Scooter))]
    [Serializable]
    public abstract class Vehicle
    {
        public Engine VehicleEngine { get; set; }

        public Chassis VehicleChassis { get; set; }

        public Transmission VehicleTransmission { get; set; }

        public Vehicle() { }

        public Vehicle (Engine engine, Chassis chassis, Transmission transmission)
        {
            VehicleEngine = engine;
            VehicleChassis = chassis;
            VehicleTransmission = transmission;
        }

        public override string ToString()
        {
            return $"Engine:\n{VehicleEngine}\nChassis:\n{VehicleChassis}\nTransmission:\n{VehicleTransmission}\n";
        }
    }
}
