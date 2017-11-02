namespace Bowling.Domain
{
    public class Strike : Frame
    {
        public Strike(int rollNumber, int[] allRolls) : base(rollNumber, allRolls)
        {
        }

        public override int FrameScore()
        {
            return AllRolls[RollNumber] + AllRolls[RollNumber + 1] + AllRolls[RollNumber + 2];
        }
    }
}