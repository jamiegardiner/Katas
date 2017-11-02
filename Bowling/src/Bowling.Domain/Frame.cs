namespace Bowling.Domain
{
    public class Frame
    {
        protected readonly int RollNumber;
        protected readonly int[] AllRolls;

        public Frame(int rollNumber, int[] allRolls)
        {
            RollNumber = rollNumber;
            AllRolls = allRolls;
        }

        public virtual int FrameScore()
        {
            return AllRolls[RollNumber] + AllRolls[RollNumber + 1];
        }
    }
}