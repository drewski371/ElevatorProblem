namespace Elevator.Console
{

    using System;

    public class Elevator
    {
        private readonly IPulley _pulley;

        public Elevator(int numberOfFloors, IPulley pulley) 
        {
            NumberOfFloors = numberOfFloors;
            _pulley = pulley;
        } 

        public void GoToFloor(int floor)
        {
            if (!IsValidFloor(floor))
            {
                Console.WriteLine($"{floor} is not valid. Enter a number between 1 and {NumberOfFloors}");
                return;
            }

            if (floor > CurrentFloor)
                _pulley.GoUp(floor, CurrentFloor);
            else if (floor < CurrentFloor)
                _pulley.GoDown(floor, CurrentFloor);

            Console.Write($"Arrived at floor {floor}");
            CurrentFloor = floor;
        }

        private bool IsValidFloor(int floor) => 
            floor > 0 &&
            floor <= NumberOfFloors;

        private int NumberOfFloors { get; }

        private int CurrentFloor { get; set; } = 1;

    }
}