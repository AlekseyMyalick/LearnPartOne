﻿using CarPark.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.Managers
{
    /// <summary>
    /// Provides a list of vehicles
    /// </summary>
    public class CarManager
    {
        /// <summary>
        /// List of vehicles.
        /// </summary>
        public List<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Initializes the list of vehicle.
        /// </summary>
        /// <param name="vehicles">List of vehicle.</param>
        public CarManager(List<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Provides complete information about all vehicles with an engine capacity of more than engineVolume.
        /// </summary>
        /// <param name="engineVolume">Engine volume for comparison.</param>
        /// <returns>List of vehicle.</returns>
        public List<Vehicle> EngineDisplacementGreaterThan(double engineVolume)
        {
            return Vehicles.Where(v => v.VehicleEngine.Volume.CompareTo(engineVolume) > 0).ToList();
        }

        /// <summary>
        /// Provides engine type, serial number and power rating for all buses and trucks.
        /// </summary>
        /// <returns>List of VehicleModel.</returns>
        public List<VehicleModel> BusAndTruckEngines()
        {
            return Vehicles.Where(v => v is Truck || v is Bus)
                .Select(v => new VehicleModel(v.VehicleEngine.Type, v.VehicleEngine.SerialNumber, v.VehicleEngine.Power)).ToList();
        }

        /// <summary>
        /// Provides complete information about all vehicles, grouped by transmission type.
        /// </summary>
        /// <returns>List of vehicle.</returns>
        public List<Vehicle> GroupedByTransmission()
        {
            return Vehicles.GroupBy(v => v.VehicleTransmission.Type).SelectMany(g => g).ToList();
        }
    }
}
