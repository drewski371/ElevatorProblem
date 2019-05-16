namespace Elevator.Console
{

    using System;
    using System.Threading;

    public class Pulley : IPulley
    {
        public void GoDown(int targetFloor, int currentFloor)
        {
            for (var i = currentFloor; i > targetFloor; i--)
            {
                Console.WriteLine($"{i}...");
                Thread.Sleep(300);
            }
        }

        public void GoUp(int targetFloor, int currentFloor)
        {
            for (var i = currentFloor; i < targetFloor; i++)
            {
                Console.WriteLine($"{i}...");
                Thread.Sleep(300);
            }
        }
    }
}
