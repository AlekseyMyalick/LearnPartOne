using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CarPark.Models;
using CarPark.Exceptions;
using System;

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
        /// Add vehicle to the collection of an object of the CarManager class.
        /// </summary>
        /// <param name="vehicle">Vehicle to add.</param>
        public void Add(Vehicle vehicle)
        {
            if (!IsContains(vehicle))
            {
                throw new AddException("Unable to add car model.");
            }

            Vehicles.Add(vehicle);
        }

        /// <summary>
        /// Determines if the collection contains an object.
        /// </summary>
        /// <param name="vehicle">A search object in the collection.</param>
        /// <returns>True if the object is in a collection, false otherwise.</returns>
        public bool IsContains(Vehicle vehicle)
        {
            return Vehicles.Select(v => v.Equals(vehicle)).Contains(true);
        }

        /// <summary>
        /// Returns a collection of cars with the specified parameter and value.
        /// </summary>
        /// <param name="parameter">The name of the property to look for.</param>
        /// <param name="value">The value of the object property to search for.</param>
        /// <returns>List of cars if their number is greater than zero,
        /// otherwise throws GetAutoByParameterException.</returns>
        public List<Vehicle> GetAutoByParameter(string parameter, string value)
        {
            if (GetNumberOfAutoWithParameter(parameter) == 0)
            {
                throw new GetAutoByParameterException("Inability to find a model by a given parameter");
            }

            return Vehicles.Where(v => GetPropertyValue(v, parameter) == value).ToList();
        }

        /// <summary>
        /// The number of objects that have this property.
        /// </summary>
        /// <param name="parameter">The name of the property to look for.</param>
        /// <returns>The number of objects that have this property.</returns>
        private int GetNumberOfAutoWithParameter(string parameter)
        {
            return Vehicles.Select(v => GetPropertyByName(v, parameter)).
                Where(p => !(p is null)).Count();
        }

        /// <summary>
        /// Returns the value of a property of an object.
        /// </summary>
        /// <param name="vehicle">The object which property is being examined.</param>
        /// <param name="propertyName">The name of the property to look for.</param>
        /// <returns>The string representation of the property value.</returns>
        private string GetPropertyValue(Vehicle vehicle, string propertyName)
        {
            PropertyInfo property = GetPropertyByName(vehicle, propertyName);

            if (property is null)
            {
                return null;
            }

            return property.GetValue(vehicle).ToString();
        }

        /// <summary>
        /// Returns a property of the class object.
        /// </summary>
        /// <param name="vehicle">The object in which to look for the property.</param>
        /// <param name="propertyName">The name of the property to look for.</param>
        /// <returns>Object of class PropertyInfo if property exists, otherwise Null.</returns>
        private PropertyInfo GetPropertyByName(Vehicle vehicle, string propertyName)
        {
            return vehicle.GetType().GetProperty(propertyName);
        }

        public void UpdateAuto(int id, string propertyName, object obj)
        {
            if (!IsIdExist(id))
            {
                throw new UpdateAutoException("The car with the given ID does not exist.");
            }

            if (obj is null)
            {
                throw new UpdateAutoException();
            }

            PropertyInfo property = GetPropertyByName(Vehicles.First(v => v.Id == id), propertyName);

            if (property is null)
            {
                throw new UpdateAutoException($"There is no {propertyName} property in a car with id = {id}.");
            }

            property.SetValue(Vehicles.First(v => v.Id == id), obj);
        }

        /// <summary>
        /// Removes a car from the collection.
        /// </summary>
        /// <param name="id">Car id to be deleted.</param>
        public void RemoveAuto(int id)
        {
            if (!IsIdExist(id))
            {
                throw new RemoveAutoException("The car with the given ID does not exist.");
            }

            Vehicles.Remove(Vehicles.First(v => v.Id == id));
        }

        /// <summary>
        /// Checks if a car with the given ID exists.
        /// </summary>
        /// <param name="id">ID that is searched for.</param>
        /// <returns>True if an auto with this id exists, otherwise false.</returns>
        private bool IsIdExist(int id)
        {
            return Vehicles.Select(v => v.Id).Contains(id);
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
