using KarioMart.Gamemodes.PVP;

namespace KarioMart.Gamemodes.TimeTrial
{
    public class TimeTrialUIController : GamemodeUIController<TimeTrial, TimeTrialGameOverScreen>
    {
        protected override void EndSession()
        {
            var bestLap = _gamemode.BestLap;
            var isRecordLap = bestLap.IsRecord(_gamemode.TrackRecord());
            gameOverScreen.SetBestTime(_gamemode.BestLap, isRecordLap);
        }
    }
}