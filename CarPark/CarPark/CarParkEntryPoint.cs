using System;
using CarPark.Managers;
using CarPark.Models;
using CarPark.Serializers;
using System.Collections.Generic;

namespace CarPark
{
    class CarParkEntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                PassengerCar passengerCar = new PassengerCar(
                    new Engine(140d, 2.3d, EngineType.Diesel, "158SF56HTW"),
                    new Chassis(4, "455FE55T25HU", 4),
                    new Transmission(TransmissionType.Mechanical, 5, TransmissionManufacturers.Aisin), 2);

                Truck truck = new Truck(
                    new Engine(190d, 4.2d, EngineType.Gas, "5454SRT5873TW"),
                    new Chassis(8, "ER97G5H5T25Q9", 47),
                    new Transmission(TransmissionType.Automatic, 5, TransmissionManufacturers.EATOn), 150);

                Bus bus = new Bus(
                    new Engine(150d, 3.9d, EngineType.Gasoline, "634F58739Q1W"),
                    new Chassis(8, "Q47FH5T25Q45", 20),
                    new Transmission(TransmissionType.Mechanical, 5, TransmissionManufacturers.Jatco), 46);

                Scooter scooter = new Scooter(
                    new Engine(80.2d, 1.2d, EngineType.Electrical, "759TV43S5O55"),
                    new Chassis(8, "39LK55VH2656R", 0.6),
                    new Transmission(TransmissionType.Automatic, 3, TransmissionManufacturers.Aisin), false);

                Truck truck1 = new Truck(
                  new Engine(180d, 5.1d, EngineType.Electrical, "DS558SRT73DF8"),
                  new Chassis(10, "ER97G5H5T25Q9", 50),
                  new Transmission(TransmissionType.Mechanical, 7, TransmissionManufacturers.Aisin), 150);

                Truck truck2 = new Truck(
                  new Engine(180d, 5.1d, EngineType.Electrical, "DS558SRT73DF8"),
                  new Chassis(9, "ER97G5H5T25Q9", 50),
                  new Transmission(TransmissionType.Mechanical, 7, TransmissionManufacturers.Aisin), 150);

                List<Vehicle> vehicles = new List<Vehicle>() { passengerCar, truck, bus, scooter, truck1, truck2};
                
                CarManager carManager = new CarManager(vehicles);

                Serializer<Vehicle>.Serialize("EngineDisplacementGreaterThan.xml", carManager.EngineDisplacementGreaterThan(1.5d));
                Serializer<VehicleModel>.Serialize("BusAndTruckEngines.xml", carManager.GetBusAndTruckEngines());
                Serializer<Vehicle>.Serialize("GroupedByTransmission.xml", carManager.GetGroupedByTransmission());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
