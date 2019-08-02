using System;
namespace LeetCode.GeeksForGeeks
{
    public abstract class TwoRobots
    {

		//    I.moveLeft() // robot moves to left by 1 unit in 1 unit time

		//II.moveRight() // robot moves to right by 1 unit in 1 unit time

		//III.noOperation() // robot does not move and takes 1 unit time

		//IV.onTopOfParachute() // returns true if the robot is standing on top of either of the parachute, else false

		//V.didWeMeet() // returns true if the robot meets to the other robot, else false

		//Write a function in order to make the robots meet each other.Robots will be executing the same copy of this function.
		
        public TwoRobots()
        {
        }

        public abstract void MoveLeft();

        public abstract void MoveRight();

        public abstract void NoOperation();

        public abstract Boolean OnTopOfParachute();

        public abstract Boolean DidWeMeet();

        public void MoveForward()
        {
            MoveLeft();
            MoveRight();
            MoveRight();
        }

        public void UTurn()
        {
            MoveLeft();
            MoveLeft();
            MoveLeft();
        }

        public Boolean MeetOtherRobot()
        {
            //Supousing they land one in front of each other
            while (true)
            {
				MoveForward();
                if (DidWeMeet()) return true;
                if (OnTopOfParachute()) UTurn(); 
            }
        }
    }
}
