using System.Collections;
using TMPro;
using UnityEngine;

namespace KarioMart.Gamemodes
{
    [RequireComponent(typeof(Canvas))]
    public class GamemodeStartCountdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countdownLabel;
        
        private Canvas _canvas;
        private bool _raceStarted;
        private GamemodeManager _gamemodeManager;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _gamemodeManager = transform.root.GetComponent<GamemodeManager>();
        }

        private void OnStartRace()
        {
            if (!_raceStarted)
                StartCoroutine(StartCountdown());
        }

        private IEnumerator StartCountdown()
        {
            _canvas.enabled = true;
            
            for (int i = 3; i > 0; i--)
            {
                countdownLabel.text = i.ToString();
                yield return new WaitForSeconds(1);
            }

            countdownLabel.text = "GO!";
            _gamemodeManager.BeginRace();
            yield return new WaitForSeconds(1);

            _canvas.enabled = false;
        }
    }
}
