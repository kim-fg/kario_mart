namespace KarioMart.Gamemodes.Data
{
    public struct RacePosition
    {
        public int CheckpointCounter;
        public int LapCounter;

        public int PositionScore(int checkpointCount) => LapCounter * checkpointCount + CheckpointCounter;

        public void EndLap()
        {
            CheckpointCounter = 0;
            LapCounter++;
        }
    }
}