using System.Collections.Generic;
using System.Linq;
using CarPark.Models;

namespace CarPark
{
    public static class Query
    {
        public static List<Vehicle> EngineDisplacementGreaterThan(List<Vehicle> vehicles, double engineVolume)
        {
            return vehicles.Where(v => v.VehicleEngine.Volume.CompareTo(engineVolume) > 0).ToList();
        }

        public static List<VehicleModel> BusAndTruckEngines(List<Vehicle> vehicles)
        {
            return vehicles.Where(v => v is Truck || v is Bus)
                .Select(v => new VehicleModel( v.VehicleEngine.EngineType, v.VehicleEngine.SerialNumber, v.VehicleEngine.Power)).ToList();
        }

        public static List<Vehicle> GroupedByTransmission(List<Vehicle> vehicles)
        {
            return vehicles.GroupBy(v => v.VehicleTransmission.Type).SelectMany(g => g).ToList();
        }
    }
}
