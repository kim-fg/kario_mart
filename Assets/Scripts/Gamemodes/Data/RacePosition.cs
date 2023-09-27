namespace KarioMart.Gamemodes.Data
{
    public struct RacePosition
    {
        public int CheckpointCounter;
        public int LapCounter;

        public int PositionScore(int lapValue) => LapCounter * lapValue + CheckpointCounter;

        public void EndLap()
        {
            CheckpointCounter = 0;
            LapCounter++;
        }
    }
}