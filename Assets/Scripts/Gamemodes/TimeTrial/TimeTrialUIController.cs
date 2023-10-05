using KarioMart.Gamemodes.PVP;

namespace KarioMart.Gamemodes.TimeTrial
{
    public class TimeTrialUIController : GamemodeUIController<TimeTrial, TimeTrialGameOverScreen>
    {
        protected override void EndSession()
        {
            gameOverScreen.DisplayLeaderboard(_gamemode.BestLap, _gamemode.Leaderboard);
        }
    }
}