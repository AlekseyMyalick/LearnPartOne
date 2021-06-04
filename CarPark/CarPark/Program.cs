using System;
using System.Collections.Generic;

namespace CarPark
{
    class Program
    {
        static void Main(string[] args)
        {
            PassengerCar passengerCar = new PassengerCar (
                new Engine(140d, 2.3d, EngineType.Diesel, "158SF56HTW"),
                new Chassis(4, "455FE55T25HU", 4),
                new Transmission(TransmissionType.Mechanical, 5, TransmissionManufacturers.Aisin), 2);

            Truck truck = new Truck (
                new Engine(190d, 4.2d, EngineType.Gas, "5454SRT5873TW"),
                new Chassis(8, "ER97G5H5T25Q9", 47),
                new Transmission(TransmissionType.Automatic, 5, TransmissionManufacturers.EATOn), 120);

            Bus bus = new Bus (
                new Engine(150d, 3.9d, EngineType.Gasoline, "634F58739Q1W"),
                new Chassis(8, "Q47FH5T25Q45", 20),
                new Transmission(TransmissionType.Mechanical, 5, TransmissionManufacturers.Jatco), 46);

            Scooter scooter = new Scooter (
                new Engine(80.2d, 1.2d, EngineType.Electrical, "759TV43S5O55"),
                new Chassis(8, "39LK55VH2656R", 0.6),
                new Transmission(TransmissionType.Automatic, 3, TransmissionManufacturers.Aisin), false);

            List<Vehicle> vehicles = new List<Vehicle>() { passengerCar, truck, bus, scooter };

            var answer = Query.GroupedByTransmission(vehicles);

            foreach (var g in answer)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.GetType());
                Console.WriteLine();
            }
        }
    }
}
