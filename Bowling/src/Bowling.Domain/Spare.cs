namespace Bowling.Domain
{
    public class Spare : Frame
    {
        public Spare(int rollNumber, int[] allRolls) : base(rollNumber, allRolls)
        {
        }

        public override int FrameScore()
        {
            return AllRolls[RollNumber] + AllRolls[RollNumber + 1] + AllRolls[RollNumber + 2];
        }
    }
}