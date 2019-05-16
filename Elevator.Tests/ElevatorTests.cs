namespace Elevator.Tests
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Elevator.Console;
    using FakeItEasy;

    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void WhenRidingElevator_AndGoingToAboveFloor_PulleyShouldGoUp()
        {
            // arrange
            var pulley = A.Fake<IPulley>();
            var numberOfFloors = 20;
            var elevator = new Elevator(numberOfFloors, pulley);

            // act
            var targetFloor = 5;
            elevator.GoToFloor(targetFloor);

            // assert
            A.CallTo(() => pulley.GoUp(targetFloor, A<int>.Ignored)).MustHaveHappened();

        }

        [TestMethod]
        public void WhenRidingElevator_AndGoingToInvalidFloor_ShouldNotGoUpOrDown()
        {
            // arrange
            var pulley = A.Fake<IPulley>();
            var numberOfFloors = 10;
            var elevator = new Elevator(numberOfFloors, pulley);

            // act
            var targetFloor = 50;
            elevator.GoToFloor(targetFloor);

            // assert
            A.CallTo(() => pulley.GoUp(A<int>.Ignored, A<int>.Ignored)).WithAnyArguments().MustNotHaveHappened();
            A.CallTo(() => pulley.GoDown(A<int>.Ignored, A<int>.Ignored)).WithAnyArguments().MustNotHaveHappened();

        }

        [TestMethod]
        public void WhenRidingElevator_AndGoingToBelowFloor_PulleyShouldGoDown()
        {
            // arrange
            var pulley = A.Fake<IPulley>();
            var numberOfFloors = 20;
            var elevator = new Elevator(numberOfFloors, pulley);

            // act
            var makeElevatorGoUp = 10;
            var targetFloor = 3;
            elevator.GoToFloor(makeElevatorGoUp);
            elevator.GoToFloor(targetFloor);

            // assert
            A.CallTo(() => pulley.GoDown(targetFloor, makeElevatorGoUp)).MustHaveHappened();

        }
    }
}
