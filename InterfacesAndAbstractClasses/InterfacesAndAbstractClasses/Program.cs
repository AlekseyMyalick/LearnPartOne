using System;

namespace InterfacesAndAbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird(new Coordinate(10, 10, 10));

            Drone drone = new Drone(new Coordinate(10, 10, 10), 4);

            Plane plane = new Plane(new Coordinate(10, 10, 10), 2000);

            Console.WriteLine($"Time Bird: {bird.GetFlyTime(new Coordinate(30, 30, 30))}");
            Console.WriteLine($"Time Drone: {drone.GetFlyTime(new Coordinate(30, 30, 30))}");
            Console.WriteLine($"Time Plane: {plane.GetFlyTime(new Coordinate(30, 30, 30))}");

        }
    }
}
