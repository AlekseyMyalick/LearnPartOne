using System;
using System.Collections.Generic;

namespace CarPark
{
    class Program
    {
        static void Main(string[] args)
        {
            PassengerCar passengerCar = new PassengerCar (
                new Engine(140d, 2.3d, EngineTypeEnum.Diesel, "158SF56HTW"),
                new Chassis(4, "455FE55T25HU", 4),
                new Transmission(TransmissionTypeEnum.Mechanical, 5, TransmissionManufacturersEnum.Aisin), 2);

            Truck truck = new Truck (
                new Engine(190d, 4.2d, EngineTypeEnum.Gas, "5454SRT5873TW"),
                new Chassis(8, "ER97G5H5T25Q9", 47),
                new Transmission(TransmissionTypeEnum.Automatic, 5, TransmissionManufacturersEnum.EATOn), 120);

            Bus bus = new Bus (
                new Engine(150d, 3.9d, EngineTypeEnum.Gasoline, "634F58739Q1W"),
                new Chassis(8, "Q47FH5T25Q45", 20),
                new Transmission(TransmissionTypeEnum.Mechanical, 5, TransmissionManufacturersEnum.Jatco), 46);

            Scooter scooter = new Scooter (
                new Engine(80.2d, 1.2d, EngineTypeEnum.Electrical, "759TV43S5O55"),
                new Chassis(8, "39LK55VH2656R", 0.6),
                new Transmission(TransmissionTypeEnum.Automatic, 3, TransmissionManufacturersEnum.Aisin), false);

            List<Vehicle> vehicles = new List<Vehicle>() { passengerCar, truck, bus, scooter };

            foreach (var item in vehicles)
            {
                Console.WriteLine(item);
            }
        }
    }
}
