using CarPark;
using CarPark.Managers;
using CarPark.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CarParkTests
{
    [TestClass]
    public class CarManagerTests
    {
        private CarManager _carManager;

        private PassengerCar _passengerCar;

        private Truck _truck;

        private Truck _truck1;

        private Bus _bus;

        private Scooter _scooter;

        [TestInitialize]
        public void InitializeCarManager()
        {
            _passengerCar = new PassengerCar(
                new Engine(140d, 2.3d, EngineType.Diesel, "158SF56HTW"),
                new Chassis(4, "455FE55T25HU", 4),
                new Transmission(TransmissionType.Mechanical, 5, TransmissionManufacturers.Aisin), 2);

            _truck = new Truck(
                new Engine(190d, 4.2d, EngineType.Gas, "5454SRT5873TW"),
                new Chassis(8, "ER97G5H5T25Q9", 47),
                new Transmission(TransmissionType.Automatic, 5, TransmissionManufacturers.EATOn), 120);

            _bus = new Bus(
                new Engine(150d, 3.9d, EngineType.Gasoline, "634F58739Q1W"),
                new Chassis(8, "Q47FH5T25Q45", 20),
                new Transmission(TransmissionType.Mechanical, 5, TransmissionManufacturers.Jatco), 46);

            _scooter = new Scooter(
                new Engine(80.2d, 1.5d, EngineType.Electrical, "759TV43S5O55"),
                new Chassis(8, "39LK55VH2656R", 0.6),
                new Transmission(TransmissionType.Automatic, 3, TransmissionManufacturers.Aisin), false);

            _truck1 = new Truck(
               new Engine(180d, 5.1d, EngineType.Electrical, "DS558SRT73DF8"),
               new Chassis(10, "ER97G5H5T25Q9", 50),
               new Transmission(TransmissionType.Mechanical, 7, TransmissionManufacturers.Aisin), 150);

            List<Vehicle> vehicles = new List<Vehicle>() { _passengerCar, _truck, _bus, _scooter, _truck1 };

            _carManager = new CarManager(vehicles);
        }

        [TestMethod]
        public void EngineDisplacementGreaterThan_ReturnTrue()
        {
            List<Vehicle> expected = new List<Vehicle>() {_passengerCar, _truck, _bus, _truck1 };
            Assert.IsTrue(_carManager.GetEngineDisplacementGreaterThan(1.5d).Except(expected).Count() == 0);
        }

        [TestMethod]
        public void BusAndTruckEngines_ReturnTrue()
        {
            List<VehicleModel> expected = new List<VehicleModel>()
            {
                new VehicleModel(_truck.VehicleEngine.Type, _truck.VehicleEngine.SerialNumber, _truck.VehicleEngine.Power),
                new VehicleModel(_bus.VehicleEngine.Type, _bus.VehicleEngine.SerialNumber, _truck.VehicleEngine.Power),
                new VehicleModel(_truck1.VehicleEngine.Type, _truck1.VehicleEngine.SerialNumber, _truck1.VehicleEngine.Power)
            };

            Assert.IsTrue(_carManager.GetBusAndTruckEngines().Except(expected).Count() == 0);
        }
    }
}
