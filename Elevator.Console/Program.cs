namespace Elevator.Console
{

    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's set up your elevator...");
            var elevator = ConfigureElevatorWithNumberOfFloors();

            Console.WriteLine("Type 'x' to exit elevator");
            while (true)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Enter floor:");
                var userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out int floorNumber))
                {
                    if (userInput == "x")
                        break;

                    Console.WriteLine($"{userInput} is not a valid floor number");
                    continue;
                }
                
                elevator.GoToFloor(floorNumber);
            }
        }

        private static Elevator ConfigureElevatorWithNumberOfFloors()
        {
            while (true)
            {
                Console.WriteLine("How many floors are in the building?");
                var userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out int numberOfFloors))
                {
                    Console.WriteLine($"{userInput} is not valid. Enter a number");
                    continue;
                }

                var pulley = new Pulley();
                return new Elevator(numberOfFloors, pulley);
            }
        }
    }
}
