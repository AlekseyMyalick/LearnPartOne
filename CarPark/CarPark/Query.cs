using System.Collections.Generic;
using System.Linq;

namespace CarPark
{
    public static class Query
    {
        public static List<Vehicle> EngineDisplacementGreaterThan(List<Vehicle> vehicles, double engineVolume)
        {
            return vehicles.Where(v => v.VehicleEngine.Volume.CompareTo(engineVolume) > 0).ToList();
        }

        public static IEnumerable<dynamic> BusAndTruckEngines(List<Vehicle> vehicles)
        {
            return vehicles.Where(v => v is Truck || v is Bus).Select(v => new {v.VehicleEngine.EngineType, v.VehicleEngine.SerialNumber, v.VehicleEngine.Power}).ToList();
        }

        public static IEnumerable<IGrouping<TransmissionType, Vehicle>> GroupedByTransmission(List<Vehicle> vehicles)
        {
            return vehicles.GroupBy(v => v.VehicleTransmission.Type);
        }
    }
}
