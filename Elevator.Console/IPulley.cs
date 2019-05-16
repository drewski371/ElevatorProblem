namespace Elevator.Console
{
    public interface IPulley
    {
        void GoUp(int targetFloor, int currentFloor);
        void GoDown(int targetFloor, int currentFloor);
    }
}